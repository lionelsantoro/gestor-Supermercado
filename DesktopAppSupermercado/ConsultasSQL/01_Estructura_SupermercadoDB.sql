/*
================================================================================
01_Estructura_SupermercadoDB.sql
================================================================================
*/
USE master;
GO

IF DB_ID(N'SupermercadoDB') IS NULL
BEGIN
    CREATE DATABASE SupermercadoDB;
END;
GO

USE SupermercadoDB;
GO

/* Este archivo se ejecuta una vez sobre una base sin tablas del proyecto. */
IF OBJECT_ID(N'dbo.persona', N'U') IS NOT NULL
BEGIN
    THROW 50000, 'SupermercadoDB ya contiene tablas. No ejecute el script de instalacion inicial sobre una base existente.', 1;
END;
GO

/* 1. PERSONA: datos personales compartidos por empleados y clientes. */
CREATE TABLE dbo.persona
(
    id_persona INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_persona PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    apellido NVARCHAR(100) NOT NULL,
    correo NVARCHAR(150) NULL,
    dni VARCHAR(20) NULL,
    direccion NVARCHAR(200) NULL,
    telefono VARCHAR(30) NULL,
    sexo NVARCHAR(20) NULL,
    fecha_nacimiento DATE NULL,
    eliminado BIT NOT NULL CONSTRAINT DF_persona_eliminado DEFAULT (0),
    creado_en DATETIME NOT NULL CONSTRAINT DF_persona_creado_en DEFAULT (GETDATE()),
    eliminado_en DATETIME NULL
);
GO

CREATE UNIQUE INDEX UQ_persona_dni
ON dbo.persona(dni)
WHERE dni IS NOT NULL;
GO

/* 2. ROLES: los identificadores 1..4 se reservan en el script de configuracion. */
CREATE TABLE dbo.roles
(
    id_rol INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_roles PRIMARY KEY,
    nombre NVARCHAR(50) NOT NULL,
    creado_en DATETIME NOT NULL CONSTRAINT DF_roles_creado_en DEFAULT (GETDATE()),
    CONSTRAINT UQ_roles_nombre UNIQUE (nombre)
);
GO

/* 3. CATEGORIAS: queda vacia para que Inventario las configure. */
CREATE TABLE dbo.categorias
(
    id_categoria INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_categorias PRIMARY KEY,
    nombre NVARCHAR(100) NOT NULL,
    descripcion NVARCHAR(MAX) NULL,
    eliminado BIT NOT NULL CONSTRAINT DF_categorias_eliminado DEFAULT (0),
    creado_en DATETIME NOT NULL CONSTRAINT DF_categorias_creado_en DEFAULT (GETDATE()),
    actualizado_en DATETIME NULL,
    eliminado_en DATETIME NULL
);
GO

CREATE UNIQUE INDEX UQ_categorias_nombre_activa
ON dbo.categorias(nombre)
WHERE eliminado = 0;
GO

/* 4. MEDIOS DE PAGO: el script de configuracion agrega las opciones iniciales. */
CREATE TABLE dbo.medios_de_pago
(
    id_medio_pago INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_medios_de_pago PRIMARY KEY,
    medio_pago NVARCHAR(50) NOT NULL,
    creado_en DATETIME NOT NULL CONSTRAINT DF_medios_pago_creado_en DEFAULT (GETDATE()),
    CONSTRAINT UQ_medios_de_pago_nombre UNIQUE (medio_pago)
);
GO

/* 5. USUARIOS: una cuenta pertenece a una persona y a un rol. */
CREATE TABLE dbo.usuarios
(
    id_usuario INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_usuarios PRIMARY KEY,
    id_persona INT NOT NULL,
    id_rol INT NOT NULL,
    correo NVARCHAR(150) NULL,
    nombre_usuario NVARCHAR(50) NOT NULL,
    contrasena VARCHAR(255) NOT NULL,
    codigo_autorizacion INT NULL,
    eliminado BIT NOT NULL CONSTRAINT DF_usuarios_eliminado DEFAULT (0),
    creado_en DATETIME NOT NULL CONSTRAINT DF_usuarios_creado_en DEFAULT (GETDATE()),
    eliminado_en DATETIME NULL,

    CONSTRAINT FK_Usuarios_Persona FOREIGN KEY (id_persona) REFERENCES dbo.persona(id_persona),
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (id_rol) REFERENCES dbo.roles(id_rol),
    CONSTRAINT UQ_Usuarios_Persona UNIQUE (id_persona),
    CONSTRAINT UQ_Usuarios_Nombre UNIQUE (nombre_usuario),
    CONSTRAINT CK_usuarios_codigo_autorizacion
        CHECK (codigo_autorizacion IS NULL OR codigo_autorizacion BETWEEN 1000 AND 9999)
);
GO

/* La clave filtrada permite muchos NULL, pero no dos codigos iguales. */
CREATE UNIQUE INDEX UQ_usuarios_codigo_autorizacion
ON dbo.usuarios(codigo_autorizacion)
WHERE codigo_autorizacion IS NOT NULL;
GO

/* 6. PRODUCTOS: coincide con GestionProductoDatos y la logica de stock por Kg. */
CREATE TABLE dbo.productos
(
    id_producto INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_productos PRIMARY KEY,
    id_categoria INT NOT NULL,
    descripcion NVARCHAR(250) NOT NULL,
    precio DECIMAL(18,2) NOT NULL,
    stock DECIMAL(18,3) NOT NULL CONSTRAINT DF_productos_stock DEFAULT (0),
    unidad_medida NVARCHAR(20) NOT NULL CONSTRAINT DF_productos_unidad DEFAULT (N'Unidad'),
    codigo_barra VARCHAR(50) NULL,
    eliminado BIT NOT NULL CONSTRAINT DF_productos_eliminado DEFAULT (0),
    creado_en DATETIME NOT NULL CONSTRAINT DF_productos_creado_en DEFAULT (GETDATE()),
    actualizado_en DATETIME NULL,
    eliminado_en DATETIME NULL,

    CONSTRAINT FK_Productos_Categorias FOREIGN KEY (id_categoria) REFERENCES dbo.categorias(id_categoria),
    CONSTRAINT CK_Productos_Precio CHECK (precio >= 0),
    CONSTRAINT CK_Productos_Stock CHECK (stock >= 0),
    CONSTRAINT CK_Productos_Unidad CHECK (unidad_medida IN (N'Unidad', N'Kg'))
);
GO

CREATE UNIQUE INDEX UQ_productos_codigo_barra
ON dbo.productos(codigo_barra)
WHERE codigo_barra IS NOT NULL;
GO

/* 7. CLIENTES: la informacion personal vive en persona; aqui se guarda el vinculo. */
CREATE TABLE dbo.clientes
(
    id_cliente INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_clientes PRIMARY KEY,
    id_persona INT NOT NULL,
    creado_en DATETIME NOT NULL CONSTRAINT DF_clientes_creado_en DEFAULT (GETDATE()),
    CONSTRAINT FK_Clientes_Persona FOREIGN KEY (id_persona) REFERENCES dbo.persona(id_persona),
    CONSTRAINT UQ_Clientes_Persona UNIQUE (id_persona)
);
GO

/* 8. CONTADOR DE TICKETS: el primer ticket confirmado sera el numero 1. */
CREATE TABLE dbo.ControlNumeracionTicket
(
    id TINYINT NOT NULL CONSTRAINT PK_ControlNumeracionTicket PRIMARY KEY,
    ultimo_numero INT NOT NULL,
    CONSTRAINT CK_ControlNumeracionTicket_Id CHECK (id = 1),
    CONSTRAINT CK_ControlNumeracionTicket_Numero CHECK (ultimo_numero >= 0)
);
GO

INSERT INTO dbo.ControlNumeracionTicket(id, ultimo_numero)
VALUES (1, 0);
GO

/* 9. VENTAS: numero_ticket se asigna desde VentaDatos dentro de una transaccion.*/
CREATE TABLE dbo.ventas
(
    id_venta INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_ventas PRIMARY KEY,
    numero_ticket INT NOT NULL,
    id_usuario INT NOT NULL,
    id_cliente INT NOT NULL,
    id_medio_pago INT NOT NULL,
    monto_total DECIMAL(18,2) NOT NULL,
    creado_en DATETIME NOT NULL CONSTRAINT DF_ventas_creado_en DEFAULT (GETDATE()),

    CONSTRAINT FK_Ventas_Usuarios FOREIGN KEY (id_usuario) REFERENCES dbo.usuarios(id_usuario),
    CONSTRAINT FK_Ventas_Clientes FOREIGN KEY (id_cliente) REFERENCES dbo.clientes(id_cliente),
    CONSTRAINT FK_Ventas_MedioPago FOREIGN KEY (id_medio_pago) REFERENCES dbo.medios_de_pago(id_medio_pago),
    CONSTRAINT UQ_ventas_numero_ticket UNIQUE (numero_ticket),
    CONSTRAINT CK_ventas_numero_ticket CHECK (numero_ticket > 0),
    CONSTRAINT CK_ventas_monto_total CHECK (monto_total >= 0)
);
GO

/* 10. DETALLE: DECIMAL permite almacenar Kg (VentaDatos divide gramos por 1000). */
CREATE TABLE dbo.detalle_venta
(
    id_detalle INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_detalle_venta PRIMARY KEY,
    id_venta INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad DECIMAL(18,3) NOT NULL,
    precio_unitario DECIMAL(18,2) NOT NULL,
    subtotal DECIMAL(18,2) NOT NULL,
    creado_en DATETIME NOT NULL CONSTRAINT DF_detalle_venta_creado_en DEFAULT (GETDATE()),

    CONSTRAINT FK_Detalle_Ventas FOREIGN KEY (id_venta) REFERENCES dbo.ventas(id_venta),
    CONSTRAINT FK_Detalle_Productos FOREIGN KEY (id_producto) REFERENCES dbo.productos(id_producto),
    CONSTRAINT CK_Detalle_Cantidad CHECK (cantidad > 0),
    CONSTRAINT CK_Detalle_Precio CHECK (precio_unitario >= 0),
    CONSTRAINT CK_Detalle_Subtotal CHECK (subtotal >= 0)
);
GO

/* 11. Indices para las consultas de historial y reportes. */
CREATE INDEX IX_ventas_creado_en ON dbo.ventas(creado_en);
CREATE INDEX IX_ventas_id_usuario ON dbo.ventas(id_usuario);
CREATE INDEX IX_ventas_id_cliente ON dbo.ventas(id_cliente);
CREATE INDEX IX_detalle_venta_id_venta ON dbo.detalle_venta(id_venta);
CREATE INDEX IX_detalle_venta_id_producto ON dbo.detalle_venta(id_producto);
CREATE INDEX IX_productos_id_categoria ON dbo.productos(id_categoria);
GO

PRINT N'Estructura de SupermercadoDB creada correctamente.';
GO

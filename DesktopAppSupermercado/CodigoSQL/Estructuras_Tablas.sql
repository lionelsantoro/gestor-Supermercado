-- 1. Tabla Persona
CREATE TABLE persona (
    id_persona INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    correo VARCHAR(150),
    eliminado BIT DEFAULT 0,
    creado_en DATETIME DEFAULT GETDATE(),
    eliminado_en DATETIME NULL
);

-- 2. Tabla Roles
CREATE TABLE roles (
    id_rol INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    creado_en DATETIME DEFAULT GETDATE()
);

-- 3. Tabla Categorias
CREATE TABLE categorias (
    id_categoria INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion VARCHAR(MAX),
    eliminado BIT DEFAULT 0,
    creado_en DATETIME DEFAULT GETDATE(),
    actualizado_en DATETIME NULL,
    eliminado_en DATETIME NULL
);

-- 4. Tabla Medios de Pago
CREATE TABLE medios_de_pago (
    id_medio_pago INT IDENTITY(1,1) PRIMARY KEY,
    medio_pago VARCHAR(50) NOT NULL,
    banco VARCHAR(100),
    creado_en DATETIME DEFAULT GETDATE()
);

-- 5. Tabla Usuarios
CREATE TABLE usuarios (
    id_usuario INT IDENTITY(1,1) PRIMARY KEY,
    id_persona INT NOT NULL UNIQUE,
    id_rol INT NOT NULL,
    correo VARCHAR(150),
    nombre_usuario VARCHAR(50) NOT NULL UNIQUE,
    contrasena VARCHAR(255) NOT NULL,
    codigo_autorizacion INT,
    eliminado BIT DEFAULT 0,
    creado_en DATETIME DEFAULT GETDATE(),
    eliminado_en DATETIME NULL,
    
    -- Llaves Foráneas (N a 1)
    CONSTRAINT FK_Usuarios_Persona FOREIGN KEY (id_persona) REFERENCES persona(id_persona),
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (id_rol) REFERENCES roles(id_rol)
);

-- 6. Tabla Productos
CREATE TABLE productos (
    id_producto INT IDENTITY(1,1) PRIMARY KEY,
    id_categoria INT NOT NULL,
    nombre VARCHAR(150) NOT NULL,
    precio DECIMAL(18,2) NOT NULL,
    stock INT NOT NULL DEFAULT 0,
    unidad_medida VARCHAR(20),
    kilogramo FLOAT,
    codigo_barra VARCHAR(50) UNIQUE,
    descripcion VARCHAR(MAX),
    eliminado BIT DEFAULT 0,
    creado_en DATETIME DEFAULT GETDATE(),
    actualizado_en DATETIME NULL,
    eliminado_en DATETIME NULL,
    
    -- Llave Foránea (N a 1)
    CONSTRAINT FK_Productos_Categorias FOREIGN KEY (id_categoria) REFERENCES categorias(id_categoria)
);

-- 7. Tabla Ventas
CREATE TABLE ventas (
    id_venta INT IDENTITY(1,1) PRIMARY KEY,
    id_usuario INT NOT NULL,
    id_medio_pago INT NOT NULL,
    monto_total DECIMAL(18,2) NOT NULL,
    estado VARCHAR(20) NOT NULL CHECK (estado IN ('Pendiente', 'Completada', 'Cancelada')),
    creado_en DATETIME DEFAULT GETDATE(),
    
    -- Llaves Foráneas (N a 1 y 1 a 1)
    CONSTRAINT FK_Ventas_Usuarios FOREIGN KEY (id_usuario) REFERENCES usuarios(id_usuario),
    CONSTRAINT FK_Ventas_MedioPago FOREIGN KEY (id_medio_pago) REFERENCES medios_de_pago(id_medio_pago)
);

-- 8. Tabla Detalle Venta
CREATE TABLE detalle_venta (
    id_detalle INT IDENTITY(1,1) PRIMARY KEY,
    id_venta INT NOT NULL,
    id_producto INT NOT NULL,
    cantidad INT NOT NULL,
    precio_unitario DECIMAL(18,2) NOT NULL,
    subtotal DECIMAL(18,2) NOT NULL,
    creado_en DATETIME DEFAULT GETDATE(),
    
    -- Llaves Foráneas (N a 1)
    CONSTRAINT FK_Detalle_Ventas FOREIGN KEY (id_venta) REFERENCES ventas(id_venta),
    CONSTRAINT FK_Detalle_Productos FOREIGN KEY (id_producto) REFERENCES productos(id_producto)
);
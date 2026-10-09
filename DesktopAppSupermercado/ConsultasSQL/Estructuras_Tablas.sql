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
    --estado VARCHAR(20) NOT NULL CHECK (estado IN ('Pendiente', 'Completada', 'Cancelada')),
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


---------------------------------------------------------------------------------------
------------- Cambios para numeración de tickets de la vista cajero -------------------
---------------------------------------------------------------------------------------

USE SupermercadoDB;
GO

-- 1. Verificar que exista la tabla ventas.
IF OBJECT_ID(N'dbo.ventas', N'U') IS NULL
BEGIN
    THROW 50001, 'No existe la tabla dbo.ventas en la base actual.', 1;
END;
GO

-- 2. Verificar que exista la columna numero_ticket.
IF COL_LENGTH(N'dbo.ventas', N'numero_ticket') IS NULL
BEGIN
    THROW 50002, 'No existe la columna numero_ticket en dbo.ventas.', 1;
END;
GO

-- 3. numero_ticket debe ser INT y no admitir NULL.
-- La tabla debe estar vacía, como indicaste.
ALTER TABLE dbo.ventas
ALTER COLUMN numero_ticket INT NOT NULL;
GO

-- 4. Impedir que dos ventas confirmadas tengan el mismo ticket.
IF NOT EXISTS
(
    SELECT 1
    FROM sys.key_constraints
    WHERE parent_object_id = OBJECT_ID(N'dbo.ventas')
      AND name = N'UQ_ventas_numero_ticket'
)
BEGIN
    ALTER TABLE dbo.ventas
    ADD CONSTRAINT UQ_ventas_numero_ticket
        UNIQUE (numero_ticket);
END;
GO

-- 5. Crear el contador transaccional.
IF OBJECT_ID(N'dbo.ControlNumeracionTicket', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ControlNumeracionTicket
    (
        id TINYINT NOT NULL,
        ultimo_numero INT NOT NULL,

        CONSTRAINT PK_ControlNumeracionTicket
            PRIMARY KEY (id),

        CONSTRAINT CK_ControlNumeracionTicket_Id
            CHECK (id = 1),

        CONSTRAINT CK_ControlNumeracionTicket_Numero
            CHECK (ultimo_numero >= 0)
    );
END;
GO

-- 6. Inicializar el contador con el último ticket existente.
-- Si ventas está vacía, el resultado es 0.
IF NOT EXISTS
(
    SELECT 1
    FROM dbo.ControlNumeracionTicket
    WHERE id = 1
)
BEGIN
    DECLARE @ultimoNumero INT;

    SELECT @ultimoNumero = ISNULL(MAX(numero_ticket), 0)
    FROM dbo.ventas;

    INSERT INTO dbo.ControlNumeracionTicket
        (id, ultimo_numero)
    VALUES
        (1, @ultimoNumero);
END;
GO

---------------------------------------------------------------------------------------
----------------- Cambio stock y cantidad de INT a DECIMAL ----------------------------
---------------------------------------------------------------------------------------

USE SupermercadoDB;
GO

DECLARE @NombreDefault SYSNAME;
DECLARE @DefinicionDefault NVARCHAR(MAX);
DECLARE @SQL NVARCHAR(MAX);

-- Obtener el nombre y la definición del DEFAULT actual.
SELECT
    @NombreDefault = dc.name,
    @DefinicionDefault = dc.definition
FROM sys.default_constraints AS dc
INNER JOIN sys.columns AS c
    ON c.object_id = dc.parent_object_id
   AND c.column_id = dc.parent_column_id
WHERE dc.parent_object_id = OBJECT_ID(N'dbo.productos')
  AND c.name = N'stock';

BEGIN TRY
    BEGIN TRANSACTION;

    -- Quitar temporalmente el DEFAULT si existe.
    IF @NombreDefault IS NOT NULL
    BEGIN
        SET @SQL =
            N'ALTER TABLE dbo.productos DROP CONSTRAINT '
            + QUOTENAME(@NombreDefault) + N';';

        EXEC sys.sp_executesql @SQL;
    END;

    -- Cambiar INT por DECIMAL.
    ALTER TABLE dbo.productos
    ALTER COLUMN stock DECIMAL(12,3) NOT NULL;

    -- Restaurar el DEFAULT original, si existía.
    IF @NombreDefault IS NOT NULL
    BEGIN
        SET @SQL =
            N'ALTER TABLE dbo.productos ADD CONSTRAINT '
            + QUOTENAME(@NombreDefault)
            + N' DEFAULT '
            + @DefinicionDefault
            + N' FOR stock;';

        EXEC sys.sp_executesql @SQL;
    END;

    COMMIT TRANSACTION;

    PRINT 'La columna stock fue modificada correctamente.';
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
GO

USE SupermercadoDB;
GO

--- Comprobar que el codigo anterior se ejecutó correctamente y que la columna stock ahora es DECIMAL(12,3) y conserva su valor default.

SELECT
    t.name AS tabla,
    c.name AS columna,
    TYPE_NAME(c.user_type_id) AS tipo_dato,
    c.precision,
    c.scale,
    dc.name AS restriccion_default,
    dc.definition AS valor_default
FROM sys.tables AS t
INNER JOIN sys.columns AS c
    ON c.object_id = t.object_id
LEFT JOIN sys.default_constraints AS dc
    ON dc.parent_object_id = c.object_id
   AND dc.parent_column_id = c.column_id
WHERE t.name IN ('productos', 'detalle_venta')
  AND c.name IN ('stock', 'cantidad');
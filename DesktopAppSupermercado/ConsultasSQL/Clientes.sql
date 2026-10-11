USE SupermercadoDB;
GO

-- 1. Crear la tabla de clientes.
IF OBJECT_ID(N'dbo.clientes', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.clientes
    (
        id_cliente INT IDENTITY(1,1) NOT NULL,
        nombre NVARCHAR(80) NOT NULL,
        apellido NVARCHAR(80) NOT NULL,
        codigo_cliente VARCHAR(4) NOT NULL,

        CONSTRAINT PK_clientes
            PRIMARY KEY (id_cliente),

        CONSTRAINT UQ_clientes_codigo
            UNIQUE (codigo_cliente),

        CONSTRAINT CK_clientes_codigo
            CHECK (
                LEN(codigo_cliente) = 4
                AND codigo_cliente NOT LIKE '%[^0-9]%'
            )
    );
END;
GO

-- 2. Insertar diez clientes de prueba sin duplicar códigos.
INSERT INTO dbo.clientes (nombre, apellido, codigo_cliente)
SELECT v.nombre, v.apellido, v.codigo_cliente
FROM
(
    VALUES
    (N'Ana',      N'Gómez',     '0001'),
    (N'Carlos',   N'Fernández','0002'),
    (N'María',    N'Rodríguez','0003'),
    (N'Juan',     N'Pérez',    '0004'),
    (N'Lucía',    N'Martínez', '0005'),
    (N'Diego',    N'López',    '0006'),
    (N'Sofía',    N'Ramírez',  '0007'),
    (N'Martín',   N'Torres',   '0008'),
    (N'Valentina',N'Acosta',   '0009'),
    (N'Andrés',   N'Benítez',  '0010')
) AS v(nombre, apellido, codigo_cliente)
WHERE NOT EXISTS
(
    SELECT 1
    FROM dbo.clientes c
    WHERE c.codigo_cliente = v.codigo_cliente
);
GO

-- 3. Agregar la relación cliente-venta.
IF COL_LENGTH(N'dbo.ventas', N'id_cliente') IS NULL
BEGIN
    ALTER TABLE dbo.ventas
    ADD id_cliente INT NULL;
END;
GO

-- 4. Si no quedan ventas sin cliente, hacer obligatorio el campo.
IF NOT EXISTS
(
    SELECT 1
    FROM dbo.ventas
    WHERE id_cliente IS NULL
)
BEGIN
    ALTER TABLE dbo.ventas
    ALTER COLUMN id_cliente INT NOT NULL;
END;
GO

-- 5. Crear la clave foránea si todavía no existe.
IF NOT EXISTS
(
    SELECT 1
    FROM sys.foreign_keys
    WHERE name = N'FK_ventas_clientes'
      AND parent_object_id = OBJECT_ID(N'dbo.ventas')
)
BEGIN
    ALTER TABLE dbo.ventas
    ADD CONSTRAINT FK_ventas_clientes
        FOREIGN KEY (id_cliente)
        REFERENCES dbo.clientes(id_cliente);
END;
GO

-- 6. Verificar los clientes y la relación.
SELECT id_cliente, nombre, apellido, codigo_cliente
FROM dbo.clientes
ORDER BY codigo_cliente;

SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'dbo'
  AND TABLE_NAME = 'ventas'
  AND COLUMN_NAME = 'id_cliente';
GO
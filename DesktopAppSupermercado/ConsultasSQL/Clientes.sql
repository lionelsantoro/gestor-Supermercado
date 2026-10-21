USE SupermercadoDB;
GO

-- =========================================================================
-- 1. Agregar las columnas id_persona y creado_en a dbo.clientes
-- =========================================================================
IF COL_LENGTH(N'dbo.clientes', N'id_persona') IS NULL
BEGIN
    ALTER TABLE dbo.clientes
    ADD id_persona INT NULL;
END;

IF COL_LENGTH(N'dbo.clientes', N'creado_en') IS NULL
BEGIN
    ALTER TABLE dbo.clientes
    ADD creado_en DATETIME NOT NULL
        CONSTRAINT DF_clientes_creado_en DEFAULT (GETDATE()) WITH VALUES;
END;
GO

-- =========================================================================
-- 2. Migrar los clientes hacia dbo.persona y limpiar dbo.clientes
-- =========================================================================
SET XACT_ABORT ON;

BEGIN TRY
    BEGIN TRANSACTION;

    -- Solo ejecutamos la migración de datos si las columnas antiguas aún existen
    IF COL_LENGTH(N'dbo.clientes', N'nombre') IS NOT NULL
    BEGIN
        DECLARE @MapaClientes TABLE
        (
            id_cliente INT PRIMARY KEY,
            id_persona INT NOT NULL
        );

        MERGE INTO dbo.persona AS destino
        USING
        (
            SELECT 
                c.id_cliente,
                c.nombre,
                c.apellido,
                ISNULL(d.correo, LOWER(c.nombre + '.' + c.apellido + '.' + CAST(c.id_cliente AS VARCHAR(10)) + '@gmail.com')) AS correo,
                ISNULL(d.dni, CAST(40000000 + c.id_cliente AS VARCHAR(15))) AS dni,
                ISNULL(d.direccion, 'Av. Independencia ' + CAST(1000 + c.id_cliente AS VARCHAR(10))) AS direccion,
                ISNULL(d.telefono, '379460' + RIGHT('0000' + CAST(c.id_cliente AS VARCHAR(4)), 4)) AS telefono,
                ISNULL(d.sexo, 'Hombre') AS sexo,
                ISNULL(d.fecha_nacimiento, '1995-01-15') AS fecha_nacimiento
            FROM dbo.clientes c
            LEFT JOIN
            (
                VALUES
                    (1,    'ana.gomez.cli@gmail.com',        '40112233', 'Av. 3 de Abril 1120',     '3794600001', 'Mujer',  '1996-04-12'),
                    (2,    'carlos.fernandez.cli@gmail.com', '38223344', 'Catamarca 845',           '3794600002', 'Hombre', '1991-08-23'),
                    (3,    'maria.rodriguez.cli@gmail.com',  '41334455', 'Mendoza 1530',            '3794600003', 'Mujer',  '1998-11-05'),
                    (4,    'juan.perez.cli@gmail.com',       '37445566', 'Córdoba 920',             '3794600004', 'Hombre', '1989-02-19'),
                    (5,    'lucia.martinez.cli@gmail.com',   '42556677', 'Yrigoyen 1740',           '3794600005', 'Mujer',  '1999-07-30'),
                    (6,    'diego.lopez.cli@gmail.com',      '39667788', 'Salta 615',               '3794600006', 'Hombre', '1993-05-14'),
                    (7,    'sofia.ramirez.cli@gmail.com',    '43778899', 'Rioja 1080',              '3794600007', 'Mujer',  '2000-09-21'),
                    (8,    'martin.torres.cli@gmail.com',    '36889900', 'San Juan 1310',           '3794600008', 'Hombre', '1987-12-03'),
                    (9,    'valentina.acosta.cli@gmail.com', '44990011', 'Tucumán 490',             '3794600009', 'Mujer',  '2001-03-27'),
                    (10,   'andres.benitez.cli@gmail.com',   '35101122', 'Chaco 1620',              '3794600010', 'Hombre', '1986-06-18'),
                    (11,   'carlos.monzon.cli@gmail.com',    '34212233', 'Av. Maipú 2150',          '3794600011', 'Hombre', '1985-10-09'),
                    (1011, 'martin.monzon.cli@gmail.com',    '45323344', 'Av. Independencia 3420',  '3794600012', 'Hombre', '2002-01-25')
            ) AS d(id_cliente, correo, dni, direccion, telefono, sexo, fecha_nacimiento)
                ON c.id_cliente = d.id_cliente
            WHERE c.id_persona IS NULL
        ) AS origen
        ON 1 = 0
        WHEN NOT MATCHED THEN
            INSERT (nombre, apellido, correo, eliminado, creado_en, eliminado_en, dni, direccion, telefono, sexo, fecha_nacimiento)
            VALUES (origen.nombre, origen.apellido, origen.correo, 0, GETDATE(), NULL, origen.dni, origen.direccion, origen.telefono, origen.sexo, origen.fecha_nacimiento)
        OUTPUT origen.id_cliente, inserted.id_persona
        INTO @MapaClientes (id_cliente, id_persona);

        -- Asignar los nuevos id_persona a cada cliente
        UPDATE c
        SET c.id_persona = m.id_persona
        FROM dbo.clientes c
        INNER JOIN @MapaClientes m
            ON c.id_cliente = m.id_cliente;

        -- Hacer obligatoria la columna id_persona
        ALTER TABLE dbo.clientes
        ALTER COLUMN id_persona INT NOT NULL;

        -- Eliminar restricciones del antiguo codigo_cliente
        IF EXISTS
        (
            SELECT 1
            FROM sys.key_constraints
            WHERE name = N'UQ_clientes_codigo'
              AND parent_object_id = OBJECT_ID(N'dbo.clientes')
        )
        BEGIN
            ALTER TABLE dbo.clientes
            DROP CONSTRAINT UQ_clientes_codigo;
        END;

        IF EXISTS
        (
            SELECT 1
            FROM sys.check_constraints
            WHERE name = N'CK_clientes_codigo'
              AND parent_object_id = OBJECT_ID(N'dbo.clientes')
        )
        BEGIN
            ALTER TABLE dbo.clientes
            DROP CONSTRAINT CK_clientes_codigo;
        END;

        -- Eliminar las columnas antiguas de datos personales
        ALTER TABLE dbo.clientes
        DROP COLUMN nombre, apellido, codigo_cliente;
    END;

    -- =========================================================================
    -- 3. Asegurar restricción UNIQUE y llave foránea hacia dbo.persona
    -- =========================================================================
    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.key_constraints
        WHERE name = N'UQ_Clientes_Persona'
          AND parent_object_id = OBJECT_ID(N'dbo.clientes')
    )
    BEGIN
        ALTER TABLE dbo.clientes
        ADD CONSTRAINT UQ_Clientes_Persona UNIQUE (id_persona);
    END;

    IF NOT EXISTS
    (
        SELECT 1
        FROM sys.foreign_keys
        WHERE name = N'FK_Clientes_Persona'
          AND parent_object_id = OBJECT_ID(N'dbo.clientes')
    )
    BEGIN
        ALTER TABLE dbo.clientes
        ADD CONSTRAINT FK_Clientes_Persona
            FOREIGN KEY (id_persona)
            REFERENCES dbo.persona(id_persona);
    END;

    COMMIT TRANSACTION;
    PRINT 'Tabla dbo.clientes actualizada correctamente con (id_cliente, id_persona, creado_en).';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;

    THROW;
END CATCH;
GO

-- =========================================================================
-- 4. Consultas de verificación
-- =========================================================================

-- A) Verificar la estructura final de dbo.clientes
SELECT id_cliente, id_persona, creado_en
FROM dbo.clientes
ORDER BY id_cliente;

-- B) Verificar los datos completos de los clientes en dbo.persona
SELECT 
    c.id_cliente,
    c.creado_en AS fecha_alta_cliente,
    p.id_persona,
    p.nombre,
    p.apellido,
    p.correo,
    p.dni,
    p.direccion,
    p.telefono,
    p.sexo
FROM dbo.clientes c
INNER JOIN dbo.persona p ON c.id_persona = p.id_persona
ORDER BY c.id_cliente;
GO
/*
================================================================================
02_Configurar_Sistema_Inicial.sql
================================================================================
*/
USE SupermercadoDB;
GO

SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;

    /* 1. Roles con IDs fijos */
    IF NOT EXISTS (SELECT 1 FROM dbo.roles)
    BEGIN
        SET IDENTITY_INSERT dbo.roles ON;

        INSERT INTO dbo.roles(id_rol, nombre)
        VALUES
            (1, N'Administrador'),
            (2, N'Cajero'),
            (3, N'Inventario'),
            (4, N'Supervisor');

        SET IDENTITY_INSERT dbo.roles OFF;
    END;

    IF EXISTS
    (
        SELECT esperado.id_rol
        FROM (VALUES
            (1, N'Administrador'),
            (2, N'Cajero'),
            (3, N'Inventario'),
            (4, N'Supervisor')
        ) AS esperado(id_rol, nombre)
        LEFT JOIN dbo.roles r ON r.id_rol = esperado.id_rol AND r.nombre = esperado.nombre
        WHERE r.id_rol IS NULL
    )
    BEGIN
        THROW 50010, 'Los IDs de roles no coinciden con el proyecto. Se esperan Administrador=1, Cajero=2, Inventario=3 y Supervisor=4.', 1;
    END;

    /* 2. Medios de pago */
    INSERT INTO dbo.medios_de_pago(medio_pago)
    SELECT v.medio_pago
    FROM (VALUES
        (N'Efectivo'),
        (N'Tarjeta de débito'),
        (N'Tarjeta de crédito'),
        (N'Transferencia')
    ) AS v(medio_pago)
    WHERE NOT EXISTS
    (
        SELECT 1 FROM dbo.medios_de_pago m WHERE m.medio_pago = v.medio_pago
    );

    /* 3. Cuenta inicial para permitir el primer ingreso al sistema. */
    IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE nombre_usuario = N'admin')
    BEGIN
        DECLARE @IdPersonaAdmin INT;
        DECLARE @IdRolAdmin INT = 1;
        DECLARE @HashAdmin VARCHAR(64);
        DECLARE @ClaveInicial VARCHAR(100) = 'admin123';

        SET @HashAdmin = LOWER(CONVERT(VARCHAR(64),
            HASHBYTES('SHA2_256', CONVERT(VARCHAR(100), @ClaveInicial)), 2));

        INSERT INTO dbo.persona(nombre, apellido, correo)
        VALUES (N'Administrador', N'Sistema', N'admin@local');

        SET @IdPersonaAdmin = CONVERT(INT, SCOPE_IDENTITY());

        INSERT INTO dbo.usuarios
            (id_persona, id_rol, correo, nombre_usuario, contrasena)
        VALUES
            (@IdPersonaAdmin, @IdRolAdmin, N'admin@local', N'admin', @HashAdmin);
    END;

    COMMIT TRANSACTION;
    PRINT N'Configuracion inicial completada.';
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO

/* Verificacion rapida de roles, medios de pago y cuenta de ingreso. */
SELECT id_rol, nombre FROM dbo.roles ORDER BY id_rol;
SELECT id_medio_pago, medio_pago FROM dbo.medios_de_pago ORDER BY id_medio_pago;
SELECT u.id_usuario, u.nombre_usuario, r.nombre AS rol
FROM dbo.usuarios u
INNER JOIN dbo.roles r ON r.id_rol = u.id_rol
WHERE u.nombre_usuario = N'admin';
GO

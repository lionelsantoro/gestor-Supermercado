/*
================================================================================
04_DatosUsuarios.sql  
================================================================================
*/
USE SupermercadoDB;
GO

SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @IdPersona INT;
    DECLARE @IdRol INT;

    /* Cajero de prueba. Clave inicial: caja123 */
    IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE nombre_usuario = N'cajero_demo')
    BEGIN
        SELECT @IdRol = id_rol FROM dbo.roles WHERE nombre = N'Cajero';
        INSERT INTO dbo.persona(nombre, apellido, correo, dni, direccion, telefono, sexo, fecha_nacimiento)
        VALUES (N'Juan', N'Prueba Cajero', N'cajero.demo@local', '45000001', N'Domicilio de prueba', '3794000001', N'Hombre', '1995-03-20');
        SET @IdPersona = CONVERT(INT, SCOPE_IDENTITY());
        INSERT INTO dbo.usuarios(id_persona, id_rol, correo, nombre_usuario, contrasena)
        VALUES (@IdPersona, @IdRol, N'cajero.demo@local', N'cajero_demo',
            LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'caja123'), 2)));
    END;

    /* Inventario de prueba. Clave inicial: inventario123 */
    IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE nombre_usuario = N'inventario_demo')
    BEGIN
        SELECT @IdRol = id_rol FROM dbo.roles WHERE nombre = N'Inventario';
        INSERT INTO dbo.persona(nombre, apellido, correo, dni, direccion, telefono, sexo, fecha_nacimiento)
        VALUES (N'Maria', N'Prueba Inventario', N'inventario.demo@local', '45000002', N'Domicilio de prueba', '3794000002', N'Mujer', '1993-08-10');
        SET @IdPersona = CONVERT(INT, SCOPE_IDENTITY());
        INSERT INTO dbo.usuarios(id_persona, id_rol, correo, nombre_usuario, contrasena)
        VALUES (@IdPersona, @IdRol, N'inventario.demo@local', N'inventario_demo',
            LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'inventario123'), 2)));
    END;

    /* Supervisor de prueba. Clave inicial: supervisor123. */
    IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE nombre_usuario = N'supervisor_demo')
    BEGIN
        SELECT @IdRol = id_rol FROM dbo.roles WHERE nombre = N'Supervisor';
        INSERT INTO dbo.persona(nombre, apellido, correo, dni, direccion, telefono, sexo, fecha_nacimiento)
        VALUES (N'Carlos', N'Prueba Supervisor', N'supervisor.demo@local', '45000003', N'Domicilio de prueba', '3794000003', N'Hombre', '1988-12-01');
        SET @IdPersona = CONVERT(INT, SCOPE_IDENTITY());
        INSERT INTO dbo.usuarios(id_persona, id_rol, correo, nombre_usuario, contrasena, codigo_autorizacion)
        VALUES (@IdPersona, @IdRol, N'supervisor.demo@local', N'supervisor_demo',
            LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'supervisor123'), 2)), NULL);
    END;

    COMMIT TRANSACTION;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0
        ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO

/* Completa el codigo del supervisor de prueba si todavia no tiene uno. */
EXEC dbo.GenerarCodigosAutorizacionSupervisores;
GO

SELECT u.nombre_usuario, r.nombre AS rol, u.codigo_autorizacion
FROM dbo.usuarios u
INNER JOIN dbo.roles r ON r.id_rol = u.id_rol
WHERE u.nombre_usuario IN (N'cajero_demo', N'inventario_demo', N'supervisor_demo');
GO

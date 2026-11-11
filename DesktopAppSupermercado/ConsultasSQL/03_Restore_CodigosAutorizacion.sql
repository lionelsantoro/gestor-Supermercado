/*
================================================================================
03_Restore_CodigosAutorizacion.sql
================================================================================
*/
USE SupermercadoDB;
GO

IF NOT EXISTS
(
    SELECT 1
    FROM sys.indexes
    WHERE name = N'UQ_usuarios_codigo_autorizacion'
      AND object_id = OBJECT_ID(N'dbo.usuarios')
)
BEGIN
    CREATE UNIQUE INDEX UQ_usuarios_codigo_autorizacion
    ON dbo.usuarios(codigo_autorizacion)
    WHERE codigo_autorizacion IS NOT NULL;
END;
GO

CREATE OR ALTER PROCEDURE dbo.GenerarCodigosAutorizacionSupervisores
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    DECLARE @IdUsuario INT;
    DECLARE @Codigo INT;
    DECLARE @CodigosAsignados TABLE
    (
        id_usuario INT NOT NULL,
        codigo_autorizacion INT NOT NULL
    );

    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE curSupervisores CURSOR LOCAL FAST_FORWARD FOR
            SELECT u.id_usuario
            FROM dbo.usuarios u
            INNER JOIN dbo.roles r ON r.id_rol = u.id_rol
            WHERE r.nombre LIKE N'%supervisor%'
              AND u.eliminado = 0
              AND u.codigo_autorizacion IS NULL
            ORDER BY u.id_usuario;

        OPEN curSupervisores;
        FETCH NEXT FROM curSupervisores INTO @IdUsuario;

        WHILE @@FETCH_STATUS = 0
        BEGIN
            SET @Codigo = NULL;

            /* Se generan numeros entre 1000 y 9999. */
            WHILE @Codigo IS NULL
            BEGIN
                SET @Codigo = 1000 + CONVERT(INT,
                    ABS(CONVERT(BIGINT, CHECKSUM(NEWID()))) % 9000);

                IF EXISTS
                (
                    SELECT 1
                    FROM dbo.usuarios WITH (UPDLOCK, HOLDLOCK)
                    WHERE codigo_autorizacion = @Codigo
                      AND codigo_autorizacion IS NOT NULL
                )
                BEGIN
                    SET @Codigo = NULL;
                END;
            END;

            UPDATE dbo.usuarios
            SET codigo_autorizacion = @Codigo
            WHERE id_usuario = @IdUsuario
              AND eliminado = 0
              AND codigo_autorizacion IS NULL;

            IF @@ROWCOUNT = 1
            BEGIN
                INSERT INTO @CodigosAsignados(id_usuario, codigo_autorizacion)
                VALUES (@IdUsuario, @Codigo);
            END;

            FETCH NEXT FROM curSupervisores INTO @IdUsuario;
        END;

        CLOSE curSupervisores;
        DEALLOCATE curSupervisores;

        COMMIT TRANSACTION;

        SELECT id_usuario, codigo_autorizacion
        FROM @CodigosAsignados
        ORDER BY id_usuario;
    END TRY
    BEGIN CATCH
        IF CURSOR_STATUS('local', 'curSupervisores') >= 0
            CLOSE curSupervisores;
        IF CURSOR_STATUS('local', 'curSupervisores') > -3
            DEALLOCATE curSupervisores;

        IF XACT_STATE() <> 0
            ROLLBACK TRANSACTION;
        THROW;
    END CATCH;
END;
GO

/* Primera ejecucion: puede devolver cero filas si todavia no hay supervisores. */
EXEC dbo.GenerarCodigosAutorizacionSupervisores;
GO

/* Ver los supervisores y sus codigos actuales. */
SELECT u.id_usuario, u.nombre_usuario, r.nombre AS rol,
       u.codigo_autorizacion, u.eliminado
FROM dbo.usuarios u
INNER JOIN dbo.roles r ON r.id_rol = u.id_rol
WHERE r.nombre LIKE N'%supervisor%'
ORDER BY u.id_usuario;
GO

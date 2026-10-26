USE SupermercadoDB;
GO

/* ============================================================
   1. Indice unico FILTRADO sobre codigo_autorizacion.
      Filtrado porque la columna es nullable y SQL Server solo
      admite UN NULL en un UNIQUE comun: con todos los
      no-supervisores en NULL, un UNIQUE normal reventaria
      al segundo usuario.
   ============================================================ */
IF NOT EXISTS (SELECT 1 FROM sys.indexes
               WHERE name = N'UQ_usuarios_codigo_autorizacion'
                 AND object_id = OBJECT_ID(N'dbo.usuarios'))
BEGIN
    CREATE UNIQUE INDEX UQ_usuarios_codigo_autorizacion
    ON dbo.usuarios (codigo_autorizacion)
    WHERE codigo_autorizacion IS NOT NULL;

    PRINT '-> Indice unico filtrado creado.';
END
ELSE
    PRINT '-> El indice unico ya existia.';
GO

/* ============================================================
   2. Asignar codigo de 4 digitos a los supervisores activos
      que todavia no tengan (en tu base, gust345 esta en NULL).
   ============================================================ */
DECLARE @idUsuario INT;
DECLARE @codigo INT;

DECLARE cur CURSOR LOCAL FAST_FORWARD FOR
    SELECT u.id_usuario
    FROM dbo.usuarios u
    INNER JOIN dbo.roles r ON u.id_rol = r.id_rol
    WHERE r.nombre LIKE '%supervisor%'
      AND u.eliminado = 0
      AND u.codigo_autorizacion IS NULL;

OPEN cur;
FETCH NEXT FROM cur INTO @idUsuario;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @codigo = NULL;
    WHILE @codigo IS NULL
    BEGIN
        SET @codigo = 1000 + ABS(CHECKSUM(NEWID())) % 9000;

        IF EXISTS (SELECT 1 FROM dbo.usuarios WHERE codigo_autorizacion = @codigo)
            SET @codigo = NULL;
    END;

    UPDATE dbo.usuarios
    SET codigo_autorizacion = @codigo
    WHERE id_usuario = @idUsuario;

    PRINT '-> Usuario ' + CAST(@idUsuario AS VARCHAR(10))
        + ' -> codigo ' + CAST(@codigo AS VARCHAR(10));

    FETCH NEXT FROM cur INTO @idUsuario;
END;

CLOSE cur;
DEALLOCATE cur;
GO

/* ============================================================
   3. Verificacion
   ============================================================ */
SELECT u.id_usuario, u.nombre_usuario, r.nombre AS rol, u.codigo_autorizacion
FROM dbo.usuarios u
INNER JOIN dbo.roles r ON u.id_rol = r.id_rol
WHERE r.nombre LIKE '%supervisor%'
ORDER BY u.id_usuario;
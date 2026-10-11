
USE SupermercadoDB;
GO

-- 1. Verificar que exista la tabla ventas.
IF OBJECT_ID(N'dbo.ventas', N'U') IS NULL
BEGIN
    THROW 50001, 'No existe la tabla dbo.ventas.', 1;
END;
GO

-- 2. Crear numero_ticket si todavía no existe.
IF COL_LENGTH(N'dbo.ventas', N'numero_ticket') IS NULL
BEGIN
    ALTER TABLE dbo.ventas
    ADD numero_ticket INT NULL;
END;
GO

-- 3. Quitar un DEFAULT anterior de numero_ticket,
-- si existe. El programa asignará el ticket explícitamente.
DECLARE @NombreDefault SYSNAME;
DECLARE @SQL NVARCHAR(MAX);

SELECT @NombreDefault = dc.name
FROM sys.default_constraints AS dc
INNER JOIN sys.columns AS c
    ON c.object_id = dc.parent_object_id
   AND c.column_id = dc.parent_column_id
WHERE dc.parent_object_id = OBJECT_ID(N'dbo.ventas')
  AND c.name = N'numero_ticket';

IF @NombreDefault IS NOT NULL
BEGIN
    SET @SQL =
        N'ALTER TABLE dbo.ventas DROP CONSTRAINT '
        + QUOTENAME(@NombreDefault) + N';';

    EXEC sys.sp_executesql @SQL;
END;
GO

-- 4. Comprobar que no haya tickets NULL.
-- Si hay ventas antiguas sin ticket, detener la configuración.
IF EXISTS
(
    SELECT 1
    FROM dbo.ventas
    WHERE numero_ticket IS NULL
)
BEGIN
    THROW 50002,
        'Hay ventas sin numero_ticket. Deben revisarse antes de continuar.',
        1;
END;
GO

-- 5. Comprobar que no existan números repetidos.
IF EXISTS
(
    SELECT numero_ticket
    FROM dbo.ventas
    GROUP BY numero_ticket
    HAVING COUNT(*) > 1
)
BEGIN
    THROW 50003,
        'Hay numeros de ticket duplicados en ventas.',
        1;
END;
GO

-- 6. Establecer el tipo y la obligatoriedad del ticket.
ALTER TABLE dbo.ventas
ALTER COLUMN numero_ticket INT NOT NULL;
GO

-- 7. Impedir tickets duplicados.
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

-- 8. Crear la tabla que controla la numeración.
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

-- 9. Inicializar el contador con el último ticket existente.
-- Si ventas está vacía, comienza en 0 y el primer ticket será 1.
DECLARE @UltimoTicket INT;

SELECT @UltimoTicket = ISNULL(MAX(numero_ticket), 0)
FROM dbo.ventas;

IF NOT EXISTS
(
    SELECT 1
    FROM dbo.ControlNumeracionTicket
    WHERE id = 1
)
BEGIN
    INSERT INTO dbo.ControlNumeracionTicket
        (id, ultimo_numero)
    VALUES
        (1, @UltimoTicket);
END
ELSE
BEGIN
    -- Nunca dejar el contador por debajo de los tickets registrados.
    UPDATE dbo.ControlNumeracionTicket
    SET ultimo_numero = @UltimoTicket
    WHERE id = 1
      AND ultimo_numero < @UltimoTicket;
END;
GO

-- 10. Verificar la configuración.
SELECT id, ultimo_numero
FROM dbo.ControlNumeracionTicket;

SELECT id_venta, numero_ticket, id_usuario, monto_total
FROM dbo.ventas
ORDER BY numero_ticket;

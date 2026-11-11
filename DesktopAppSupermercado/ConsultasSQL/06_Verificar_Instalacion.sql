/*
================================================================================
06_Verificar_Instalacion.sql
================================================================================
*/
USE SupermercadoDB;
GO

/* Tablas creadas. */
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
ORDER BY TABLE_NAME;
GO

/* Cantidad de registros por tabla principal. */
SELECT N'Persona' AS Tabla, COUNT(*) AS Registros FROM dbo.persona
UNION ALL SELECT N'Roles', COUNT(*) FROM dbo.roles
UNION ALL SELECT N'Usuarios', COUNT(*) FROM dbo.usuarios
UNION ALL SELECT N'Categorias', COUNT(*) FROM dbo.categorias
UNION ALL SELECT N'Productos', COUNT(*) FROM dbo.productos
UNION ALL SELECT N'Clientes', COUNT(*) FROM dbo.clientes
UNION ALL SELECT N'Medios de pago', COUNT(*) FROM dbo.medios_de_pago
UNION ALL SELECT N'Ventas', COUNT(*) FROM dbo.ventas
UNION ALL SELECT N'Detalles de venta', COUNT(*) FROM dbo.detalle_venta;
GO

/* Confirmar los IDs de rol usados por los permisos y la autorizacion de supervisor. */
SELECT id_rol, nombre FROM dbo.roles ORDER BY id_rol;
GO

/* Confirmar que el contador existe y comienza en cero en una base nueva. */
SELECT id, ultimo_numero FROM dbo.ControlNumeracionTicket;
GO

/* Verificar la unicidad filtrada de los codigos de autorizacion. */
SELECT name, is_unique, has_filter, filter_definition
FROM sys.indexes
WHERE object_id = OBJECT_ID(N'dbo.usuarios')
  AND name = N'UQ_usuarios_codigo_autorizacion';
GO

/* Verificar supervisores que aun requieren codigo. */
SELECT u.id_usuario, u.nombre_usuario, u.codigo_autorizacion
FROM dbo.usuarios u
INNER JOIN dbo.roles r ON r.id_rol = u.id_rol
WHERE r.nombre LIKE N'%supervisor%'
  AND u.eliminado = 0
ORDER BY u.id_usuario;
GO

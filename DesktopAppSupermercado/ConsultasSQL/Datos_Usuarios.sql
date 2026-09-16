-- 1. Primero creamos los 4 roles
INSERT INTO roles (nombre) VALUES 
('Administrador'),
('Cajero'),
('Inventario'),
('Supervisor');

-- 2. Luego creamos las 4 personas físicas
INSERT INTO persona (nombre, apellido, correo) VALUES 
('Ana', 'Gomez', 'admin@empresa.com'),
('Juan', 'Perez', 'cajero@empresa.com'),
('Maria', 'Lopez', 'inventario@empresa.com'),
('Carlos', 'Ruiz', 'supervisor@empresa.com');

-- 3. Finalmente creamos los usuarios vinculando la persona (1 a 4) y el rol (1 a 4)
INSERT INTO usuarios (id_persona, id_rol, correo, nombre_usuario, contrasena, codigo_autorizacion) VALUES 
(1, 1, 'admin@empresa.com', 'admin', 'admin123', NULL),       -- Ana es Administradora
(2, 2, 'cajero@empresa.com', 'cajero', 'caja123', NULL),      -- Juan es Cajero
(3, 3, 'inventario@empresa.com', 'inventario', 'inv123', NULL), -- Maria es Inventario
(4, 4, 'supervisor@empresa.com', 'supervisor', 'super123', 8888); -- Carlos es Supervisor
-- ==============================================================================
-- SCRIPT DE INICIALIZACIÓN DE DATOS - SISTEMA DE SUPERMERCADO
-- ==============================================================================

-- 1. Primero actualizamos la estructura de la tabla 'persona' antes de insertar datos
ALTER TABLE persona
ADD dni VARCHAR(20),
    direccion VARCHAR(200),
    telefono VARCHAR(30),
    sexo VARCHAR(10),
    fecha_nacimiento DATE;

-- 2. Creamos el índice único para el DNI (Evita personas duplicadas)
CREATE UNIQUE INDEX UQ_persona_dni ON persona(dni) WHERE dni IS NOT NULL;

-- 3. Insertamos los 4 roles del sistema
INSERT INTO roles (nombre) VALUES 
('Administrador'),
('Cajero'),
('Inventario'),
('Supervisor');

-- 4. Insertamos las personas físicas con TODOS sus datos (incluyendo los campos nuevos)
INSERT INTO persona (nombre, apellido, correo, dni, direccion, telefono, sexo, fecha_nacimiento) VALUES 
('Ana', 'Gomez', 'admin@empresa.com', '30111222', 'Av. España 100', '3794000001', 'Mujer', '1990-05-15'),
('Juan', 'Perez', 'cajero@empresa.com', '35222333', 'San Martin 200', '3794000002', 'Hombre', '1995-03-20'),
('Maria', 'Lopez', 'inventario@empresa.com', '33444555', 'Junin 300', '3794000003', 'Mujer', '1993-08-10'),
('Carlos', 'Ruiz', 'supervisor@empresa.com', '31555666', 'Pellegrini 400', '3794000004', 'Hombre', '1988-12-01');

-- 5. Finalmente, creamos los usuarios vinculando persona y rol, usando directamente las contraseñas encriptadas
-- Contraseñas en texto plano de referencia: admin123, caja123, inv123, super123
INSERT INTO usuarios (id_persona, id_rol, correo, nombre_usuario, contrasena, codigo_autorizacion) VALUES 
(1, 1, 'admin@empresa.com', 'admin', '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9', NULL),           -- Ana es Administradora
(2, 2, 'cajero@empresa.com', 'cajero', '682b1787210953a4a1f91a9eed757bc3b3e8827fd464a2d970db063a24b1526a', NULL),         -- Juan es Cajero
(3, 3, 'inventario@empresa.com', 'inventario', '170b00da0d752f0eef5fa3608ea2e6c0bd751a9bf539dc101ebe9425f5003c53', NULL), -- Maria es Inventario
(4, 4, 'supervisor@empresa.com', 'supervisor', '4e4c56e4a15f89f05c2f4c72613da2a18c9665d4f0d6acce16415eb06f9be776', 8888); -- Carlos es Supervisor
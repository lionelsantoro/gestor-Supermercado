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


//  1) agregar los campos faltantes a la tabla persona

ALTER TABLE persona
ADD dni VARCHAR(20),
    direccion VARCHAR(200),
    telefono VARCHAR(30),
    sexo VARCHAR(10),
    fecha_nacimiento DATE;

    //   2) Crear un índice único en la columna dni para evitar duplicado
    CREATE UNIQUE INDEX UQ_persona_dni 
ON persona(dni) 
WHERE dni IS NOT NULL;



// 3)  Actualizar los registros existentes con los nuevos campos
UPDATE persona SET dni = '30111222', direccion = 'Av. España 100', telefono = '3794000001', sexo = 'Mujer', fecha_nacimiento = '1990-05-15' WHERE id_persona = 1;

UPDATE persona SET dni = '35222333', direccion = 'San Martin 200', telefono = '3794000002', sexo = 'Hombre', fecha_nacimiento = '1995-03-20' WHERE id_persona = 2;

UPDATE persona SET dni = '33444555', direccion = 'Junin 300', telefono = '3794000003', sexo = 'Mujer', fecha_nacimiento = '1993-08-10' WHERE id_persona = 3;

UPDATE persona SET dni = '31555666', direccion = 'Pellegrini 400', telefono = '3794000004', sexo = 'Hombre', fecha_nacimiento = '1988-12-01' WHERE id_persona = 4;UPDATE persona SET dni = '30111222', direccion = 'Av. España 100', telefono = '3794000001', sexo = 'Mujer', fecha_nacimiento = '1990-05-15' WHERE id_persona = 1;

UPDATE persona SET dni = '35222333', direccion = 'San Martin 200', telefono = '3794000002', sexo = 'Hombre', fecha_nacimiento = '1995-03-20' WHERE id_persona = 2;

UPDATE persona SET dni = '33444555', direccion = 'Junin 300', telefono = '3794000003', sexo = 'Mujer', fecha_nacimiento = '1993-08-10' WHERE id_persona = 3;

UPDATE persona SET dni = '31555666', direccion = 'Pellegrini 400', telefono = '3794000004', sexo = 'Hombre', fecha_nacimiento = '1988-12-01' WHERE id_persona = 4;




// 4)  soluciuonar el problema de la contraseña encriptada para los usuarios existentes  en el inicio de sesion
UPDATE usuarios SET contrasena = '240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9' 
WHERE nombre_usuario = 'admin';

UPDATE usuarios SET contrasena = '682b1787210953a4a1f91a9eed757bc3b3e8827fd464a2d970db063a24b1526a' 
WHERE nombre_usuario = 'cajero';

UPDATE usuarios SET contrasena = '170b00da0d752f0eef5fa3608ea2e6c0bd751a9bf539dc101ebe9425f5003c53' 
WHERE nombre_usuario = 'inventario';

UPDATE usuarios SET contrasena = '4e4c56e4a15f89f05c2f4c72613da2a18c9665d4f0d6acce16415eb06f9be776' 
WHERE nombre_usuario = 'supervisor';
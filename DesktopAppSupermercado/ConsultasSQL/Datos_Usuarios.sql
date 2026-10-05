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














.......................................................



-- ==========================================
-- 1. CARGAR CATEGORÍAS
-- ==========================================
INSERT INTO categorias (nombre) VALUES 
('Bebidas'),
('Lácteos'),
('Almacén'),
('Limpieza'),
('Carnicería'),
('Verdulería'),
('Panadería');

-- ==========================================
-- 2. CARGAR 15 PRODUCTOS
-- ==========================================
-- Enviamos NULL a "nombre" y "kilogramo" antiguos porque ahora usamos "descripcion" y "stock".

INSERT INTO productos (id_categoria, descripcion, precio, stock, unidad_medida, codigo_barra, nombre, kilogramo) VALUES 
-- BEBIDAS
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Coca-Cola 2.25L', 2500.00, 48, 'Unidad', '7790895000997', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Cerveza Quilmes Clásica 1L', 2200.00, 120, 'Unidad', '7791234567891', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Agua Mineral Kin 1.5L', 950.00, 60, 'Unidad', '7790895007002', NULL, NULL),

-- LÁCTEOS
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Leche Entera La Serenísima 1L', 1350.00, 30, 'Unidad', '7790742300000', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Queso Cremoso Cremigal', 6500.00, 15.5, 'Kg', '2000000000010', NULL, NULL),

-- ALMACÉN
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Yerba Mate Taragüi 1Kg', 4200.00, 45, 'Unidad', '7790070000088', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Fideos Tallarines Matarazzo 500g', 1150.00, 80, 'Unidad', '7790070318596', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Arroz Gallo Oro 1Kg', 2100.00, 40, 'Unidad', '7790070000019', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Aceite de Girasol Natura 1.5L', 2850.00, 35, 'Unidad', '7790070411716', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Azúcar Ledesma Clásica 1Kg', 950.00, 200, 'Unidad', '7790070000057', NULL, NULL),

-- LIMPIEZA
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Detergente Magistral 500ml', 1850.00, 25, 'Unidad', '7790070000101', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Lavandina Ayudín Clásica 1L', 1250.00, 60, 'Unidad', '7790070000118', NULL, NULL),

-- CARNICERÍA
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Asado de Tira Especial', 7500.00, 25.5, 'Kg', '2000000000027', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Carne Picada Especial', 6800.00, 10.2, 'Kg', '2000000000034', NULL, NULL),

-- VERDULERÍA / PANADERÍA
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Papa Negra', 800.00, 50.0, 'Kg', '2000000000041', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Pan Francés Mignón', 1800.00, 18.5, 'Kg', '2000000000058', NULL, NULL);



2)  .....................


-- Borrar todos los productos y reiniciar el contador
DELETE FROM productos;
DBCC CHECKIDENT ('productos', RESEED, 0);

-- Insertar 20 productos nuevos con código de 6 dígitos
INSERT INTO productos (id_categoria, descripcion, precio, stock, unidad_medida, codigo_barra, nombre, kilogramo) VALUES 
-- Bebidas
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Coca-Cola 2.25L', 2500, 48, 'Unidad', '100001', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Cerveza Quilmes Clásica 1L', 2200, 120, 'Unidad', '100002', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Agua Mineral Kin 1.5L', 950, 60, 'Unidad', '100003', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Sprite 2L Retornable', 1800, 30, 'Unidad', '100004', NULL, NULL),
-- Lácteos
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Leche Entera La Serenísima 1L', 1350, 30, 'Unidad', '200001', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Queso Cremoso Cremigal', 6500, 15.5, 'Kg', '200002', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Yogur Firme Ilolay Frutilla', 850, 40, 'Unidad', '200003', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Manteca Tonadita 200g', 1900, 25, 'Unidad', '200004', NULL, NULL),
-- Almacén
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Yerba Mate Taragüi 1Kg', 4200, 45, 'Unidad', '300001', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Fideos Tallarines Matarazzo 500g', 1150, 80, 'Unidad', '300002', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Arroz Gallo Oro 1Kg', 2100, 40, 'Unidad', '300003', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Aceite de Girasol Natura 1.5L', 2850, 35, 'Unidad', '300004', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Azúcar Ledesma Clásica 1Kg', 950, 200, 'Unidad', '300005', NULL, NULL),
-- Limpieza
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Detergente Magistral 500ml', 1850, 25, 'Unidad', '400001', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Lavandina Ayudín Clásica 1L', 1250, 60, 'Unidad', '400002', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Limpiador Poett Primavera 900ml', 1400, 40, 'Unidad', '400003', NULL, NULL),
-- Carnicería
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Asado de Tira Especial', 7500, 25.5, 'Kg', '500001', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Carne Picada Especial', 6800, 10.2, 'Kg', '500002', NULL, NULL),
-- Verdulería y Panadería
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Papa Negra', 800, 50.0, 'Kg', '600001', NULL, NULL),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Pan Francés Mignón', 1800, 18.5, 'Kg', '700001', NULL, NULL);
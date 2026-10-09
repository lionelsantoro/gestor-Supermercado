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


1)  .....................

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


3)  .....................


-- ==========================================
-- 3. CARGAR CATEGORÍAS
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
-- 4. CARGAR 10 PRODUCTOS POR CATEGORÍA (70 en total)
-- ==========================================
INSERT INTO productos (id_categoria, nombre, precio, stock, unidad_medida, codigo_barra) VALUES 

-- BEBIDAS (Códigos 100001 al 100010)
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Coca-Cola 2.25L', 2500, 48, 'Unidad', '100001'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Cerveza Quilmes Clásica 1L', 2200, 120, 'Unidad', '100002'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Agua Mineral Kin 1.5L', 950, 60, 'Unidad', '100003'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Sprite 2L Retornable', 1800, 30, 'Unidad', '100004'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Fernet Branca 750ml', 8500, 24, 'Unidad', '100005'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Jugo Cepita Naranja 1L', 1200, 40, 'Unidad', '100006'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Cerveza Brahma 1L', 2000, 100, 'Unidad', '100007'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Vino Toro en Caja 1L', 1500, 50, 'Unidad', '100008'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Soda Kin 1.5L', 800, 60, 'Unidad', '100009'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Bebidas'), 'Paso de los Toros Pomelo 1.5L', 1600, 35, 'Unidad', '100010'),

-- LÁCTEOS (Códigos 200001 al 200010)
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Leche Entera La Serenísima 1L', 1350, 30, 'Unidad', '200001'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Queso Cremoso Cremigal', 6500, 15.5, 'Kg', '200002'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Yogur Firme Ilolay Frutilla', 850, 40, 'Unidad', '200003'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Manteca Tonadita 200g', 1900, 25, 'Unidad', '200004'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Dulce de Leche Sancor 400g', 2100, 30, 'Unidad', '200005'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Queso Rallado La Serenísima 120g', 1800, 40, 'Unidad', '200006'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Crema de Leche Tregar 200cc', 1400, 20, 'Unidad', '200007'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Leche Chocolatada Cindor 1L', 2200, 25, 'Unidad', '200008'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Queso Crema Mendicrim 300g', 2500, 20, 'Unidad', '200009'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Lácteos'), 'Postre Danette Vainilla', 900, 35, 'Unidad', '200010'),

-- ALMACÉN (Códigos 300001 al 300010)
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Yerba Mate Playadito 1Kg', 4500, 50, 'Unidad', '300001'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Fideos Tallarines Matarazzo 500g', 1150, 80, 'Unidad', '300002'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Arroz Gallo Oro 1Kg', 2100, 40, 'Unidad', '300003'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Aceite de Girasol Natura 1.5L', 2850, 35, 'Unidad', '300004'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Azúcar Ledesma Clásica 1Kg', 950, 100, 'Unidad', '300005'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Harina Pureza 0000 1Kg', 1200, 60, 'Unidad', '300006'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Puré de Tomate Arcor 520g', 850, 90, 'Unidad', '300007'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Mayonesa Hellmanns 475g', 1600, 45, 'Unidad', '300008'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Galletitas Surtido Diversión 400g', 1500, 55, 'Unidad', '300009'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Almacén'), 'Atún Desmenuzado La Campagnola', 1900, 30, 'Unidad', '300010'),

-- LIMPIEZA (Códigos 400001 al 400010)
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Detergente Magistral 500ml', 1850, 25, 'Unidad', '400001'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Lavandina Ayudín Clásica 1L', 1250, 60, 'Unidad', '400002'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Limpiador Poett Primavera 900ml', 1400, 40, 'Unidad', '400003'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Jabón en Polvo Ala 800g', 2200, 35, 'Unidad', '400004'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Suavizante Vivere Clásico 900ml', 1900, 30, 'Unidad', '400005'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Papel Higiénico Higienol 4u', 2500, 50, 'Unidad', '400006'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Rollo de Cocina Sussex 3u', 1800, 40, 'Unidad', '400007'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Jabón de Tocador Rexona 3u', 1500, 45, 'Unidad', '400008'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Esponja Mortimer Multiuso', 600, 100, 'Unidad', '400009'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Limpieza'), 'Limpiavidrios Cif Gatillo 500ml', 2100, 20, 'Unidad', '400010'),

-- CARNICERÍA (Códigos 500001 al 500010)
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Asado de Tira Especial', 7500, 25.5, 'Kg', '500001'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Carne Picada Especial', 6800, 10.2, 'Kg', '500002'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Vacío de Novillo', 8200, 18.0, 'Kg', '500003'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Matambre de Cerdo', 7900, 12.5, 'Kg', '500004'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Nalga para Milanesa', 8500, 22.0, 'Kg', '500005'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Pechuga de Pollo', 4500, 30.0, 'Kg', '500006'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Chorizo de Cerdo', 4200, 15.0, 'Kg', '500007'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Morcilla Bombón', 3500, 10.0, 'Kg', '500008'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Costillita de Cerdo', 6500, 20.0, 'Kg', '500009'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Carnicería'), 'Osobuco', 4800, 14.5, 'Kg', '500010'),

-- VERDULERÍA (Códigos 600001 al 600010)
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Papa Negra', 800, 50.0, 'Kg', '600001'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Cebolla', 900, 40.0, 'Kg', '600002'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Tomate Perita', 1500, 30.0, 'Kg', '600003'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Lechuga Capuchina', 1200, 15.0, 'Kg', '600004'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Zanahoria', 1000, 25.0, 'Kg', '600005'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Manzana Roja', 1800, 20.0, 'Kg', '600006'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Banana Cavendish', 1600, 35.0, 'Kg', '600007'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Naranja para Jugo', 1100, 45.0, 'Kg', '600008'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Limón', 800, 20.0, 'Kg', '600009'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Verdulería'), 'Morrón Rojo', 2500, 10.0, 'Kg', '600010'),

-- PANADERÍA (Códigos 700001 al 700010)
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Pan Francés Mignón', 1800, 18.5, 'Kg', '700001'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Medialunas de Manteca', 350, 120, 'Unidad', '700002'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Pan de Miga', 3500, 10.0, 'Kg', '700003'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Bizcochitos de Grasa', 4500, 15.0, 'Kg', '700004'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Facturas Surtidas', 400, 100, 'Unidad', '700005'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Pan Rallado', 1500, 25.0, 'Kg', '700006'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Prepizza', 900, 40, 'Unidad', '700007'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Pan de Hamburguesa 4u', 1200, 30, 'Unidad', '700008'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Pan para Pancho 6u', 1100, 35, 'Unidad', '700009'),
((SELECT id_categoria FROM categorias WHERE nombre = 'Panadería'), 'Chipá de Queso', 7000, 12.0, 'Kg', '700010');
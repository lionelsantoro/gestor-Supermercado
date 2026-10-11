/*
Carga/sincronización de 70 productos de prueba para la versión de la tabla productos

IMPORTANTE:
- Este script NO elimina productos.
- Identifica cada producto por codigo_barra.
- Si el código ya existe, actualiza sus datos de catálogo y stock inicial.
- Si no existe, inserta el producto.
- Por eso, al volver a ejecutarlo se restablecen precios y stocks de prueba.
- Ejecutar en una base de datos de desarrollo/prueba, no después de ventas reales.
- Las categorías se crean solo si faltan.
*/
USE SupermercadoDB;
GO
SET XACT_ABORT ON;
BEGIN TRY
    BEGIN TRANSACTION;

    DECLARE @Productos TABLE
    (
        Categoria NVARCHAR(100) NOT NULL,
        Nombre NVARCHAR(150) NOT NULL,
        Precio DECIMAL(12,2) NOT NULL,
        Stock DECIMAL(12,3) NOT NULL,
        UnidadMedida NVARCHAR(20) NOT NULL,
        CodigoBarra VARCHAR(6) NOT NULL PRIMARY KEY
    );

    INSERT INTO @Productos
        (Categoria, Nombre, Precio, Stock, UnidadMedida, CodigoBarra)
    VALUES
    (N'Bebidas', N'Coca-Cola 2.25L', 2500.00, 48.000, N'Unidad', '100001'),
    (N'Bebidas', N'Cerveza Quilmes Clásica 1L', 2200.00, 120.000, N'Unidad', '100002'),
    (N'Bebidas', N'Agua Mineral Kin 1.5L', 950.00, 60.000, N'Unidad', '100003'),
    (N'Bebidas', N'Sprite 2L Retornable', 1800.00, 30.000, N'Unidad', '100004'),
    (N'Bebidas', N'Fernet Branca 750ml', 8500.00, 24.000, N'Unidad', '100005'),
    (N'Bebidas', N'Jugo Cepita Naranja 1L', 1200.00, 40.000, N'Unidad', '100006'),
    (N'Bebidas', N'Cerveza Brahma 1L', 2000.00, 100.000, N'Unidad', '100007'),
    (N'Bebidas', N'Vino Toro en Caja 1L', 1500.00, 50.000, N'Unidad', '100008'),
    (N'Bebidas', N'Soda Kin 1.5L', 800.00, 60.000, N'Unidad', '100009'),
    (N'Bebidas', N'Paso de los Toros Pomelo 1.5L', 1600.00, 35.000, N'Unidad', '100010'),
    (N'Lácteos', N'Leche Entera La Serenísima 1L', 1350.00, 30.000, N'Unidad', '200001'),
    (N'Lácteos', N'Queso Cremoso Cremigal', 6500.00, 15.500, N'Kg', '200002'),
    (N'Lácteos', N'Yogur Firme Ilolay Frutilla', 850.00, 40.000, N'Unidad', '200003'),
    (N'Lácteos', N'Manteca Tonadita 200g', 1900.00, 25.000, N'Unidad', '200004'),
    (N'Lácteos', N'Dulce de Leche Sancor 400g', 2100.00, 30.000, N'Unidad', '200005'),
    (N'Lácteos', N'Queso Rallado La Serenísima 120g', 1800.00, 40.000, N'Unidad', '200006'),
    (N'Lácteos', N'Crema de Leche Tregar 200cc', 1400.00, 20.000, N'Unidad', '200007'),
    (N'Lácteos', N'Leche Chocolatada Cindor 1L', 2200.00, 25.000, N'Unidad', '200008'),
    (N'Lácteos', N'Queso Crema Mendicrim 300g', 2500.00, 20.000, N'Unidad', '200009'),
    (N'Lácteos', N'Postre Danette Vainilla', 900.00, 35.000, N'Unidad', '200010'),
    (N'Almacén', N'Yerba Mate Playadito 1Kg', 4500.00, 50.000, N'Unidad', '300001'),
    (N'Almacén', N'Fideos Tallarines Matarazzo 500g', 1150.00, 80.000, N'Unidad', '300002'),
    (N'Almacén', N'Arroz Gallo Oro 1Kg', 2100.00, 40.000, N'Unidad', '300003'),
    (N'Almacén', N'Aceite de Girasol Natura 1.5L', 2850.00, 35.000, N'Unidad', '300004'),
    (N'Almacén', N'Azúcar Ledesma Clásica 1Kg', 950.00, 100.000, N'Unidad', '300005'),
    (N'Almacén', N'Harina Pureza 0000 1Kg', 1200.00, 60.000, N'Unidad', '300006'),
    (N'Almacén', N'Puré de Tomate Arcor 520g', 850.00, 90.000, N'Unidad', '300007'),
    (N'Almacén', N'Mayonesa Hellmanns 475g', 1600.00, 45.000, N'Unidad', '300008'),
    (N'Almacén', N'Galletitas Surtido Diversión 400g', 1500.00, 55.000, N'Unidad', '300009'),
    (N'Almacén', N'Atún Desmenuzado La Campagnola', 1900.00, 30.000, N'Unidad', '300010'),
    (N'Limpieza', N'Detergente Magistral 500ml', 1850.00, 25.000, N'Unidad', '400001'),
    (N'Limpieza', N'Lavandina Ayudín Clásica 1L', 1250.00, 60.000, N'Unidad', '400002'),
    (N'Limpieza', N'Limpiador Poett Primavera 900ml', 1400.00, 40.000, N'Unidad', '400003'),
    (N'Limpieza', N'Jabón en Polvo Ala 800g', 2200.00, 35.000, N'Unidad', '400004'),
    (N'Limpieza', N'Suavizante Vivere Clásico 900ml', 1900.00, 30.000, N'Unidad', '400005'),
    (N'Limpieza', N'Papel Higiénico Higienol 4u', 2500.00, 50.000, N'Unidad', '400006'),
    (N'Limpieza', N'Rollo de Cocina Sussex 3u', 1800.00, 40.000, N'Unidad', '400007'),
    (N'Limpieza', N'Jabón de Tocador Rexona 3u', 1500.00, 45.000, N'Unidad', '400008'),
    (N'Limpieza', N'Esponja Mortimer Multiuso', 600.00, 100.000, N'Unidad', '400009'),
    (N'Limpieza', N'Limpiavidrios Cif Gatillo 500ml', 2100.00, 20.000, N'Unidad', '400010'),
    (N'Carnicería', N'Asado de Tira Especial', 7500.00, 25.500, N'Kg', '500001'),
    (N'Carnicería', N'Carne Picada Especial', 6800.00, 10.200, N'Kg', '500002'),
    (N'Carnicería', N'Vacío de Novillo', 8200.00, 18.000, N'Kg', '500003'),
    (N'Carnicería', N'Matambre de Cerdo', 7900.00, 12.500, N'Kg', '500004'),
    (N'Carnicería', N'Nalga para Milanesa', 8500.00, 22.000, N'Kg', '500005'),
    (N'Carnicería', N'Pechuga de Pollo', 4500.00, 30.000, N'Kg', '500006'),
    (N'Carnicería', N'Chorizo de Cerdo', 4200.00, 15.000, N'Kg', '500007'),
    (N'Carnicería', N'Morcilla Bombón', 3500.00, 10.000, N'Kg', '500008'),
    (N'Carnicería', N'Costillita de Cerdo', 6500.00, 20.000, N'Kg', '500009'),
    (N'Carnicería', N'Osobuco', 4800.00, 14.500, N'Kg', '500010'),
    (N'Verdulería', N'Papa Negra', 800.00, 50.000, N'Kg', '600001'),
    (N'Verdulería', N'Cebolla', 900.00, 40.000, N'Kg', '600002'),
    (N'Verdulería', N'Tomate Perita', 1500.00, 30.000, N'Kg', '600003'),
    (N'Verdulería', N'Lechuga Capuchina', 1200.00, 15.000, N'Kg', '600004'),
    (N'Verdulería', N'Zanahoria', 1000.00, 25.000, N'Kg', '600005'),
    (N'Verdulería', N'Manzana Roja', 1800.00, 20.000, N'Kg', '600006'),
    (N'Verdulería', N'Banana Cavendish', 1600.00, 35.000, N'Kg', '600007'),
    (N'Verdulería', N'Naranja para Jugo', 1100.00, 45.000, N'Kg', '600008'),
    (N'Verdulería', N'Limón', 800.00, 20.000, N'Kg', '600009'),
    (N'Verdulería', N'Morrón Rojo', 2500.00, 10.000, N'Kg', '600010'),
    (N'Panadería', N'Pan Francés Mignón', 1800.00, 18.500, N'Kg', '700001'),
    (N'Panadería', N'Medialunas de Manteca', 350.00, 120.000, N'Unidad', '700002'),
    (N'Panadería', N'Pan de Miga', 3500.00, 10.000, N'Kg', '700003'),
    (N'Panadería', N'Bizcochitos de Grasa', 4500.00, 15.000, N'Kg', '700004'),
    (N'Panadería', N'Facturas Surtidas', 400.00, 100.000, N'Unidad', '700005'),
    (N'Panadería', N'Pan Rallado', 1500.00, 25.000, N'Kg', '700006'),
    (N'Panadería', N'Prepizza', 900.00, 40.000, N'Unidad', '700007'),
    (N'Panadería', N'Pan de Hamburguesa 4u', 1200.00, 30.000, N'Unidad', '700008'),
    (N'Panadería', N'Pan para Pancho 6u', 1100.00, 35.000, N'Unidad', '700009'),
    (N'Panadería', N'Chipá de Queso', 7000.00, 12.000, N'Kg', '700010');

    -- Crear únicamente las categorías que todavía no existen.
    INSERT INTO dbo.categorias (nombre)
    SELECT cats.Categoria
    FROM (VALUES
    (N'Bebidas')
    (N'Lácteos')
    (N'Almacén')
    (N'Limpieza')
    (N'Carnicería')
    (N'Verdulería')
    (N'Panadería')
    ) AS cats(Categoria)
    WHERE NOT EXISTS
    (
        SELECT 1 FROM dbo.categorias c WHERE c.nombre = cats.Categoria
    );

    IF EXISTS
    (
        SELECT 1
        FROM @Productos s
        WHERE NOT EXISTS
        (
            SELECT 1 FROM dbo.categorias c WHERE c.nombre = s.Categoria
        )
    )
        THROW 50010, 'Falta alguna categoria necesaria para cargar productos.', 1;

    -- Actualizar productos ya existentes por codigo_barra.
    UPDATE p
    SET p.id_categoria = c.id_categoria,
        p.descripcion = s.Nombre,
        p.precio = s.Precio,
        p.stock = s.Stock,
        p.unidad_medida = s.UnidadMedida,
        p.nombre = NULL,
        p.kilogramo = NULL,
        p.eliminado = 0
    FROM dbo.productos p
    INNER JOIN @Productos s ON p.codigo_barra = s.CodigoBarra
    INNER JOIN dbo.categorias c ON c.nombre = s.Categoria;

    -- Insertar los que todavía no existen.
    INSERT INTO dbo.productos
        (id_categoria, descripcion, precio, stock, unidad_medida,
         codigo_barra, nombre, kilogramo)
    SELECT c.id_categoria, s.Nombre, s.Precio, s.Stock,
           s.UnidadMedida, s.CodigoBarra, NULL, NULL
    FROM @Productos s
    INNER JOIN dbo.categorias c ON c.nombre = s.Categoria
    WHERE NOT EXISTS
    (
        SELECT 1 FROM dbo.productos p WHERE p.codigo_barra = s.CodigoBarra
    );

    COMMIT TRANSACTION;

    SELECT COUNT(*) AS ProductosDelListado
    FROM dbo.productos p
    INNER JOIN @Productos s ON p.codigo_barra = s.CodigoBarra;

    SELECT p.id_producto, p.descripcion, p.precio, p.stock,
           p.unidad_medida, p.codigo_barra, c.nombre AS categoria
    FROM dbo.productos p
    INNER JOIN @Productos s ON p.codigo_barra = s.CodigoBarra
    INNER JOIN dbo.categorias c ON c.id_categoria = p.id_categoria
    ORDER BY p.codigo_barra;
END TRY
BEGIN CATCH
    IF XACT_STATE() <> 0 ROLLBACK TRANSACTION;
    THROW;
END CATCH;
GO

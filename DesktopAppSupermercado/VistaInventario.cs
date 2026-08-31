using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class VistaInventario : Form
    {
        public VistaInventario()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Creamos una instancia del nuevo formulario
            FormNuevoProducto formProducto = new FormNuevoProducto();
            // Lo mostramos como una ventana emergente (modal)
            formProducto.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Creamos una instancia del nuevo formulario
            FormNuevaCategoria formCategoria = new FormNuevaCategoria();
            // Lo mostramos como una ventana emergente
            formCategoria.ShowDialog();
        }

        private void VistaInventario_Load(object sender, EventArgs e)
        {
            // --- Llenar tabla de Categorías (dataGridView2) ---
            // Columnas: IdCategoria, NombreCategoria, Descripcion
            dataGridView2.Rows.Add("1", "Almacén", "Productos secos y de despensa");
            dataGridView2.Rows.Add("2", "Lácteos", "Leches, yogures y quesos");
            dataGridView2.Rows.Add("3", "Bebidas", "Aguas, gaseosas y jugos");
            dataGridView2.Rows.Add("4", "Limpieza", "Artículos de limpieza para el hogar");
            dataGridView2.Rows.Add("5", "Perfumería", "Higiene personal y cosmética");

            // --- Llenar tabla de Productos (dataGridView1) ---
            // Columnas: Nombre, Id_categoria, Precio, Stock, Unidad_Medida, Codigo_Barra
            // El botón 'Modificar' se genera automáticamente, no se le pasa dato aquí.

            // Categoría 1: Almacén
            dataGridView1.Rows.Add("Arroz Blanco 1kg", "1", "1200", "50", "Unidad", "7791234567890");
            dataGridView1.Rows.Add("Lata de Lentejas", "1", "2500", "30", "Unidad", "7790987654321");

            // Categoría 2: Lácteos
            dataGridView1.Rows.Add("Leche Entera 1L", "2", "1100", "100", "Unidad", "7791122334455");
            dataGridView1.Rows.Add("Queso Cremoso", "2", "8500", "15", "Kg", "7795544332211");

            // Categoría 3: Bebidas
            dataGridView1.Rows.Add("Gaseosa Cola 2L", "3", "3200", "60", "Unidad", "7796677889900");
            dataGridView1.Rows.Add("Agua Mineral 1.5L", "3", "950", "80", "Unidad", "7790099887766");

            // Categoría 4: Limpieza
            dataGridView1.Rows.Add("Lavandina 1L", "4", "1300", "45", "Unidad", "7792244668800");
            dataGridView1.Rows.Add("Detergente 500ml", "4", "1800", "55", "Unidad", "7791357924680");

            // Categoría 5: Perfumería
            dataGridView1.Rows.Add("Jabón de Tocador", "5", "800", "120", "Unidad", "7793692581470");
            dataGridView1.Rows.Add("Shampoo 400ml", "5", "4500", "25", "Unidad", "7799517538520");

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

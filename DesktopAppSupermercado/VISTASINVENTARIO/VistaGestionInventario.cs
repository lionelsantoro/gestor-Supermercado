using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado.VISTASINVENTARIO
{
    public partial class VistaGestionInventario : Form
    {
        public VistaGestionInventario()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gbEdicionProducto_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void labelUInidadMedida_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void labelNombre_Click(object sender, EventArgs e)
        {

        }

        private void labelDescripcion_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // Aquí es donde la magia ocurre al abrir la pantalla
        private void VistaGestionInventario_Load(object sender, EventArgs e)
        {
            // 1. Limpiar las filas por precaución antes de cargar
            dgvCategorias.Rows.Clear();
            dgvProductos.Rows.Clear();

            // 2. Insertar datos estáticos para Categorías (1 columna)
            dgvCategorias.Rows.Add("Bebidas");
            dgvCategorias.Rows.Add("Almacén");
            dgvCategorias.Rows.Add("Lácteos");
            dgvCategorias.Rows.Add("Limpieza");

            // 3. Insertar datos estáticos para Productos 
            // (Asegúrate de que el orden coincida con tus columnas: Codigo, Nombre, Precio, Stock, Unidad, Kg)
            dgvProductos.Rows.Add("77912345", "Coca Cola 2L", "2500.00", "50", "Unidad", "2.0");
            dgvProductos.Rows.Add("77954321", "Fideos Matarazzo", "1200.00", "120", "Unidad", "0.5");
            dgvProductos.Rows.Add("77998765", "Queso Cremoso", "4500.00", "15", "Kg", "1.0");
            dgvProductos.Rows.Add("77900011", "Lavandina Ayudín", "900.00", "35", "Unidad", "1.0");
        }
    }
}
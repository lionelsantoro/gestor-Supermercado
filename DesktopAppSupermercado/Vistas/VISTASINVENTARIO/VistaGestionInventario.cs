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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // 1. Obtener los valores de los filtros y la barra de búsqueda
            string categoriaBuscada = cmbFiltroCategoria.Text;
            string textoBusqueda = txtBuscarProducto.Text.Trim().ToLower(); // Extraemos el texto a buscar

            // 2. Obtener y validar los rangos de stock
            int stockMin = 0;
            int stockMax = int.MaxValue;

            if (!string.IsNullOrWhiteSpace(txtStockMin.Text))
            {
                int.TryParse(txtStockMin.Text, out stockMin);
            }

            if (!string.IsNullOrWhiteSpace(txtStockMax.Text))
            {
                int.TryParse(txtStockMax.Text, out stockMax);
            }

            // 3. Suspender el layout de la grilla para mejorar el rendimiento
            dgvProductos.SuspendLayout();

            // 4. Recorrer todas las filas de la grilla
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                if (fila.IsNewRow) continue;

                // Leer los valores de la fila
                string codigoFila = fila.Cells[0].Value?.ToString().ToLower() ?? "";
                string nombreFila = fila.Cells[1].Value?.ToString().ToLower() ?? "";
                string categoriaFila = fila.Cells[6].Value?.ToString() ?? "";

                int stockFila = 0;
                if (fila.Cells[3].Value != null)
                {
                    int.TryParse(fila.Cells[3].Value.ToString(), out stockFila);
                }

                // 5. Evaluar las 3 condiciones independientes
                bool coincideCategoria = (categoriaBuscada == "Todas" || string.IsNullOrEmpty(categoriaBuscada) || categoriaFila == categoriaBuscada);
                bool coincideStock = (stockFila >= stockMin && stockFila <= stockMax);

                // Coincide si la barra está vacía, o si el texto es parte del Nombre o del Código
                bool coincideTexto = string.IsNullOrEmpty(textoBusqueda) ||
                                     nombreFila.Contains(textoBusqueda) ||
                                     codigoFila.Contains(textoBusqueda);

                // 6. Aplicar la visibilidad: La fila debe cumplir con TODAS las condiciones activas
                fila.Visible = coincideCategoria && coincideStock && coincideTexto;
            }

            // Restaurar el layout
            dgvProductos.ResumeLayout();
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

        private void VistaGestionInventario_Load(object sender, EventArgs e)
        {

            cmbFiltroCategoria.Items.Add("Todas");
            cmbFiltroCategoria.Items.Add("Bebidas");
            cmbFiltroCategoria.Items.Add("Almacén");
            cmbFiltroCategoria.Items.Add("Lácteos");
            cmbFiltroCategoria.Items.Add("Limpieza");
            cmbFiltroCategoria.Items.Add("Panaderia");
            cmbFiltroCategoria.Items.Add("Carniceria");
            cmbFiltroCategoria.SelectedIndex = 0;

            dgvCategorias.Rows.Clear();
            dgvProductos.Rows.Clear();

            dataCategoria.Rows.Add("Bebidas");
            dataCategoria.Rows.Add("Almacén");
            dataCategoria.Rows.Add("Lácteos");
            dataCategoria.Rows.Add("Limpieza");
            dataCategoria.Rows.Add("Panaderia");
            dataCategoria.Rows.Add("Carniceria");

            // --- BEBIDAS ---
            dgvProductos.Rows.Add("77912345", "Coca Cola 2L", "2500.00", "50", "Unidad", "2.0", "Bebidas");
            dgvProductos.Rows.Add("77912346", "Sprite 2L", "2500.00", "30", "Unidad", "2.0", "Bebidas");
            dgvProductos.Rows.Add("77912347", "Cerveza Quilmes 1L", "1800.00", "100", "Unidad", "1.0", "Bebidas");
            dgvProductos.Rows.Add("77912348", "Vino Tinto Malbec 750ml", "4500.00", "40", "Unidad", "0.75", "Bebidas");
            dgvProductos.Rows.Add("77912349", "Agua Mineral 1.5L", "1200.00", "80", "Unidad", "1.5", "Bebidas");
            dgvProductos.Rows.Add("77912350", "Jugo Naranja 1L", "1500.00", "60", "Unidad", "1.0", "Bebidas");
            dgvProductos.Rows.Add("77912351", "Fernet Branca 750ml", "8500.00", "20", "Unidad", "0.75", "Bebidas");
            dgvProductos.Rows.Add("77912352", "Soda 2L", "1100.00", "50", "Unidad", "2.0", "Bebidas");
            dgvProductos.Rows.Add("77912353", "Energizante 250ml", "2200.00", "35", "Unidad", "0.25", "Bebidas");
            dgvProductos.Rows.Add("77912354", "Cerveza Brahma 1L", "1750.00", "100", "Unidad", "1.0", "Bebidas");

            // --- ALMACÉN ---
            dgvProductos.Rows.Add("77954321", "Fideos Matarazzo", "1200.00", "120", "Unidad", "0.5", "Almacén");
            dgvProductos.Rows.Add("77954322", "Arroz Arborio", "3200.00", "45", "Unidad", "0.5", "Almacén");
            dgvProductos.Rows.Add("77954323", "Pure de Tomate Arcor", "800.00", "200", "Unidad", "0.52", "Almacén");
            dgvProductos.Rows.Add("77954324", "Aceite de Girasol 1.5L", "2800.00", "90", "Unidad", "1.5", "Almacén");
            dgvProductos.Rows.Add("77954325", "Azucar 1Kg", "1100.00", "150", "Unidad", "1.0", "Almacén");
            dgvProductos.Rows.Add("77954326", "Yerba Mate 1Kg", "4200.00", "65", "Unidad", "1.0", "Almacén");
            dgvProductos.Rows.Add("77954327", "Harina Blancaflor 0000", "1300.00", "100", "Unidad", "1.0", "Almacén");
            dgvProductos.Rows.Add("77954328", "Sal Fina 500g", "600.00", "80", "Unidad", "0.5", "Almacén");
            dgvProductos.Rows.Add("77954329", "Lentejas 400g", "1500.00", "40", "Unidad", "0.4", "Almacén");
            dgvProductos.Rows.Add("77954330", "Atun 170g", "2100.00", "55", "Unidad", "0.17", "Almacén");

            // --- LÁCTEOS ---
            dgvProductos.Rows.Add("77998765", "Queso Cremoso", "4500.00", "15", "Kg", "1.0", "Lácteos");
            dgvProductos.Rows.Add("77998766", "Leche Entera 1L", "1400.00", "150", "Unidad", "1.0", "Lácteos");
            dgvProductos.Rows.Add("77998767", "Yogur Bebible Frutilla 1L", "1800.00", "70", "Unidad", "1.0", "Lácteos");
            dgvProductos.Rows.Add("77998768", "Manteca Sancor 200g", "2300.00", "45", "Unidad", "0.2", "Lácteos");
            dgvProductos.Rows.Add("77998769", "Dulce de Leche 400g", "3100.00", "60", "Unidad", "0.4", "Lácteos");
            dgvProductos.Rows.Add("77998770", "Queso Rallado 120g", "1900.00", "80", "Unidad", "0.12", "Lácteos");
            dgvProductos.Rows.Add("77998771", "Crema de Leche 200ml", "1600.00", "50", "Unidad", "0.2", "Lácteos");
            dgvProductos.Rows.Add("77998772", "Postrecito 120g", "900.00", "90", "Unidad", "0.12", "Lácteos");
            dgvProductos.Rows.Add("77998773", "Queso Tybo en Fetas 200g", "2600.00", "35", "Unidad", "0.2", "Lácteos");
            dgvProductos.Rows.Add("77998774", "Leche Descremada 1L", "1400.00", "110", "Unidad", "1.0", "Lácteos");

            // --- LIMPIEZA ---
            dgvProductos.Rows.Add("77900011", "Lavandina Ayudín", "900.00", "35", "Unidad", "1.0", "Limpieza");
            dgvProductos.Rows.Add("77900012", "Detergente 500ml", "1600.00", "80", "Unidad", "0.5", "Limpieza");
            dgvProductos.Rows.Add("77900013", "Desodorante de Pisos 900ml", "1200.00", "60", "Unidad", "0.9", "Limpieza");
            dgvProductos.Rows.Add("77900014", "Jabón en Polvo 3Kg", "5500.00", "25", "Unidad", "3.0", "Limpieza");
            dgvProductos.Rows.Add("77900015", "Suavizante Vivere 900ml", "1800.00", "40", "Unidad", "0.9", "Limpieza");
            dgvProductos.Rows.Add("77900016", "Limpiador Cif Crema 250g", "1100.00", "75", "Unidad", "0.25", "Limpieza");
            dgvProductos.Rows.Add("77900017", "Papel Higiénico x4", "2400.00", "90", "Unidad", "1.0", "Limpieza");
            dgvProductos.Rows.Add("77900018", "Rollo de Cocina x3", "1900.00", "65", "Unidad", "1.0", "Limpieza");
            dgvProductos.Rows.Add("77900019", "Esponja Mortimer", "500.00", "150", "Unidad", "1.0", "Limpieza");
            dgvProductos.Rows.Add("77900020", "Trapo de Piso", "1300.00", "80", "Unidad", "1.0", "Limpieza");

            // --- PANADERIA ---
            dgvProductos.Rows.Add("77922233", "Pan de Molde", "1500.00", "20", "Unidad", "0.5", "Panaderia");
            dgvProductos.Rows.Add("77922234", "Facturas Surtidas", "4500.00", "15", "Docena", "1.0", "Panaderia");
            dgvProductos.Rows.Add("77922235", "Pan Frances", "1800.00", "10", "Kg", "1.0", "Panaderia");
            dgvProductos.Rows.Add("77922236", "Prepizza de Tomate", "1200.00", "30", "Unidad", "0.4", "Panaderia");
            dgvProductos.Rows.Add("77922237", "Bizcochitos de Grasa 200g", "900.00", "50", "Unidad", "0.2", "Panaderia");
            dgvProductos.Rows.Add("77922238", "Pan Rallado 500g", "1100.00", "65", "Unidad", "0.5", "Panaderia");
            dgvProductos.Rows.Add("77922239", "Tostadas 150g", "1300.00", "40", "Unidad", "0.15", "Panaderia");
            dgvProductos.Rows.Add("77922240", "Pan para Hamburguesas", "2200.00", "25", "Unidad", "0.4", "Panaderia");
            dgvProductos.Rows.Add("77922241", "Pan para Panchos", "2000.00", "35", "Unidad", "0.35", "Panaderia");
            dgvProductos.Rows.Add("77922242", "Pionono Dulce", "1600.00", "15", "Unidad", "0.25", "Panaderia");

            // --- CARNICERIA ---
            dgvProductos.Rows.Add("77944455", "Carne Molida", "8000.00", "10", "Kg", "1.0", "Carniceria");
            dgvProductos.Rows.Add("77944456", "Asado de Tira", "9500.00", "12", "Kg", "1.0", "Carniceria");
            dgvProductos.Rows.Add("77944457", "Vacio", "10500.00", "8", "Kg", "1.0", "Carniceria");
            dgvProductos.Rows.Add("77944458", "Pechuga de Pollo", "6500.00", "20", "Kg", "1.0", "Carniceria");
            dgvProductos.Rows.Add("77944459", "Milanesa Preparada", "8500.00", "15", "Kg", "1.0", "Carniceria");
            dgvProductos.Rows.Add("77944460", "Chorizo Puro Cerdo", "7000.00", "18", "Kg", "1.0", "Carniceria");
            dgvProductos.Rows.Add("77944461", "Costeleta de Cerdo", "6800.00", "14", "Kg", "1.0", "Carniceria");
            dgvProductos.Rows.Add("77944462", "Matambre de Vaca", "9800.00", "6", "Kg", "1.0", "Carniceria");
            dgvProductos.Rows.Add("77944463", "Pata Muslo", "4500.00", "25", "Kg", "1.0", "Carniceria");
            dgvProductos.Rows.Add("77944464", "Cuadril", "11000.00", "10", "Kg", "1.0", "Carniceria");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void labelCategoria_Click(object sender, EventArgs e)
        {

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiarfiltros_Click(object sender, EventArgs e)
        {
            // 1. Limpiar los campos de texto correspondientes al stock
            txtStockMin.Clear(); // o txtStockMin.Text = "";
            txtStockMax.Clear(); // o txtStockMax.Text = "";
            txtBuscarProducto.Clear();

            // (Opcional) Si también usas el TextBox de búsqueda general original, límpialo aquí:
            // txtBusquedaGeneral.Clear();

            // 2. Restablecer el ComboBox a la opción por defecto ("Todas")
            if (cmbFiltroCategoria.Items.Count > 0)
            {
                cmbFiltroCategoria.SelectedIndex = 0;
            }

            // 3. Suspender el layout de la grilla para mejorar el rendimiento visual
            dgvProductos.SuspendLayout();

            // 4. Recorrer todas las filas de la grilla y hacerlas visibles nuevamente
            foreach (DataGridViewRow fila in dgvProductos.Rows)
            {
                // Evitar procesar la fila vacía de nuevo registro al final del DataGridView
                if (fila.IsNewRow) continue;

                fila.Visible = true;
            }

            // 5. Restaurar el layout de la grilla
            dgvProductos.ResumeLayout();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnBuscar_TextChanged(object sender, EventArgs e)
        {
            btnBuscar.PerformClick();
        }
    }
}
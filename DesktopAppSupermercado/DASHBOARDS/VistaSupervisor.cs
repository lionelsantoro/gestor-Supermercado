using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado.DASHBOARDS
{
    public partial class VistaSupervisor : Form
    {
        public VistaSupervisor()
        {
            InitializeComponent();
        }

        private void btnReportesC_Click(object sender, EventArgs e)
        {

        }

        private void btnSalirC_Click(object sender, EventArgs e)
        {

        }

        private void btnSalirSUPERVISOR_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBuscar.Clear(); // Borra el texto de búsqueda anterior
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            if (tabControl1.SelectedTab == null) return;

            // Pestaña 0: Ventas
            if (tabControl1.SelectedIndex == 0 && dgvVentas.DataSource is DataTable dtVentas)
            {
                dtVentas.DefaultView.RowFilter = $"Convert(id_venta, 'System.String') LIKE '%{filtro}%'";
            }
            // Pestaña 1: Productos Vendidos
            else if (tabControl1.SelectedIndex == 1 && dgvProductosVendidos.DataSource is DataTable dtProductos)
            {
                dtProductos.DefaultView.RowFilter = $"nombre LIKE '%{filtro}%'";
            }
            // Pestaña 2: Auditoría
            else if (tabControl1.SelectedIndex == 2 && dgvControlInventario.DataSource is DataTable dtInventario)
            {
                // Nota: vi en tu imagen que tu grilla se llama dgvControlInventario, no dgvAuditoria
                dtInventario.DefaultView.RowFilter = $"accion LIKE '%{filtro}%'";
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VistaSupervisor_Load(object sender, EventArgs e)
        {
            // Evitar que se dupliquen las columnas visuales
            dgvVentas.AutoGenerateColumns = false;
            dgvProductosVendidos.AutoGenerateColumns = false;
            dgvControlInventario.AutoGenerateColumns = false;

            // --------------------------------------------------------
            // PESTAÑA 1: Ventas Realizadas
            // --------------------------------------------------------
            DataTable dtVentas = new DataTable();
            dtVentas.Columns.Add("Numero de venta", typeof(int));
            dtVentas.Columns.Add("Total", typeof(decimal));
            dtVentas.Columns.Add("Medio de Pago", typeof(string));
            dtVentas.Columns.Add("Banco", typeof(string));

            dtVentas.Rows.Add(1001, 15400.50m, "Tarjeta de Crédito", "Galicia");
            dtVentas.Rows.Add(1002, 8200.00m, "Efectivo", "-");
            dtVentas.Rows.Add(1003, 43100.75m, "Tarjeta de Débito", "Santander");

            dgvVentas.DataSource = dtVentas;

            // --------------------------------------------------------
            // PESTAÑA 2: Productos Vendidos
            // --------------------------------------------------------
            DataTable dtProductos = new DataTable();
            dtProductos.Columns.Add("Numero de Producto", typeof(int));
            dtProductos.Columns.Add("Descripcion", typeof(string));
            dtProductos.Columns.Add("Precio Unitario", typeof(decimal));
            dtProductos.Columns.Add("Stock", typeof(int));
            dtProductos.Columns.Add("Kilogramo", typeof(float));
            dtProductos.Columns.Add("Unidad de Medida", typeof(string));

            dtProductos.Rows.Add(10, "Harina 000", 850.00m, 45, 0, "Unidad");
            dtProductos.Rows.Add(11, "Harina 0000", 920.00m, 30, 0, "Unidad");
            dtProductos.Rows.Add(12, "Papas", 350.00m, 100, 2000, "Kg");

            dgvProductosVendidos.DataSource = dtProductos;

            // --------------------------------------------------------
            // PESTAÑA 3: Control de Inventario
            // --------------------------------------------------------
            DataTable dtInventario = new DataTable();
            dtInventario.Columns.Add("Id Historial", typeof(int));
            dtInventario.Columns.Add("Nombre del Empleado", typeof(string));
            dtInventario.Columns.Add("Producto Modificado", typeof(string));
            dtInventario.Columns.Add("Accion", typeof(string));
            dtInventario.Columns.Add("Fecha", typeof(DateTime));

            dtInventario.Rows.Add(1, "Lucas Kruzolek", "Harina 000", "Cambio de Precio", DateTime.Now.AddDays(-1));
            dtInventario.Rows.Add(2, "Pablo Fernandez", "Levadura Fresca", "Ajuste de Stock", DateTime.Now.AddHours(-5));
            dtInventario.Rows.Add(3, "Lucas Kruzolek", "Harina 0000", "Eliminación Lote", DateTime.Now.AddMinutes(-30));

            dgvControlInventario.DataSource = dtInventario;
        }
    }
}

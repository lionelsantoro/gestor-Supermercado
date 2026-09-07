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
    }
}

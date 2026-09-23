using DesktopAppSupermercado.ReglasNegocio;
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

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        // Método centralizado para actualizar la grilla
        private void ActualizarGrilla()
        {

            string texto = txtBuscar.Text.Trim();
            string rolSeleccionado = cmbFiltroRol.SelectedItem?.ToString() ?? "Todos";

            // Asignamos el DataTable directamente al DataGridView
            dgvUsuarios.DataSource = usuarioNegocio.ListarUsuarios(texto, rolSeleccionado);
        }

        // Evento: Se dispara cuando cambias de pestaña en el TabControl
        private void tabControlSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos si salimos de la pestaña de "Control de Usuarios"
            // Cambia "tabPageUsuarios" por el nombre real de tu pestaña en (Name)
            if (tabControlSupervisor.SelectedTab?.Name != "tabPageUsuarios")
            {
                // Limpiamos los filtros para que al volver esté todo reseteado
                txtBuscar.Clear();
                cmbFiltroRol.SelectedIndex = 0;
            }
        }

        private void VistaSupervisor_Load(object sender, EventArgs e)
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvVentas.AutoGenerateColumns = false;
            dgvProductosVendidos.AutoGenerateColumns = false;

            // --------------------------------------------------------
            // PESTAÑA 1: Ventas Realizadas
            // --------------------------------------------------------
            DataTable dtVentas = new DataTable();
            dtVentas.Columns.Add("Numero de venta", typeof(int));
            dtVentas.Columns.Add("Total", typeof(decimal));
            dtVentas.Columns.Add("Medio de Pago", typeof(string));
            dtVentas.Columns.Add("Banco", typeof(string));
            dtVentas.Columns.Add("Numero de Caja", typeof(string));
            dtVentas.Columns.Add("Cajero", typeof(string));

            dtVentas.Rows.Add(1001, 15400.50m, "Tarjeta de Crédito", "Galicia", "1", "Juan");
            dtVentas.Rows.Add(1002, 8200.00m, "Efectivo", "-", "2", "María");
            dtVentas.Rows.Add(1003, 43100.75m, "Tarjeta de Débito", "Santander", "3", "Pedro");

            dgvVentas.DataSource = dtVentas;

            // --------------------------------------------------------
            // PESTAÑA 2: Productos Vendidos
            // --------------------------------------------------------
            DataTable dtProductos = new DataTable();
            dtProductos.Columns.Add("Numero de Producto", typeof(int));
            dtProductos.Columns.Add("Descripcion", typeof(string));
            dtProductos.Columns.Add("Precio Unitario", typeof(decimal));
            dtProductos.Columns.Add("Cantidad", typeof(int));
            dtProductos.Columns.Add("Kilogramo", typeof(float));
            dtProductos.Columns.Add("Unidad de Medida", typeof(string));

            dtProductos.Rows.Add(10, "Harina 000", 850.00m, 45, 0, "Unidad");
            dtProductos.Rows.Add(11, "Harina 0000", 920.00m, 30, 0, "Unidad");
            dtProductos.Rows.Add(12, "Papas", 350.00m, 100, 2000, "Kg");

            dgvProductosVendidos.DataSource = dtProductos;

            // --------------------------------------------------------
            // PESTAÑA 3: Control de Usuarioss
            // --------------------------------------------------------
            RolNegocio rolNegocio = new RolNegocio();

            cmbFiltroRol.Items.Clear();
            cmbFiltroRol.Items.Add("Todos");

            // Traemos los roles reales desde SQL y los sumamos al ComboBox
            List<string> rolesDB = rolNegocio.ListarNombresRoles();
            foreach (string rol in rolesDB)
            {
                cmbFiltroRol.Items.Add(rol);
            }

            cmbFiltroRol.SelectedIndex = 0;

            // Cargamos la grilla de usuarios
            ActualizarGrilla();
        }

        private void cmbFiltroRol_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }
    }
}

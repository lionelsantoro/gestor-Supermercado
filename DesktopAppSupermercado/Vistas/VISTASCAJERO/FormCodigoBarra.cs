using DesktopAppSupermercado.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class FormCodigoBarra : Form
    {
        private readonly ProductoNegocio productoNegocio = new ProductoNegocio();
        private readonly GestionCategoriaNegocio categoriaNegocio = new GestionCategoriaNegocio();

        private bool cargandoCategorias = false;
        public string DescripcionSeleccionada { get; private set; }

        public FormCodigoBarra()
        {
            InitializeComponent();

            Load += FormCodigoBarra_Load;
            txtBuscarProducto.TextChanged += txtBuscarProducto_TextChanged;
            cmbCategoria.SelectionChangeCommitted += cmbCategoria_SelectionChangeCommitted;
            dgvProducto.CellDoubleClick += dgvProducto_CellDoubleClick;
            dgvProducto.KeyDown += dgvProducto_KeyDown;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormCodigoBarra_Load(object sender, EventArgs e)
        {
            txtBuscarProducto.MaxLength = 100;

            dgvProducto.AutoGenerateColumns = true;
            dgvProducto.Columns.Clear();
            dgvProducto.ReadOnly = true;
            dgvProducto.AllowUserToAddRows = false;
            dgvProducto.AllowUserToDeleteRows = false;
            dgvProducto.MultiSelect = false;
            dgvProducto.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvProducto.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            CargarCategorias();
            CargarProductos();
        }

        private void txtBuscarProducto_TextChanged(
            object sender,
            EventArgs e)
        {
            CargarProductos();
        }

        private void CargarProductos()
        {
            try
            {
                int? idCategoria = null;

                if (cmbCategoria.SelectedValue != null &&
                    cmbCategoria.SelectedValue != DBNull.Value &&
                    int.TryParse(
                        cmbCategoria.SelectedValue.ToString(),
                        out int id))
                {
                    idCategoria = id;
                }

                DataTable tabla = productoNegocio.BuscarProductosParaSeleccion(
                    txtBuscarProducto.Text,
                    idCategoria);

                dgvProducto.DataSource = tabla;

                if (dgvProducto.Columns.Contains("id_categoria"))
                    dgvProducto.Columns["id_categoria"].Visible = false;

                if (dgvProducto.Columns.Contains("descripcion"))
                    dgvProducto.Columns["descripcion"].HeaderText = "Descripción";

                if (dgvProducto.Columns.Contains("codigo_barra"))
                    dgvProducto.Columns["codigo_barra"].HeaderText = "Código de barras";

                if (dgvProducto.Columns.Contains("precio"))
                {
                    dgvProducto.Columns["precio"].HeaderText = "Precio";
                    dgvProducto.Columns["precio"].DefaultCellStyle.Format = "C2";
                }

                if (dgvProducto.Columns.Contains("stock"))
                {
                    dgvProducto.Columns["stock"].HeaderText = "Stock";
                    dgvProducto.Columns["stock"].DefaultCellStyle.Format = "0.##";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los productos.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void CargarCategorias()
        {
            try
            {
                cargandoCategorias = true;

                DataTable tabla = categoriaNegocio.ListarCategorias();

                DataRow todas = tabla.NewRow();
                todas["id_categoria"] = DBNull.Value;
                todas["nombre"] = "Todas las categorías";

                tabla.Rows.InsertAt(todas, 0);

                cmbCategoria.DataSource = null;
                cmbCategoria.DisplayMember = "nombre";
                cmbCategoria.ValueMember = "id_categoria";
                cmbCategoria.DataSource = tabla;
                cmbCategoria.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las categorías.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargandoCategorias = false;
            }
        }

        private void dgvProducto_CellDoubleClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SeleccionarProducto(e.RowIndex);
        }

        private void dgvProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            e.SuppressKeyPress = true;
            e.Handled = true;

            if (dgvProducto.CurrentRow != null &&
                !dgvProducto.CurrentRow.IsNewRow)
            {
                SeleccionarProducto(dgvProducto.CurrentRow.Index);
            }
        }

        private void SeleccionarProducto(int indiceFila)
        {
            if (indiceFila < 0 ||
                indiceFila >= dgvProducto.Rows.Count)
            {
                return;
            }

            object valor = dgvProducto.Rows[indiceFila]
                .Cells["descripcion"].Value;

            if (valor == null || valor == DBNull.Value)
                return;

            DescripcionSeleccionada = valor.ToString();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void cmbCategoria_SelectionChangeCommitted(
    object sender,
    EventArgs e)
        {
            if (!cargandoCategorias)
                CargarProductos();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

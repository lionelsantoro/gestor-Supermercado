using System;
using System.Data;
using System.Windows.Forms;
using DesktopAppSupermercado.ReglasNegocio;

namespace DesktopAppSupermercado.VISTASINVENTARIO
{
    public partial class VistaGestionInventario : Form
    {
        // Instanciamos nuestras NUEVAS clases de negocio
        private GestionProductoNegocio productoNegocio = new GestionProductoNegocio();
        private GestionCategoriaNegocio categoriaNegocio = new GestionCategoriaNegocio();

        private int _idProductoActual = 0;
        private int _idCategoriaActual = 0;
        private DataTable dtProductosGlobal;

        public VistaGestionInventario()
        {
            InitializeComponent();
        }

        private void VistaGestionInventario_Load(object sender, EventArgs e)
        {
            txtCodigoBarras.MaxLength = 6;

            // 1. Apagamos la creación automática de columnas extra (los IDs)
            dataCategoria.AutoGenerateColumns = false;
            dgvProductos.AutoGenerateColumns = false;

            CargarCombos();
            ActualizarGrillas();
            LimpiarFormularioCategoria();
            LimpiarFormularioProducto();

            // Enlazamos los eventos para que filtren automáticamente mientras el usuario escribe
            txtBuscarProducto.TextChanged += FiltrarProductos;
            txtStockMin.TextChanged += FiltrarProductos;
            txtStockMax.TextChanged += FiltrarProductos;
            cmbFiltroCategoria.SelectedIndexChanged += FiltrarProductos;
        }

        private void CargarCombos()
        {
            DataTable dtCategorias = categoriaNegocio.ListarCategorias();

            // 1. Combo de Crear/Editar Producto
            cmbCategoriaProducto.DisplayMember = "nombre";
            cmbCategoriaProducto.ValueMember = "id_categoria";
            cmbCategoriaProducto.DataSource = dtCategorias;
            cmbCategoriaProducto.SelectedIndex = -1;

            // 2. Combo de Filtros de búsqueda (agregando la opción "Todas" al inicio)
            DataTable dtFiltro = dtCategorias.Copy();
            DataRow filaTodos = dtFiltro.NewRow();
            filaTodos["id_categoria"] = 0;
            filaTodos["nombre"] = "Todas";
            dtFiltro.Rows.InsertAt(filaTodos, 0);

            cmbFiltroCategoria.DisplayMember = "nombre";
            cmbFiltroCategoria.ValueMember = "id_categoria";
            cmbFiltroCategoria.DataSource = dtFiltro;
            cmbFiltroCategoria.SelectedIndex = 0;

            // 3. Combo Unidad Medida
            cmbUnidadMedida.Items.Clear();
            cmbUnidadMedida.Items.Add("Unidad");
            cmbUnidadMedida.Items.Add("Kg");
        }

        private void ActualizarGrillas()
        {
            dataCategoria.DataSource = categoriaNegocio.ListarCategorias();

            // Guardamos la lista en una variable global para aplicar los filtros muy rápido
            dtProductosGlobal = productoNegocio.ListarProductos();
            dgvProductos.DataSource = dtProductosGlobal;
        }

        // ==========================================
        // SECCIÓN CRUD: CATEGORÍAS
        // ==========================================
        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                categoriaNegocio.GuardarCategoria(_idCategoriaActual, txtNombreCategoria.Text);
                MessageBox.Show(_idCategoriaActual == 0 ? "Categoría creada con éxito." : "Categoría modificada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioCategoria();
                ActualizarGrillas();
                CargarCombos(); // Recargamos para que aparezca en el combo de productos
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            if (_idCategoriaActual == 0)
            {
                MessageBox.Show("Seleccione una categoría de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Seguro que desea eliminar esta categoría?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    categoriaNegocio.EliminarCategoria(_idCategoriaActual);
                    MessageBox.Show("Categoría eliminada.");
                    LimpiarFormularioCategoria();
                    ActualizarGrillas();
                    CargarCombos();
                }
                catch (Exception ex) { MessageBox.Show(ex.Message, "Operación Denegada", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
        }

        private void dataCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView? fila = dataCategoria.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (fila != null)
                {
                    _idCategoriaActual = Convert.ToInt32(fila["id_categoria"]);
                    txtNombreCategoria.Text = fila["nombre"]?.ToString() ?? "";
                    btnGuardarCategoria.Text = "Modificar Categoría";
                }
            }
        }

        private void LimpiarFormularioCategoria()
        {
            _idCategoriaActual = 0;
            txtNombreCategoria.Clear();
            btnGuardarCategoria.Text = "+ Nueva Categoría";
        }

        // ==========================================
        // SECCIÓN CRUD: PRODUCTOS
        // ==========================================
        private void btnGuardarProductosInventario_Click(object sender, EventArgs e)
        {
            try
            {
                int idCategoria = cmbCategoriaProducto.SelectedValue != null ? Convert.ToInt32(cmbCategoriaProducto.SelectedValue) : 0;
                string unidad = cmbUnidadMedida.SelectedItem?.ToString() ?? "";

                productoNegocio.GuardarProducto(
                    _idProductoActual, idCategoria, txtDescripcionProducto.Text,
                    txtPrecioProducto.Text, txtStockProducto.Text,
                    unidad, txtCodigoBarras.Text
                );

                MessageBox.Show(_idProductoActual == 0 ? "Producto creado con éxito." : "Producto modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LimpiarFormularioProducto();
                ActualizarGrillas();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnEliminarProductoInventario_Click(object sender, EventArgs e)
        {
            if (_idProductoActual == 0)
            {
                MessageBox.Show("Seleccione un producto de la lista para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Seguro que desea eliminar este producto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                productoNegocio.EliminarProducto(_idProductoActual);
                MessageBox.Show("Producto eliminado.");
                LimpiarFormularioProducto();
                ActualizarGrillas();
            }
        }

        private void btnCancelarProductosInventario_Click(object sender, EventArgs e)
        {
            LimpiarFormularioProducto();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataRowView? fila = dgvProductos.Rows[e.RowIndex].DataBoundItem as DataRowView;
                if (fila != null)
                {
                    _idProductoActual = Convert.ToInt32(fila["id_producto"]);
                    txtCodigoBarras.Text = fila["codigo_barra"]?.ToString() ?? "";
                    txtDescripcionProducto.Text = fila["descripcion"]?.ToString() ?? "";
                    txtPrecioProducto.Text = fila["precio"]?.ToString() ?? "";
                    txtStockProducto.Text = fila["stock"]?.ToString() ?? "";
                    cmbUnidadMedida.Text = fila["unidad_medida"]?.ToString() ?? "";

                    if (fila["id_categoria"] != DBNull.Value)
                        cmbCategoriaProducto.SelectedValue = Convert.ToInt32(fila["id_categoria"]);

                    btnGuardarProductosInventario.Text = "Modificar";
                    gbEdicionProducto.Text = "Editando Producto: " + txtDescripcionProducto.Text;
                }
            }
        }

        private void LimpiarFormularioProducto()
        {
            _idProductoActual = 0;
            txtCodigoBarras.Clear();
            txtDescripcionProducto.Clear();
            txtPrecioProducto.Clear();
            txtStockProducto.Clear();
            cmbCategoriaProducto.SelectedIndex = -1;
            cmbUnidadMedida.SelectedIndex = -1;

            btnGuardarProductosInventario.Text = "Guardar";
            gbEdicionProducto.Text = "Crear o Editar Productos";
        }

        // ==========================================
        // FILTROS EN TIEMPO REAL
        // ==========================================
        private void FiltrarProductos(object sender, EventArgs e)
        {
            if (dtProductosGlobal == null) return;

            string filtro = "";
            string texto = txtBuscarProducto.Text.Trim().Replace("'", "''");

            // 1. Filtrar por texto (código o descripción)
            if (!string.IsNullOrEmpty(texto))
                filtro += $"(codigo_barra LIKE '%{texto}%' OR descripcion LIKE '%{texto}%') ";

            // 2. Filtrar por categoría (si no es "Todas")
            if (cmbFiltroCategoria.SelectedIndex > 0)
            {
                string cat = cmbFiltroCategoria.Text.Replace("'", "''");
                if (filtro.Length > 0) filtro += " AND ";
                filtro += $"categoria_nombre = '{cat}'";
            }

            // 3. Filtrar por Stock Mínimo
            if (decimal.TryParse(txtStockMin.Text, out decimal stockMin))
            {
                if (filtro.Length > 0) filtro += " AND ";
                filtro += $"stock >= {stockMin}";
            }

            // 4. Filtrar por Stock Máximo
            if (decimal.TryParse(txtStockMax.Text, out decimal stockMax))
            {
                if (filtro.Length > 0) filtro += " AND ";
                filtro += $"stock <= {stockMax}";
            }

            // Aplicamos la vista filtrada a la grilla
            dtProductosGlobal.DefaultView.RowFilter = filtro;
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Clear();
            txtStockMin.Clear();
            txtStockMax.Clear();
            if (cmbFiltroCategoria.Items.Count > 0) cmbFiltroCategoria.SelectedIndex = 0;
        }

        // ==========================================
        // VALIDACIONES DE ENTRADA (KEYPRESS)
        // ==========================================
        private void SoloNumeros_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y la tecla de borrar (Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora la tecla presionada si es letra
            }
        }

        private void NumerosDecimales_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite números, borrar y la coma
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Evita que el usuario escriba dos comas en el mismo campo
            TextBox txt = sender as TextBox;
            if (txt != null && e.KeyChar == ',' && txt.Text.Contains(","))
            {
                e.Handled = true;
            }
        }


        private void txtCodigoBarras_Leave(object sender, EventArgs e)
        {
            // Verificamos "al instante" cuando el usuario termina de escribir y pasa a la siguiente caja
            if (txtCodigoBarras.Text.Trim().Length == 6)
            {
                if (productoNegocio.VerificarCodigoExistente(txtCodigoBarras.Text, _idProductoActual))
                {
                    MessageBox.Show("¡Atención! Este código de barras ya está registrado en otro producto.", "Código Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoBarras.Focus(); // Devuelve el cursor a la caja de código para que lo corrija
                    txtCodigoBarras.SelectAll(); // Selecciona el texto para borrarlo fácil
                }
            }
        }
    }
}
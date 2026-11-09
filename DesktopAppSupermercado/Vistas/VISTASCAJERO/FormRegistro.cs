using DesktopAppSupermercado.Entidades;
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
    public partial class FormRegistro : Form
    {
        private readonly ClienteNegocio negocio = new ClienteNegocio();
        private int? idClienteSeleccionado = null;
        private bool cargandoClientes = false;

        public FormRegistro()
        {
            InitializeComponent();

            dgvRegistroCliente.SelectionChanged += dgvRegistroCliente_SelectionChanged;

        }

        private void FormRegistro_Load(object sender, EventArgs e)
        {
            dgvRegistroCliente.AutoGenerateColumns = true;
            dgvRegistroCliente.Columns.Clear();

            dgvRegistroCliente.ReadOnly = true;
            dgvRegistroCliente.AllowUserToAddRows = false;
            dgvRegistroCliente.AllowUserToDeleteRows = false;
            dgvRegistroCliente.MultiSelect = false;
            dgvRegistroCliente.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvRegistroCliente.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            txtNombreCliente.MaxLength = 80;
            txtApellidoCliente.MaxLength = 80;
            txtCorreo.MaxLength = 150;
            txtDni.MaxLength = 8;
            txtDireccion.MaxLength = 250;
            txtTelefono.MaxLength = 20;
            txtBuscarCliente.MaxLength = 160;
            txtFechaNacimiento.MaxLength = 10;

            CargarClientes();
        }

        private void CargarClientes()
        {
            cargandoClientes = true;
            idClienteSeleccionado = null;

            try
            {
                DataTable tabla = negocio.BuscarClientes(txtBuscarCliente.Text);

                dgvRegistroCliente.DataSource = tabla;

                // Evitar que quede una fila seleccionada automáticamente.
                dgvRegistroCliente.CurrentCell = null;
                dgvRegistroCliente.ClearSelection();

                if (dgvRegistroCliente.Columns.Contains("id_cliente"))
                {
                    dgvRegistroCliente.Columns["id_cliente"].Visible = false;
                }

                if (dgvRegistroCliente.Columns.Contains("nombre"))
                    dgvRegistroCliente.Columns["nombre"].HeaderText = "Nombre";

                if (dgvRegistroCliente.Columns.Contains("apellido"))
                    dgvRegistroCliente.Columns["apellido"].HeaderText = "Apellido";

                if (dgvRegistroCliente.Columns.Contains("correo"))
                    dgvRegistroCliente.Columns["correo"].HeaderText = "Correo";

                if (dgvRegistroCliente.Columns.Contains("dni"))
                    dgvRegistroCliente.Columns["dni"].HeaderText = "DNI";

                if (dgvRegistroCliente.Columns.Contains("direccion"))
                    dgvRegistroCliente.Columns["direccion"].HeaderText = "Dirección";

                if (dgvRegistroCliente.Columns.Contains("telefono"))
                    dgvRegistroCliente.Columns["telefono"].HeaderText = "Teléfono";

                if (dgvRegistroCliente.Columns.Contains("sexo"))
                    dgvRegistroCliente.Columns["sexo"].HeaderText = "Sexo";

                if (dgvRegistroCliente.Columns.Contains("fecha_nacimiento"))
                {
                    dgvRegistroCliente.Columns["fecha_nacimiento"].HeaderText =
                        "Fecha de nacimiento";

                    dgvRegistroCliente.Columns["fecha_nacimiento"]
                        .DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los clientes.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            finally
            {
                cargandoClientes = false;
            }
        }

        private void dgvRegistroCliente_SelectionChanged(
    object sender,
    EventArgs e)
        {
            // Ignorar los cambios de selección provocados por la carga de datos.
            if (cargandoClientes)
                return;

            // Verificar que realmente haya una fila seleccionada.
            if (dgvRegistroCliente.SelectedRows.Count == 0)
                return;

            DataGridViewRow fila = dgvRegistroCliente.SelectedRows[0];

            // Obtener el ID del cliente seleccionado.
            if (!int.TryParse(
                Convert.ToString(fila.Cells["id_cliente"].Value),
                out int idCliente))
            {
                return;
            }

            idClienteSeleccionado = idCliente;

            // Completar los campos de texto.
            txtNombreCliente.Text =
                ObtenerTextoCelda(fila, "nombre");

            txtApellidoCliente.Text =
                ObtenerTextoCelda(fila, "apellido");

            txtCorreo.Text =
                ObtenerTextoCelda(fila, "correo");

            txtDni.Text =
                ObtenerTextoCelda(fila, "dni");

            txtDireccion.Text =
                ObtenerTextoCelda(fila, "direccion");

            txtTelefono.Text =
                ObtenerTextoCelda(fila, "telefono");

            // Completar la fecha de nacimiento.
            object valorFecha = fila.Cells["fecha_nacimiento"].Value;

            if (valorFecha != null && valorFecha != DBNull.Value)
            {
                DateTime fecha = Convert.ToDateTime(valorFecha);

                txtFechaNacimiento.Text =
                    fecha.ToString("dd/MM/yyyy");
            }
            else
            {
                txtFechaNacimiento.Clear();
            }

            // Seleccionar el sexo correspondiente.
            string sexo = ObtenerTextoCelda(fila, "sexo");

            rbHombre.Checked =
                sexo.Equals("Hombre", StringComparison.OrdinalIgnoreCase);

            rbMujer.Checked =
                sexo.Equals("Mujer", StringComparison.OrdinalIgnoreCase);
        }

        private string ObtenerTextoCelda(
    DataGridViewRow fila,
    string nombreColumna)
        {
            object valor = fila.Cells[nombreColumna].Value;

            if (valor == null || valor == DBNull.Value)
                return "";

            return Convert.ToString(valor);
        }

        private void btnRegistrarNuevoCliente_Click(
    object sender,
    EventArgs e)
        {
            string sexo = rbHombre.Checked
                ? "Hombre"
                : rbMujer.Checked
                    ? "Mujer"
                    : "";

            try
            {
                bool fueActualizacion;

                Cliente cliente = negocio.GuardarCliente(
                    txtNombreCliente.Text,
                    txtApellidoCliente.Text,
                    txtCorreo.Text,
                    txtDni.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    sexo,
                    txtFechaNacimiento.Text,
                    idClienteSeleccionado,
                    out fueActualizacion);

                string mensaje = fueActualizacion
                    ? "Cliente actualizado correctamente."
                    : "Cliente registrado correctamente.";

                string titulo = fueActualizacion
                    ? "Actualización exitosa"
                    : "Registro exitoso";

                MessageBox.Show(
                    mensaje + "\n\n" +
                    $"Nombre: {cliente.Nombre} {cliente.Apellido}\n" +
                    $"DNI: {cliente.Dni}\n" +
                    $"ID de cliente: {cliente.IdCliente}",
                    titulo,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LimpiarCampos();

                CargarClientes();

                txtNombreCliente.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo guardar el cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtNombreCliente.Focus();
        }

        private void LimpiarCampos(bool limpiarBusqueda = true)
        {
            // Descartar el cliente seleccionado.
            idClienteSeleccionado = null;

            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtCorreo.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtFechaNacimiento.Clear();

            if (limpiarBusqueda)
                txtBuscarCliente.Clear();

            rbHombre.Checked = false;
            rbMujer.Checked = false;

            dgvRegistroCliente.ClearSelection();
        }

        private void txtBuscarCliente_TextChanged(
            object sender,
            EventArgs e)
        {
            CargarClientes();
        }

        private bool ValidarNombreApellido(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return false;

            foreach (char caracter in texto)
            {
                if (!char.IsLetter(caracter) &&
                    caracter != ' ' &&
                    caracter != '\'' &&
                    caracter != '-')
                {
                    return false;
                }
            }

            return true;
        }

        private void txtNombreCliente_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            // Permitir escribir, borrar y desplazarse.
            e.Handled = false;
        }

        private void txtApellidoCliente_KeyPress(
            object sender,
            KeyPressEventArgs e)
        {
            // Permitir escribir, borrar y desplazarse.
            e.Handled = false;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            // Comprobar que exista un cliente seleccionado.
            if (!idClienteSeleccionado.HasValue ||
                dgvRegistroCliente.SelectedRows.Count == 0)
            {
                MessageBox.Show(
                    "Seleccione un cliente de la grilla para eliminarlo.",
                    "Cliente no seleccionado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                // Obtener los datos para mostrar la confirmación.
                string nombreCliente =
                    txtNombreCliente.Text + " " + txtApellidoCliente.Text;

                string dniCliente = txtDni.Text;

                DialogResult respuesta = MessageBox.Show(
                    "¿Está seguro de que desea eliminar al siguiente cliente?\n\n" +
                    $"Nombre: {nombreCliente}\n" +
                    $"DNI: {dniCliente}\n\n" +
                    "El cliente dejará de aparecer en los registros activos, " +
                    "pero sus datos se conservarán en la base de datos.",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                // Si el usuario cancela, no realizar ninguna operación.
                if (respuesta != DialogResult.Yes)
                    return;

                // Ejecutar la eliminación lógica.
                negocio.EliminarCliente(idClienteSeleccionado.Value);

                // Limpiar los campos sin borrar el filtro de búsqueda.
                LimpiarCampos(false);

                // Actualizar la grilla.
                CargarClientes();

                MessageBox.Show(
                    "El cliente fue eliminado correctamente.",
                    "Eliminación exitosa",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtNombreCliente.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "No se pudo eliminar el cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void rbMujer_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}

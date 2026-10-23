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

        public FormRegistro()
        {
            InitializeComponent();
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
            try
            {
                DataTable tabla = negocio.BuscarClientes(txtBuscarCliente.Text);

                dgvRegistroCliente.DataSource = tabla;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los clientes.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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
                Cliente cliente = negocio.RegistrarCliente(
                    txtNombreCliente.Text,
                    txtApellidoCliente.Text,
                    txtCorreo.Text,
                    txtDni.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    sexo,
                    txtFechaNacimiento.Text);

                MessageBox.Show(
                    "Cliente registrado correctamente.\n\n" +
                    $"Nombre: {cliente.Nombre} {cliente.Apellido}\n" +
                    $"DNI: {cliente.Dni}\n" +
                    $"ID de cliente: {cliente.IdCliente}",
                    "Registro exitoso",
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
                    "No se pudo registrar el cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }


        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            txtNombreCliente.Focus();
        }

        private void LimpiarCampos()
        {
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtCorreo.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtFechaNacimiento.Clear();
            txtBuscarCliente.Clear();

            rbHombre.Checked = false;
            rbMujer.Checked = false;
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

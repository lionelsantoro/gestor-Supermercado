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

        private void FormRegistro_Load(
            object sender,
            EventArgs e)
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

            CargarClientes();
        }

        private void CargarClientes()
        {
            try
            {
                DataTable tabla =
                    negocio.BuscarClientes(txtBuscarCliente.Text);

                dgvRegistroCliente.DataSource = tabla;

                if (dgvRegistroCliente.Columns["id_cliente"] != null)
                {
                    dgvRegistroCliente.Columns["id_cliente"].HeaderText = "ID";
                }

                if (dgvRegistroCliente.Columns["nombre"] != null)
                {
                    dgvRegistroCliente.Columns["nombre"].HeaderText = "Nombre";
                }

                if (dgvRegistroCliente.Columns["apellido"] != null)
                {
                    dgvRegistroCliente.Columns["apellido"].HeaderText = "Apellido";
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
        }

        private void btnRegistrarNuevoCliente_Click(
            object sender,
            EventArgs e)
        {
            string nombre = txtNombreCliente.Text.Trim();
            string apellido = txtApellidoCliente.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show(
                    "Ingrese el nombre del cliente.",
                    "Dato obligatorio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombreCliente.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(apellido))
            {
                MessageBox.Show(
                    "Ingrese el apellido del cliente.",
                    "Dato obligatorio",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellidoCliente.Focus();
                return;
            }

            if (!ValidarNombreApellido(nombre))
            {
                MessageBox.Show(
                    "El nombre solo puede contener letras, espacios, apóstrofes y guiones.",
                    "Nombre inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtNombreCliente.Focus();
                return;
            }

            if (!ValidarNombreApellido(apellido))
            {
                MessageBox.Show(
                    "El apellido solo puede contener letras, espacios, apóstrofes y guiones.",
                    "Apellido inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtApellidoCliente.Focus();
                return;
            }

            try
            {
                Cliente cliente = negocio.RegistrarCliente(
                    nombre,
                    apellido);

                MessageBox.Show(
                    $"Cliente registrado correctamente.\n\n" +
                    $"Nombre: {cliente.NombreCompleto}\n" +
                    $"Código: {cliente.CodigoCliente}",
                    "Registro exitoso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtNombreCliente.Clear();
                txtApellidoCliente.Clear();

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


        private void btnLimpiar_Click(
           object sender,
           EventArgs e)
        {
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtNombreCliente.Focus();
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
    }
}

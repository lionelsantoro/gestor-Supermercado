using DesktopAppSupermercado.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class FormPagar : Form
    {
        public int IdMedioPagoSeleccionado { get; private set; }
        public FormPagar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbMedioPago.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtBanco.Text))
            {
                MessageBox.Show("Por favor, seleccione un Medio de Pago y complete el Banco.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(txtBanco.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El campo Banco solo puede contener letras.", "Formato inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IdMedioPagoSeleccionado = Convert.ToInt32(cmbMedioPago.SelectedValue);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormPagar_Load(object sender, EventArgs e)
        {
            MedioPagoNegocio negocio = new MedioPagoNegocio();
            cmbMedioPago.DataSource = negocio.ObtenerListaMediosPago();
            cmbMedioPago.DisplayMember = "Nombre";
            cmbMedioPago.ValueMember = "IdMedioPago";
            cmbMedioPago.SelectedIndex = -1;
        }
    }
}

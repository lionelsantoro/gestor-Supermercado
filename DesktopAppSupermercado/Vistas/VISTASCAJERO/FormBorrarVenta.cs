using DesktopAppSupermercado.ReglasNegocio.Cajero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class FormBorrarVenta : Form
    {
        private readonly AutorizacionNegocio negocio = new AutorizacionNegocio();

        public FormBorrarVenta()
        {
            InitializeComponent();

            txtCodigo.MaxLength = 4;
            txtCodigo.PasswordChar = '●';

            this.AcceptButton = btnConfirmar;
        }
        // Permite ingresar únicamente dígitos numéricos en el campo del código de autorización.
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir únicamente números y teclas de control.
            if (!char.IsControl(e.KeyChar) &&
                (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

        // Valida el código del supervisor y devuelve OK a VistaCajero cuando la autorización es correcta.
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                negocio.ValidarCodigoSupervisor(txtCodigo.Text);

                // La autorización fue correcta.
                // Informar a VistaCajero que puede descartar la venta.
                this.DialogResult = DialogResult.OK;

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Autorización denegada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCodigo.Clear();
                txtCodigo.Focus();
            }
        }

        // Cierra el formulario sin autorizar la cancelación de la venta.
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Metodo vacio
        private void FormBorrarVenta_Load(object sender, EventArgs e)
        {

        }
    }
}

using DesktopAppSupermercado.ReglasNegocio.Cajero;
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

        // Cierra el formulario de pago sin confirmar la operación.
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Manejador del segundo botón; actualmente no realiza ninguna acción.
        private void button2_Click(object sender, EventArgs e)
        {

        }

        // Comprueba que se haya seleccionado un medio de pago y devuelve su identificador a VistaCajero.
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (cmbMedioPago.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un Medio de Pago y complete el Banco.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IdMedioPagoSeleccionado = Convert.ToInt32(cmbMedioPago.SelectedValue);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // Carga los medios de pago disponibles y configura los campos de visualización y valor del ComboBox.
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

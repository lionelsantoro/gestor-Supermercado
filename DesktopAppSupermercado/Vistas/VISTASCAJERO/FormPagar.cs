using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class FormPagar : Form
    {
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
            // 1. Validar que los campos no estén vacíos
            if (string.IsNullOrWhiteSpace(cmbMedioPago.Text) || string.IsNullOrWhiteSpace(txtBanco.Text))
            {
                MessageBox.Show("Por favor, complete el Medio de Pago y el Banco para continuar.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Corta la ejecución aquí, no deja avanzar
            }

            // 2. Si todo está lleno, le decimos a la ventana padre que la operación fue un éxito (OK)
            this.DialogResult = DialogResult.OK;

            // 3. Cerramos la ventana emergente
            this.Close();
        }
    }
}

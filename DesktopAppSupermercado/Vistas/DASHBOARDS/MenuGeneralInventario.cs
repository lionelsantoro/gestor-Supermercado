using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DesktopAppSupermercado.VISTASINVENTARIO;

namespace DesktopAppSupermercado.DASHBOARDS
{
    public partial class MenuGeneralInventario : Form
    {
        private Form formularioActivo = null;

        public MenuGeneralInventario()
        {
            InitializeComponent();
        }

        private void AbrirFormularioHijo(Form formularioHijo)
        {
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;

            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            PanelContenedor.Controls.Add(formularioHijo);
            PanelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnGestionProductosyCategoriasINVENTARIO_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VistaGestionInventario());
        }
    }
}
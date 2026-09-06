using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
// 1. Importamos la carpeta donde está tu nueva vista
using DesktopAppSupermercado.VISTASINVENTARIO;

namespace DesktopAppSupermercado.DASHBOARDS
{
    public partial class MenuGeneralInventario : Form
    {
        // 2. Variable para llevar el control del formulario que está abierto
        private Form formularioActivo = null;

        public MenuGeneralInventario()
        {
            InitializeComponent();
        }

        // 3. Método que incrusta cualquier formulario dentro del PanelContenedor
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Si hay otro formulario abierto, lo cerramos primero
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;

            // Configuraciones clave para incrustarlo (quitar bordes y rellenar)
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;

            // Agregarlo al panel naranja
            PanelContenedor.Controls.Add(formularioHijo);
            PanelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        // 4. Tu botón ahora llama al método para abrir la vista
        private void btnGestionProductosyCategoriasINVENTARIO_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VistaGestionInventario());
        }
    }
}
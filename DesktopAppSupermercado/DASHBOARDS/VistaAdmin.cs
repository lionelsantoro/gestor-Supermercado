using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class VistaAdmin : Form
    {
        // 1. Variable para recordar qué formulario está abierto
        private Form formularioActivo = null;

        public VistaAdmin()
        {
            InitializeComponent();
        }

        // 2. Función maestra que incrusta las vistas dentro del panel central
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            // Si ya hay un formulario abierto, lo cerramos
            if (formularioActivo != null)
            {
                formularioActivo.Close();
            }

            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false; // Quita el comportamiento de ventana independiente
            formularioHijo.FormBorderStyle = FormBorderStyle.None; // Elimina los bordes
            formularioHijo.Dock = DockStyle.Fill; // Expande para llenar el contenedor

            PanelContenedor.Controls.Add(formularioHijo); // Lo inyecta en tu panel naranja
            PanelContenedor.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VISTASADMIN.VistaUsuariosAdmin());
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VISTASADMIN.VistaBackupAdmin());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new VISTASADMIN.VistaReportesAdmin());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cierra toda la aplicación
        }
    }
}
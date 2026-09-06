using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            VistaSupervisorDeCaja vistaSup = new VistaSupervisorDeCaja();
            vistaSup.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            VistaInventario vistaInv = new VistaInventario();
            vistaInv.Show();
        }

        private void btnCajero_Click(object sender, EventArgs e)
        {
            VistaCajero vistaCaj = new VistaCajero();
            vistaCaj.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            VistaAdmin vistaAdmin = new VistaAdmin();
            vistaAdmin.Show();
        }
    }
}

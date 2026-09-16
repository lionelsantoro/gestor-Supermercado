using DesktopAppSupermercado.DASHBOARDS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class VistaCajero : Form
    {
        public VistaCajero()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

        }

        private void VistaCajero_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Arroz Blanco 1kg", "2", "$ 2.400,00");
            dataGridView1.Rows.Add("Leche Entera 1L", "3", "$ 3.300,00");
            dataGridView1.Rows.Add("Queso Cremoso (Kg)", "1,5", "$ 12.750,00");
            dataGridView1.Rows.Add("Gaseosa Cola 2L", "1", "$ 3.200,00");
            dataGridView1.Rows.Add("Pan Lactal", "1", "$ 1.200,00");
        }

        private void btnModificarCompra_Click(object sender, EventArgs e)
        {
            FormEditarVenta vistaSup = new FormEditarVenta();
            vistaSup.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnIconoCajero_Click(object sender, EventArgs e)
        {

        }

        private void btnPagar_Click_1(object sender, EventArgs e)
        {
            FormPagar vistaSup = new FormPagar();
            vistaSup.Show();
        }

        private void btnBorrarCompra_Click(object sender, EventArgs e)
        {
            FormBorrarVenta vistaSup = new FormBorrarVenta();
            vistaSup.Show();
        }

        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            FormCodigoBarra vistaSup = new FormCodigoBarra();
            vistaSup.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

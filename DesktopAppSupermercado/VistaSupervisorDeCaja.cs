using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class VistaSupervisorDeCaja : Form
    {
        public VistaSupervisorDeCaja()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormDevoluciones formDev = new FormDevoluciones();
            formDev.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VistaSupervisorDeCaja_Load(object sender, EventArgs e)
        {
            // --- Llenar tabla de Anulaciones (dataGridView1 - arriba) ---
            // Columnas: Id_compra, Id_usuario, Motivo, Fecha, Estado
            dataGridView1.Rows.Add("0123", "CPREZ", "Error de cajero", "31/08/2026 10:15", "cancelada");
            dataGridView1.Rows.Add("0124", "MGOMEZ", "Cliente se arrepintió", "31/08/2026 12:30", "realizada");
            dataGridView1.Rows.Add("0125", "CPREZ", "Error de cajero", "31/08/2026 14:05", "en proceso");
            dataGridView1.Rows.Add("0126", "MGOMEZ", "Cambio de producto", "31/08/2026 15:00", "cancelada");
            dataGridView1.Rows.Add("0127", "JSANCHEZ", "Monto incorrecto", "31/08/2026 15:45", "realizada");

            // --- Llenar tabla de Devoluciones (dataGridView2 - abajo) ---
            // Columnas: Id_anulacion, Id_usuario, Motivo, Fecha, Monto, Estado
            // Hacemos que los IDs de anulación correspondan con anulaciones existentes
            // y que las fechas sean posteriores a la anulación.
            dataGridView2.Rows.Add("0123", "SUP01", "Devolución aprobada", "31/08/2026 10:20", "$ 15.000", "exitosa");
            dataGridView2.Rows.Add("0126", "SUP01", "Devolución aprobada", "31/08/2026 15:10", "$ 4.500", "exitosa");

            // Devoluciones con problemas o estados de prueba
            dataGridView2.Rows.Add("0099", "SUP01", "ID de compra no existe", "31/08/2026 16:30", "$ 0", "rechazada");
            dataGridView2.Rows.Add("0127", "SUP01", "Monto no coincide", "31/08/2026 17:00", "$ 0", "rechazada");
            dataGridView2.Rows.Add("0124", "SUP01", "En proceso de verificación", "31/08/2026 17:15", "$ 22.300", "exitosa");
        }
    }
}

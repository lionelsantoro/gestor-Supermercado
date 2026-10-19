using DesktopAppSupermercado.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado.DASHBOARDS
{
    public partial class VistaSupervisor : Form
    {
        public VistaSupervisor()
        {
            InitializeComponent();
        }

        private void btnReportesC_Click(object sender, EventArgs e)
        {

        }

        private void btnSalirC_Click(object sender, EventArgs e)
        {

        }

        private void btnSalirSUPERVISOR_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        // Método centralizado para actualizar la grilla
        private void ActualizarGrilla()
        {

            string texto = txtBuscar.Text.Trim();
            string rolSeleccionado = cmbFiltroRol.SelectedItem?.ToString() ?? "Todos";

            // Asignamos el DataTable directamente al DataGridView
            dgvUsuarios.DataSource = usuarioNegocio.ListarUsuarios(texto, rolSeleccionado);
        }

        // Evento: Se dispara cuando cambias de pestaña en el TabControl
        private void tabControlSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificamos si salimos de la pestaña de "Control de Usuarios"
            // Cambia "tabPageUsuarios" por el nombre real de tu pestaña en (Name)
            if (tabControlSupervisor.SelectedTab?.Name != "tabPageUsuarios")
            {
                // Limpiamos los filtros para que al volver esté todo reseteado
                txtBuscar.Clear();
                cmbFiltroRol.SelectedIndex = 0;
            }
        }

        private void VistaSupervisor_Load(object sender, EventArgs e)
        {
            dgvUsuarios.AutoGenerateColumns = false;
            dgvVentas.AutoGenerateColumns = false;
            dgvProductosVendidos.AutoGenerateColumns = false;

            dtpFechaDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaHasta.Value = DateTime.Now;

            // --------------------------------------------------------
            // PESTAÑA 3: Control de Usuarioss
            // --------------------------------------------------------
            RolNegocio rolNegocio = new RolNegocio();

            cmbFiltroRol.Items.Clear();
            cmbFiltroRol.Items.Add("Todos");

            // Traemos los roles reales desde SQL y los sumamos al ComboBox
            List<string> rolesDB = rolNegocio.ListarNombresRoles();
            foreach (string rol in rolesDB)
            {
                cmbFiltroRol.Items.Add(rol);
            }

            cmbFiltroRol.SelectedIndex = 0;

            // Cargamos la grilla de usuarios
            ActualizarGrilla();
        }

        private void cmbFiltroRol_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ActualizarGrilla();
        }

        private ReporteNegocio reporteNegocio = new ReporteNegocio();

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaDesde = dtpFechaDesde.Value;
                DateTime fechaHasta = dtpFechaHasta.Value;

                // Opcional: Si también quieres refrescar tu grilla dgvVentas en pantalla:
                // dgvVentas.DataSource = reporteNegocio.ObtenerVentasValidadas(fechaDesde, fechaHasta);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    sfd.Title = "Guardar Reporte de Ventas";
                    sfd.FileName = $"Reporte_Ventas_{fechaDesde:yyyyMMdd}_al_{fechaHasta:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Llamamos a la capa de negocio para validar y generar el PDF
                        reporteNegocio.GenerarPdfReporteVentas(fechaDesde, fechaHasta, sfd.FileName);

                        MessageBox.Show(
                            "El reporte de ventas se generó correctamente.",
                            "Reporte Generado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Abrimos el PDF recién creado con el visor predeterminado de Windows
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (ArgumentException ex)
            {
                // Errores de validación de fechas (ej. Fecha Desde > Fecha Hasta)
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                // Cuando no hay ventas registradas en ese rango
                MessageBox.Show(ex.Message, "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Cualquier otro error inesperado (BD o permisos de archivo)
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

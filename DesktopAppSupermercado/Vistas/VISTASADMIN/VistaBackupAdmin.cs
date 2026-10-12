using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using DesktopAppSupermercado.ReglasNegocio;

namespace DesktopAppSupermercado.VISTASADMIN
{
    public partial class VistaBackupAdmin : Form
    {
        // =============================================================
        // CAMPOS
        // =============================================================
        private BackupNegocio negocio = new BackupNegocio();

        public VistaBackupAdmin()
        {
            InitializeComponent();
        }

        // =============================================================
        // EVENTOS VACÍOS QUE EL DISEÑADOR ESPERA (no hacen nada)
        // =============================================================

        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void dgvBackups_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        // =============================================================
        // CARGA INICIAL
        // =============================================================

        private void VistaBackupAdmin_Load(object sender, EventArgs e)
        {
            // Solo las 6 columnas del diseñador; no generar las ocultas
            dgvBackups.AutoGenerateColumns = false;

            // --- Encabezados legibles sobre el fondo naranja ---
            dgvBackups.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvBackups.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvBackups.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgvBackups.Font, FontStyle.Bold);

            // --- El label de estado no debe tener fondo rojo fijo ---
            lblEstado.BackColor = Color.Transparent;

            // --- Filtro apagado por defecto ---
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
            dtpDesde.Enabled = false;
            dtpHasta.Enabled = false;
            btnRestore.Enabled = false;

            // --- Nombre de la base desde la conexión ---
            try
            {
                txtBaseDatos.Text = negocio.ObtenerNombreBaseDatos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error de conexión",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CargarHistorial();
        }

        // =============================================================
        // CARGAR EL DATAGRID
        // =============================================================

        private void CargarHistorial()
        {
            lblEstado.ForeColor = Color.Black;

            try
            {
                Cursor = Cursors.WaitCursor;

                DateTime? desde = null;
                DateTime? hasta = null;

                if (chkFiltrarFechas.Checked)
                {
                    desde = dtpDesde.Value;
                    hasta = dtpHasta.Value;
                }

                DataTable tabla = negocio.ListarHistorial(txtBaseDatos.Text, desde, hasta);
                dgvBackups.DataSource = tabla;

                if (tabla.Rows.Count == 0)
                    lblEstado.Text = "No hay backups en ese rango de fechas.";
                else
                    lblEstado.Text = tabla.Rows.Count + " backup(s) encontrados.";
            }
            catch (ApplicationException ex)
            {
                dgvBackups.DataSource = null;
                lblEstado.ForeColor = Color.DarkRed;
                lblEstado.Text = ex.Message;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo leer el historial:\n" + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                ActualizarBotonRestore();
            }
        }

        // =============================================================
        // SELECCIÓN Y ESTADO DEL BOTÓN RESTAURAR
        // =============================================================

        private DataRowView FilaSeleccionada()
        {
            if (dgvBackups.CurrentRow == null) return null;
            return dgvBackups.CurrentRow.DataBoundItem as DataRowView;
        }

        private void ActualizarBotonRestore()
        {
            DataRowView fila = FilaSeleccionada();
            btnRestore.Enabled = fila != null &&
                                 negocio.EstaDisponible(fila["disponible"].ToString());
        }

        private void dgvBackups_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarBotonRestore();
        }

        // Pinta en gris los backups que no se pueden restaurar
        private void dgvBackups_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataRowView fila = dgvBackups.Rows[e.RowIndex].DataBoundItem as DataRowView;
            if (fila != null && !negocio.EstaDisponible(fila["disponible"].ToString()))
            {
                e.CellStyle.ForeColor = Color.Gray;
                e.CellStyle.SelectionForeColor = Color.Gainsboro;
            }
        }

        private void BloquearBotones(bool bloquear)
        {
            btnBackup.Enabled = !bloquear;
            btnActualizar.Enabled = !bloquear;
            btnRestore.Enabled = !bloquear;
        }

        // =============================================================
        // FILTRO DE FECHAS
        // =============================================================

        private void chkFiltrarFechas_CheckedChanged(object sender, EventArgs e)
        {
            dtpDesde.Enabled = chkFiltrarFechas.Checked;
            dtpHasta.Enabled = chkFiltrarFechas.Checked;
            CargarHistorial();
        }

        private void dtpDesde_ValueChanged(object sender, EventArgs e)
        {
            if (chkFiltrarFechas.Checked) CargarHistorial();
        }

        private void dtpHasta_ValueChanged(object sender, EventArgs e)
        {
            if (chkFiltrarFechas.Checked) CargarHistorial();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            CargarHistorial();
        }

        // =============================================================
        // BOTÓN BACK UP (abre el explorador de archivos)
        // =============================================================

        private void btnBackup_Click(object sender, EventArgs e)
        {
            sfdBackup.InitialDirectory = negocio.ObtenerCarpetaInicial();
            sfdBackup.FileName = negocio.SugerirNombreArchivo(txtBaseDatos.Text);

            if (sfdBackup.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                BloquearBotones(true);
                lblEstado.Text = "Creando backup, esperá...";
                lblEstado.Refresh();

                negocio.CrearBackup(txtBaseDatos.Text, sfdBackup.FileName);

                MessageBox.Show("Backup creado correctamente en:\n" + sfdBackup.FileName,
                    "Listo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "No se pudo crear el backup",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                BloquearBotones(false);
                CargarHistorial();
            }
        }

        // =============================================================
        // BOTÓN RESTAURAR
        // =============================================================

        private void btnRestore_Click(object sender, EventArgs e)
        {
            DataRowView fila = FilaSeleccionada();
            if (fila == null)
            {
                MessageBox.Show("Seleccioná un backup de la lista.", "Atención");
                return;
            }

            DateTime fecha = Convert.ToDateTime(fila["fecha"]);
            string ruta = fila["ruta"].ToString();
            int posicion = Convert.ToInt32(fila["posicion"]);
            string estado = fila["disponible"].ToString();

            // --- Confirmación ---
            string aviso =
                "Vas a restaurar '" + txtBaseDatos.Text + "' al estado del " +
                fecha.ToString("dd/MM/yyyy HH:mm") + ".\n\n" +
                "Se perderán TODAS las ventas y cambios hechos después de esa fecha, " +
                "y se cerrarán las sesiones abiertas (incluidas las cajas).\n\n" +
                "Esta acción no se puede deshacer. ¿Continuar?";

            if (MessageBox.Show(aviso, "Confirmar restauración", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            try
            {
                Cursor = Cursors.WaitCursor;
                BloquearBotones(true);
                lblEstado.Text = "Restaurando, no cierres la aplicación...";
                lblEstado.Refresh();

                negocio.Restaurar(txtBaseDatos.Text, ruta, posicion, estado);

                MessageBox.Show("Base restaurada al " + fecha.ToString("dd/MM/yyyy HH:mm") +
                    ".\n\nCerrá sesión y volvé a ingresar para trabajar con los datos restaurados.",
                    "Restauración completa", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "No se puede restaurar",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("La restauración falló:\n" + ex.Message +
                    "\n\nRevisá el estado de la base en SSMS antes de seguir.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
                BloquearBotones(false);
                CargarHistorial();
            }
        }
    }
}
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
        private UsuarioAdminNegocio usuarioNegocio = new UsuarioAdminNegocio();

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
        // DIÁLOGO DE AUTORIZACIÓN DEL SUPERVISOR
        // Se arma por código, sin formulario en el diseñador.
        // Usa AutoSize para que no se corte con el escalado al 200%.
        // =============================================================

        /// <summary>
        /// Pide el código de 4 dígitos y lo valida contra la base.
        /// Devuelve true solo si un supervisor activo autorizó.
        /// </summary>
        private bool PedirAutorizacionSupervisor()
        {
            // Si no hay nadie que pueda autorizar, conviene decirlo claro
            // en vez de dejar al administrador probando códigos.
            try
            {
                if (!usuarioNegocio.HaySupervisoresConCodigo())
                {
                    MessageBox.Show(
                        "No hay supervisores activos con código de autorización cargado.\n\n" +
                        "Cargá un supervisor desde la pantalla de Usuarios antes de restaurar.",
                        "Sin supervisores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo verificar los supervisores:\n" + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // --- Armado del diálogo (se dimensiona solo según el contenido) ---
            using (Form dialogo = new Form())
            {
                dialogo.Text = "Autorización de supervisor";
                dialogo.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialogo.StartPosition = FormStartPosition.CenterParent;
                dialogo.MaximizeBox = false;
                dialogo.MinimizeBox = false;
                dialogo.BackColor = Color.FromArgb(255, 192, 128);
                dialogo.AutoScaleMode = AutoScaleMode.Font;
                dialogo.AutoSize = true;
                dialogo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                dialogo.Padding = new Padding(25);

                // Contenedor vertical: calcula solo el alto que necesita
                TableLayoutPanel panel = new TableLayoutPanel();
                panel.AutoSize = true;
                panel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                panel.ColumnCount = 1;
                panel.RowCount = 4;
                panel.Dock = DockStyle.Fill;
                panel.BackColor = Color.Transparent;

                Label lblTexto = new Label();
                lblTexto.Text = "Ingresá el código de autorización de un supervisor:";
                lblTexto.AutoSize = true;
                lblTexto.Margin = new Padding(0, 0, 0, 15);

                TextBox txtCodigo = new TextBox();
                txtCodigo.MaxLength = 4;
                txtCodigo.Font = new Font(dialogo.Font.FontFamily, 18F, FontStyle.Bold);
                txtCodigo.TextAlign = HorizontalAlignment.Center;
                txtCodigo.Width = 180;
                txtCodigo.Margin = new Padding(0, 0, 0, 10);

                // Solo dígitos
                txtCodigo.KeyPress += (s, ev) =>
                {
                    if (!char.IsControl(ev.KeyChar) && !char.IsDigit(ev.KeyChar))
                        ev.Handled = true;
                };

                Label lblError = new Label();
                lblError.AutoSize = true;
                lblError.ForeColor = Color.DarkRed;
                lblError.Text = " ";   // reserva la línea para que no salte el layout
                lblError.Margin = new Padding(0, 0, 0, 15);

                // Fila horizontal de botones
                FlowLayoutPanel panelBotones = new FlowLayoutPanel();
                panelBotones.AutoSize = true;
                panelBotones.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                panelBotones.FlowDirection = FlowDirection.LeftToRight;
                panelBotones.BackColor = Color.Transparent;
                panelBotones.Margin = new Padding(0);

                Button btnAceptar = new Button();
                btnAceptar.Text = "Autorizar";
                btnAceptar.AutoSize = true;
                btnAceptar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                btnAceptar.Padding = new Padding(15, 8, 15, 8);
                btnAceptar.Margin = new Padding(0, 0, 15, 0);

                Button btnCancelar = new Button();
                btnCancelar.Text = "Cancelar";
                btnCancelar.AutoSize = true;
                btnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                btnCancelar.Padding = new Padding(15, 8, 15, 8);
                btnCancelar.DialogResult = DialogResult.Cancel;

                // --- Validación al aceptar ---
                btnAceptar.Click += (s, ev) =>
                {
                    lblError.Text = " ";

                    if (!int.TryParse(txtCodigo.Text.Trim(), out int codigo))
                    {
                        lblError.Text = "Ingresá un código numérico.";
                        txtCodigo.SelectAll();
                        txtCodigo.Focus();
                        return;
                    }

                    try
                    {
                        if (usuarioNegocio.ValidarCodigoSupervisor(codigo))
                        {
                            dialogo.DialogResult = DialogResult.OK;
                            dialogo.Close();
                        }
                        else
                        {
                            lblError.Text = "Código incorrecto o el supervisor no está activo.";
                            txtCodigo.SelectAll();
                            txtCodigo.Focus();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo validar el código:\n" + ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                };

                panelBotones.Controls.Add(btnAceptar);
                panelBotones.Controls.Add(btnCancelar);

                panel.Controls.Add(lblTexto, 0, 0);
                panel.Controls.Add(txtCodigo, 0, 1);
                panel.Controls.Add(lblError, 0, 2);
                panel.Controls.Add(panelBotones, 0, 3);

                dialogo.Controls.Add(panel);

                dialogo.AcceptButton = btnAceptar;    // Enter confirma
                dialogo.CancelButton = btnCancelar;   // Esc cancela

                return dialogo.ShowDialog(this) == DialogResult.OK;
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

            // --- Confirmación 1: advertencia de pérdida de datos ---
            string aviso =
                "Vas a restaurar '" + txtBaseDatos.Text + "' al estado del " +
                fecha.ToString("dd/MM/yyyy HH:mm") + ".\n\n" +
                "Se perderán TODAS las ventas y cambios hechos después de esa fecha, " +
                "y se cerrarán las sesiones abiertas (incluidas las cajas).\n\n" +
                "Esta acción no se puede deshacer. ¿Continuar?";

            if (MessageBox.Show(aviso, "Confirmar restauración", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                return;

            // --- Confirmación 2: autorización de un supervisor ---
            bool autorizado = PedirAutorizacionSupervisor();

            if (!autorizado)
            {
                lblEstado.ForeColor = Color.DarkRed;
                lblEstado.Text = "Restauración cancelada: falta autorización del supervisor.";
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                BloquearBotones(true);
                lblEstado.ForeColor = Color.Black;
                lblEstado.Text = "Restaurando, no cierres la aplicación...";
                lblEstado.Refresh();

                negocio.Restaurar(txtBaseDatos.Text, ruta, posicion, estado, autorizado);

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
                lblEstado.Text = "";
                CargarHistorial();
            }
        }
    }
}
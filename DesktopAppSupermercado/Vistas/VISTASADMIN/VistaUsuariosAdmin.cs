using System;
using System.Data;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;
using DesktopAppSupermercado.ReglasNegocio;

namespace DesktopAppSupermercado.VISTASADMIN
{
    public partial class VistaUsuariosAdmin : Form
    {
        private UsuarioAdminNegocio negocio = new UsuarioAdminNegocio();
        private int _idUsuarioActual = 0;
        private int _idPersonaActual = 0;
        private bool _editandoInactivo = false;
        private const string PASSWORD_MASK = "••••••••";

        public VistaUsuariosAdmin()
        {
            InitializeComponent();
        }

        private void VistaUsuariosAdmin_Load(object sender, EventArgs e)
        {
            txtContrasena.UseSystemPasswordChar = true;
            dtpFechaNac.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.ShowCheckBox = true;
            dtpFechaHasta.ShowCheckBox = true;
            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Checked = false;
            txtDNI.MaxLength = 8;
            txtTelefono.MaxLength = 12;

            ConfigurarColumnasDGV();
            CargarCombos();
            ActualizarGrillas();
        }

        private void ConfigurarColumnasDGV()
        {
            dgvActivos.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;

            // Propiedades para ambas grillas
            colIdUsuario.DataPropertyName = "id_usuario";
            colDNI.DataPropertyName = "dni";
            colNombre.DataPropertyName = "nombre";
            colApellido.DataPropertyName = "apellido";
            colUsuario.DataPropertyName = "nombre_usuario";
            colEmail.DataPropertyName = "correo";
            colDireccion.DataPropertyName = "direccion";
            colTelefono.DataPropertyName = "telefono";
            colSexo.DataPropertyName = "sexo";
            colFechaNac.DataPropertyName = "fecha_nacimiento";
            colRol.DataPropertyName = "rol";
            colFechaAlta.DataPropertyName = "fecha_alta";

            colIdUsuarioInact.DataPropertyName = "id_usuario";
            colDniInact.DataPropertyName = "dni";
            colNombreInact.DataPropertyName = "nombre";
            colApellidoInact.DataPropertyName = "apellido";
            colUsuarioInact.DataPropertyName = "nombre_usuario";
            colEmailInact.DataPropertyName = "correo";
            colDireccionInact.DataPropertyName = "direccion";
            colTelefonoInact.DataPropertyName = "telefono";
            colSexoInact.DataPropertyName = "sexo";
            colFechaNacInact.DataPropertyName = "fecha_nacimiento";
            colRolInact.DataPropertyName = "rol";
            colFechaAltaInact.DataPropertyName = "fecha_alta";
        }

        private void CargarCombos()
        {
            DataTable dtRoles = negocio.ObtenerListaRoles();

            // Combo Perfil Alta
            cmbPerfil.DisplayMember = "nombre";
            cmbPerfil.ValueMember = "id_rol";
            cmbPerfil.DataSource = dtRoles;
            cmbPerfil.SelectedIndex = -1;

            // Combo Filtro (Duplicamos la tabla para no cruzar datos y agregamos "Todos")
            DataTable dtFiltro = dtRoles.Copy();
            DataRow filaTodos = dtFiltro.NewRow();
            filaTodos["id_rol"] = 0;
            filaTodos["nombre"] = "Todos";
            dtFiltro.Rows.InsertAt(filaTodos, 0);

            cmbFiltroRol.DisplayMember = "nombre";
            cmbFiltroRol.ValueMember = "id_rol";
            cmbFiltroRol.DataSource = dtFiltro;
            cmbFiltroRol.SelectedIndex = 0;
        }

        private void ActualizarGrillas()
        {
            string nombre = txtBuscarNombre.Text.Trim();
            int idRol = (cmbFiltroRol.SelectedValue != null && cmbFiltroRol.SelectedValue != DBNull.Value) ? Convert.ToInt32(cmbFiltroRol.SelectedValue) : 0;

            object? fechaDesde = null;
            object? fechaHasta = null;

            // Lógica estricta de fechas: solo se aplica si AMBAS están marcadas
            if (dtpFechaDesde.Checked && dtpFechaHasta.Checked)
            {
                if (dtpFechaDesde.Value.Date <= dtpFechaHasta.Value.Date)
                {
                    fechaDesde = dtpFechaDesde.Value.Date;
                    fechaHasta = dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1);
                }
                else
                {
                    // Si son incongruentes, alertamos y desmarcamos una para no trabar el buscador
                    MessageBox.Show("La fecha 'Desde' no puede ser mayor a la fecha 'Hasta' (o viceversa).", "Fechas inválidas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtpFechaHasta.Checked = false;
                    return; // Cortamos la ejecución hasta que el usuario corrija
                }
            }

            dgvActivos.DataSource = negocio.ListarUsuarios(nombre, idRol, fechaDesde, fechaHasta, true);
            dataGridView1.DataSource = negocio.ListarUsuarios(nombre, idRol, fechaDesde, fechaHasta, false);
        }

        // 1. Buscador de texto en tiempo real
        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            ActualizarGrillas();
        }

        // 2. Filtro de rol en tiempo real
        private void cmbFiltroRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Solo actualizamos si el combo ya terminó de cargar sus datos desde la BD
            if (cmbFiltroRol.DataSource != null)
            {
                ActualizarGrillas();
            }
        }

        // 3. Filtros de fecha en tiempo real (reaccionan al chequear o cambiar el calendario)
        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            ActualizarGrillas();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            ActualizarGrillas();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarFormularioVisual()) return;

            string sexo = rbHombre.Checked ? "Hombre" : "Mujer";
            int idRol = Convert.ToInt32(cmbPerfil.SelectedValue);
            bool cambiaClave = (_idUsuarioActual == 0) || (txtContrasena.Text != PASSWORD_MASK && !string.IsNullOrWhiteSpace(txtContrasena.Text));

            try
            {
                negocio.GuardarUsuario(_idPersonaActual, _idUsuarioActual, txtNombre.Text.Trim(), txtApellido.Text.Trim(),
                                       txtDNI.Text.Trim(), txtDireccion.Text.Trim(), txtTelefono.Text.Trim(), sexo,
                                       dtpFechaNac.Value.Date, txtEmail.Text.Trim(), idRol, txtUsuario.Text.Trim(),
                                       txtContrasena.Text, cambiaClave);

                MessageBox.Show(_idUsuarioActual == 0 ? "Usuario creado." : "Usuario modificado.");
                LimpiarFormulario();
                ActualizarGrillas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idUsuarioActual == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario.");
                return;
            }

            negocio.EliminarUsuario(_idUsuarioActual);
            MessageBox.Show("Usuario dado de baja.");
            LimpiarFormulario();
            ActualizarGrillas();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            cmbFiltroRol.SelectedIndex = 0;
            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Checked = false;
            ActualizarGrillas();
        }

        private void dgvActivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) AutocompletarGrilla(dgvActivos, e.RowIndex, false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) AutocompletarGrilla(dataGridView1, e.RowIndex, true);
        }

        private void AutocompletarGrilla(DataGridView dgv, int fila, bool inactivo)
        {
            DataRowView? drv = dgv.Rows[fila].DataBoundItem as DataRowView;
            if (drv == null) return;

            _idUsuarioActual = Convert.ToInt32(drv["id_usuario"]);
            _idPersonaActual = Convert.ToInt32(drv["id_persona"]);
            _editandoInactivo = inactivo;

            txtNombre.Text = drv["nombre"]?.ToString()??"";
            txtApellido.Text = drv["apellido"]?.ToString()??"";
            txtDNI.Text = drv["dni"]?.ToString()??"";
            txtUsuario.Text = drv["nombre_usuario"]?.ToString()??"";
            txtEmail.Text = drv["correo"]?.ToString()??"";
            txtDireccion.Text = drv["direccion"]?.ToString()??"";
            txtTelefono.Text = drv["telefono"]?.ToString()??"";
            txtContrasena.Text = PASSWORD_MASK;

            string sexo = drv["sexo"]?.ToString()??"";
            rbHombre.Checked = (sexo == "Hombre");
            rbMujer.Checked = (sexo == "Mujer");
            if (drv["fecha_nacimiento"] != DBNull.Value) dtpFechaNac.Value = Convert.ToDateTime(drv["fecha_nacimiento"]);

            cmbPerfil.Text = drv["rol"]?.ToString()??"";
            btnGuardar.Text = "Modificar";
        }

        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtDNI.Text, @"^\d{8}$") && negocio.ExisteDni(txtDNI.Text, _idPersonaActual))
                MessageBox.Show("Ya existe una persona con ese DNI.");
        }

        private bool ValidarFormularioVisual()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text)) { MessageBox.Show("Llene todos los campos."); return false; }
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")) { MessageBox.Show("Nombre inválido."); return false; }
            if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$")) { MessageBox.Show("Apellido inválido."); return false; }
            if (!Regex.IsMatch(txtDNI.Text, @"^\d{8}$")) { MessageBox.Show("DNI inválido."); return false; }
            if (!Regex.IsMatch(txtTelefono.Text, @"^\d{7,12}$")) { MessageBox.Show("Teléfono inválido."); return false; }
            if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) { MessageBox.Show("Email inválido."); return false; }
            if (!rbHombre.Checked && !rbMujer.Checked) { MessageBox.Show("Seleccione sexo."); return false; }
            if (cmbPerfil.SelectedIndex == -1) { MessageBox.Show("Seleccione perfil."); return false; }

            int edad = DateTime.Today.Year - dtpFechaNac.Value.Year;
            if (dtpFechaNac.Value.Date > DateTime.Today.AddYears(-edad)) edad--;
            if (edad < 18) { MessageBox.Show("Debe ser mayor de 18 años."); return false; }

            if (_idUsuarioActual == 0 && string.IsNullOrWhiteSpace(txtContrasena.Text)) { MessageBox.Show("Ingrese clave."); return false; }
            if (negocio.ExisteDni(txtDNI.Text, _idPersonaActual)) { MessageBox.Show("El DNI ya existe."); return false; }
            if (negocio.ExisteUsuario(txtUsuario.Text, _idUsuarioActual)) { MessageBox.Show("El usuario ya existe."); return false; }
            return true;
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear(); txtApellido.Clear(); txtUsuario.Clear(); txtContrasena.Clear(); txtEmail.Clear();
            txtDNI.Clear(); txtDireccion.Clear(); txtTelefono.Clear(); dtpFechaNac.Value = DateTime.Today;
            rbHombre.Checked = false; rbMujer.Checked = false; cmbPerfil.SelectedIndex = -1;
            _idUsuarioActual = 0; _idPersonaActual = 0; _editandoInactivo = false; btnGuardar.Text = "Guardar";
        }

        private void btnCancelar_Click(object sender, EventArgs e) => LimpiarFormulario();
        private void txtContrasena_Enter(object sender, EventArgs e) { if (_idUsuarioActual > 0 && txtContrasena.Text == PASSWORD_MASK) txtContrasena.Clear(); }
        private void txtContrasena_Leave(object sender, EventArgs e) { if (_idUsuarioActual > 0 && string.IsNullOrEmpty(txtContrasena.Text)) txtContrasena.Text = PASSWORD_MASK; }
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true; }
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ') e.Handled = true; }
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e) { if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ') e.Handled = true; }

        // Eventos visuales vacíos
        private void btnEliminar_Click_1(object sender, EventArgs e) => btnEliminar_Click(sender, e);
        private void btnCancelar_Click_1(object sender, EventArgs e) => btnCancelar_Click(sender, e);
        private void btnGuardar_Click_1(object sender, EventArgs e) => btnGuardar_Click(sender, e);
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label5_Click_2(object sender, EventArgs e) { }
        private void label8_Click_1(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label14_Click(object sender, EventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
        private void txtUsuario_TextChanged(object sender, EventArgs e) { }
        private void txtDNI_TextChanged(object sender, EventArgs e) { }
        private void cmbPerfil_SelectedIndexChanged(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
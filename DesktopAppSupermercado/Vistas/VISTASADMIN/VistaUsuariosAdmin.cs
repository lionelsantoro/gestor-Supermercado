using DesktopAppSupermercado.Datos;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing;

namespace DesktopAppSupermercado.VISTASADMIN
{
    public partial class VistaUsuariosAdmin : Form
    {
        // ============================================================
        // CAMPOS PRIVADOS
        // ============================================================
        private int _idUsuarioActual = 0;
        private int _idPersonaActual = 0;
        private bool _editandoInactivo = false;
        private const string PASSWORD_MASK = "••••••••";

        public VistaUsuariosAdmin()
        {
            InitializeComponent();
        }

        // ============================================================
        // LOAD DEL FORMULARIO
        // ============================================================
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

            // Límite de caracteres por código (por si no se seteó en el diseñador)
            txtDNI.MaxLength = 8;
            txtTelefono.MaxLength = 12;

            ConfigurarColumnasDGV();

            CargarComboPerfil();
            CargarComboFiltroRol();
            CargarActivos();
            CargarInactivos();
        }

        // Vincula cada columna del DGV con el nombre del campo del SELECT
        private void ConfigurarColumnasDGV()
        {
            dgvActivos.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;

            // ---- DGV Activos ----
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

            // ---- DGV Inactivos (dataGridView1) ----
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

        // ============================================================
        // HELPER: Obtiene el id_rol seleccionado en el filtro
        // ============================================================
        private int ObtenerIdRolFiltro()
        {
            if (cmbFiltroRol.SelectedValue == null
                || cmbFiltroRol.SelectedValue == DBNull.Value)
                return 0;

            if (int.TryParse(cmbFiltroRol.SelectedValue.ToString(), out int id))
                return id;

            return 0;
        }

        // ============================================================
        // CARGA DE COMBOS
        // ============================================================
        private void CargarComboPerfil()
        {
            Conexion miConexion = new Conexion();
            try
            {
                using (SqlConnection cn = miConexion.ObtenerConexion())
                {
                    cn.Open();
                    string query = "SELECT id_rol, nombre FROM roles ORDER BY nombre";
                    SqlDataAdapter da = new SqlDataAdapter(query, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbPerfil.DataSource = null;
                    cmbPerfil.DisplayMember = "nombre";
                    cmbPerfil.ValueMember = "id_rol";
                    cmbPerfil.DataSource = dt;
                    cmbPerfil.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los perfiles: " + ex.Message);
            }
        }

        private void CargarComboFiltroRol()
        {
            Conexion miConexion = new Conexion();
            try
            {
                using (SqlConnection cn = miConexion.ObtenerConexion())
                {
                    cn.Open();
                    string query = "SELECT id_rol, nombre FROM roles ORDER BY nombre";
                    SqlDataAdapter da = new SqlDataAdapter(query, cn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow filaTodos = dt.NewRow();
                    filaTodos["id_rol"] = 0;
                    filaTodos["nombre"] = "Todos";
                    dt.Rows.InsertAt(filaTodos, 0);

                    cmbFiltroRol.DataSource = null;
                    cmbFiltroRol.DisplayMember = "nombre";
                    cmbFiltroRol.ValueMember = "id_rol";
                    cmbFiltroRol.DataSource = dt;
                    cmbFiltroRol.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar filtro de roles: " + ex.Message);
            }
        }

        // ============================================================
        // CARGA DE DATAGRIDS (CON FILTROS APLICABLES)
        // ============================================================
        private void CargarActivos()
        {
            Conexion miConexion = new Conexion();
            try
            {
                using (SqlConnection cn = miConexion.ObtenerConexion())
                {
                    cn.Open();

                    string query = @"
                        SELECT u.id_usuario, p.dni, p.nombre, p.apellido,
                               u.nombre_usuario, u.correo, p.direccion, p.telefono,
                               p.sexo, p.fecha_nacimiento, r.nombre AS rol,
                               u.creado_en AS fecha_alta, p.id_persona
                        FROM usuarios u
                        INNER JOIN persona p ON u.id_persona = p.id_persona
                        INNER JOIN roles r ON u.id_rol = r.id_rol
                        WHERE u.eliminado = 0
                          AND (@nombre = '' OR p.nombre LIKE '%' + @nombre + '%' 
                               OR p.apellido LIKE '%' + @nombre + '%')
                          AND (@idRol = 0 OR u.id_rol = @idRol)
                          AND (@fechaDesde IS NULL OR u.creado_en >= @fechaDesde)
                          AND (@fechaHasta IS NULL OR u.creado_en <= @fechaHasta)
                        ORDER BY u.id_usuario";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtBuscarNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@idRol", ObtenerIdRolFiltro());
                        cmd.Parameters.AddWithValue("@fechaDesde",
                            dtpFechaDesde.Checked ? (object)dtpFechaDesde.Value.Date : DBNull.Value);
                        cmd.Parameters.AddWithValue("@fechaHasta",
                            dtpFechaHasta.Checked ? (object)dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1) : DBNull.Value);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dgvActivos.DataSource = null;
                        dgvActivos.DataSource = dt;
                        dgvActivos.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar activos: " + ex.Message);
            }
        }

        private void CargarInactivos()
        {
            Conexion miConexion = new Conexion();
            try
            {
                using (SqlConnection cn = miConexion.ObtenerConexion())
                {
                    cn.Open();
                    string query = @"
                        SELECT u.id_usuario, p.dni, p.nombre, p.apellido,
                               u.nombre_usuario, u.correo, p.direccion, p.telefono,
                               p.sexo, p.fecha_nacimiento, r.nombre AS rol,
                               u.creado_en AS fecha_alta, p.id_persona
                        FROM usuarios u
                        INNER JOIN persona p ON u.id_persona = p.id_persona
                        INNER JOIN roles r ON u.id_rol = r.id_rol
                        WHERE u.eliminado = 1
                          AND (@nombre = '' OR p.nombre LIKE '%' + @nombre + '%' 
                               OR p.apellido LIKE '%' + @nombre + '%')
                          AND (@idRol = 0 OR u.id_rol = @idRol)
                          AND (@fechaDesde IS NULL OR u.creado_en >= @fechaDesde)
                          AND (@fechaHasta IS NULL OR u.creado_en <= @fechaHasta)
                        ORDER BY u.id_usuario";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtBuscarNombre.Text.Trim());
                        cmd.Parameters.AddWithValue("@idRol", ObtenerIdRolFiltro());
                        cmd.Parameters.AddWithValue("@fechaDesde",
                            dtpFechaDesde.Checked ? (object)dtpFechaDesde.Value.Date : DBNull.Value);
                        cmd.Parameters.AddWithValue("@fechaHasta",
                            dtpFechaHasta.Checked ? (object)dtpFechaHasta.Value.Date.AddDays(1).AddSeconds(-1) : DBNull.Value);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = dt;
                        dataGridView1.Refresh();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar inactivos: " + ex.Message);
            }
        }

        // ============================================================
        // VALIDACIONES AL GUARDAR
        // ============================================================
        private bool ValidarCampos()
        {
            // 1) Ningún campo vacío
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtDNI.Text) ||
                string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return false;
            }

            // 2) Nombre: solo letras y espacios
            if (!Regex.IsMatch(txtNombre.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El nombre solo puede contener letras.");
                return false;
            }

            // 3) Apellido: solo letras y espacios
            if (!Regex.IsMatch(txtApellido.Text, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ\s]+$"))
            {
                MessageBox.Show("El apellido solo puede contener letras.");
                return false;
            }

            // 4) DNI: exactamente 8 dígitos numéricos
            if (!Regex.IsMatch(txtDNI.Text, @"^\d{8}$"))
            {
                MessageBox.Show("El DNI debe tener exactamente 8 dígitos numéricos.");
                return false;
            }

            // 5) Teléfono: entre 7 y 12 dígitos numéricos
            if (!Regex.IsMatch(txtTelefono.Text, @"^\d{7,12}$"))
            {
                MessageBox.Show("El teléfono debe tener entre 7 y 12 dígitos numéricos.");
                return false;
            }

            // 6) Email: formato nombre@dominio.extension (ej: nombre@gmail.com)
            if (!Regex.IsMatch(txtEmail.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                MessageBox.Show("El email no tiene un formato válido (ej: nombre@gmail.com).");
                return false;
            }

            // 7) Sexo: debe elegir uno
            if (!rbHombre.Checked && !rbMujer.Checked)
            {
                MessageBox.Show("Debe seleccionar el sexo.");
                return false;
            }

            // 8) Perfil: debe estar seleccionado
            if (cmbPerfil.SelectedIndex == -1 || cmbPerfil.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un perfil.");
                return false;
            }

            // 9) Edad mínima: 18 años
            int edad = DateTime.Today.Year - dtpFechaNac.Value.Year;
            if (dtpFechaNac.Value.Date > DateTime.Today.AddYears(-edad)) edad--;
            if (edad < 18)
            {
                MessageBox.Show("El usuario debe ser mayor de 18 años.");
                return false;
            }

            // 10) Contraseña: obligatoria solo en alta nueva
            if (_idUsuarioActual == 0 && string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Debe ingresar una contraseña.");
                return false;
            }

            // 11) DNI duplicado
            if (ExisteDni(txtDNI.Text, _idPersonaActual))
            {
                MessageBox.Show("Ya existe una persona con ese DNI.");
                return false;
            }

            // 12) Nombre de usuario duplicado
            if (ExisteUsuario(txtUsuario.Text, _idUsuarioActual))
            {
                MessageBox.Show("Ya existe ese nombre de usuario.");
                return false;
            }

            return true;
        }

        private bool ExisteDni(string dni, int idPersonaExcluir)
        {
            Conexion miConexion = new Conexion();
            using (SqlConnection cn = miConexion.ObtenerConexion())
            {
                cn.Open();
                string query = "SELECT COUNT(*) FROM persona WHERE dni = @dni AND id_persona <> @idExcluir";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@dni", dni);
                    cmd.Parameters.AddWithValue("@idExcluir", idPersonaExcluir);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        private bool ExisteUsuario(string usuario, int idUsuarioExcluir)
        {
            Conexion miConexion = new Conexion();
            using (SqlConnection cn = miConexion.ObtenerConexion())
            {
                cn.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE nombre_usuario = @usuario AND id_usuario <> @idExcluir";
                using (SqlCommand cmd = new SqlCommand(query, cn))
                {
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@idExcluir", idUsuarioExcluir);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        // ============================================================
        // AVISO DE DNI DUPLICADO EN TIEMPO REAL
        // ============================================================
        private void txtDNI_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(txtDNI.Text, @"^\d{8}$"))
            {
                if (ExisteDni(txtDNI.Text, _idPersonaActual))
                {
                    MessageBox.Show("Atención: ya existe un usuario con ese DNI.");
                }
            }
        }

        // ============================================================
        // VALIDACIONES EN TIEMPO DE ESCRITURA (KeyPress)
        // ============================================================
        // Bloquean la tecla inválida en el momento. e.Handled = true anula
        // la tecla. char.IsControl deja pasar Backspace, Delete, etc.

        // DNI: solo dígitos
        private void txtDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // Teléfono: solo dígitos
        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        // Nombre: solo letras y espacio
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        // Apellido: solo letras y espacio
        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        // ============================================================
        // BOTÓN GUARDAR (ALTA O MODIFICACIÓN)
        // ============================================================
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            string sexo = rbHombre.Checked ? "Hombre" : "Mujer";
            int idRol = Convert.ToInt32(cmbPerfil.SelectedValue);

            bool cambiarContrasena = (_idUsuarioActual == 0) ||
                                     (txtContrasena.Text != PASSWORD_MASK &&
                                      !string.IsNullOrWhiteSpace(txtContrasena.Text));
            string contrasenaHash = cambiarContrasena ? HashearSHA256(txtContrasena.Text) : "";

            Conexion miConexion = new Conexion();
            try
            {
                using (SqlConnection cn = miConexion.ObtenerConexion())
                {
                    cn.Open();

                    if (_idUsuarioActual == 0)
                    {
                        // ========== ALTA NUEVA ==========
                        string sqlPersona = @"
                            INSERT INTO persona 
                            (nombre, apellido, dni, direccion, telefono, sexo, fecha_nacimiento, correo)
                            VALUES 
                            (@nombre, @apellido, @dni, @direccion, @telefono, @sexo, @fechaNac, @correo);
                            SELECT SCOPE_IDENTITY();";

                        int idPersona;
                        using (SqlCommand cmd = new SqlCommand(sqlPersona, cn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                            cmd.Parameters.AddWithValue("@dni", txtDNI.Text.Trim());
                            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                            cmd.Parameters.AddWithValue("@sexo", sexo);
                            cmd.Parameters.AddWithValue("@fechaNac", dtpFechaNac.Value.Date);
                            cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                            idPersona = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        string sqlUsuario = @"
                            INSERT INTO usuarios 
                            (id_persona, id_rol, correo, nombre_usuario, contrasena)
                            VALUES 
                            (@idPersona, @idRol, @correo, @usuario, @contrasena)";

                        using (SqlCommand cmd = new SqlCommand(sqlUsuario, cn))
                        {
                            cmd.Parameters.AddWithValue("@idPersona", idPersona);
                            cmd.Parameters.AddWithValue("@idRol", idRol);
                            cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                            cmd.Parameters.AddWithValue("@contrasena", contrasenaHash);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Usuario creado correctamente.");

                        // Limpiar filtros para que el nuevo usuario sea visible sí o sí
                        LimpiarFiltrosSinRecargar();
                    }
                    else
                    {
                        // ========== MODIFICACIÓN ==========
                        string sqlPersona = @"
                            UPDATE persona SET
                                nombre = @nombre, apellido = @apellido, dni = @dni,
                                direccion = @direccion, telefono = @telefono, sexo = @sexo,
                                fecha_nacimiento = @fechaNac, correo = @correo
                            WHERE id_persona = @idPersona";

                        using (SqlCommand cmd = new SqlCommand(sqlPersona, cn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
                            cmd.Parameters.AddWithValue("@apellido", txtApellido.Text.Trim());
                            cmd.Parameters.AddWithValue("@dni", txtDNI.Text.Trim());
                            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text.Trim());
                            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text.Trim());
                            cmd.Parameters.AddWithValue("@sexo", sexo);
                            cmd.Parameters.AddWithValue("@fechaNac", dtpFechaNac.Value.Date);
                            cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@idPersona", _idPersonaActual);
                            cmd.ExecuteNonQuery();
                        }

                        string sqlUsuario;
                        if (cambiarContrasena)
                        {
                            sqlUsuario = @"
                                UPDATE usuarios SET
                                    id_rol = @idRol, correo = @correo,
                                    nombre_usuario = @usuario, contrasena = @contrasena,
                                    eliminado = 0, eliminado_en = NULL
                                WHERE id_usuario = @idUsuario";
                        }
                        else
                        {
                            sqlUsuario = @"
                                UPDATE usuarios SET
                                    id_rol = @idRol, correo = @correo,
                                    nombre_usuario = @usuario,
                                    eliminado = 0, eliminado_en = NULL
                                WHERE id_usuario = @idUsuario";
                        }

                        using (SqlCommand cmd = new SqlCommand(sqlUsuario, cn))
                        {
                            cmd.Parameters.AddWithValue("@idRol", idRol);
                            cmd.Parameters.AddWithValue("@correo", txtEmail.Text.Trim());
                            cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text.Trim());
                            if (cambiarContrasena)
                                cmd.Parameters.AddWithValue("@contrasena", contrasenaHash);
                            cmd.Parameters.AddWithValue("@idUsuario", _idUsuarioActual);
                            cmd.ExecuteNonQuery();
                        }

                        string msj = _editandoInactivo
                            ? "Usuario reactivado y modificado correctamente."
                            : "Usuario modificado correctamente.";
                        MessageBox.Show(msj);
                    }
                }

                CargarActivos();
                CargarInactivos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void LimpiarFiltrosSinRecargar()
        {
            txtBuscarNombre.Clear();
            cmbFiltroRol.SelectedIndex = 0;
            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Checked = false;
        }

        // ============================================================
        // BOTÓN CANCELAR (LIMPIA FORMULARIO)
        // ============================================================
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtEmail.Clear();
            txtDNI.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            dtpFechaNac.Value = DateTime.Today;
            rbHombre.Checked = false;
            rbMujer.Checked = false;
            cmbPerfil.SelectedIndex = -1;

            _idUsuarioActual = 0;
            _idPersonaActual = 0;
            _editandoInactivo = false;
            btnGuardar.Text = "Guardar";
        }

        // ============================================================
        // BOTÓN ELIMINAR (BAJA LÓGICA)
        // ============================================================
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idUsuarioActual == 0)
            {
                MessageBox.Show("Debe seleccionar un usuario del listado para eliminar.");
                return;
            }

            Conexion miConexion = new Conexion();
            try
            {
                using (SqlConnection cn = miConexion.ObtenerConexion())
                {
                    cn.Open();
                    string query = @"
                        UPDATE usuarios 
                        SET eliminado = 1, eliminado_en = GETDATE() 
                        WHERE id_usuario = @idUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, cn))
                    {
                        cmd.Parameters.AddWithValue("@idUsuario", _idUsuarioActual);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario dado de baja.");
                CargarActivos();
                CargarInactivos();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        // ============================================================
        // BOTONES DE FILTROS
        // ============================================================
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Checked != dtpFechaHasta.Checked)
            {
                MessageBox.Show("Para filtrar por fecha, debe indicar tanto 'Desde' como 'Hasta'.");
                return;
            }

            if (dtpFechaDesde.Checked && dtpFechaDesde.Value > dtpFechaHasta.Value)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor a la fecha 'Hasta'.");
                return;
            }

            CargarActivos();
            CargarInactivos();
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            LimpiarFiltrosSinRecargar();
            CargarActivos();
            CargarInactivos();
        }

        // ============================================================
        // CLIC EN LOS DATAGRIDVIEWS (AUTOCOMPLETAR FORMULARIO)
        // ============================================================
        private void dgvActivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            AutocompletarDesdeGrilla(dgvActivos, e.RowIndex, false);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            AutocompletarDesdeGrilla(dataGridView1, e.RowIndex, true);
        }

        private void AutocompletarDesdeGrilla(DataGridView dgv, int fila, bool esInactivo)
        {
            DataRowView drv = dgv.Rows[fila].DataBoundItem as DataRowView;
            if (drv == null) return;

            _idUsuarioActual = Convert.ToInt32(drv["id_usuario"]);
            _idPersonaActual = Convert.ToInt32(drv["id_persona"]);
            _editandoInactivo = esInactivo;

            txtNombre.Text = drv["nombre"]?.ToString() ?? "";
            txtApellido.Text = drv["apellido"]?.ToString() ?? "";
            txtDNI.Text = drv["dni"]?.ToString() ?? "";
            txtUsuario.Text = drv["nombre_usuario"]?.ToString() ?? "";
            txtEmail.Text = drv["correo"]?.ToString() ?? "";
            txtDireccion.Text = drv["direccion"]?.ToString() ?? "";
            txtTelefono.Text = drv["telefono"]?.ToString() ?? "";

            txtContrasena.Text = PASSWORD_MASK;

            string sexo = drv["sexo"]?.ToString() ?? "";
            rbHombre.Checked = sexo == "Hombre";
            rbMujer.Checked = sexo == "Mujer";

            if (drv["fecha_nacimiento"] != DBNull.Value && drv["fecha_nacimiento"] != null)
            {
                dtpFechaNac.Value = Convert.ToDateTime(drv["fecha_nacimiento"]);
            }

            string rolNombre = drv["rol"]?.ToString() ?? "";
            DataTable dtPerfil = cmbPerfil.DataSource as DataTable;
            if (dtPerfil != null)
            {
                for (int i = 0; i < dtPerfil.Rows.Count; i++)
                {
                    if (dtPerfil.Rows[i]["nombre"].ToString() == rolNombre)
                    {
                        cmbPerfil.SelectedIndex = i;
                        break;
                    }
                }
            }

            btnGuardar.Text = "Modificar";
        }

        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (_idUsuarioActual > 0 && txtContrasena.Text == PASSWORD_MASK)
            {
                txtContrasena.Clear();
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (_idUsuarioActual > 0 && string.IsNullOrEmpty(txtContrasena.Text))
            {
                txtContrasena.Text = PASSWORD_MASK;
            }
        }

        // ============================================================
        // HELPER: HASH DE CONTRASEÑA (SHA-256)
        // ============================================================
        private string HashearSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }

        // ============================================================
        // EVENTOS AUTOGENERADOS DEL DESIGNER (redirigen o quedan vacíos)
        // ============================================================
        private void btnEliminar_Click_1(object sender, EventArgs e) => btnEliminar_Click(sender, e);
        private void btnCancelar_Click_1(object sender, EventArgs e) => btnCancelar_Click(sender, e);
        private void btnGuardar_Click_1(object sender, EventArgs e) => btnGuardar_Click(sender, e);
        private void btnFiltrar_Click_1(object sender, EventArgs e) => btnFiltrar_Click(sender, e);

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
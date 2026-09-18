namespace DesktopAppSupermercado.VISTASADMIN
{
    partial class VistaUsuariosAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtUsuario = new TextBox();
            txtContrasena = new TextBox();
            txtEmail = new TextBox();
            cmbPerfil = new ComboBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            txtDNI = new TextBox();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            dtpFechaNac = new DateTimePicker();
            rbHombre = new RadioButton();
            rbMujer = new RadioButton();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvActivos = new DataGridView();
            colIdUsuario = new DataGridViewTextBoxColumn();
            colDNI = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colSexo = new DataGridViewTextBoxColumn();
            colFechaNac = new DataGridViewTextBoxColumn();
            colRol = new DataGridViewTextBoxColumn();
            colFechaAlta = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            dataGridView1 = new DataGridView();
            colIdUsuarioInact = new DataGridViewTextBoxColumn();
            colDniInact = new DataGridViewTextBoxColumn();
            colNombreInact = new DataGridViewTextBoxColumn();
            colApellidoInact = new DataGridViewTextBoxColumn();
            colUsuarioInact = new DataGridViewTextBoxColumn();
            colEmailInact = new DataGridViewTextBoxColumn();
            colDireccionInact = new DataGridViewTextBoxColumn();
            colTelefonoInact = new DataGridViewTextBoxColumn();
            colSexoInact = new DataGridViewTextBoxColumn();
            colFechaNacInact = new DataGridViewTextBoxColumn();
            colRolInact = new DataGridViewTextBoxColumn();
            colFechaAltaInact = new DataGridViewTextBoxColumn();
            dgvInactivos = new DataGridView();
            btnEliminar = new Button();
            btnCancelar = new Button();
            btnGuardar = new Button();
            label13 = new Label();
            txtBuscarNombre = new TextBox();
            cmbFiltroRol = new ComboBox();
            label14 = new Label();
            lblFechaDesde = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            dtpFechaDesde = new DateTimePicker();
            lblFechaHasta = new Label();
            dtpFechaHasta = new DateTimePicker();
            btnFiltrar = new Button();
            btnLimpiarFiltros = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvActivos).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInactivos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 19.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, -3);
            label1.Name = "label1";
            label1.Size = new Size(287, 74);
            label1.TabIndex = 0;
            label1.Text = "Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 142);
            label2.Name = "label2";
            label2.Size = new Size(102, 32);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(4, 209);
            label3.Name = "label3";
            label3.Size = new Size(102, 32);
            label3.TabIndex = 2;
            label3.Text = "Apellido";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(4, 279);
            label4.Name = "label4";
            label4.Size = new Size(94, 32);
            label4.TabIndex = 3;
            label4.Text = "Usuario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(-7, 331);
            label5.Name = "label5";
            label5.Size = new Size(134, 32);
            label5.TabIndex = 4;
            label5.Text = "Contraseña";
            label5.Click += label5_Click_2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(23, 390);
            label6.Name = "label6";
            label6.Size = new Size(71, 32);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(610, 83);
            label7.Name = "label7";
            label7.Size = new Size(67, 32);
            label7.TabIndex = 6;
            label7.Text = "Perfil";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(123, 135);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(414, 39);
            txtNombre.TabIndex = 7;
            txtNombre.KeyPress += txtNombre_KeyPress;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(123, 206);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(409, 39);
            txtApellido.TabIndex = 8;
            txtApellido.KeyPress += txtApellido_KeyPress;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(121, 276);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(409, 39);
            txtUsuario.TabIndex = 9;
            txtUsuario.TextChanged += txtUsuario_TextChanged;
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(123, 328);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.Size = new Size(407, 39);
            txtContrasena.TabIndex = 10;
            txtContrasena.Enter += txtContrasena_Enter;
            txtContrasena.Leave += txtContrasena_Leave;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(121, 390);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(411, 39);
            txtEmail.TabIndex = 11;
            // 
            // cmbPerfil
            // 
            cmbPerfil.FormattingEnabled = true;
            cmbPerfil.Location = new Point(760, 78);
            cmbPerfil.Name = "cmbPerfil";
            cmbPerfil.Size = new Size(416, 40);
            cmbPerfil.TabIndex = 12;
            cmbPerfil.SelectedIndexChanged += cmbPerfil_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(39, 86);
            label8.Name = "label8";
            label8.Size = new Size(55, 32);
            label8.TabIndex = 13;
            label8.Text = "DNI";
            label8.Click += label8_Click_1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(598, 155);
            label9.Name = "label9";
            label9.Size = new Size(114, 32);
            label9.TabIndex = 14;
            label9.Text = "Direccion";
            label9.Click += label9_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(548, 230);
            label10.Name = "label10";
            label10.Size = new Size(206, 32);
            label10.TabIndex = 15;
            label10.Text = "Fecha Nacimiento";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(598, 303);
            label11.Name = "label11";
            label11.Size = new Size(107, 32);
            label11.TabIndex = 16;
            label11.Text = "Telefono";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(612, 368);
            label12.Name = "label12";
            label12.Size = new Size(65, 32);
            label12.TabIndex = 17;
            label12.Text = "Sexo";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(121, 83);
            txtDNI.MaxLength = 8;
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(416, 39);
            txtDNI.TabIndex = 18;
            txtDNI.TextChanged += txtDNI_TextChanged;
            txtDNI.KeyPress += txtDNI_KeyPress;
            txtDNI.Leave += txtDNI_Leave;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(760, 148);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(416, 39);
            txtDireccion.TabIndex = 19;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(760, 303);
            txtTelefono.MaxLength = 12;
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(416, 39);
            txtTelefono.TabIndex = 21;
            txtTelefono.KeyPress += txtTelefono_KeyPress;
            // 
            // dtpFechaNac
            // 
            dtpFechaNac.Location = new Point(760, 225);
            dtpFechaNac.Name = "dtpFechaNac";
            dtpFechaNac.Size = new Size(416, 39);
            dtpFechaNac.TabIndex = 22;
            // 
            // rbHombre
            // 
            rbHombre.AutoSize = true;
            rbHombre.Location = new Point(745, 364);
            rbHombre.Name = "rbHombre";
            rbHombre.Size = new Size(139, 36);
            rbHombre.TabIndex = 23;
            rbHombre.TabStop = true;
            rbHombre.Text = "Hombre ";
            rbHombre.UseVisualStyleBackColor = true;
            // 
            // rbMujer
            // 
            rbMujer.AutoSize = true;
            rbMujer.Location = new Point(1004, 366);
            rbMujer.Name = "rbMujer";
            rbMujer.Size = new Size(108, 36);
            rbMujer.TabIndex = 24;
            rbMujer.TabStop = true;
            rbMujer.Text = "Mujer";
            rbMujer.UseVisualStyleBackColor = true;
            rbMujer.CheckedChanged += radioButton2_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 536);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1702, 297);
            tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvActivos);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1686, 243);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Activos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvActivos
            // 
            dgvActivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvActivos.Columns.AddRange(new DataGridViewColumn[] { colIdUsuario, colDNI, colNombre, colApellido, colUsuario, colEmail, colDireccion, colTelefono, colSexo, colFechaNac, colRol, colFechaAlta });
            dgvActivos.Dock = DockStyle.Fill;
            dgvActivos.Location = new Point(3, 3);
            dgvActivos.Name = "dgvActivos";
            dgvActivos.RowHeadersWidth = 82;
            dgvActivos.Size = new Size(1680, 237);
            dgvActivos.TabIndex = 0;
            dgvActivos.CellClick += dgvActivos_CellClick;
            // 
            // colIdUsuario
            // 
            colIdUsuario.HeaderText = "ID";
            colIdUsuario.MinimumWidth = 10;
            colIdUsuario.Name = "colIdUsuario";
            colIdUsuario.Width = 200;
            // 
            // colDNI
            // 
            colDNI.HeaderText = "DNI";
            colDNI.MinimumWidth = 10;
            colDNI.Name = "colDNI";
            colDNI.Width = 200;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 10;
            colNombre.Name = "colNombre";
            colNombre.Width = 200;
            // 
            // colApellido
            // 
            colApellido.HeaderText = "Apellido";
            colApellido.MinimumWidth = 10;
            colApellido.Name = "colApellido";
            colApellido.Width = 200;
            // 
            // colUsuario
            // 
            colUsuario.HeaderText = "Usuario";
            colUsuario.MinimumWidth = 10;
            colUsuario.Name = "colUsuario";
            colUsuario.Width = 200;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 10;
            colEmail.Name = "colEmail";
            colEmail.Width = 200;
            // 
            // colDireccion
            // 
            colDireccion.HeaderText = "Direccion";
            colDireccion.MinimumWidth = 10;
            colDireccion.Name = "colDireccion";
            colDireccion.Width = 200;
            // 
            // colTelefono
            // 
            colTelefono.HeaderText = "Telefono";
            colTelefono.MinimumWidth = 10;
            colTelefono.Name = "colTelefono";
            colTelefono.Width = 200;
            // 
            // colSexo
            // 
            colSexo.HeaderText = "Sexo";
            colSexo.MinimumWidth = 10;
            colSexo.Name = "colSexo";
            colSexo.Width = 200;
            // 
            // colFechaNac
            // 
            colFechaNac.HeaderText = "Fecha Nac";
            colFechaNac.MinimumWidth = 10;
            colFechaNac.Name = "colFechaNac";
            colFechaNac.Width = 200;
            // 
            // colRol
            // 
            colRol.HeaderText = "Rol";
            colRol.MinimumWidth = 10;
            colRol.Name = "colRol";
            colRol.Width = 200;
            // 
            // colFechaAlta
            // 
            colFechaAlta.HeaderText = "Fecha Alta";
            colFechaAlta.MinimumWidth = 10;
            colFechaAlta.Name = "colFechaAlta";
            colFechaAlta.Width = 200;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridView1);
            tabPage2.Controls.Add(dgvInactivos);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1686, 243);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Inactivos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colIdUsuarioInact, colDniInact, colNombreInact, colApellidoInact, colUsuarioInact, colEmailInact, colDireccionInact, colTelefonoInact, colSexoInact, colFechaNacInact, colRolInact, colFechaAltaInact });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(3, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(1680, 237);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // colIdUsuarioInact
            // 
            colIdUsuarioInact.HeaderText = "ID";
            colIdUsuarioInact.MinimumWidth = 10;
            colIdUsuarioInact.Name = "colIdUsuarioInact";
            colIdUsuarioInact.Width = 200;
            // 
            // colDniInact
            // 
            colDniInact.HeaderText = "DNI";
            colDniInact.MinimumWidth = 10;
            colDniInact.Name = "colDniInact";
            colDniInact.Width = 200;
            // 
            // colNombreInact
            // 
            colNombreInact.HeaderText = "Nombre";
            colNombreInact.MinimumWidth = 10;
            colNombreInact.Name = "colNombreInact";
            colNombreInact.Width = 200;
            // 
            // colApellidoInact
            // 
            colApellidoInact.HeaderText = "Apellido";
            colApellidoInact.MinimumWidth = 10;
            colApellidoInact.Name = "colApellidoInact";
            colApellidoInact.Width = 200;
            // 
            // colUsuarioInact
            // 
            colUsuarioInact.HeaderText = "Usuario";
            colUsuarioInact.MinimumWidth = 10;
            colUsuarioInact.Name = "colUsuarioInact";
            colUsuarioInact.Width = 200;
            // 
            // colEmailInact
            // 
            colEmailInact.HeaderText = "Email";
            colEmailInact.MinimumWidth = 10;
            colEmailInact.Name = "colEmailInact";
            colEmailInact.Width = 200;
            // 
            // colDireccionInact
            // 
            colDireccionInact.HeaderText = "Direccion";
            colDireccionInact.MinimumWidth = 10;
            colDireccionInact.Name = "colDireccionInact";
            colDireccionInact.Width = 200;
            // 
            // colTelefonoInact
            // 
            colTelefonoInact.HeaderText = "Telefono";
            colTelefonoInact.MinimumWidth = 10;
            colTelefonoInact.Name = "colTelefonoInact";
            colTelefonoInact.Width = 200;
            // 
            // colSexoInact
            // 
            colSexoInact.HeaderText = "Sexo";
            colSexoInact.MinimumWidth = 10;
            colSexoInact.Name = "colSexoInact";
            colSexoInact.Width = 200;
            // 
            // colFechaNacInact
            // 
            colFechaNacInact.HeaderText = "Fecha Nac";
            colFechaNacInact.MinimumWidth = 10;
            colFechaNacInact.Name = "colFechaNacInact";
            colFechaNacInact.Width = 200;
            // 
            // colRolInact
            // 
            colRolInact.HeaderText = "Rol";
            colRolInact.MinimumWidth = 10;
            colRolInact.Name = "colRolInact";
            colRolInact.Width = 200;
            // 
            // colFechaAltaInact
            // 
            colFechaAltaInact.HeaderText = "Fecha Alta";
            colFechaAltaInact.MinimumWidth = 10;
            colFechaAltaInact.Name = "colFechaAltaInact";
            colFechaAltaInact.Width = 200;
            // 
            // dgvInactivos
            // 
            dgvInactivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInactivos.Dock = DockStyle.Fill;
            dgvInactivos.Location = new Point(3, 3);
            dgvInactivos.Name = "dgvInactivos";
            dgvInactivos.RowHeadersWidth = 82;
            dgvInactivos.Size = new Size(1680, 237);
            dgvInactivos.TabIndex = 0;
            // 
            // btnEliminar
            // 
            btnEliminar.BackColor = Color.FromArgb(192, 0, 192);
            btnEliminar.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminar.Location = new Point(1222, 198);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(169, 169);
            btnEliminar.TabIndex = 32;
            btnEliminar.Text = "Eliminar Usuario";
            btnEliminar.UseVisualStyleBackColor = false;
            btnEliminar.Click += btnEliminar_Click_1;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Tomato;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.ForeColor = SystemColors.ActiveCaptionText;
            btnCancelar.Image = Properties.Resources.cancel_circle_close_delete_discard_file_x_icon_123219__1_;
            btnCancelar.ImageAlign = ContentAlignment.TopCenter;
            btnCancelar.Location = new Point(1408, 20);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(156, 156);
            btnCancelar.TabIndex = 31;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.BottomCenter;
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click_1;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.YellowGreen;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.Black;
            btnGuardar.Image = Properties.Resources.Save_37110;
            btnGuardar.ImageAlign = ContentAlignment.TopCenter;
            btnGuardar.Location = new Point(1222, 25);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(160, 155);
            btnGuardar.TabIndex = 30;
            btnGuardar.Text = "Guardar";
            btnGuardar.TextAlign = ContentAlignment.BottomCenter;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click_1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(12, 457);
            label13.Name = "label13";
            label13.Size = new Size(318, 32);
            label13.TabIndex = 33;
            label13.Text = "Buscar Usuarios por Nombre";
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Location = new Point(336, 458);
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.Size = new Size(250, 39);
            txtBuscarNombre.TabIndex = 34;
            // 
            // cmbFiltroRol
            // 
            cmbFiltroRol.FormattingEnabled = true;
            cmbFiltroRol.Items.AddRange(new object[] { "Todos", "Administrador", "Supervisor de Caja", "Cajero", "Inventario" });
            cmbFiltroRol.Location = new Point(677, 462);
            cmbFiltroRol.Name = "cmbFiltroRol";
            cmbFiltroRol.Size = new Size(185, 40);
            cmbFiltroRol.TabIndex = 36;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(612, 461);
            label14.Name = "label14";
            label14.Size = new Size(47, 32);
            label14.TabIndex = 37;
            label14.Text = "Rol";
            label14.Click += label14_Click;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Location = new Point(881, 466);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(81, 32);
            lblFechaDesde.TabIndex = 38;
            lblFechaDesde.Text = "Desde";
            lblFechaDesde.Click += label15_Click;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(968, 468);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(207, 39);
            dtpFechaDesde.TabIndex = 39;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Location = new Point(1193, 473);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(73, 32);
            lblFechaHasta.TabIndex = 40;
            lblFechaHasta.Text = "Hasta";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(1272, 473);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(193, 39);
            dtpFechaHasta.TabIndex = 41;
            // 
            // btnFiltrar
            // 
            btnFiltrar.Location = new Point(1547, 478);
            btnFiltrar.Name = "btnFiltrar";
            btnFiltrar.Size = new Size(111, 84);
            btnFiltrar.TabIndex = 42;
            btnFiltrar.Text = "Filtrar";
            btnFiltrar.UseVisualStyleBackColor = true;
            btnFiltrar.Click += btnFiltrar_Click_1;
            // 
            // btnLimpiarFiltros
            // 
            btnLimpiarFiltros.Location = new Point(1547, 368);
            btnLimpiarFiltros.Name = "btnLimpiarFiltros";
            btnLimpiarFiltros.Size = new Size(111, 90);
            btnLimpiarFiltros.TabIndex = 43;
            btnLimpiarFiltros.Text = "Limpiar Filtros";
            btnLimpiarFiltros.UseVisualStyleBackColor = true;
            btnLimpiarFiltros.Click += btnLimpiarFiltros_Click;
            // 
            // VistaUsuariosAdmin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1718, 835);
            Controls.Add(btnLimpiarFiltros);
            Controls.Add(btnFiltrar);
            Controls.Add(dtpFechaHasta);
            Controls.Add(lblFechaHasta);
            Controls.Add(dtpFechaDesde);
            Controls.Add(lblFechaDesde);
            Controls.Add(label14);
            Controls.Add(cmbFiltroRol);
            Controls.Add(txtBuscarNombre);
            Controls.Add(label13);
            Controls.Add(btnEliminar);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(tabControl1);
            Controls.Add(rbMujer);
            Controls.Add(rbHombre);
            Controls.Add(dtpFechaNac);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(txtDNI);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(cmbPerfil);
            Controls.Add(txtEmail);
            Controls.Add(txtContrasena);
            Controls.Add(txtUsuario);
            Controls.Add(txtApellido);
            Controls.Add(txtNombre);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = Color.Black;
            Name = "VistaUsuariosAdmin";
            Text = "VistaUsuariosAdmin";
            WindowState = FormWindowState.Maximized;
            Load += VistaUsuariosAdmin_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvActivos).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInactivos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtUsuario;
        private TextBox txtContrasena;
        private TextBox txtEmail;
        private ComboBox cmbPerfil;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private Label label12;
        private TextBox txtDNI;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private DateTimePicker dtpFechaNac;
        private RadioButton rbHombre;
        private RadioButton rbMujer;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvActivos;
        private DataGridView dgvInactivos;
        private Button btnEliminar;
        private Button btnCancelar;
        private Button btnGuardar;
        private Label label13;
        private TextBox txtBuscarNombre;
        private ComboBox cmbFiltroRol;
        private Label label14;
        private Label lblFechaDesde;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private DateTimePicker dtpFechaDesde;
        private Label lblFechaHasta;
        private DateTimePicker dtpFechaHasta;
        private Button btnFiltrar;
        private Button btnLimpiarFiltros;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colIdUsuario;
        private DataGridViewTextBoxColumn colDNI;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colDireccion;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colSexo;
        private DataGridViewTextBoxColumn colFechaNac;
        private DataGridViewTextBoxColumn colRol;
        private DataGridViewTextBoxColumn colFechaAlta;
        private DataGridViewTextBoxColumn colIdUsuarioInact;
        private DataGridViewTextBoxColumn colDniInact;
        private DataGridViewTextBoxColumn colNombreInact;
        private DataGridViewTextBoxColumn colApellidoInact;
        private DataGridViewTextBoxColumn colUsuarioInact;
        private DataGridViewTextBoxColumn colEmailInact;
        private DataGridViewTextBoxColumn colDireccionInact;
        private DataGridViewTextBoxColumn colTelefonoInact;
        private DataGridViewTextBoxColumn colSexoInact;
        private DataGridViewTextBoxColumn colFechaNacInact;
        private DataGridViewTextBoxColumn colRolInact;
        private DataGridViewTextBoxColumn colFechaAltaInact;
    }
}
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
            txtPassword = new TextBox();
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
            dtpFechaNacimiento = new DateTimePicker();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            btnGuardar = new Button();
            btnCancelar = new Button();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvUsuarios = new DataGridView();
            tabPage2 = new TabPage();
            dgvInactivos = new DataGridView();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInactivos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, -3);
            label1.Name = "label1";
            label1.Size = new Size(233, 60);
            label1.TabIndex = 0;
            label1.Text = "Usuarios";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(45, 75);
            label2.Name = "label2";
            label2.Size = new Size(102, 32);
            label2.TabIndex = 1;
            label2.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 148);
            label3.Name = "label3";
            label3.Size = new Size(102, 32);
            label3.TabIndex = 2;
            label3.Text = "Apellido";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(45, 205);
            label4.Name = "label4";
            label4.Size = new Size(94, 32);
            label4.TabIndex = 3;
            label4.Text = "Usuario";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(45, 254);
            label5.Name = "label5";
            label5.Size = new Size(134, 32);
            label5.TabIndex = 4;
            label5.Text = "Contraseña";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(63, 310);
            label6.Name = "label6";
            label6.Size = new Size(71, 32);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(63, 368);
            label7.Name = "label7";
            label7.Size = new Size(67, 32);
            label7.TabIndex = 6;
            label7.Text = "Perfil";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(163, 75);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(291, 39);
            txtNombre.TabIndex = 7;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(153, 141);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(317, 39);
            txtApellido.TabIndex = 8;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(163, 198);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(307, 39);
            txtUsuario.TabIndex = 9;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(185, 254);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(277, 39);
            txtPassword.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(163, 310);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(261, 39);
            txtEmail.TabIndex = 11;
            // 
            // cmbPerfil
            // 
            cmbPerfil.FormattingEnabled = true;
            cmbPerfil.Location = new Point(153, 368);
            cmbPerfil.Name = "cmbPerfil";
            cmbPerfil.Size = new Size(250, 40);
            cmbPerfil.TabIndex = 12;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(634, 75);
            label8.Name = "label8";
            label8.Size = new Size(55, 32);
            label8.TabIndex = 13;
            label8.Text = "DNI";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(634, 148);
            label9.Name = "label9";
            label9.Size = new Size(114, 32);
            label9.TabIndex = 14;
            label9.Text = "Direccion";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(563, 230);
            label10.Name = "label10";
            label10.Size = new Size(206, 32);
            label10.TabIndex = 15;
            label10.Text = "Fecha Nacimiento";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(634, 313);
            label11.Name = "label11";
            label11.Size = new Size(107, 32);
            label11.TabIndex = 16;
            label11.Text = "Telefono";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(647, 376);
            label12.Name = "label12";
            label12.Size = new Size(65, 32);
            label12.TabIndex = 17;
            label12.Text = "Sexo";
            // 
            // txtDNI
            // 
            txtDNI.Location = new Point(745, 75);
            txtDNI.Name = "txtDNI";
            txtDNI.Size = new Size(291, 39);
            txtDNI.TabIndex = 18;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(745, 148);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(291, 39);
            txtDireccion.TabIndex = 19;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(771, 303);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(291, 39);
            txtTelefono.TabIndex = 21;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(791, 225);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(302, 39);
            dtpFechaNacimiento.TabIndex = 22;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(771, 376);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(139, 36);
            radioButton1.TabIndex = 23;
            radioButton1.TabStop = true;
            radioButton1.Text = "Hombre ";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(986, 376);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(108, 36);
            radioButton2.TabIndex = 24;
            radioButton2.TabStop = true;
            radioButton2.Text = "Mujer";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Lime;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Location = new Point(1102, 102);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(266, 78);
            btnGuardar.TabIndex = 25;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.Red;
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.Location = new Point(1102, 261);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(266, 78);
            btnCancelar.TabIndex = 26;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 442);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1590, 391);
            tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvUsuarios);
            tabPage1.Location = new Point(8, 46);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1574, 337);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Activos";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Dock = DockStyle.Fill;
            dgvUsuarios.Location = new Point(3, 3);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 82;
            dgvUsuarios.Size = new Size(1568, 331);
            dgvUsuarios.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvInactivos);
            tabPage2.Location = new Point(8, 46);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1574, 337);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Inactivos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvInactivos
            // 
            dgvInactivos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInactivos.Dock = DockStyle.Fill;
            dgvInactivos.Location = new Point(3, 3);
            dgvInactivos.Name = "dgvInactivos";
            dgvInactivos.RowHeadersWidth = 82;
            dgvInactivos.Size = new Size(1568, 331);
            dgvInactivos.TabIndex = 0;
            // 
            // VistaUsuariosAdmin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1606, 835);
            Controls.Add(tabControl1);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(dtpFechaNacimiento);
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
            Controls.Add(txtPassword);
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
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            tabPage2.ResumeLayout(false);
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
        private TextBox txtPassword;
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
        private DateTimePicker dtpFechaNacimiento;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private Button btnGuardar;
        private Button btnCancelar;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private DataGridView dgvUsuarios;
        private DataGridView dgvInactivos;
    }
}
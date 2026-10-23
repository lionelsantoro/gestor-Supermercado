namespace DesktopAppSupermercado
{
    partial class FormRegistro
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
            dgvRegistroCliente = new DataGridView();
            txtApellidoCliente = new TextBox();
            txtNombreCliente = new TextBox();
            label5 = new Label();
            btnRegistrarNuevoCliente = new Button();
            btnLimpiar = new Button();
            txtBuscarCliente = new TextBox();
            label6 = new Label();
            label7 = new Label();
            txtCorreo = new TextBox();
            label8 = new Label();
            rbHombre = new RadioButton();
            rbMujer = new RadioButton();
            txtDni = new TextBox();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            txtDireccion = new TextBox();
            txtTelefono = new TextBox();
            label12 = new Label();
            txtFechaNacimiento = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvRegistroCliente).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 31);
            label1.Name = "label1";
            label1.Size = new Size(0, 31);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(592, 36);
            label2.Name = "label2";
            label2.Size = new Size(0, 31);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(274, 15);
            label3.Name = "label3";
            label3.Size = new Size(108, 31);
            label3.TabIndex = 2;
            label3.Text = "Nombre:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(536, 16);
            label4.Name = "label4";
            label4.Size = new Size(0, 31);
            label4.TabIndex = 3;
            // 
            // dgvRegistroCliente
            // 
            dgvRegistroCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistroCliente.Location = new Point(8, 215);
            dgvRegistroCliente.Name = "dgvRegistroCliente";
            dgvRegistroCliente.RowHeadersWidth = 51;
            dgvRegistroCliente.Size = new Size(1045, 436);
            dgvRegistroCliente.TabIndex = 6;
            dgvRegistroCliente.CellContentClick += dgvRegistro_CellContentClick;
            // 
            // txtApellidoCliente
            // 
            txtApellidoCliente.Location = new Point(388, 58);
            txtApellidoCliente.Name = "txtApellidoCliente";
            txtApellidoCliente.Size = new Size(266, 27);
            txtApellidoCliente.TabIndex = 7;
            txtApellidoCliente.KeyPress += txtApellidoCliente_KeyPress;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(388, 17);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(266, 27);
            txtNombreCliente.TabIndex = 8;
            txtNombreCliente.KeyPress += txtNombreCliente_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(271, 54);
            label5.Name = "label5";
            label5.Size = new Size(111, 31);
            label5.TabIndex = 9;
            label5.Text = "Apellido:";
            // 
            // btnRegistrarNuevoCliente
            // 
            btnRegistrarNuevoCliente.Location = new Point(5, 17);
            btnRegistrarNuevoCliente.Name = "btnRegistrarNuevoCliente";
            btnRegistrarNuevoCliente.Size = new Size(260, 43);
            btnRegistrarNuevoCliente.TabIndex = 10;
            btnRegistrarNuevoCliente.Text = "Registrar Cliente Nuevo";
            btnRegistrarNuevoCliente.UseVisualStyleBackColor = true;
            btnRegistrarNuevoCliente.Click += btnRegistrarNuevoCliente_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(5, 82);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(260, 41);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(174, 182);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(480, 27);
            txtBuscarCliente.TabIndex = 12;
            txtBuscarCliente.TextChanged += txtBuscarCliente_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(5, 176);
            label6.Name = "label6";
            label6.Size = new Size(172, 31);
            label6.TabIndex = 13;
            label6.Text = "Buscar Cliente:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(290, 92);
            label7.Name = "label7";
            label7.Size = new Size(92, 31);
            label7.TabIndex = 14;
            label7.Text = "Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(388, 100);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(266, 27);
            txtCorreo.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(310, 134);
            label8.Name = "label8";
            label8.Size = new Size(72, 31);
            label8.TabIndex = 16;
            label8.Text = "Sexo:";
            // 
            // rbHombre
            // 
            rbHombre.AutoSize = true;
            rbHombre.Location = new Point(388, 141);
            rbHombre.Name = "rbHombre";
            rbHombre.Size = new Size(85, 24);
            rbHombre.TabIndex = 17;
            rbHombre.TabStop = true;
            rbHombre.Text = "Hombre";
            rbHombre.UseVisualStyleBackColor = true;
            // 
            // rbMujer
            // 
            rbMujer.AutoSize = true;
            rbMujer.Location = new Point(479, 141);
            rbMujer.Name = "rbMujer";
            rbMujer.Size = new Size(68, 24);
            rbMujer.TabIndex = 18;
            rbMujer.TabStop = true;
            rbMujer.Text = "Mujer";
            rbMujer.UseVisualStyleBackColor = true;
            rbMujer.CheckedChanged += rbMujer_CheckedChanged;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(784, 15);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(266, 27);
            txtDni.TabIndex = 19;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(716, 11);
            label9.Name = "label9";
            label9.Size = new Size(62, 31);
            label9.TabIndex = 20;
            label9.Text = "DNI:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(660, 52);
            label10.Name = "label10";
            label10.Size = new Size(122, 31);
            label10.TabIndex = 21;
            label10.Text = "Direccion:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(669, 94);
            label11.Name = "label11";
            label11.Size = new Size(113, 31);
            label11.TabIndex = 22;
            label11.Text = "Telefono:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(784, 56);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(266, 27);
            txtDireccion.TabIndex = 23;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(784, 98);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(266, 27);
            txtTelefono.TabIndex = 24;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(566, 134);
            label12.Name = "label12";
            label12.Size = new Size(212, 31);
            label12.TabIndex = 25;
            label12.Text = "Fecha Nacimiento:";
            // 
            // txtFechaNacimiento
            // 
            txtFechaNacimiento.Location = new Point(784, 138);
            txtFechaNacimiento.Name = "txtFechaNacimiento";
            txtFechaNacimiento.Size = new Size(266, 27);
            txtFechaNacimiento.TabIndex = 26;
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1055, 654);
            Controls.Add(txtFechaNacimiento);
            Controls.Add(label12);
            Controls.Add(txtTelefono);
            Controls.Add(txtDireccion);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(txtDni);
            Controls.Add(rbMujer);
            Controls.Add(rbHombre);
            Controls.Add(label8);
            Controls.Add(txtCorreo);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(txtBuscarCliente);
            Controls.Add(btnLimpiar);
            Controls.Add(btnRegistrarNuevoCliente);
            Controls.Add(label5);
            Controls.Add(txtNombreCliente);
            Controls.Add(txtApellidoCliente);
            Controls.Add(dgvRegistroCliente);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormRegistro";
            Load += FormRegistro_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRegistroCliente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DataGridView dgvRegistroCliente;
        private TextBox txtApellidoCliente;
        private TextBox txtNombreCliente;
        private Label label5;
        private Button btnRegistrarNuevoCliente;
        private Button btnLimpiar;
        private TextBox txtBuscarCliente;
        private Label label6;
        private Label label7;
        private TextBox txtCorreo;
        private Label label8;
        private RadioButton rbHombre;
        private RadioButton rbMujer;
        private TextBox txtDni;
        private Label label9;
        private Label label10;
        private Label label11;
        private TextBox txtDireccion;
        private TextBox txtTelefono;
        private Label label12;
        private TextBox txtFechaNacimiento;
    }
}
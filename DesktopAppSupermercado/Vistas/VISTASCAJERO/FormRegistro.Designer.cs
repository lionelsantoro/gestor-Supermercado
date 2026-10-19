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
            label2.Location = new Point(320, 39);
            label2.Name = "label2";
            label2.Size = new Size(0, 31);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(11, 9);
            label3.Name = "label3";
            label3.Size = new Size(189, 31);
            label3.TabIndex = 2;
            label3.Text = "Nombre Cliente:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(264, 19);
            label4.Name = "label4";
            label4.Size = new Size(0, 31);
            label4.TabIndex = 3;
            // 
            // dgvRegistroCliente
            // 
            dgvRegistroCliente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistroCliente.Location = new Point(8, 167);
            dgvRegistroCliente.Name = "dgvRegistroCliente";
            dgvRegistroCliente.RowHeadersWidth = 51;
            dgvRegistroCliente.Size = new Size(467, 484);
            dgvRegistroCliente.TabIndex = 6;
            dgvRegistroCliente.CellContentClick += dgvRegistro_CellContentClick;
            // 
            // txtApellidoCliente
            // 
            txtApellidoCliente.Location = new Point(206, 46);
            txtApellidoCliente.Name = "txtApellidoCliente";
            txtApellidoCliente.ReadOnly = false;
            txtApellidoCliente.Size = new Size(266, 27);
            txtApellidoCliente.TabIndex = 7;
            txtApellidoCliente.KeyPress += txtApellidoCliente_KeyPress;
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(206, 12);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.ReadOnly = false;
            txtNombreCliente.Size = new Size(266, 27);
            txtNombreCliente.TabIndex = 8;
            txtNombreCliente.KeyPress += txtNombreCliente_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(8, 40);
            label5.Name = "label5";
            label5.Size = new Size(192, 31);
            label5.TabIndex = 9;
            label5.Text = "Apellido Cliente:";
            // 
            // btnRegistrarNuevoCliente
            // 
            btnRegistrarNuevoCliente.Location = new Point(8, 77);
            btnRegistrarNuevoCliente.Name = "btnRegistrarNuevoCliente";
            btnRegistrarNuevoCliente.Size = new Size(189, 43);
            btnRegistrarNuevoCliente.TabIndex = 10;
            btnRegistrarNuevoCliente.Text = "Registrar Cliente Nuevo";
            btnRegistrarNuevoCliente.UseVisualStyleBackColor = true;
            btnRegistrarNuevoCliente.Click += btnRegistrarNuevoCliente_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(206, 79);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(266, 41);
            btnLimpiar.TabIndex = 11;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // txtBuscarCliente
            // 
            txtBuscarCliente.Location = new Point(177, 134);
            txtBuscarCliente.Name = "txtBuscarCliente";
            txtBuscarCliente.Size = new Size(295, 27);
            txtBuscarCliente.TabIndex = 12;
            txtBuscarCliente.TextChanged += txtBuscarCliente_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(8, 128);
            label6.Name = "label6";
            label6.Size = new Size(172, 31);
            label6.TabIndex = 13;
            label6.Text = "Buscar Cliente:";
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(480, 654);
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
    }
}
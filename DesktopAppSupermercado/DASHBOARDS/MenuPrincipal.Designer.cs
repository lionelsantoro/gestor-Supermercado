namespace DesktopAppSupermercado
{
    partial class MenuPrincipal
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
            txtContrasena = new TextBox();
            txtUsuario = new TextBox();
            btnIngresar = new Button();
            btnLimpiar = new Button();
            btnAdmin = new ToolStripButton();
            btnCajero = new ToolStripButton();
            btnInventario = new ToolStripButton();
            btnSupervisor = new ToolStripButton();
            toolStrip1 = new ToolStrip();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(68, 159);
            label1.Name = "label1";
            label1.Size = new Size(315, 54);
            label1.TabIndex = 1;
            label1.Text = "Inicio de Sesion";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(105, 239);
            label2.Name = "label2";
            label2.Size = new Size(103, 31);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(68, 295);
            label3.Name = "label3";
            label3.Size = new Size(140, 31);
            label3.TabIndex = 3;
            label3.Text = "Contrasena:";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(214, 299);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(171, 27);
            txtContrasena.TabIndex = 4;
            txtContrasena.TextChanged += textBox1_TextChanged;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(214, 245);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(171, 27);
            txtUsuario.TabIndex = 5;
            // 
            // btnIngresar
            // 
            btnIngresar.Location = new Point(68, 347);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(94, 29);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(226, 347);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(159, 29);
            btnLimpiar.TabIndex = 7;
            btnLimpiar.Text = "Limpiar Campos";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnAdmin
            // 
            btnAdmin.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnAdmin.Image = Properties.Resources.admin11;
            btnAdmin.ImageTransparentColor = Color.Magenta;
            btnAdmin.Name = "btnAdmin";
            btnAdmin.Size = new Size(124, 124);
            btnAdmin.TextAlign = ContentAlignment.BottomCenter;
            btnAdmin.Click += btnAdmin_Click;
            // 
            // btnCajero
            // 
            btnCajero.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnCajero.Image = Properties.Resources.cajero11;
            btnCajero.ImageTransparentColor = Color.Magenta;
            btnCajero.Name = "btnCajero";
            btnCajero.Size = new Size(124, 124);
            btnCajero.Click += btnCajero_Click;
            // 
            // btnInventario
            // 
            btnInventario.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnInventario.Image = Properties.Resources.inventario1;
            btnInventario.ImageTransparentColor = Color.Magenta;
            btnInventario.Name = "btnInventario";
            btnInventario.Size = new Size(124, 124);
            btnInventario.Click += btnInventario_Click;
            // 
            // btnSupervisor
            // 
            btnSupervisor.DisplayStyle = ToolStripItemDisplayStyle.Image;
            btnSupervisor.Image = Properties.Resources.supervisor11;
            btnSupervisor.ImageTransparentColor = Color.Magenta;
            btnSupervisor.Name = "btnSupervisor";
            btnSupervisor.Size = new Size(124, 124);
            btnSupervisor.Click += toolStripButton4_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(120, 120);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAdmin, btnCajero, btnInventario, btnSupervisor });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 2, 0);
            toolStrip1.Size = new Size(521, 127);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(521, 446);
            Controls.Add(btnLimpiar);
            Controls.Add(btnIngresar);
            Controls.Add(txtUsuario);
            Controls.Add(txtContrasena);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            Load += MenuPrincipal_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtContrasena;
        private TextBox txtUsuario;
        private Button btnIngresar;
        private Button btnLimpiar;
        private ToolStripButton btnAdmin;
        private ToolStripButton btnCajero;
        private ToolStripButton btnInventario;
        private ToolStripButton btnSupervisor;
        private ToolStrip toolStrip1;
    }
}
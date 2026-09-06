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
            toolStrip1 = new ToolStrip();
            btnAdmin = new ToolStripButton();
            btnCajero = new ToolStripButton();
            btnInventario = new ToolStripButton();
            btnSupervisor = new ToolStripButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(120, 120);
            toolStrip1.Items.AddRange(new ToolStripItem[] { btnAdmin, btnCajero, btnInventario, btnSupervisor });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Padding = new Padding(0, 0, 3, 0);
            toolStrip1.Size = new Size(840, 130);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(110, 254);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(508, 86);
            label1.TabIndex = 1;
            label1.Text = "Inicio de Sesion";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(171, 382);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(166, 50);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(110, 472);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(227, 50);
            label3.TabIndex = 3;
            label3.Text = "Contrasena:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(348, 478);
            textBox1.Margin = new Padding(5, 5, 5, 5);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(275, 39);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(348, 392);
            textBox2.Margin = new Padding(5, 5, 5, 5);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(275, 39);
            textBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(110, 555);
            button1.Margin = new Padding(5, 5, 5, 5);
            button1.Name = "button1";
            button1.Size = new Size(153, 46);
            button1.TabIndex = 6;
            button1.Text = "Ingresar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(367, 555);
            button2.Margin = new Padding(5, 5, 5, 5);
            button2.Name = "button2";
            button2.Size = new Size(258, 46);
            button2.TabIndex = 7;
            button2.Text = "Limpiar Campos";
            button2.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(840, 714);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Margin = new Padding(5, 5, 5, 5);
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            Load += MenuPrincipal_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton btnAdmin;
        private ToolStripButton btnCajero;
        private ToolStripButton btnInventario;
        private ToolStripButton btnSupervisor;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
    }
}
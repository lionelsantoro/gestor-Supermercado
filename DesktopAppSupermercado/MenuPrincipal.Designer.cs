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
            toolStrip1.Size = new Size(517, 127);
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
            // textBox1
            // 
            textBox1.Location = new Point(214, 299);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(171, 27);
            textBox1.TabIndex = 4;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(214, 245);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(171, 27);
            textBox2.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(68, 347);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 6;
            button1.Text = "Ingresar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(226, 347);
            button2.Name = "button2";
            button2.Size = new Size(159, 29);
            button2.TabIndex = 7;
            button2.Text = "Limpiar Campos";
            button2.UseVisualStyleBackColor = true;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(517, 446);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(toolStrip1);
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
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
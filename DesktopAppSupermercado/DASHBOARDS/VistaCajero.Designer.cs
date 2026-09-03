namespace DesktopAppSupermercado
{
    partial class VistaCajero
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
            panel1 = new Panel();
            btnPagar = new Button();
            panel2 = new Panel();
            btnCargarProducto = new Button();
            btnModificarCompra = new Button();
            btnIconoCajero = new Button();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnPagar);
            panel1.Controls.Add(btnModificarCompra);
            panel1.Controls.Add(btnIconoCajero);
            panel1.Controls.Add(btnCargarProducto);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(100, 586);
            panel1.TabIndex = 0;
            // 
            // btnPagar
            // 
            btnPagar.BackColor = SystemColors.ButtonFace;
            btnPagar.Image = Properties.Resources.pagar1;
            btnPagar.Location = new Point(0, 246);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(94, 75);
            btnPagar.TabIndex = 1;
            btnPagar.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 224, 192);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(100, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(699, 586);
            panel2.TabIndex = 1;
            // 
            // btnCargarProducto
            // 
            btnCargarProducto.Image = Properties.Resources.agregarprodct3;
            btnCargarProducto.Location = new Point(0, 84);
            btnCargarProducto.Name = "btnCargarProducto";
            btnCargarProducto.Size = new Size(94, 75);
            btnCargarProducto.TabIndex = 2;
            btnCargarProducto.UseVisualStyleBackColor = true;
            // 
            // btnModificarCompra
            // 
            btnModificarCompra.Image = Properties.Resources.modificar1;
            btnModificarCompra.Location = new Point(0, 165);
            btnModificarCompra.Name = "btnModificarCompra";
            btnModificarCompra.Size = new Size(94, 75);
            btnModificarCompra.TabIndex = 3;
            btnModificarCompra.UseVisualStyleBackColor = true;
            btnModificarCompra.Click += btnModificarCompra_Click;
            // 
            // btnIconoCajero
            // 
            btnIconoCajero.Image = Properties.Resources.cajero21;
            btnIconoCajero.Location = new Point(0, 3);
            btnIconoCajero.Name = "btnIconoCajero";
            btnIconoCajero.Size = new Size(94, 75);
            btnIconoCajero.TabIndex = 4;
            btnIconoCajero.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ActiveCaption;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(699, 125);
            panel3.TabIndex = 0;
            // 
            // VistaCajero
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(799, 586);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "VistaCajero";
            Text = "VistaCajero";
            Load += VistaCajero_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnPagar;
        private Panel panel2;
        private Button btnCargarProducto;
        private Button btnModificarCompra;
        private Button btnIconoCajero;
        private Panel panel3;
    }
}
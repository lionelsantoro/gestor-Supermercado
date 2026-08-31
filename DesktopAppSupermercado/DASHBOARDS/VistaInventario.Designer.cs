namespace DesktopAppSupermercado.DASHBOARDS
{
    partial class VistaInventario
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
            PanelContenedor = new Panel();
            PanelMenu = new Panel();
            btnSalirC = new Button();
            btnReportesC = new Button();
            btnVentas = new Button();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(131, 0);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(669, 450);
            PanelContenedor.TabIndex = 5;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnSalirC);
            PanelMenu.Controls.Add(btnReportesC);
            PanelMenu.Controls.Add(btnVentas);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(131, 450);
            PanelMenu.TabIndex = 4;
            // 
            // btnSalirC
            // 
            btnSalirC.Dock = DockStyle.Bottom;
            btnSalirC.FlatStyle = FlatStyle.Flat;
            btnSalirC.ForeColor = SystemColors.ActiveCaptionText;
            btnSalirC.Location = new Point(0, 397);
            btnSalirC.Name = "btnSalirC";
            btnSalirC.Size = new Size(131, 53);
            btnSalirC.TabIndex = 1;
            btnSalirC.Text = "Salir";
            btnSalirC.UseVisualStyleBackColor = true;
            // 
            // btnReportesC
            // 
            btnReportesC.FlatStyle = FlatStyle.Flat;
            btnReportesC.Location = new Point(7, 186);
            btnReportesC.Name = "btnReportesC";
            btnReportesC.Size = new Size(118, 52);
            btnReportesC.TabIndex = 1;
            btnReportesC.Text = "Reportes";
            btnReportesC.UseVisualStyleBackColor = true;
            // 
            // btnVentas
            // 
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Location = new Point(0, 0);
            btnVentas.Name = "btnVentas";
            btnVentas.Size = new Size(131, 45);
            btnVentas.TabIndex = 1;
            btnVentas.Text = "Productos";
            btnVentas.UseVisualStyleBackColor = true;
            // 
            // VistaInventario
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Name = "VistaInventario";
            Text = "VistaInventario";
            PanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenedor;
        private Panel PanelMenu;
        private Button btnSalirC;
        private Button btnReportesC;
        private Button btnVentas;
    }
}
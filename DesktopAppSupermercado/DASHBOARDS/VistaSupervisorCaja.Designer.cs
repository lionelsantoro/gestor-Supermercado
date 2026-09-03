namespace DesktopAppSupermercado.DASHBOARDS
{
    partial class VistaSupervisorCaja
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
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(78, 0);
            PanelContenedor.Margin = new Padding(2);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(414, 257);
            PanelContenedor.TabIndex = 5;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnSalirC);
            PanelMenu.Controls.Add(btnReportesC);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Margin = new Padding(2);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(78, 257);
            PanelMenu.TabIndex = 4;
            // 
            // btnSalirC
            // 
            btnSalirC.Dock = DockStyle.Bottom;
            btnSalirC.FlatStyle = FlatStyle.Flat;
            btnSalirC.ForeColor = SystemColors.ActiveCaptionText;
            btnSalirC.Location = new Point(0, 224);
            btnSalirC.Margin = new Padding(2);
            btnSalirC.Name = "btnSalirC";
            btnSalirC.Size = new Size(78, 33);
            btnSalirC.TabIndex = 1;
            btnSalirC.Text = "Salir";
            btnSalirC.UseVisualStyleBackColor = true;
            // 
            // btnReportesC
            // 
            btnReportesC.FlatStyle = FlatStyle.Flat;
            btnReportesC.Location = new Point(0, 138);
            btnReportesC.Margin = new Padding(2);
            btnReportesC.Name = "btnReportesC";
            btnReportesC.Size = new Size(77, 32);
            btnReportesC.TabIndex = 1;
            btnReportesC.Text = "Reportes";
            btnReportesC.UseVisualStyleBackColor = true;
            btnReportesC.Click += btnReportesC_Click;
            // 
            // VistaSupervisorCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(492, 257);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Margin = new Padding(2);
            Name = "VistaSupervisorCaja";
            Text = "VistaSupervisorCaja";
            PanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenedor;
        private Panel PanelMenu;
        private Button btnSalirC;
        private Button btnReportesC;
    }
}
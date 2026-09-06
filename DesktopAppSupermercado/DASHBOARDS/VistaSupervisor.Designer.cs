namespace DesktopAppSupermercado.DASHBOARDS
{
    partial class VistaSupervisor
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
            btnSalirSUPERVISOR = new Button();
            btnReportesSUPERVISOR = new Button();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(131, 0);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(1122, 668);
            PanelContenedor.TabIndex = 5;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnSalirSUPERVISOR);
            PanelMenu.Controls.Add(btnReportesSUPERVISOR);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(131, 668);
            PanelMenu.TabIndex = 4;
            // 
            // btnSalirSUPERVISOR
            // 
            btnSalirSUPERVISOR.Dock = DockStyle.Bottom;
            btnSalirSUPERVISOR.FlatStyle = FlatStyle.Flat;
            btnSalirSUPERVISOR.ForeColor = SystemColors.ActiveCaptionText;
            btnSalirSUPERVISOR.Location = new Point(0, 491);
            btnSalirSUPERVISOR.Name = "btnSalirSUPERVISOR";
            btnSalirSUPERVISOR.Size = new Size(131, 177);
            btnSalirSUPERVISOR.TabIndex = 1;
            btnSalirSUPERVISOR.Text = "Salir";
            btnSalirSUPERVISOR.UseVisualStyleBackColor = true;
            btnSalirSUPERVISOR.Click += btnSalirC_Click;
            // 
            // btnReportesSUPERVISOR
            // 
            btnReportesSUPERVISOR.FlatStyle = FlatStyle.Flat;
            btnReportesSUPERVISOR.Location = new Point(7, 37);
            btnReportesSUPERVISOR.Name = "btnReportesSUPERVISOR";
            btnReportesSUPERVISOR.Size = new Size(118, 218);
            btnReportesSUPERVISOR.TabIndex = 1;
            btnReportesSUPERVISOR.Text = "Reportes";
            btnReportesSUPERVISOR.UseVisualStyleBackColor = true;
            // 
            // VistaSupervisor
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1253, 668);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Name = "VistaSupervisor";
            Text = "VistaSupervisor";
            PanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenedor;
        private Panel PanelMenu;
        private Button btnSalirSUPERVISOR;
        private Button btnReportesSUPERVISOR;
    }
}
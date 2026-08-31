namespace DesktopAppSupermercado
{
    partial class VistaAdmin
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
            PanelMenu = new Panel();
            btnSalir = new Button();
            btnReportes = new Button();
            btnBackup = new Button();
            btnUsuarios = new Button();
            PanelContenedor = new Panel();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnSalir);
            PanelMenu.Controls.Add(btnReportes);
            PanelMenu.Controls.Add(btnBackup);
            PanelMenu.Controls.Add(btnUsuarios);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(131, 808);
            PanelMenu.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.Dock = DockStyle.Bottom;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.ForeColor = SystemColors.ActiveCaptionText;
            btnSalir.Location = new Point(0, 755);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(131, 53);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnReportes
            // 
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Location = new Point(3, 499);
            btnReportes.Name = "btnReportes";
            btnReportes.Size = new Size(118, 52);
            btnReportes.TabIndex = 1;
            btnReportes.Text = "Reportes";
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnBackup
            // 
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Location = new Point(7, 252);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(118, 46);
            btnBackup.TabIndex = 1;
            btnBackup.Text = "BackUp";
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Location = new Point(0, 0);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(131, 45);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(131, 0);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(1902, 808);
            PanelContenedor.TabIndex = 1;
            // 
            // VistaAdmin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2033, 808);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Name = "VistaAdmin";
            Text = "VistaAdmin";
            WindowState = FormWindowState.Maximized;
            PanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelMenu;
        private Button btnUsuarios;
        private Button btnReportes;
        private Button btnBackup;
        private Button btnSalir;
        private Panel PanelContenedor;
    }
}
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
            btnSalirADMIN = new Button();
            btnBackupADMIN = new Button();
            btnUsuariosADMIN = new Button();
            PanelContenedor = new Panel();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnSalirADMIN);
            PanelMenu.Controls.Add(btnBackupADMIN);
            PanelMenu.Controls.Add(btnUsuariosADMIN);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(131, 808);
            PanelMenu.TabIndex = 0;
            // 
            // btnSalirADMIN
            // 
            btnSalirADMIN.Dock = DockStyle.Bottom;
            btnSalirADMIN.FlatStyle = FlatStyle.Flat;
            btnSalirADMIN.ForeColor = SystemColors.ActiveCaptionText;
            btnSalirADMIN.Location = new Point(0, 596);
            btnSalirADMIN.Name = "btnSalirADMIN";
            btnSalirADMIN.Size = new Size(131, 212);
            btnSalirADMIN.TabIndex = 1;
            btnSalirADMIN.Text = "Salir";
            btnSalirADMIN.UseVisualStyleBackColor = true;
            btnSalirADMIN.Click += btnSalir_Click;
            // 
            // btnBackupADMIN
            // 
            btnBackupADMIN.FlatStyle = FlatStyle.Flat;
            btnBackupADMIN.Location = new Point(7, 297);
            btnBackupADMIN.Name = "btnBackupADMIN";
            btnBackupADMIN.Size = new Size(118, 265);
            btnBackupADMIN.TabIndex = 1;
            btnBackupADMIN.Text = "BackUp";
            btnBackupADMIN.UseVisualStyleBackColor = true;
            btnBackupADMIN.Click += btnBackup_Click;
            // 
            // btnUsuariosADMIN
            // 
            btnUsuariosADMIN.Dock = DockStyle.Top;
            btnUsuariosADMIN.FlatStyle = FlatStyle.Flat;
            btnUsuariosADMIN.Location = new Point(0, 0);
            btnUsuariosADMIN.Name = "btnUsuariosADMIN";
            btnUsuariosADMIN.Size = new Size(131, 277);
            btnUsuariosADMIN.TabIndex = 1;
            btnUsuariosADMIN.Text = "Usuarios";
            btnUsuariosADMIN.UseVisualStyleBackColor = true;
            btnUsuariosADMIN.Click += btnUsuarios_Click;
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
        private Button btnUsuariosADMIN;
        private Button btnBackupADMIN;
        private Button btnSalirADMIN;
        private Panel PanelContenedor;
    }
}
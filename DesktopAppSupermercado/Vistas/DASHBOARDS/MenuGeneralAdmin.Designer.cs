using System;
using System.Drawing;
using System.Windows.Forms;

namespace DesktopAppSupermercado.DASHBOARDS
{
    partial class MenuGeneralAdmin
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
            PanelMenu.Size = new Size(139, 808);
            PanelMenu.TabIndex = 0;
            // 
            // btnSalirADMIN
            // 
            btnSalirADMIN.Dock = DockStyle.Bottom;
            btnSalirADMIN.FlatStyle = FlatStyle.Flat;
            btnSalirADMIN.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalirADMIN.ForeColor = SystemColors.ButtonHighlight;
            btnSalirADMIN.Image = Properties.Resources.logout_90894__2_;
            btnSalirADMIN.ImageAlign = ContentAlignment.TopCenter;
            btnSalirADMIN.Location = new Point(0, 596);
            btnSalirADMIN.Name = "btnSalirADMIN";
            btnSalirADMIN.Size = new Size(139, 212);
            btnSalirADMIN.TabIndex = 1;
            btnSalirADMIN.Text = "Salir";
            btnSalirADMIN.TextAlign = ContentAlignment.BottomCenter;
            btnSalirADMIN.UseVisualStyleBackColor = true;
            btnSalirADMIN.Click += btnSalir_Click;
            // 
            // btnBackupADMIN
            // 
            btnBackupADMIN.BackgroundImage = Properties.Resources.ic_settings_backup_restore_128_28716;
            btnBackupADMIN.FlatStyle = FlatStyle.Flat;
            btnBackupADMIN.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnBackupADMIN.ForeColor = SystemColors.ControlLightLight;
            btnBackupADMIN.ImageAlign = ContentAlignment.TopCenter;
            btnBackupADMIN.Location = new Point(7, 297);
            btnBackupADMIN.Name = "btnBackupADMIN";
            btnBackupADMIN.Size = new Size(118, 138);
            btnBackupADMIN.TabIndex = 1;
            btnBackupADMIN.Text = "BackUp";
            btnBackupADMIN.TextAlign = ContentAlignment.BottomCenter;
            btnBackupADMIN.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnBackupADMIN.UseVisualStyleBackColor = true;
            btnBackupADMIN.Click += btnBackup_Click;
            // 
            // btnUsuariosADMIN
            // 
            btnUsuariosADMIN.BackgroundImage = Properties.Resources.community_users_12977;
            btnUsuariosADMIN.Dock = DockStyle.Top;
            btnUsuariosADMIN.FlatStyle = FlatStyle.Flat;
            btnUsuariosADMIN.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUsuariosADMIN.ForeColor = SystemColors.HighlightText;
            btnUsuariosADMIN.Location = new Point(0, 0);
            btnUsuariosADMIN.Name = "btnUsuariosADMIN";
            btnUsuariosADMIN.Size = new Size(139, 133);
            btnUsuariosADMIN.TabIndex = 1;
            btnUsuariosADMIN.Text = "Usuarios";
            btnUsuariosADMIN.TextAlign = ContentAlignment.BottomCenter;
            btnUsuariosADMIN.UseVisualStyleBackColor = true;
            btnUsuariosADMIN.Click += btnUsuarios_Click;
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(139, 0);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(1894, 808);
            PanelContenedor.TabIndex = 1;
            PanelContenedor.Paint += PanelContenedor_Paint;
            // 
            // MenuGeneralAdmin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2033, 808);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Name = "MenuGeneralAdmin";
            Text = "Menu General Admin";
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
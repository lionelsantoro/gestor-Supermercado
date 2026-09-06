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
            PanelContenedor = new Panel();
            PanelMenu = new Panel();
            this.btnSalirCAJERO = new Button();
            btnClientesCAJERO = new Button();
            btnVentasCAJERO = new Button();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(131, 0);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(1746, 938);
            PanelContenedor.TabIndex = 3;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnVentasCAJERO);
            PanelMenu.Controls.Add(this.btnSalirCAJERO);
            PanelMenu.Controls.Add(btnClientesCAJERO);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(131, 938);
            PanelMenu.TabIndex = 2;
            // 
            // btnSalirCAJERO
            // 
            this.btnSalirCAJERO.Dock = DockStyle.Bottom;
            this.btnSalirCAJERO.FlatStyle = FlatStyle.Flat;
            this.btnSalirCAJERO.ForeColor = SystemColors.ActiveCaptionText;
            this.btnSalirCAJERO.Location = new Point(0, 669);
            this.btnSalirCAJERO.Name = "btnSalirCAJERO";
            this.btnSalirCAJERO.Size = new Size(131, 269);
            this.btnSalirCAJERO.TabIndex = 1;
            this.btnSalirCAJERO.Text = "Salir";
            this.btnSalirCAJERO.UseVisualStyleBackColor = true;
            // 
            // btnClientesCAJERO
            // 
            btnClientesCAJERO.Dock = DockStyle.Top;
            btnClientesCAJERO.FlatStyle = FlatStyle.Flat;
            btnClientesCAJERO.Location = new Point(0, 0);
            btnClientesCAJERO.Name = "btnClientesCAJERO";
            btnClientesCAJERO.Size = new Size(131, 294);
            btnClientesCAJERO.TabIndex = 1;
            btnClientesCAJERO.Text = "Clientes";
            btnClientesCAJERO.UseVisualStyleBackColor = true;
            // 
            // btnVentasCAJERO
            // 
            btnVentasCAJERO.BackColor = SystemColors.ActiveCaption;
            btnVentasCAJERO.Location = new Point(0, 320);
            btnVentasCAJERO.Name = "btnVentasCAJERO";
            btnVentasCAJERO.Size = new Size(127, 300);
            btnVentasCAJERO.TabIndex = 0;
            btnVentasCAJERO.Text = "Ventas";
            btnVentasCAJERO.UseVisualStyleBackColor = false;
            // 
            // VistaCajero
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1877, 938);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Margin = new Padding(5, 5, 5, 5);
            Name = "VistaCajero";
            Text = "VistaCajero";
            Load += VistaCajero_Load;
            PanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenedor;
        private Panel PanelMenu;
        private Button btnSalir;
        private Button btnReportes;
        private Button btnBackup;
        private Button btnClientesCAJERO;
        private Button btnVentasCAJERO;
    }
}
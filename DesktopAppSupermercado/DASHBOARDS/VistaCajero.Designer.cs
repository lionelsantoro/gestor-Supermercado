namespace DesktopAppSupermercado
{
    partial class VistaCajero
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            PanelContenedor = new Panel();
            PanelMenu = new Panel();
            btnSalirCAJERO = new Button();
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
            PanelContenedor.Size = new Size(1601, 916);
            PanelContenedor.TabIndex = 3;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnSalirCAJERO);
            PanelMenu.Controls.Add(btnClientesCAJERO);
            PanelMenu.Controls.Add(btnVentasCAJERO);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(131, 916);
            PanelMenu.TabIndex = 2;
            // 
            // btnSalirCAJERO
            // 
            btnSalirCAJERO.Dock = DockStyle.Bottom;
            btnSalirCAJERO.FlatStyle = FlatStyle.Flat;
            btnSalirCAJERO.ForeColor = SystemColors.ActiveCaptionText;
            btnSalirCAJERO.Location = new Point(0, 863);
            btnSalirCAJERO.Name = "btnSalirCAJERO";
            btnSalirCAJERO.Size = new Size(131, 53);
            btnSalirCAJERO.TabIndex = 2;
            btnSalirCAJERO.Text = "Salir";
            btnSalirCAJERO.UseVisualStyleBackColor = true;
            // 
            // btnClientesCAJERO
            // 
            btnClientesCAJERO.Dock = DockStyle.Top;
            btnClientesCAJERO.FlatStyle = FlatStyle.Flat;
            btnClientesCAJERO.Location = new Point(0, 45);
            btnClientesCAJERO.Name = "btnClientesCAJERO";
            btnClientesCAJERO.Size = new Size(131, 45);
            btnClientesCAJERO.TabIndex = 1;
            btnClientesCAJERO.Text = "Clientes";
            btnClientesCAJERO.UseVisualStyleBackColor = true;
            btnClientesCAJERO.Click += btnClientesCAJERO_Click;
            // 
            // btnVentasCAJERO
            // 
            btnVentasCAJERO.Dock = DockStyle.Top;
            btnVentasCAJERO.FlatStyle = FlatStyle.Flat;
            btnVentasCAJERO.Location = new Point(0, 0);
            btnVentasCAJERO.Name = "btnVentasCAJERO";
            btnVentasCAJERO.Size = new Size(131, 45);
            btnVentasCAJERO.TabIndex = 0;
            btnVentasCAJERO.Text = "Ventas";
            btnVentasCAJERO.UseVisualStyleBackColor = true;
            // 
            // VistaCajero
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1732, 916);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Name = "VistaCajero";
            Text = "VistaCajero";
            PanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenedor;
        private Panel PanelMenu;
        private Button btnSalirCAJERO;
        private Button btnClientesCAJERO;
        private Button btnVentasCAJERO;
    }
}
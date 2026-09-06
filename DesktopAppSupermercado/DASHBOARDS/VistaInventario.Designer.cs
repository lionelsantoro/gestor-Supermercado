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
            btnSalirINVENTARIO = new Button();
            btnGestionProductosyCategoriasINVENTARIO = new Button();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(131, 0);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(1640, 610);
            PanelContenedor.TabIndex = 5;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnGestionProductosyCategoriasINVENTARIO);
            PanelMenu.Controls.Add(btnSalirINVENTARIO);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(131, 610);
            PanelMenu.TabIndex = 4;
            // 
            // btnSalirINVENTARIO
            // 
            btnSalirINVENTARIO.Dock = DockStyle.Bottom;
            btnSalirINVENTARIO.FlatStyle = FlatStyle.Flat;
            btnSalirINVENTARIO.ForeColor = SystemColors.ActiveCaptionText;
            btnSalirINVENTARIO.Location = new Point(0, 323);
            btnSalirINVENTARIO.Name = "btnSalirINVENTARIO";
            btnSalirINVENTARIO.Size = new Size(131, 287);
            btnSalirINVENTARIO.TabIndex = 1;
            btnSalirINVENTARIO.Text = "Salir";
            btnSalirINVENTARIO.UseVisualStyleBackColor = true;
            // 
            // btnGestionProductosyCategoriasINVENTARIO
            // 
            btnGestionProductosyCategoriasINVENTARIO.BackColor = SystemColors.ActiveCaption;
            btnGestionProductosyCategoriasINVENTARIO.Location = new Point(0, 32);
            btnGestionProductosyCategoriasINVENTARIO.Name = "btnGestionProductosyCategoriasINVENTARIO";
            btnGestionProductosyCategoriasINVENTARIO.Size = new Size(135, 272);
            btnGestionProductosyCategoriasINVENTARIO.TabIndex = 0;
            btnGestionProductosyCategoriasINVENTARIO.Text = "Gestion Productos y Categorias";
            btnGestionProductosyCategoriasINVENTARIO.UseVisualStyleBackColor = false;
            // 
            // VistaInventario
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1771, 610);
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
        private Button btnSalirINVENTARIO;
        private Button btnGestionProductosyCategoriasINVENTARIO;
    }
}
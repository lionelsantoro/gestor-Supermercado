namespace DesktopAppSupermercado.DASHBOARDS
{
    partial class MenuGeneralInventario
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
            btnGestionProductosyCategoriasINVENTARIO = new Button();
            btnSalirINVENTARIO = new Button();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(156, 0);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(1615, 610);
            PanelContenedor.TabIndex = 5;
            PanelContenedor.Paint += PanelContenedor_Paint;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnGestionProductosyCategoriasINVENTARIO);
            PanelMenu.Controls.Add(btnSalirINVENTARIO);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(156, 610);
            PanelMenu.TabIndex = 4;
            // 
            // btnGestionProductosyCategoriasINVENTARIO
            // 
            btnGestionProductosyCategoriasINVENTARIO.BackColor = SystemColors.ActiveCaption;
            btnGestionProductosyCategoriasINVENTARIO.Font = new Font("Arial Black", 7.875F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGestionProductosyCategoriasINVENTARIO.ForeColor = SystemColors.ButtonHighlight;
            btnGestionProductosyCategoriasINVENTARIO.Image = Properties.Resources._3890929_chart_growth_invest_market_stock_111188;
            btnGestionProductosyCategoriasINVENTARIO.ImageAlign = ContentAlignment.TopCenter;
            btnGestionProductosyCategoriasINVENTARIO.Location = new Point(0, 32);
            btnGestionProductosyCategoriasINVENTARIO.Name = "btnGestionProductosyCategoriasINVENTARIO";
            btnGestionProductosyCategoriasINVENTARIO.Size = new Size(156, 272);
            btnGestionProductosyCategoriasINVENTARIO.TabIndex = 0;
            btnGestionProductosyCategoriasINVENTARIO.Text = "Gestion de Productos y Categorias";
            btnGestionProductosyCategoriasINVENTARIO.TextAlign = ContentAlignment.BottomCenter;
            btnGestionProductosyCategoriasINVENTARIO.UseVisualStyleBackColor = false;
            btnGestionProductosyCategoriasINVENTARIO.Click += btnGestionProductosyCategoriasINVENTARIO_Click;
            // 
            // btnSalirINVENTARIO
            // 
            btnSalirINVENTARIO.BackColor = SystemColors.ActiveCaption;
            btnSalirINVENTARIO.Dock = DockStyle.Bottom;
            btnSalirINVENTARIO.FlatStyle = FlatStyle.Flat;
            btnSalirINVENTARIO.Font = new Font("Arial Black", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalirINVENTARIO.ForeColor = SystemColors.ButtonHighlight;
            btnSalirINVENTARIO.Image = Properties.Resources.logout_90894__2_1;
            btnSalirINVENTARIO.ImageAlign = ContentAlignment.TopCenter;
            btnSalirINVENTARIO.Location = new Point(0, 323);
            btnSalirINVENTARIO.Name = "btnSalirINVENTARIO";
            btnSalirINVENTARIO.Size = new Size(156, 287);
            btnSalirINVENTARIO.TabIndex = 1;
            btnSalirINVENTARIO.Text = "Salir";
            btnSalirINVENTARIO.TextAlign = ContentAlignment.BottomCenter;
            btnSalirINVENTARIO.UseVisualStyleBackColor = false;
            // 
            // MenuGeneralInventario
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1771, 610);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Name = "MenuGeneralInventario";
            Text = "Menu General Inventario";
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
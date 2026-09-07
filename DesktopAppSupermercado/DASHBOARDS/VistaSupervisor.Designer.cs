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
            txtBuscar = new TextBox();
            label1 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dgvVentas = new DataGridView();
            IdVenta = new DataGridViewTextBoxColumn();
            Monto = new DataGridViewTextBoxColumn();
            MedioPago = new DataGridViewTextBoxColumn();
            VentaBanco = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            dgvProductosVendidos = new DataGridView();
            IdProducto = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Stockk = new DataGridViewTextBoxColumn();
            Kilogramoo = new DataGridViewTextBoxColumn();
            Unidad = new DataGridViewTextBoxColumn();
            tabPage3 = new TabPage();
            dgvControlInventario = new DataGridView();
            IdHistorial = new DataGridViewTextBoxColumn();
            NombreUsuario = new DataGridViewTextBoxColumn();
            NombreProducto = new DataGridViewTextBoxColumn();
            Cambio = new DataGridViewTextBoxColumn();
            FechaCambio = new DataGridViewTextBoxColumn();
            PanelMenu = new Panel();
            btnSalir = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            PanelContenedor.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductosVendidos).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvControlInventario).BeginInit();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Controls.Add(txtBuscar);
            PanelContenedor.Controls.Add(label1);
            PanelContenedor.Controls.Add(tabControl1);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(115, 0);
            PanelContenedor.Margin = new Padding(2);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(848, 781);
            PanelContenedor.TabIndex = 5;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(92, 15);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(333, 27);
            txtBuscar.TabIndex = 2;
            txtBuscar.TextChanged += txtBuscar_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 9);
            label1.Name = "label1";
            label1.Size = new Size(92, 31);
            label1.TabIndex = 1;
            label1.Text = "Buscar:";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Location = new Point(0, 50);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(845, 731);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvVentas);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(837, 698);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ventas Realizadas";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Columns.AddRange(new DataGridViewColumn[] { IdVenta, Monto, MedioPago, VentaBanco });
            dgvVentas.Location = new Point(6, 6);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(823, 734);
            dgvVentas.TabIndex = 0;
            dgvVentas.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // IdVenta
            // 
            IdVenta.HeaderText = "Numero de venta";
            IdVenta.MinimumWidth = 6;
            IdVenta.Name = "IdVenta";
            IdVenta.Width = 125;
            // 
            // Monto
            // 
            Monto.HeaderText = "Total";
            Monto.MinimumWidth = 6;
            Monto.Name = "Monto";
            Monto.Width = 125;
            // 
            // MedioPago
            // 
            MedioPago.HeaderText = "Medio de Pago";
            MedioPago.MinimumWidth = 6;
            MedioPago.Name = "MedioPago";
            MedioPago.Width = 125;
            // 
            // VentaBanco
            // 
            VentaBanco.HeaderText = "Banco";
            VentaBanco.MinimumWidth = 6;
            VentaBanco.Name = "VentaBanco";
            VentaBanco.Width = 125;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvProductosVendidos);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(837, 698);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Productos Vendidos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvProductosVendidos
            // 
            dgvProductosVendidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosVendidos.Columns.AddRange(new DataGridViewColumn[] { IdProducto, Nombre, Precio, Stockk, Kilogramoo, Unidad });
            dgvProductosVendidos.Location = new Point(6, 6);
            dgvProductosVendidos.Name = "dgvProductosVendidos";
            dgvProductosVendidos.RowHeadersWidth = 51;
            dgvProductosVendidos.Size = new Size(825, 684);
            dgvProductosVendidos.TabIndex = 0;
            // 
            // IdProducto
            // 
            IdProducto.HeaderText = "Numero de Producto";
            IdProducto.MinimumWidth = 6;
            IdProducto.Name = "IdProducto";
            IdProducto.Width = 125;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Descripcion";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio Unitario";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.Width = 125;
            // 
            // Stockk
            // 
            Stockk.HeaderText = "Stock";
            Stockk.MinimumWidth = 6;
            Stockk.Name = "Stockk";
            Stockk.Width = 125;
            // 
            // Kilogramoo
            // 
            Kilogramoo.HeaderText = "Kilogramo";
            Kilogramoo.MinimumWidth = 6;
            Kilogramoo.Name = "Kilogramoo";
            Kilogramoo.Width = 125;
            // 
            // Unidad
            // 
            Unidad.HeaderText = "Unidad de Medida";
            Unidad.MinimumWidth = 6;
            Unidad.Name = "Unidad";
            Unidad.Width = 125;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dgvControlInventario);
            tabPage3.Location = new Point(4, 29);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(837, 698);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Control de Inventario";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgvControlInventario
            // 
            dgvControlInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvControlInventario.Columns.AddRange(new DataGridViewColumn[] { IdHistorial, NombreUsuario, NombreProducto, Cambio, FechaCambio });
            dgvControlInventario.Location = new Point(6, 6);
            dgvControlInventario.Name = "dgvControlInventario";
            dgvControlInventario.RowHeadersWidth = 51;
            dgvControlInventario.Size = new Size(828, 684);
            dgvControlInventario.TabIndex = 0;
            // 
            // IdHistorial
            // 
            IdHistorial.HeaderText = "Id Historial";
            IdHistorial.MinimumWidth = 6;
            IdHistorial.Name = "IdHistorial";
            IdHistorial.Width = 125;
            // 
            // NombreUsuario
            // 
            NombreUsuario.HeaderText = "Nombre del Empleado";
            NombreUsuario.MinimumWidth = 6;
            NombreUsuario.Name = "NombreUsuario";
            NombreUsuario.Width = 125;
            // 
            // NombreProducto
            // 
            NombreProducto.HeaderText = "Producto Modificado";
            NombreProducto.MinimumWidth = 6;
            NombreProducto.Name = "NombreProducto";
            NombreProducto.Width = 125;
            // 
            // Cambio
            // 
            Cambio.HeaderText = "Accion";
            Cambio.MinimumWidth = 6;
            Cambio.Name = "Cambio";
            Cambio.Width = 125;
            // 
            // FechaCambio
            // 
            FechaCambio.HeaderText = "Fecha";
            FechaCambio.MinimumWidth = 6;
            FechaCambio.Name = "FechaCambio";
            FechaCambio.Width = 125;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(btnSalir);
            PanelMenu.Controls.Add(button3);
            PanelMenu.Controls.Add(button2);
            PanelMenu.Controls.Add(button1);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Margin = new Padding(2);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(115, 781);
            PanelMenu.TabIndex = 4;
            // 
            // btnSalir
            // 
            btnSalir.Image = Properties.Resources.salie;
            btnSalir.Location = new Point(13, 642);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(97, 127);
            btnSalir.TabIndex = 3;
            btnSalir.Text = "Salir";
            btnSalir.TextAlign = ContentAlignment.BottomCenter;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click_1;
            // 
            // button3
            // 
            button3.Image = Properties.Resources.reporte;
            button3.Location = new Point(13, 278);
            button3.Name = "button3";
            button3.Size = new Size(97, 127);
            button3.TabIndex = 2;
            button3.Text = "Inventario";
            button3.TextAlign = ContentAlignment.BottomCenter;
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.reporte;
            button2.Location = new Point(13, 145);
            button2.Name = "button2";
            button2.Size = new Size(97, 127);
            button2.TabIndex = 1;
            button2.Text = "Productos";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.reporte;
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(97, 127);
            button1.TabIndex = 0;
            button1.Text = "Ventas";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            // 
            // VistaSupervisor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(963, 781);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Margin = new Padding(2);
            Name = "VistaSupervisor";
            Text = "VistaSupervisor";
            PanelContenedor.ResumeLayout(false);
            PanelContenedor.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductosVendidos).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvControlInventario).EndInit();
            PanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenedor;
        private Panel PanelMenu;
        private Button button1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Button button3;
        private Button button2;
        private DataGridView dgvVentas;
        private DataGridViewTextBoxColumn IdVenta;
        private DataGridViewTextBoxColumn Monto;
        private DataGridViewTextBoxColumn MedioPago;
        private DataGridViewTextBoxColumn VentaBanco;
        private TextBox txtBuscar;
        private Label label1;
        private DataGridView dgvProductosVendidos;
        private DataGridView dgvControlInventario;
        private DataGridViewTextBoxColumn IdProducto;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Stockk;
        private DataGridViewTextBoxColumn Kilogramoo;
        private DataGridViewTextBoxColumn Unidad;
        private DataGridViewTextBoxColumn IdHistorial;
        private DataGridViewTextBoxColumn NombreUsuario;
        private DataGridViewTextBoxColumn NombreProducto;
        private DataGridViewTextBoxColumn Cambio;
        private DataGridViewTextBoxColumn FechaCambio;
        private Button btnSalir;
    }
}
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
            CajaVenta = new DataGridViewTextBoxColumn();
            CajeroVenta = new DataGridViewTextBoxColumn();
            tabPage2 = new TabPage();
            dgvProductosVendidos = new DataGridView();
            IdProducto = new DataGridViewTextBoxColumn();
            Nombre = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Cantidadd = new DataGridViewTextBoxColumn();
            Kilogramoo = new DataGridViewTextBoxColumn();
            Unidad = new DataGridViewTextBoxColumn();
            tabPage4 = new TabPage();
            dataGridView1 = new DataGridView();
            IdEmpleado = new DataGridViewTextBoxColumn();
            NombreUsuario = new DataGridViewTextBoxColumn();
            ApellidoUsuario = new DataGridViewTextBoxColumn();
            RolUsuario = new DataGridViewTextBoxColumn();
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
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            PanelContenedor.Size = new Size(1114, 781);
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
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Location = new Point(0, 50);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1111, 731);
            tabControl1.TabIndex = 0;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvVentas);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1103, 698);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ventas Realizadas";
            tabPage1.UseVisualStyleBackColor = true;
            tabPage1.Click += tabPage1_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Columns.AddRange(new DataGridViewColumn[] { IdVenta, Monto, MedioPago, VentaBanco, CajaVenta, CajeroVenta });
            dgvVentas.Location = new Point(6, 6);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(1091, 734);
            dgvVentas.TabIndex = 0;
            dgvVentas.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // IdVenta
            // 
            IdVenta.DataPropertyName = "Numero de Venta";
            IdVenta.HeaderText = "Numero de venta";
            IdVenta.MinimumWidth = 6;
            IdVenta.Name = "IdVenta";
            IdVenta.Width = 125;
            // 
            // Monto
            // 
            Monto.DataPropertyName = "Total";
            Monto.HeaderText = "Total";
            Monto.MinimumWidth = 6;
            Monto.Name = "Monto";
            Monto.Width = 125;
            // 
            // MedioPago
            // 
            MedioPago.DataPropertyName = "Medio de Pago";
            MedioPago.HeaderText = "Medio de Pago";
            MedioPago.MinimumWidth = 6;
            MedioPago.Name = "MedioPago";
            MedioPago.Width = 125;
            // 
            // VentaBanco
            // 
            VentaBanco.DataPropertyName = "Banco";
            VentaBanco.HeaderText = "Banco";
            VentaBanco.MinimumWidth = 6;
            VentaBanco.Name = "VentaBanco";
            VentaBanco.Width = 125;
            // 
            // CajaVenta
            // 
            CajaVenta.HeaderText = "Numero de Caja";
            CajaVenta.MinimumWidth = 6;
            CajaVenta.Name = "CajaVenta";
            CajaVenta.Width = 125;
            // 
            // CajeroVenta
            // 
            CajeroVenta.HeaderText = "Cajero";
            CajeroVenta.MinimumWidth = 6;
            CajeroVenta.Name = "CajeroVenta";
            CajeroVenta.Width = 125;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvProductosVendidos);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1103, 698);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Productos Vendidos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvProductosVendidos
            // 
            dgvProductosVendidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosVendidos.Columns.AddRange(new DataGridViewColumn[] { IdProducto, Nombre, Precio, Cantidadd, Kilogramoo, Unidad });
            dgvProductosVendidos.Location = new Point(6, 6);
            dgvProductosVendidos.Name = "dgvProductosVendidos";
            dgvProductosVendidos.RowHeadersWidth = 51;
            dgvProductosVendidos.Size = new Size(1091, 684);
            dgvProductosVendidos.TabIndex = 0;
            // 
            // IdProducto
            // 
            IdProducto.DataPropertyName = "Numero de Producto";
            IdProducto.HeaderText = "Numero de Producto";
            IdProducto.MinimumWidth = 6;
            IdProducto.Name = "IdProducto";
            IdProducto.Width = 125;
            // 
            // Nombre
            // 
            Nombre.DataPropertyName = "Descripcion";
            Nombre.HeaderText = "Descripcion";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Precio
            // 
            Precio.DataPropertyName = "Precio unitario";
            Precio.HeaderText = "Precio Unitario";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.Width = 125;
            // 
            // Cantidadd
            // 
            Cantidadd.DataPropertyName = "Cantidad";
            Cantidadd.HeaderText = "Cantidad";
            Cantidadd.MinimumWidth = 6;
            Cantidadd.Name = "Cantidadd";
            Cantidadd.Width = 125;
            // 
            // Kilogramoo
            // 
            Kilogramoo.DataPropertyName = "Kilogramo";
            Kilogramoo.HeaderText = "Kilogramo";
            Kilogramoo.MinimumWidth = 6;
            Kilogramoo.Name = "Kilogramoo";
            Kilogramoo.Width = 125;
            // 
            // Unidad
            // 
            Unidad.DataPropertyName = "Unidad de Medida";
            Unidad.HeaderText = "Unidad de Medida";
            Unidad.MinimumWidth = 6;
            Unidad.Name = "Unidad";
            Unidad.Width = 125;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dataGridView1);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1103, 698);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Control de Usuarios";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdEmpleado, NombreUsuario, ApellidoUsuario, RolUsuario });
            dataGridView1.Location = new Point(1, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1096, 692);
            dataGridView1.TabIndex = 0;
            // 
            // IdEmpleado
            // 
            IdEmpleado.HeaderText = "Id Empleado";
            IdEmpleado.MinimumWidth = 6;
            IdEmpleado.Name = "IdEmpleado";
            IdEmpleado.Width = 125;
            // 
            // NombreUsuario
            // 
            NombreUsuario.HeaderText = "Nombre";
            NombreUsuario.MinimumWidth = 6;
            NombreUsuario.Name = "NombreUsuario";
            NombreUsuario.Width = 125;
            // 
            // ApellidoUsuario
            // 
            ApellidoUsuario.HeaderText = "Apellido";
            ApellidoUsuario.MinimumWidth = 6;
            ApellidoUsuario.Name = "ApellidoUsuario";
            ApellidoUsuario.Width = 125;
            // 
            // RolUsuario
            // 
            RolUsuario.HeaderText = "Rol";
            RolUsuario.MinimumWidth = 6;
            RolUsuario.Name = "RolUsuario";
            RolUsuario.Width = 125;
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
            button3.Text = "Usuarios";
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
            ClientSize = new Size(1229, 781);
            Controls.Add(PanelContenedor);
            Controls.Add(PanelMenu);
            Margin = new Padding(2);
            Name = "VistaSupervisor";
            Text = "VistaSupervisor";
            Load += VistaSupervisor_Load;
            PanelContenedor.ResumeLayout(false);
            PanelContenedor.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProductosVendidos).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private Button button3;
        private Button button2;
        private DataGridView dgvVentas;
        private TextBox txtBuscar;
        private Label label1;
        private DataGridView dgvProductosVendidos;
        private Button btnSalir;
        private DataGridViewTextBoxColumn IdVenta;
        private DataGridViewTextBoxColumn Monto;
        private DataGridViewTextBoxColumn MedioPago;
        private DataGridViewTextBoxColumn VentaBanco;
        private TabPage tabPage4;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdEmpleado;
        private DataGridViewTextBoxColumn NombreUsuario;
        private DataGridViewTextBoxColumn ApellidoUsuario;
        private DataGridViewTextBoxColumn RolUsuario;
        private DataGridViewTextBoxColumn CajaVenta;
        private DataGridViewTextBoxColumn CajeroVenta;
        private DataGridViewTextBoxColumn IdProducto;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Cantidadd;
        private DataGridViewTextBoxColumn Kilogramoo;
        private DataGridViewTextBoxColumn Unidad;
    }
}
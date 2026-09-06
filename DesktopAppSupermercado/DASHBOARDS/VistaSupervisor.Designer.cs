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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            dataGridView2 = new DataGridView();
            nombreProducto = new DataGridViewTextBoxColumn();
            CantidadProucto = new DataGridViewTextBoxColumn();
            PrecioUnitario = new DataGridViewTextBoxColumn();
            dataGridView3 = new DataGridView();
            Nombre2 = new DataGridViewTextBoxColumn();
            StockProducto = new DataGridViewTextBoxColumn();
            label3 = new Label();
            Id_venta = new DataGridViewTextBoxColumn();
            Monto = new DataGridViewTextBoxColumn();
            MedioPago = new DataGridViewTextBoxColumn();
            Banco = new DataGridViewTextBoxColumn();
            button1 = new Button();
            PanelContenedor.SuspendLayout();
            PanelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Controls.Add(label3);
            PanelContenedor.Controls.Add(dataGridView3);
            PanelContenedor.Controls.Add(dataGridView2);
            PanelContenedor.Controls.Add(label2);
            PanelContenedor.Controls.Add(label1);
            PanelContenedor.Controls.Add(dataGridView1);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(115, 0);
            PanelContenedor.Margin = new Padding(2);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(848, 781);
            PanelContenedor.TabIndex = 5;
            // 
            // PanelMenu
            // 
            PanelMenu.BackColor = SystemColors.ActiveCaption;
            PanelMenu.Controls.Add(button1);
            PanelMenu.Dock = DockStyle.Left;
            PanelMenu.Location = new Point(0, 0);
            PanelMenu.Margin = new Padding(2);
            PanelMenu.Name = "PanelMenu";
            PanelMenu.Size = new Size(115, 781);
            PanelMenu.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id_venta, Monto, MedioPago, Banco });
            dataGridView1.Location = new Point(16, 46);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(553, 188);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 12);
            label1.Name = "label1";
            label1.Size = new Size(203, 31);
            label1.TabIndex = 1;
            label1.Text = "Ventas realizadas:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(16, 251);
            label2.Name = "label2";
            label2.Size = new Size(232, 31);
            label2.TabIndex = 2;
            label2.Text = "Productos vendidos:";
            label2.Click += label2_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { nombreProducto, CantidadProucto, PrecioUnitario });
            dataGridView2.Location = new Point(16, 285);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(427, 188);
            dataGridView2.TabIndex = 3;
            // 
            // nombreProducto
            // 
            nombreProducto.HeaderText = "Nombre";
            nombreProducto.MinimumWidth = 6;
            nombreProducto.Name = "nombreProducto";
            nombreProducto.Width = 125;
            // 
            // CantidadProucto
            // 
            CantidadProucto.HeaderText = "Cantidad";
            CantidadProucto.MinimumWidth = 6;
            CantidadProucto.Name = "CantidadProucto";
            CantidadProucto.Width = 125;
            // 
            // PrecioUnitario
            // 
            PrecioUnitario.HeaderText = "Precio Unitario";
            PrecioUnitario.MinimumWidth = 6;
            PrecioUnitario.Name = "PrecioUnitario";
            PrecioUnitario.Width = 125;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { Nombre2, StockProducto });
            dataGridView3.Location = new Point(16, 533);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(300, 188);
            dataGridView3.TabIndex = 4;
            // 
            // Nombre2
            // 
            Nombre2.HeaderText = "Nombre2";
            Nombre2.MinimumWidth = 6;
            Nombre2.Name = "Nombre2";
            Nombre2.Width = 125;
            // 
            // StockProducto
            // 
            StockProducto.HeaderText = "Stock";
            StockProducto.MinimumWidth = 6;
            StockProducto.Name = "StockProducto";
            StockProducto.Width = 125;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(16, 499);
            label3.Name = "label3";
            label3.Size = new Size(259, 31);
            label3.TabIndex = 5;
            label3.Text = "Producto Modificados:";
            label3.Click += label3_Click;
            // 
            // Id_venta
            // 
            Id_venta.HeaderText = "Id_venta";
            Id_venta.MinimumWidth = 6;
            Id_venta.Name = "Id_venta";
            Id_venta.Width = 125;
            // 
            // Monto
            // 
            Monto.HeaderText = "Monto Total";
            Monto.MinimumWidth = 6;
            Monto.Name = "Monto";
            Monto.Width = 125;
            // 
            // MedioPago
            // 
            MedioPago.HeaderText = "Medio Pago";
            MedioPago.MinimumWidth = 6;
            MedioPago.Name = "MedioPago";
            MedioPago.Width = 125;
            // 
            // Banco
            // 
            Banco.HeaderText = "Banco";
            Banco.MinimumWidth = 6;
            Banco.Name = "Banco";
            Banco.Width = 125;
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(94, 74);
            button1.TabIndex = 0;
            button1.Text = "button1";
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
            PanelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenedor;
        private Panel PanelMenu;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn nombreProducto;
        private DataGridViewTextBoxColumn CantidadProucto;
        private DataGridViewTextBoxColumn PrecioUnitario;
        private Label label2;
        private Label label1;
        private Label label3;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn Nombre2;
        private DataGridViewTextBoxColumn StockProducto;
        private DataGridViewTextBoxColumn Id_venta;
        private DataGridViewTextBoxColumn Monto;
        private DataGridViewTextBoxColumn MedioPago;
        private DataGridViewTextBoxColumn Banco;
        private Button button1;
    }
}
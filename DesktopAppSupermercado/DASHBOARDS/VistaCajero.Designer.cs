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
            dataGridView1 = new DataGridView();
            Producto = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label3 = new Label();
            btnAgregarProducto = new Button();
            btnCodigoBarra = new Button();
            btnCancelarCompra = new Button();
            btnPagar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Producto, Cantidad, Precio });
            dataGridView1.Location = new Point(12, 75);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(429, 499);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Producto
            // 
            Producto.HeaderText = "Producto";
            Producto.MinimumWidth = 6;
            Producto.Name = "Producto";
            Producto.Width = 125;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            Cantidad.Width = 125;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 21);
            label1.Name = "label1";
            label1.Size = new Size(215, 41);
            label1.TabIndex = 1;
            label1.Text = "Total Compra:";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(221, 24);
            label3.Name = "label3";
            label3.Size = new Size(149, 38);
            label3.TabIndex = 3;
            label3.Text = "$15.345,14";
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Image = Properties.Resources.agregarprodct2;
            btnAgregarProducto.Location = new Point(466, 75);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(146, 158);
            btnAgregarProducto.TabIndex = 4;
            btnAgregarProducto.Text = "Agregar Producto";
            btnAgregarProducto.TextAlign = ContentAlignment.BottomCenter;
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // btnCodigoBarra
            // 
            btnCodigoBarra.Image = Properties.Resources.codigobarra;
            btnCodigoBarra.Location = new Point(466, 248);
            btnCodigoBarra.Name = "btnCodigoBarra";
            btnCodigoBarra.Size = new Size(146, 158);
            btnCodigoBarra.TabIndex = 5;
            btnCodigoBarra.Text = "Codigo de Barra";
            btnCodigoBarra.TextAlign = ContentAlignment.BottomCenter;
            btnCodigoBarra.UseVisualStyleBackColor = true;
            btnCodigoBarra.Click += button2_Click;
            // 
            // btnCancelarCompra
            // 
            btnCancelarCompra.Image = Properties.Resources.cancelarcompra;
            btnCancelarCompra.Location = new Point(631, 248);
            btnCancelarCompra.Name = "btnCancelarCompra";
            btnCancelarCompra.Size = new Size(146, 158);
            btnCancelarCompra.TabIndex = 6;
            btnCancelarCompra.Text = "Cancelar Compra";
            btnCancelarCompra.TextAlign = ContentAlignment.BottomCenter;
            btnCancelarCompra.UseVisualStyleBackColor = true;
            btnCancelarCompra.Click += button3_Click;
            // 
            // btnPagar
            // 
            btnPagar.Image = Properties.Resources.pagar;
            btnPagar.Location = new Point(631, 75);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(146, 158);
            btnPagar.TabIndex = 7;
            btnPagar.Text = "Pagar";
            btnPagar.TextAlign = ContentAlignment.BottomCenter;
            btnPagar.UseVisualStyleBackColor = true;
            btnPagar.Click += btnPagar_Click;
            // 
            // VistaCajero
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(800, 586);
            Controls.Add(btnPagar);
            Controls.Add(btnCancelarCompra);
            Controls.Add(btnCodigoBarra);
            Controls.Add(btnAgregarProducto);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "VistaCajero";
            Text = "VistaCajero";
            Load += VistaCajero_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private DataGridViewTextBoxColumn Producto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn Precio;
        private Label label3;
        private Button btnAgregarProducto;
        private Button btnCodigoBarra;
        private Button btnCancelarCompra;
        private Button btnPagar;
    }
}
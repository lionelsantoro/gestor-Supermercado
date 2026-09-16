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
            panel1 = new Panel();
            btnSalir = new Button();
            btnBorrarVenta = new Button();
            btnPagar = new Button();
            btnNuevaVenta = new Button();
            btnIngresarCodigo = new Button();
            panel2 = new Panel();
            panel5 = new Panel();
            textBox5 = new TextBox();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            btnAgregarProducto = new Button();
            btnGenerarPDF = new Button();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            label3 = new Label();
            label5 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            NombreProducto = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            PrecioUnitario = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnBorrarVenta);
            panel1.Controls.Add(btnPagar);
            panel1.Controls.Add(btnNuevaVenta);
            panel1.Controls.Add(btnIngresarCodigo);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(117, 644);
            panel1.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.Image = Properties.Resources.salie;
            btnSalir.Location = new Point(12, 499);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 124);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.TextAlign = ContentAlignment.BottomCenter;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnBorrarVenta
            // 
            btnBorrarVenta.Image = Properties.Resources.cancelarcompra3;
            btnBorrarVenta.ImageAlign = ContentAlignment.TopCenter;
            btnBorrarVenta.Location = new Point(12, 382);
            btnBorrarVenta.Name = "btnBorrarVenta";
            btnBorrarVenta.Size = new Size(94, 111);
            btnBorrarVenta.TabIndex = 5;
            btnBorrarVenta.Text = "Vaciar la venta";
            btnBorrarVenta.TextAlign = ContentAlignment.BottomCenter;
            btnBorrarVenta.UseVisualStyleBackColor = true;
            btnBorrarVenta.Click += btnBorrarCompra_Click;
            // 
            // btnPagar
            // 
            btnPagar.BackColor = SystemColors.ButtonFace;
            btnPagar.Image = Properties.Resources.pagar1;
            btnPagar.ImageAlign = ContentAlignment.TopCenter;
            btnPagar.Location = new Point(12, 273);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(94, 103);
            btnPagar.TabIndex = 1;
            btnPagar.Text = "Pagar";
            btnPagar.TextAlign = ContentAlignment.BottomCenter;
            btnPagar.UseVisualStyleBackColor = false;
            btnPagar.Click += btnPagar_Click_1;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Image = Properties.Resources.cajero22;
            btnNuevaVenta.ImageAlign = ContentAlignment.TopCenter;
            btnNuevaVenta.Location = new Point(12, 17);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(94, 100);
            btnNuevaVenta.TabIndex = 4;
            btnNuevaVenta.Text = "Nueva Venta";
            btnNuevaVenta.TextAlign = ContentAlignment.BottomCenter;
            btnNuevaVenta.UseVisualStyleBackColor = true;
            btnNuevaVenta.Click += btnIconoCajero_Click;
            // 
            // btnIngresarCodigo
            // 
            btnIngresarCodigo.Image = Properties.Resources.codigobarra2;
            btnIngresarCodigo.ImageAlign = ContentAlignment.TopCenter;
            btnIngresarCodigo.Location = new Point(12, 123);
            btnIngresarCodigo.Name = "btnIngresarCodigo";
            btnIngresarCodigo.Size = new Size(94, 144);
            btnIngresarCodigo.TabIndex = 2;
            btnIngresarCodigo.Text = "Ingresar Codido de barra";
            btnIngresarCodigo.TextAlign = ContentAlignment.BottomCenter;
            btnIngresarCodigo.UseVisualStyleBackColor = true;
            btnIngresarCodigo.Click += btnCargarProducto_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(255, 224, 192);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(dataGridView1);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(117, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(850, 644);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 224, 192);
            panel5.Controls.Add(textBox5);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(0, 588);
            panel5.Name = "panel5";
            panel5.Size = new Size(850, 56);
            panel5.TabIndex = 2;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(97, 16);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(368, 27);
            textBox5.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(6, 6);
            label6.Name = "label6";
            label6.Size = new Size(96, 41);
            label6.TabIndex = 0;
            label6.Text = "Total:";
            label6.Click += label6_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { NombreProducto, Cantidad, PrecioUnitario });
            dataGridView1.Location = new Point(0, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(850, 465);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 224, 192);
            panel3.Controls.Add(btnAgregarProducto);
            panel3.Controls.Add(btnGenerarPDF);
            panel3.Controls.Add(textBox4);
            panel3.Controls.Add(textBox3);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(textBox2);
            panel3.Controls.Add(textBox1);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(850, 133);
            panel3.TabIndex = 0;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(484, 55);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(94, 62);
            btnAgregarProducto.TabIndex = 9;
            btnAgregarProducto.Text = "Agregar producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            // 
            // btnGenerarPDF
            // 
            btnGenerarPDF.Location = new Point(600, 55);
            btnGenerarPDF.Name = "btnGenerarPDF";
            btnGenerarPDF.Size = new Size(94, 62);
            btnGenerarPDF.TabIndex = 8;
            btnGenerarPDF.Text = "Generar Ticket";
            btnGenerarPDF.UseVisualStyleBackColor = true;
            btnGenerarPDF.Click += btnGenerarPDF_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(136, 90);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(329, 27);
            textBox4.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(137, 57);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(328, 27);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(23, 86);
            label3.Name = "label3";
            label3.Size = new Size(116, 31);
            label3.TabIndex = 5;
            label3.Text = "Cantidad:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(31, 55);
            label5.Name = "label5";
            label5.Size = new Size(108, 31);
            label5.TabIndex = 4;
            label5.Text = "Nombre:";
            label5.Click += label5_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(290, 17);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(569, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(0, 3);
            label2.Name = "label2";
            label2.Size = new Size(298, 41);
            label2.TabIndex = 1;
            label2.Text = "Numero de compra:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(472, 3);
            label1.Name = "label1";
            label1.Size = new Size(106, 41);
            label1.TabIndex = 0;
            label1.Text = "Fecha:";
            label1.Click += label1_Click_1;
            // 
            // NombreProducto
            // 
            NombreProducto.HeaderText = "Nombre";
            NombreProducto.MinimumWidth = 6;
            NombreProducto.Name = "NombreProducto";
            NombreProducto.Width = 125;
            // 
            // Cantidad
            // 
            Cantidad.HeaderText = "Cantidad";
            Cantidad.MinimumWidth = 6;
            Cantidad.Name = "Cantidad";
            Cantidad.Width = 125;
            // 
            // PrecioUnitario
            // 
            PrecioUnitario.HeaderText = "Precio_Unitario";
            PrecioUnitario.MinimumWidth = 6;
            PrecioUnitario.Name = "PrecioUnitario";
            PrecioUnitario.Width = 125;
            // 
            // VistaCajero
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(967, 644);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "VistaCajero";
            Text = "VistaCajero";
            Load += VistaCajero_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnPagar;
        private Panel panel2;
        private Button btnIngresarCodigo;
        private Button btnNuevaVenta;
        private Panel panel3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label3;
        private Label label5;
        private Panel panel5;
        private Label label6;
        private TextBox textBox5;
        private Button btnSalir;
        private Button btnGenerarPDF;
        private Button btnBorrarVenta;
        private Button btnAgregarProducto;
        private DataGridViewTextBoxColumn NombreProducto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn PrecioUnitario;
    }
}
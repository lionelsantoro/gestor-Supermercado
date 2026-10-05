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
            btnRegistro = new Button();
            btnIngresarCodigo = new Button();
            panel2 = new Panel();
            panel5 = new Panel();
            txtTotal = new TextBox();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            btnNuevaVenta = new Button();
            btnAgregarProducto = new Button();
            btnGenerarPDF = new Button();
            textCant = new TextBox();
            txtNombre = new TextBox();
            label3 = new Label();
            label5 = new Label();
            txtNumeroCompra = new TextBox();
            txtFecha = new TextBox();
            label2 = new Label();
            label1 = new Label();
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
            panel1.Controls.Add(btnRegistro);
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
            // btnRegistro
            // 
            btnRegistro.Image = Properties.Resources.cajero21;
            btnRegistro.ImageAlign = ContentAlignment.TopCenter;
            btnRegistro.Location = new Point(12, 17);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(94, 100);
            btnRegistro.TabIndex = 4;
            btnRegistro.Text = "Registro";
            btnRegistro.TextAlign = ContentAlignment.BottomCenter;
            btnRegistro.UseVisualStyleBackColor = true;
            btnRegistro.Click += btnIconoCajero_Click;
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
            panel2.Size = new Size(789, 644);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 224, 192);
            panel5.Controls.Add(txtTotal);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(0, 588);
            panel5.Name = "panel5";
            panel5.Size = new Size(789, 56);
            panel5.TabIndex = 2;
            // 
            // txtTotal
            // 
            txtTotal.Location = new Point(97, 16);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(368, 27);
            txtTotal.TabIndex = 1;
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
            dataGridView1.Location = new Point(0, 133);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(789, 458);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick_1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 224, 192);
            panel3.Controls.Add(btnNuevaVenta);
            panel3.Controls.Add(btnAgregarProducto);
            panel3.Controls.Add(btnGenerarPDF);
            panel3.Controls.Add(textCant);
            panel3.Controls.Add(txtNombre);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(txtNumeroCompra);
            panel3.Controls.Add(txtFecha);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(789, 133);
            panel3.TabIndex = 0;
            // 
            // btnNuevaVenta
            // 
            btnNuevaVenta.Location = new Point(484, 57);
            btnNuevaVenta.Name = "btnNuevaVenta";
            btnNuevaVenta.Size = new Size(94, 60);
            btnNuevaVenta.TabIndex = 10;
            btnNuevaVenta.Text = "Nueva Venta";
            btnNuevaVenta.UseVisualStyleBackColor = true;
            btnNuevaVenta.Click += btnNuevaVenta_Click;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(584, 57);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(94, 62);
            btnAgregarProducto.TabIndex = 9;
            btnAgregarProducto.Text = "Agregar producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click_1;
            // 
            // btnGenerarPDF
            // 
            btnGenerarPDF.Location = new Point(684, 57);
            btnGenerarPDF.Name = "btnGenerarPDF";
            btnGenerarPDF.Size = new Size(94, 62);
            btnGenerarPDF.TabIndex = 8;
            btnGenerarPDF.Text = "Generar Ticket";
            btnGenerarPDF.UseVisualStyleBackColor = true;
            btnGenerarPDF.Click += btnGenerarPDF_Click;
            // 
            // textCant
            // 
            textCant.Location = new Point(136, 90);
            textCant.Name = "textCant";
            textCant.Size = new Size(329, 27);
            textCant.TabIndex = 7;
            textCant.Enter += textCant_Enter;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(137, 57);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(328, 27);
            txtNombre.TabIndex = 6;
            txtNombre.TextChanged += textBox3_TextChanged;
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
            // txtNumeroCompra
            // 
            txtNumeroCompra.Location = new Point(290, 17);
            txtNumeroCompra.Name = "txtNumeroCompra";
            txtNumeroCompra.Size = new Size(125, 27);
            txtNumeroCompra.TabIndex = 3;
            txtNumeroCompra.TextChanged += textBox2_TextChanged;
            // 
            // txtFecha
            // 
            txtFecha.Location = new Point(569, 17);
            txtFecha.Name = "txtFecha";
            txtFecha.Size = new Size(125, 27);
            txtFecha.TabIndex = 2;
            txtFecha.TextChanged += textBox1_TextChanged;
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
            // VistaCajero
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(906, 644);
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
        private Button btnRegistro;
        private Panel panel3;
        private TextBox txtNumeroCompra;
        private TextBox txtFecha;
        private Label label2;
        private Label label1;
        private DataGridView dataGridView1;
        private TextBox textCant;
        private TextBox txtNombre;
        private Label label3;
        private Label label5;
        private Panel panel5;
        private Label label6;
        private TextBox txtTotal;
        private Button btnSalir;
        private Button btnGenerarPDF;
        private Button btnBorrarVenta;
        private Button btnAgregarProducto;
        private Button btnNuevaVenta;
    }
}
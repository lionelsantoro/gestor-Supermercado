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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            btnPagar = new Button();
            panel2 = new Panel();
            btnCargarProducto = new Button();
            btnModificarCompra = new Button();
            btnIconoCajero = new Button();
            panel3 = new Panel();
            label1 = new Label();
            label2 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            dataGridView1 = new DataGridView();
            NombreProducto = new DataGridViewTextBoxColumn();
            Cantidad = new DataGridViewTextBoxColumn();
            PrecioUnitario = new DataGridViewTextBoxColumn();
            label5 = new Label();
            label3 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            panel5 = new Panel();
            label6 = new Label();
            btnBorrarCompra = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.Controls.Add(btnBorrarCompra);
            panel1.Controls.Add(btnPagar);
            panel1.Controls.Add(btnModificarCompra);
            panel1.Controls.Add(btnIconoCajero);
            panel1.Controls.Add(btnCargarProducto);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(117, 644);
            panel1.TabIndex = 0;
            // 
            // btnPagar
            // 
            btnPagar.BackColor = SystemColors.ButtonFace;
            btnPagar.Image = Properties.Resources.pagar1;
            btnPagar.Location = new Point(12, 246);
            btnPagar.Name = "btnPagar";
            btnPagar.Size = new Size(94, 75);
            btnPagar.TabIndex = 1;
            btnPagar.UseVisualStyleBackColor = false;
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
            // btnCargarProducto
            // 
            btnCargarProducto.Image = Properties.Resources.codigobarra2;
            btnCargarProducto.Location = new Point(12, 84);
            btnCargarProducto.Name = "btnCargarProducto";
            btnCargarProducto.Size = new Size(94, 75);
            btnCargarProducto.TabIndex = 2;
            btnCargarProducto.UseVisualStyleBackColor = true;
            // 
            // btnModificarCompra
            // 
            btnModificarCompra.Image = Properties.Resources.modificar1;
            btnModificarCompra.Location = new Point(12, 165);
            btnModificarCompra.Name = "btnModificarCompra";
            btnModificarCompra.Size = new Size(94, 75);
            btnModificarCompra.TabIndex = 3;
            btnModificarCompra.UseVisualStyleBackColor = true;
            btnModificarCompra.Click += btnModificarCompra_Click;
            // 
            // btnIconoCajero
            // 
            btnIconoCajero.Image = Properties.Resources.cajero21;
            btnIconoCajero.Location = new Point(12, 6);
            btnIconoCajero.Name = "btnIconoCajero";
            btnIconoCajero.Size = new Size(94, 75);
            btnIconoCajero.TabIndex = 4;
            btnIconoCajero.UseVisualStyleBackColor = true;
            btnIconoCajero.Click += btnIconoCajero_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(255, 224, 192);
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
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBox1
            // 
            textBox1.Location = new Point(569, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(290, 17);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            textBox2.TextChanged += textBox2_TextChanged;
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(23, 50);
            label5.Name = "label5";
            label5.Size = new Size(108, 31);
            label5.TabIndex = 4;
            label5.Text = "Nombre:";
            label5.Click += label5_Click;
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
            // textBox3
            // 
            textBox3.Location = new Point(126, 57);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(339, 27);
            textBox3.TabIndex = 6;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(136, 90);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(329, 27);
            textBox4.TabIndex = 7;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 224, 192);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(0, 588);
            panel5.Name = "panel5";
            panel5.Size = new Size(850, 56);
            panel5.TabIndex = 2;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(11, 13);
            label6.Name = "label6";
            label6.Size = new Size(96, 41);
            label6.TabIndex = 0;
            label6.Text = "Total:";
            label6.Click += label6_Click;
            // 
            // btnBorrarCompra
            // 
            btnBorrarCompra.Image = Properties.Resources.cancelarcompra3;
            btnBorrarCompra.Location = new Point(12, 327);
            btnBorrarCompra.Name = "btnBorrarCompra";
            btnBorrarCompra.Size = new Size(94, 75);
            btnBorrarCompra.TabIndex = 5;
            btnBorrarCompra.UseVisualStyleBackColor = true;
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
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnPagar;
        private Panel panel2;
        private Button btnCargarProducto;
        private Button btnModificarCompra;
        private Button btnIconoCajero;
        private Panel panel3;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label2;
        private Label label1;
        private ContextMenuStrip contextMenuStrip1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn NombreProducto;
        private DataGridViewTextBoxColumn Cantidad;
        private DataGridViewTextBoxColumn PrecioUnitario;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label3;
        private Label label5;
        private Panel panel5;
        private Label label6;
        private Button btnBorrarCompra;
    }
}
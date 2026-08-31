namespace DesktopAppSupermercado
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            Nombre = new DataGridViewTextBoxColumn();
            Id_categoria = new DataGridViewTextBoxColumn();
            Precio = new DataGridViewTextBoxColumn();
            Stock = new DataGridViewTextBoxColumn();
            Unidad_Medida = new DataGridViewTextBoxColumn();
            Codigo_Barra = new DataGridViewTextBoxColumn();
            Modificar = new DataGridViewButtonColumn();
            dataGridView2 = new DataGridView();
            IdCategoria = new DataGridViewTextBoxColumn();
            NombreCategoria = new DataGridViewTextBoxColumn();
            Descripcion = new DataGridViewTextBoxColumn();
            textBox2 = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Image = Properties.Resources.nuevoprodct1;
            button1.Location = new Point(519, 50);
            button1.Name = "button1";
            button1.Size = new Size(176, 217);
            button1.TabIndex = 0;
            button1.Text = "Nuevo Producto";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.nuevocateg;
            button2.Location = new Point(738, 53);
            button2.Name = "button2";
            button2.Size = new Size(162, 214);
            button2.TabIndex = 1;
            button2.Text = "Nueva Categoria";
            button2.TextAlign = ContentAlignment.BottomCenter;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 293);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 2;
            label1.Text = "Buscar producto:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(135, 290);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(805, 27);
            textBox1.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Nombre, Id_categoria, Precio, Stock, Unidad_Medida, Codigo_Barra, Modificar });
            dataGridView1.Location = new Point(12, 329);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(928, 298);
            dataGridView1.TabIndex = 4;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Nombre
            // 
            Nombre.HeaderText = "Nombre";
            Nombre.MinimumWidth = 6;
            Nombre.Name = "Nombre";
            Nombre.Width = 125;
            // 
            // Id_categoria
            // 
            Id_categoria.HeaderText = "Id_categoria";
            Id_categoria.MinimumWidth = 6;
            Id_categoria.Name = "Id_categoria";
            Id_categoria.Width = 125;
            // 
            // Precio
            // 
            Precio.HeaderText = "Precio";
            Precio.MinimumWidth = 6;
            Precio.Name = "Precio";
            Precio.Width = 125;
            // 
            // Stock
            // 
            Stock.HeaderText = "Stock";
            Stock.MinimumWidth = 6;
            Stock.Name = "Stock";
            Stock.Width = 125;
            // 
            // Unidad_Medida
            // 
            Unidad_Medida.HeaderText = "Unidad_Medida";
            Unidad_Medida.MinimumWidth = 6;
            Unidad_Medida.Name = "Unidad_Medida";
            Unidad_Medida.Width = 125;
            // 
            // Codigo_Barra
            // 
            Codigo_Barra.HeaderText = "Codigo_Barra";
            Codigo_Barra.MinimumWidth = 6;
            Codigo_Barra.Name = "Codigo_Barra";
            Codigo_Barra.Width = 125;
            // 
            // Modificar
            // 
            Modificar.HeaderText = "Modificar";
            Modificar.MinimumWidth = 6;
            Modificar.Name = "Modificar";
            Modificar.Text = "Modificar";
            Modificar.UseColumnTextForButtonValue = true;
            Modificar.Width = 125;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { IdCategoria, NombreCategoria, Descripcion });
            dataGridView2.Location = new Point(12, 53);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(429, 214);
            dataGridView2.TabIndex = 5;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // IdCategoria
            // 
            IdCategoria.HeaderText = "IdCategoria";
            IdCategoria.MinimumWidth = 6;
            IdCategoria.Name = "IdCategoria";
            IdCategoria.Width = 125;
            // 
            // NombreCategoria
            // 
            NombreCategoria.HeaderText = "NombreCategoria";
            NombreCategoria.MinimumWidth = 6;
            NombreCategoria.Name = "NombreCategoria";
            NombreCategoria.Width = 125;
            // 
            // Descripcion
            // 
            Descripcion.HeaderText = "Descripcion";
            Descripcion.MinimumWidth = 6;
            Descripcion.Name = "Descripcion";
            Descripcion.Width = 125;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(135, 20);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(306, 27);
            textBox2.TabIndex = 7;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 20);
            label2.Name = "label2";
            label2.Size = new Size(122, 20);
            label2.TabIndex = 6;
            label2.Text = "Buscar categoria:";
            label2.Click += label2_Click;
            // 
            // VistaInventario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(957, 639);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "VistaInventario";
            Text = "VistaInventario";
            Load += VistaInventario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Nombre;
        private DataGridViewTextBoxColumn Id_categoria;
        private DataGridViewTextBoxColumn Precio;
        private DataGridViewTextBoxColumn Stock;
        private DataGridViewTextBoxColumn Unidad_Medida;
        private DataGridViewTextBoxColumn Codigo_Barra;
        private DataGridViewButtonColumn Modificar;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn IdCategoria;
        private DataGridViewTextBoxColumn NombreCategoria;
        private DataGridViewTextBoxColumn Descripcion;
        private TextBox textBox2;
        private Label label2;
    }
}
namespace DesktopAppSupermercado.VISTASINVENTARIO
{
    partial class VistaGestionInventario
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
            splitContainer1 = new SplitContainer();
            btnEliminarCategoria = new Button();
            btnModificarCategoria = new Button();
            dataGridView1 = new DataGridView();
            ColCategorias = new DataGridViewTextBoxColumn();
            dgvCategorias = new DataGridView();
            colCatNombre = new DataGridViewTextBoxColumn();
            btnNuevaCategoria = new Button();
            dgvProductos = new DataGridView();
            ColCodigo = new DataGridViewTextBoxColumn();
            ColNombre = new DataGridViewTextBoxColumn();
            ColPrecio = new DataGridViewTextBoxColumn();
            ColStock = new DataGridViewTextBoxColumn();
            ColUnidad = new DataGridViewTextBoxColumn();
            ColKg = new DataGridViewTextBoxColumn();
            panelInferior = new Panel();
            gbEdicionProducto = new GroupBox();
            btnEliminarProductoInventario = new Button();
            btnCancelarProductosInventario = new Button();
            cmbEstado = new ComboBox();
            btnGuardarProductosInventario = new Button();
            cmbUnidad = new ComboBox();
            cmbCategoria = new ComboBox();
            txtStock = new TextBox();
            txtNombreProducto = new TextBox();
            txtDescripcion = new TextBox();
            txtPeso = new TextBox();
            txtPrecio = new TextBox();
            txtCodigoBarras = new TextBox();
            labelDescripcion = new Label();
            labelEstado = new Label();
            labelPeso = new Label();
            labelUInidadMedida = new Label();
            labelStock = new Label();
            labelPrecio = new Label();
            labelCategoria = new Label();
            labelNombre = new Label();
            labelCodigoBarra = new Label();
            panelSuperior = new Panel();
            button1 = new Button();
            txtBuscarProducto = new TextBox();
            btnCancelarProducto = new Button();
            btnGuardarProducto = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            panelInferior.SuspendLayout();
            gbEdicionProducto.SuspendLayout();
            panelSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.BackColor = Color.FromArgb(255, 192, 128);
            splitContainer1.Panel1.Controls.Add(btnEliminarCategoria);
            splitContainer1.Panel1.Controls.Add(btnModificarCategoria);
            splitContainer1.Panel1.Controls.Add(dataGridView1);
            splitContainer1.Panel1.Controls.Add(dgvCategorias);
            splitContainer1.Panel1.Controls.Add(btnNuevaCategoria);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(255, 192, 128);
            splitContainer1.Panel2.Controls.Add(dgvProductos);
            splitContainer1.Panel2.Controls.Add(panelInferior);
            splitContainer1.Panel2.Controls.Add(panelSuperior);
            splitContainer1.Panel2.Controls.Add(btnCancelarProducto);
            splitContainer1.Panel2.Controls.Add(btnGuardarProducto);
            splitContainer1.Size = new Size(1701, 1026);
            splitContainer1.SplitterDistance = 402;
            splitContainer1.TabIndex = 0;
            // 
            // btnEliminarCategoria
            // 
            btnEliminarCategoria.BackColor = Color.Red;
            btnEliminarCategoria.Dock = DockStyle.Bottom;
            btnEliminarCategoria.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarCategoria.Location = new Point(0, 684);
            btnEliminarCategoria.Name = "btnEliminarCategoria";
            btnEliminarCategoria.Size = new Size(402, 114);
            btnEliminarCategoria.TabIndex = 5;
            btnEliminarCategoria.Text = "Eliminar Categoria";
            btnEliminarCategoria.UseVisualStyleBackColor = false;
            // 
            // btnModificarCategoria
            // 
            btnModificarCategoria.BackColor = Color.Yellow;
            btnModificarCategoria.Dock = DockStyle.Bottom;
            btnModificarCategoria.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnModificarCategoria.Location = new Point(0, 798);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(402, 114);
            btnModificarCategoria.TabIndex = 4;
            btnModificarCategoria.Text = "Modificar Categoria";
            btnModificarCategoria.UseVisualStyleBackColor = false;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.FromArgb(255, 192, 128);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColCategorias });
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new Size(402, 912);
            dataGridView1.TabIndex = 3;
            // 
            // ColCategorias
            // 
            ColCategorias.HeaderText = "Categorias";
            ColCategorias.MinimumWidth = 10;
            ColCategorias.Name = "ColCategorias";
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.BackgroundColor = Color.FromArgb(255, 192, 128);
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Columns.AddRange(new DataGridViewColumn[] { colCatNombre });
            dgvCategorias.Dock = DockStyle.Fill;
            dgvCategorias.Location = new Point(0, 0);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.RowHeadersWidth = 82;
            dgvCategorias.Size = new Size(402, 912);
            dgvCategorias.TabIndex = 0;
            dgvCategorias.CellContentClick += dgvCategorias_CellContentClick;
            // 
            // colCatNombre
            // 
            colCatNombre.HeaderText = "Categorías";
            colCatNombre.MinimumWidth = 10;
            colCatNombre.Name = "colCatNombre";
            // 
            // btnNuevaCategoria
            // 
            btnNuevaCategoria.BackColor = Color.DeepSkyBlue;
            btnNuevaCategoria.Dock = DockStyle.Bottom;
            btnNuevaCategoria.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNuevaCategoria.Location = new Point(0, 912);
            btnNuevaCategoria.Name = "btnNuevaCategoria";
            btnNuevaCategoria.Size = new Size(402, 114);
            btnNuevaCategoria.TabIndex = 0;
            btnNuevaCategoria.Text = "+ Nueva categoría";
            btnNuevaCategoria.UseVisualStyleBackColor = false;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.FromArgb(255, 192, 128);
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { ColCodigo, ColNombre, ColPrecio, ColStock, ColUnidad, ColKg });
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(0, 60);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 82;
            dgvProductos.Size = new Size(1295, 716);
            dgvProductos.TabIndex = 2;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            // 
            // ColCodigo
            // 
            ColCodigo.HeaderText = "Codigo";
            ColCodigo.MinimumWidth = 10;
            ColCodigo.Name = "ColCodigo";
            // 
            // ColNombre
            // 
            ColNombre.HeaderText = "Nombre";
            ColNombre.MinimumWidth = 10;
            ColNombre.Name = "ColNombre";
            // 
            // ColPrecio
            // 
            ColPrecio.HeaderText = "Precio";
            ColPrecio.MinimumWidth = 10;
            ColPrecio.Name = "ColPrecio";
            // 
            // ColStock
            // 
            ColStock.HeaderText = "Stock";
            ColStock.MinimumWidth = 10;
            ColStock.Name = "ColStock";
            // 
            // ColUnidad
            // 
            ColUnidad.HeaderText = "Unidad";
            ColUnidad.MinimumWidth = 10;
            ColUnidad.Name = "ColUnidad";
            // 
            // ColKg
            // 
            ColKg.HeaderText = "Kg";
            ColKg.MinimumWidth = 10;
            ColKg.Name = "ColKg";
            // 
            // panelInferior
            // 
            panelInferior.Controls.Add(gbEdicionProducto);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 776);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(1295, 250);
            panelInferior.TabIndex = 1;
            // 
            // gbEdicionProducto
            // 
            gbEdicionProducto.Controls.Add(btnEliminarProductoInventario);
            gbEdicionProducto.Controls.Add(btnCancelarProductosInventario);
            gbEdicionProducto.Controls.Add(cmbEstado);
            gbEdicionProducto.Controls.Add(btnGuardarProductosInventario);
            gbEdicionProducto.Controls.Add(cmbUnidad);
            gbEdicionProducto.Controls.Add(cmbCategoria);
            gbEdicionProducto.Controls.Add(txtStock);
            gbEdicionProducto.Controls.Add(txtNombreProducto);
            gbEdicionProducto.Controls.Add(txtDescripcion);
            gbEdicionProducto.Controls.Add(txtPeso);
            gbEdicionProducto.Controls.Add(txtPrecio);
            gbEdicionProducto.Controls.Add(txtCodigoBarras);
            gbEdicionProducto.Controls.Add(labelDescripcion);
            gbEdicionProducto.Controls.Add(labelEstado);
            gbEdicionProducto.Controls.Add(labelPeso);
            gbEdicionProducto.Controls.Add(labelUInidadMedida);
            gbEdicionProducto.Controls.Add(labelStock);
            gbEdicionProducto.Controls.Add(labelPrecio);
            gbEdicionProducto.Controls.Add(labelCategoria);
            gbEdicionProducto.Controls.Add(labelNombre);
            gbEdicionProducto.Controls.Add(labelCodigoBarra);
            gbEdicionProducto.Dock = DockStyle.Fill;
            gbEdicionProducto.Location = new Point(0, 0);
            gbEdicionProducto.Name = "gbEdicionProducto";
            gbEdicionProducto.Size = new Size(1295, 250);
            gbEdicionProducto.TabIndex = 2;
            gbEdicionProducto.TabStop = false;
            gbEdicionProducto.Text = "Editar producto seleccionado";
            gbEdicionProducto.Enter += gbEdicionProducto_Enter;
            // 
            // btnEliminarProductoInventario
            // 
            btnEliminarProductoInventario.BackColor = Color.FromArgb(192, 0, 192);
            btnEliminarProductoInventario.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarProductoInventario.Location = new Point(1120, 81);
            btnEliminarProductoInventario.Name = "btnEliminarProductoInventario";
            btnEliminarProductoInventario.Size = new Size(169, 160);
            btnEliminarProductoInventario.TabIndex = 29;
            btnEliminarProductoInventario.Text = "Eliminar Producto";
            btnEliminarProductoInventario.UseVisualStyleBackColor = false;
            // 
            // btnCancelarProductosInventario
            // 
            btnCancelarProductosInventario.BackColor = Color.Tomato;
            btnCancelarProductosInventario.FlatStyle = FlatStyle.Flat;
            btnCancelarProductosInventario.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarProductosInventario.ForeColor = SystemColors.ActiveCaptionText;
            btnCancelarProductosInventario.Image = Properties.Resources.cancel_circle_close_delete_discard_file_x_icon_123219__1_;
            btnCancelarProductosInventario.ImageAlign = ContentAlignment.TopCenter;
            btnCancelarProductosInventario.Location = new Point(952, 80);
            btnCancelarProductosInventario.Name = "btnCancelarProductosInventario";
            btnCancelarProductosInventario.Size = new Size(156, 156);
            btnCancelarProductosInventario.TabIndex = 28;
            btnCancelarProductosInventario.Text = "Cancelar";
            btnCancelarProductosInventario.TextAlign = ContentAlignment.BottomCenter;
            btnCancelarProductosInventario.UseVisualStyleBackColor = false;
            // 
            // cmbEstado
            // 
            cmbEstado.FormattingEnabled = true;
            cmbEstado.Location = new Point(411, 201);
            cmbEstado.Name = "cmbEstado";
            cmbEstado.Size = new Size(175, 40);
            cmbEstado.TabIndex = 19;
            // 
            // btnGuardarProductosInventario
            // 
            btnGuardarProductosInventario.BackColor = Color.YellowGreen;
            btnGuardarProductosInventario.FlatStyle = FlatStyle.Flat;
            btnGuardarProductosInventario.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarProductosInventario.ForeColor = Color.Black;
            btnGuardarProductosInventario.Image = Properties.Resources.Save_37110;
            btnGuardarProductosInventario.ImageAlign = ContentAlignment.TopCenter;
            btnGuardarProductosInventario.Location = new Point(786, 81);
            btnGuardarProductosInventario.Name = "btnGuardarProductosInventario";
            btnGuardarProductosInventario.Size = new Size(160, 155);
            btnGuardarProductosInventario.TabIndex = 27;
            btnGuardarProductosInventario.Text = "Guardar";
            btnGuardarProductosInventario.TextAlign = ContentAlignment.BottomCenter;
            btnGuardarProductosInventario.UseVisualStyleBackColor = false;
            // 
            // cmbUnidad
            // 
            cmbUnidad.FormattingEnabled = true;
            cmbUnidad.Location = new Point(607, 167);
            cmbUnidad.Name = "cmbUnidad";
            cmbUnidad.Size = new Size(148, 40);
            cmbUnidad.TabIndex = 18;
            cmbUnidad.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(744, 35);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(142, 40);
            cmbCategoria.TabIndex = 17;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(417, 131);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(169, 39);
            txtStock.TabIndex = 16;
            // 
            // txtNombreProducto
            // 
            txtNombreProducto.Location = new Point(435, 47);
            txtNombreProducto.Name = "txtNombreProducto";
            txtNombreProducto.Size = new Size(166, 39);
            txtNombreProducto.TabIndex = 15;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(1039, 35);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(256, 39);
            txtDescripcion.TabIndex = 14;
            // 
            // txtPeso
            // 
            txtPeso.Location = new Point(121, 209);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(194, 39);
            txtPeso.TabIndex = 13;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(100, 128);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(221, 39);
            txtPrecio.TabIndex = 12;
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(183, 43);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(138, 39);
            txtCodigoBarras.TabIndex = 11;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(895, 35);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(138, 32);
            labelDescripcion.TabIndex = 8;
            labelDescripcion.Text = "Descripcion";
            labelDescripcion.Click += labelDescripcion_Click;
            // 
            // labelEstado
            // 
            labelEstado.AutoSize = true;
            labelEstado.Location = new Point(321, 204);
            labelEstado.Name = "labelEstado";
            labelEstado.Size = new Size(84, 32);
            labelEstado.TabIndex = 7;
            labelEstado.Text = "Estado";
            // 
            // labelPeso
            // 
            labelPeso.AutoSize = true;
            labelPeso.Location = new Point(3, 209);
            labelPeso.Name = "labelPeso";
            labelPeso.Size = new Size(112, 32);
            labelPeso.TabIndex = 6;
            labelPeso.Text = "Peso (Kg)";
            // 
            // labelUInidadMedida
            // 
            labelUInidadMedida.AutoSize = true;
            labelUInidadMedida.Location = new Point(592, 113);
            labelUInidadMedida.Name = "labelUInidadMedida";
            labelUInidadMedida.Size = new Size(178, 32);
            labelUInidadMedida.TabIndex = 5;
            labelUInidadMedida.Text = "Unidad Medida";
            labelUInidadMedida.Click += labelUInidadMedida_Click;
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(327, 136);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(71, 32);
            labelStock.TabIndex = 4;
            labelStock.Text = "Stock";
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Location = new Point(3, 131);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(79, 32);
            labelPrecio.TabIndex = 3;
            labelPrecio.Text = "Precio";
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(607, 38);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(116, 32);
            labelCategoria.TabIndex = 2;
            labelCategoria.Text = "Categoria";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(327, 47);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(102, 32);
            labelNombre.TabIndex = 1;
            labelNombre.Text = "Nombre";
            labelNombre.Click += labelNombre_Click;
            // 
            // labelCodigoBarra
            // 
            labelCodigoBarra.AutoSize = true;
            labelCodigoBarra.Font = new Font("Segoe UI", 7.875F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCodigoBarra.Location = new Point(0, 45);
            labelCodigoBarra.Name = "labelCodigoBarra";
            labelCodigoBarra.Size = new Size(171, 30);
            labelCodigoBarra.TabIndex = 0;
            labelCodigoBarra.Text = "Codigo de Barras";
            labelCodigoBarra.Click += label1_Click;
            // 
            // panelSuperior
            // 
            panelSuperior.Controls.Add(button1);
            panelSuperior.Controls.Add(txtBuscarProducto);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1295, 60);
            panelSuperior.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(1096, 11);
            button1.Name = "button1";
            button1.Size = new Size(199, 43);
            button1.TabIndex = 2;
            button1.Text = "Buscar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(441, 12);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(649, 39);
            txtBuscarProducto.TabIndex = 1;
            // 
            // btnCancelarProducto
            // 
            btnCancelarProducto.Location = new Point(729, 610);
            btnCancelarProducto.Name = "btnCancelarProducto";
            btnCancelarProducto.Size = new Size(158, 87);
            btnCancelarProducto.TabIndex = 9;
            btnCancelarProducto.Text = "Cancelar";
            btnCancelarProducto.UseVisualStyleBackColor = true;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.Location = new Point(831, 489);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(179, 85);
            btnGuardarProducto.TabIndex = 10;
            btnGuardarProducto.Text = "Guardar";
            btnGuardarProducto.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // VistaGestionInventario
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1701, 1026);
            Controls.Add(splitContainer1);
            Name = "VistaGestionInventario";
            Text = "VistaGestionInventario";
            Load += VistaGestionInventario_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            panelInferior.ResumeLayout(false);
            gbEdicionProducto.ResumeLayout(false);
            gbEdicionProducto.PerformLayout();
            panelSuperior.ResumeLayout(false);
            panelSuperior.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splitContainer1;
        private Button btnNuevaCategoria;
        private DataGridView dgvCategorias;
        private Panel panelSuperior;
        private Panel panelInferior;
        private Button button1;
        private TextBox txtBuscarProducto;
        private GroupBox gbEdicionProducto;
        private DataGridView dgvProductos;
        private Label labelNombre;
        private Label labelCodigoBarra;
        private Label labelStock;
        private Label labelPrecio;
        private Label labelCategoria;
        private Label labelEstado;
        private Label labelPeso;
        private Label labelUInidadMedida;
        private Button btnGuardarProducto;
        private Button btnCancelarProducto;
        private Label labelDescripcion;
        private TextBox txtCodigoBarras;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtNombreProducto;
        private TextBox txtDescripcion;
        private TextBox txtPeso;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private ComboBox cmbEstado;
        private ComboBox cmbUnidad;
        private ComboBox cmbCategoria;
        private Button btnCancelarProductosInventario;
        private Button btnGuardarProductosInventario;
        private DataGridViewTextBoxColumn colCatNombre;
        private Button btnEliminarCategoria;
        private Button btnModificarCategoria;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ColCategorias;
        private DataGridViewTextBoxColumn ColCodigo;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColPrecio;
        private DataGridViewTextBoxColumn ColStock;
        private DataGridViewTextBoxColumn ColUnidad;
        private DataGridViewTextBoxColumn ColKg;
        private Button btnEliminarProductoInventario;
    }
}
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
            txtNombreCategoria = new TextBox();
            label3 = new Label();
            btnEliminarCategoria = new Button();
            dataCategoria = new DataGridView();
            ColCategorias = new DataGridViewTextBoxColumn();
            dgvCategorias = new DataGridView();
            colCatNombre = new DataGridViewTextBoxColumn();
            btnGuardarCategoria = new Button();
            dgvProductos = new DataGridView();
            ColCodigo = new DataGridViewTextBoxColumn();
            ColNombre = new DataGridViewTextBoxColumn();
            ColPrecio = new DataGridViewTextBoxColumn();
            ColStock = new DataGridViewTextBoxColumn();
            ColUnidad = new DataGridViewTextBoxColumn();
            Categoriaa = new DataGridViewTextBoxColumn();
            panelInferior = new Panel();
            gbEdicionProducto = new GroupBox();
            btnEliminarProductoInventario = new Button();
            btnCancelarProductosInventario = new Button();
            btnGuardarProductosInventario = new Button();
            cmbUnidadMedida = new ComboBox();
            cmbCategoriaProducto = new ComboBox();
            txtStockProducto = new TextBox();
            txtDescripcionProducto = new TextBox();
            txtPrecioProducto = new TextBox();
            txtCodigoBarras = new TextBox();
            labelDescripcion = new Label();
            labelUInidadMedida = new Label();
            labelStock = new Label();
            labelPrecio = new Label();
            labelCategoria = new Label();
            labelCodigoBarra = new Label();
            panelSuperior = new Panel();
            btnLimpiarfiltros = new Button();
            label2 = new Label();
            label1 = new Label();
            txtStockMax = new TextBox();
            txtStockMin = new TextBox();
            cmbFiltroCategoria = new ComboBox();
            btnBuscar = new Button();
            txtBuscarProducto = new TextBox();
            btnCancelarProducto = new Button();
            btnGuardarProducto = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataCategoria).BeginInit();
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
            splitContainer1.Panel1.Controls.Add(txtNombreCategoria);
            splitContainer1.Panel1.Controls.Add(label3);
            splitContainer1.Panel1.Controls.Add(btnEliminarCategoria);
            splitContainer1.Panel1.Controls.Add(dataCategoria);
            splitContainer1.Panel1.Controls.Add(dgvCategorias);
            splitContainer1.Panel1.Controls.Add(btnGuardarCategoria);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.BackColor = Color.FromArgb(255, 192, 128);
            splitContainer1.Panel2.Controls.Add(dgvProductos);
            splitContainer1.Panel2.Controls.Add(panelInferior);
            splitContainer1.Panel2.Controls.Add(panelSuperior);
            splitContainer1.Panel2.Controls.Add(btnCancelarProducto);
            splitContainer1.Panel2.Controls.Add(btnGuardarProducto);
            splitContainer1.Size = new Size(2641, 1026);
            splitContainer1.SplitterDistance = 620;
            splitContainer1.SplitterWidth = 3;
            splitContainer1.TabIndex = 0;
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.Location = new Point(132, 744);
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.Size = new Size(200, 39);
            txtNombreCategoria.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 744);
            label3.Name = "label3";
            label3.Size = new Size(102, 32);
            label3.TabIndex = 1;
            label3.Text = "Nombre";
            // 
            // btnEliminarCategoria
            // 
            btnEliminarCategoria.BackColor = Color.Red;
            btnEliminarCategoria.Dock = DockStyle.Bottom;
            btnEliminarCategoria.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarCategoria.Location = new Point(0, 798);
            btnEliminarCategoria.Name = "btnEliminarCategoria";
            btnEliminarCategoria.Size = new Size(620, 114);
            btnEliminarCategoria.TabIndex = 5;
            btnEliminarCategoria.Text = "Eliminar Categoria";
            btnEliminarCategoria.UseVisualStyleBackColor = false;
            btnEliminarCategoria.Click += btnEliminarCategoria_Click;
            // 
            // dataCategoria
            // 
            dataCategoria.AllowUserToAddRows = false;
            dataCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataCategoria.BackgroundColor = Color.FromArgb(255, 192, 128);
            dataCategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCategoria.Columns.AddRange(new DataGridViewColumn[] { ColCategorias });
            dataCategoria.Dock = DockStyle.Fill;
            dataCategoria.Location = new Point(0, 0);
            dataCategoria.Name = "dataCategoria";
            dataCategoria.RowHeadersWidth = 82;
            dataCategoria.Size = new Size(620, 912);
            dataCategoria.TabIndex = 3;
            dataCategoria.CellClick += dataCategoria_CellClick;
            // 
            // ColCategorias
            // 
            ColCategorias.DataPropertyName = "nombre";
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
            dgvCategorias.Size = new Size(620, 912);
            dgvCategorias.TabIndex = 0;
            // 
            // colCatNombre
            // 
            colCatNombre.HeaderText = "Categorías";
            colCatNombre.MinimumWidth = 10;
            colCatNombre.Name = "colCatNombre";
            // 
            // btnGuardarCategoria
            // 
            btnGuardarCategoria.BackColor = Color.DeepSkyBlue;
            btnGuardarCategoria.Dock = DockStyle.Bottom;
            btnGuardarCategoria.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarCategoria.Location = new Point(0, 912);
            btnGuardarCategoria.Name = "btnGuardarCategoria";
            btnGuardarCategoria.Size = new Size(620, 114);
            btnGuardarCategoria.TabIndex = 0;
            btnGuardarCategoria.Text = "+ Nueva categoría";
            btnGuardarCategoria.UseVisualStyleBackColor = false;
            btnGuardarCategoria.Click += btnGuardarCategoria_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = Color.FromArgb(255, 192, 128);
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { ColCodigo, ColNombre, ColPrecio, ColStock, ColUnidad, Categoriaa });
            dgvProductos.Dock = DockStyle.Fill;
            dgvProductos.Location = new Point(0, 61);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 82;
            dgvProductos.Size = new Size(2018, 715);
            dgvProductos.TabIndex = 2;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // ColCodigo
            // 
            ColCodigo.DataPropertyName = "codigo_barra";
            ColCodigo.HeaderText = "Codigo";
            ColCodigo.MinimumWidth = 10;
            ColCodigo.Name = "ColCodigo";
            // 
            // ColNombre
            // 
            ColNombre.DataPropertyName = "descripcion";
            ColNombre.HeaderText = "Descripcion";
            ColNombre.MinimumWidth = 10;
            ColNombre.Name = "ColNombre";
            // 
            // ColPrecio
            // 
            ColPrecio.DataPropertyName = "precio";
            ColPrecio.HeaderText = "Precio";
            ColPrecio.MinimumWidth = 10;
            ColPrecio.Name = "ColPrecio";
            // 
            // ColStock
            // 
            ColStock.DataPropertyName = "stock";
            ColStock.HeaderText = "Stock";
            ColStock.MinimumWidth = 10;
            ColStock.Name = "ColStock";
            // 
            // ColUnidad
            // 
            ColUnidad.DataPropertyName = "unidad_medida";
            ColUnidad.HeaderText = "Unidad";
            ColUnidad.MinimumWidth = 10;
            ColUnidad.Name = "ColUnidad";
            // 
            // Categoriaa
            // 
            Categoriaa.DataPropertyName = "categoria_nombre";
            Categoriaa.HeaderText = "Categoria";
            Categoriaa.MinimumWidth = 6;
            Categoriaa.Name = "Categoriaa";
            // 
            // panelInferior
            // 
            panelInferior.Controls.Add(gbEdicionProducto);
            panelInferior.Dock = DockStyle.Bottom;
            panelInferior.Location = new Point(0, 776);
            panelInferior.Name = "panelInferior";
            panelInferior.Size = new Size(2018, 250);
            panelInferior.TabIndex = 1;
            // 
            // gbEdicionProducto
            // 
            gbEdicionProducto.Controls.Add(btnEliminarProductoInventario);
            gbEdicionProducto.Controls.Add(btnCancelarProductosInventario);
            gbEdicionProducto.Controls.Add(btnGuardarProductosInventario);
            gbEdicionProducto.Controls.Add(cmbUnidadMedida);
            gbEdicionProducto.Controls.Add(cmbCategoriaProducto);
            gbEdicionProducto.Controls.Add(txtStockProducto);
            gbEdicionProducto.Controls.Add(txtDescripcionProducto);
            gbEdicionProducto.Controls.Add(txtPrecioProducto);
            gbEdicionProducto.Controls.Add(txtCodigoBarras);
            gbEdicionProducto.Controls.Add(labelDescripcion);
            gbEdicionProducto.Controls.Add(labelUInidadMedida);
            gbEdicionProducto.Controls.Add(labelStock);
            gbEdicionProducto.Controls.Add(labelPrecio);
            gbEdicionProducto.Controls.Add(labelCategoria);
            gbEdicionProducto.Controls.Add(labelCodigoBarra);
            gbEdicionProducto.Dock = DockStyle.Fill;
            gbEdicionProducto.Location = new Point(0, 0);
            gbEdicionProducto.Name = "gbEdicionProducto";
            gbEdicionProducto.Size = new Size(2018, 250);
            gbEdicionProducto.TabIndex = 2;
            gbEdicionProducto.TabStop = false;
            gbEdicionProducto.Text = "Crear o Editar Productos";
            // 
            // btnEliminarProductoInventario
            // 
            btnEliminarProductoInventario.BackColor = Color.FromArgb(192, 0, 192);
            btnEliminarProductoInventario.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEliminarProductoInventario.Location = new Point(1826, 62);
            btnEliminarProductoInventario.Name = "btnEliminarProductoInventario";
            btnEliminarProductoInventario.Size = new Size(169, 160);
            btnEliminarProductoInventario.TabIndex = 29;
            btnEliminarProductoInventario.Text = "Eliminar Producto";
            btnEliminarProductoInventario.UseVisualStyleBackColor = false;
            btnEliminarProductoInventario.Click += btnEliminarProductoInventario_Click;
            // 
            // btnCancelarProductosInventario
            // 
            btnCancelarProductosInventario.BackColor = Color.Tomato;
            btnCancelarProductosInventario.FlatStyle = FlatStyle.Flat;
            btnCancelarProductosInventario.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelarProductosInventario.ForeColor = SystemColors.ActiveCaptionText;
            btnCancelarProductosInventario.Image = Properties.Resources.cancel_circle_close_delete_discard_file_x_icon_123219__1_;
            btnCancelarProductosInventario.ImageAlign = ContentAlignment.TopCenter;
            btnCancelarProductosInventario.Location = new Point(1646, 66);
            btnCancelarProductosInventario.Name = "btnCancelarProductosInventario";
            btnCancelarProductosInventario.Size = new Size(156, 154);
            btnCancelarProductosInventario.TabIndex = 28;
            btnCancelarProductosInventario.Text = "Cancelar";
            btnCancelarProductosInventario.TextAlign = ContentAlignment.BottomCenter;
            btnCancelarProductosInventario.UseVisualStyleBackColor = false;
            btnCancelarProductosInventario.Click += btnCancelarProductosInventario_Click;
            // 
            // btnGuardarProductosInventario
            // 
            btnGuardarProductosInventario.BackColor = Color.YellowGreen;
            btnGuardarProductosInventario.FlatStyle = FlatStyle.Flat;
            btnGuardarProductosInventario.Font = new Font("Arial Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardarProductosInventario.ForeColor = Color.Black;
            btnGuardarProductosInventario.Image = Properties.Resources.Save_37110;
            btnGuardarProductosInventario.ImageAlign = ContentAlignment.TopCenter;
            btnGuardarProductosInventario.Location = new Point(1462, 67);
            btnGuardarProductosInventario.Name = "btnGuardarProductosInventario";
            btnGuardarProductosInventario.Size = new Size(159, 157);
            btnGuardarProductosInventario.TabIndex = 27;
            btnGuardarProductosInventario.Text = "Guardar";
            btnGuardarProductosInventario.TextAlign = ContentAlignment.BottomCenter;
            btnGuardarProductosInventario.UseVisualStyleBackColor = false;
            btnGuardarProductosInventario.Click += btnGuardarProductosInventario_Click;
            // 
            // cmbUnidadMedida
            // 
            cmbUnidadMedida.FormattingEnabled = true;
            cmbUnidadMedida.Location = new Point(1189, 127);
            cmbUnidadMedida.Name = "cmbUnidadMedida";
            cmbUnidadMedida.Size = new Size(191, 40);
            cmbUnidadMedida.TabIndex = 18;
            // 
            // cmbCategoriaProducto
            // 
            cmbCategoriaProducto.FormattingEnabled = true;
            cmbCategoriaProducto.Location = new Point(255, 139);
            cmbCategoriaProducto.Name = "cmbCategoriaProducto";
            cmbCategoriaProducto.Size = new Size(240, 40);
            cmbCategoriaProducto.TabIndex = 17;
            // 
            // txtStockProducto
            // 
            txtStockProducto.Location = new Point(699, 128);
            txtStockProducto.Name = "txtStockProducto";
            txtStockProducto.Size = new Size(287, 39);
            txtStockProducto.TabIndex = 16;
            txtStockProducto.KeyPress += NumerosDecimales_KeyPress;
            // 
            // txtDescripcionProducto
            // 
            txtDescripcionProducto.Location = new Point(699, 69);
            txtDescripcionProducto.Name = "txtDescripcionProducto";
            txtDescripcionProducto.Size = new Size(287, 39);
            txtDescripcionProducto.TabIndex = 14;
            // 
            // txtPrecioProducto
            // 
            txtPrecioProducto.Location = new Point(1180, 67);
            txtPrecioProducto.Name = "txtPrecioProducto";
            txtPrecioProducto.Size = new Size(191, 39);
            txtPrecioProducto.TabIndex = 12;
            txtPrecioProducto.KeyPress += NumerosDecimales_KeyPress;
            // 
            // txtCodigoBarras
            // 
            txtCodigoBarras.Location = new Point(255, 75);
            txtCodigoBarras.Name = "txtCodigoBarras";
            txtCodigoBarras.Size = new Size(232, 39);
            txtCodigoBarras.TabIndex = 11;
            txtCodigoBarras.KeyPress += SoloNumeros_KeyPress;
            txtCodigoBarras.Leave += txtCodigoBarras_Leave;
            // 
            // labelDescripcion
            // 
            labelDescripcion.AutoSize = true;
            labelDescripcion.Location = new Point(551, 80);
            labelDescripcion.Name = "labelDescripcion";
            labelDescripcion.Size = new Size(138, 32);
            labelDescripcion.TabIndex = 8;
            labelDescripcion.Text = "Descripcion";
            // 
            // labelUInidadMedida
            // 
            labelUInidadMedida.AutoSize = true;
            labelUInidadMedida.Location = new Point(1005, 131);
            labelUInidadMedida.Name = "labelUInidadMedida";
            labelUInidadMedida.Size = new Size(178, 32);
            labelUInidadMedida.TabIndex = 5;
            labelUInidadMedida.Text = "Unidad Medida";
            // 
            // labelStock
            // 
            labelStock.AutoSize = true;
            labelStock.Location = new Point(619, 139);
            labelStock.Name = "labelStock";
            labelStock.Size = new Size(71, 32);
            labelStock.TabIndex = 4;
            labelStock.Text = "Stock";
            // 
            // labelPrecio
            // 
            labelPrecio.AutoSize = true;
            labelPrecio.Location = new Point(1037, 69);
            labelPrecio.Name = "labelPrecio";
            labelPrecio.Size = new Size(79, 32);
            labelPrecio.TabIndex = 3;
            labelPrecio.Text = "Precio";
            // 
            // labelCategoria
            // 
            labelCategoria.AutoSize = true;
            labelCategoria.Location = new Point(47, 147);
            labelCategoria.Name = "labelCategoria";
            labelCategoria.Size = new Size(116, 32);
            labelCategoria.TabIndex = 2;
            labelCategoria.Text = "Categoria";
            // 
            // labelCodigoBarra
            // 
            labelCodigoBarra.AutoSize = true;
            labelCodigoBarra.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelCodigoBarra.Location = new Point(47, 82);
            labelCodigoBarra.Name = "labelCodigoBarra";
            labelCodigoBarra.Size = new Size(196, 32);
            labelCodigoBarra.TabIndex = 0;
            labelCodigoBarra.Text = "Codigo de Barras";
            // 
            // panelSuperior
            // 
            panelSuperior.Controls.Add(btnLimpiarfiltros);
            panelSuperior.Controls.Add(label2);
            panelSuperior.Controls.Add(label1);
            panelSuperior.Controls.Add(txtStockMax);
            panelSuperior.Controls.Add(txtStockMin);
            panelSuperior.Controls.Add(cmbFiltroCategoria);
            panelSuperior.Controls.Add(btnBuscar);
            panelSuperior.Controls.Add(txtBuscarProducto);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(0, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(2018, 61);
            panelSuperior.TabIndex = 0;
            // 
            // btnLimpiarfiltros
            // 
            btnLimpiarfiltros.Location = new Point(1771, 8);
            btnLimpiarfiltros.Margin = new Padding(5);
            btnLimpiarfiltros.Name = "btnLimpiarfiltros";
            btnLimpiarfiltros.Size = new Size(224, 46);
            btnLimpiarfiltros.TabIndex = 8;
            btnLimpiarfiltros.Text = "Limpiar Filtros";
            btnLimpiarfiltros.UseVisualStyleBackColor = true;
            btnLimpiarfiltros.Click += btnLimpiarFiltros_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(1072, 14);
            label2.Margin = new Padding(5, 0, 5, 0);
            label2.Name = "label2";
            label2.Size = new Size(134, 32);
            label2.TabIndex = 7;
            label2.Text = "Stock Min:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(1422, 16);
            label1.Margin = new Padding(5, 0, 5, 0);
            label1.Name = "label1";
            label1.Size = new Size(138, 32);
            label1.TabIndex = 6;
            label1.Text = "Stock Max:";
            // 
            // txtStockMax
            // 
            txtStockMax.Location = new Point(1558, 10);
            txtStockMax.Margin = new Padding(5);
            txtStockMax.Name = "txtStockMax";
            txtStockMax.Size = new Size(201, 39);
            txtStockMax.TabIndex = 5;
            // 
            // txtStockMin
            // 
            txtStockMin.Location = new Point(1209, 10);
            txtStockMin.Margin = new Padding(5);
            txtStockMin.Name = "txtStockMin";
            txtStockMin.Size = new Size(201, 39);
            txtStockMin.TabIndex = 4;
            // 
            // cmbFiltroCategoria
            // 
            cmbFiltroCategoria.FormattingEnabled = true;
            cmbFiltroCategoria.Location = new Point(874, 10);
            cmbFiltroCategoria.Margin = new Padding(5);
            cmbFiltroCategoria.Name = "cmbFiltroCategoria";
            cmbFiltroCategoria.Size = new Size(186, 40);
            cmbFiltroCategoria.TabIndex = 3;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(10, 11);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(198, 43);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(214, 11);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(649, 39);
            txtBuscarProducto.TabIndex = 1;
            // 
            // btnCancelarProducto
            // 
            btnCancelarProducto.Location = new Point(730, 610);
            btnCancelarProducto.Name = "btnCancelarProducto";
            btnCancelarProducto.Size = new Size(158, 86);
            btnCancelarProducto.TabIndex = 9;
            btnCancelarProducto.Text = "Cancelar";
            btnCancelarProducto.UseVisualStyleBackColor = true;
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.Location = new Point(830, 490);
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
            ClientSize = new Size(2641, 1026);
            Controls.Add(splitContainer1);
            Name = "VistaGestionInventario";
            Text = "VistaGestionInventario";
            Load += VistaGestionInventario_Load;
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataCategoria).EndInit();
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
        private Button btnGuardarCategoria;
        private DataGridView dgvCategorias;
        private Panel panelSuperior;
        private Panel panelInferior;
        private Button btnBuscar;
        private TextBox txtBuscarProducto;
        private GroupBox gbEdicionProducto;
        private DataGridView dgvProductos;
        private Label labelCodigoBarra;
        private Label labelStock;
        private Label labelPrecio;
        private Label labelCategoria;
        private Label labelUInidadMedida;
        private Button btnGuardarProducto;
        private Button btnCancelarProducto;
        private Label labelDescripcion;
        private TextBox txtCodigoBarras;
        private ContextMenuStrip contextMenuStrip1;
        private TextBox txtDescripcionProducto;
        private TextBox txtPrecioProducto;
        private TextBox txtStockProducto;
        private ComboBox cmbUnidadMedida;
        private ComboBox cmbCategoriaProducto;
        private Button btnCancelarProductosInventario;
        private Button btnGuardarProductosInventario;
        private DataGridViewTextBoxColumn colCatNombre;
        private Button btnEliminarCategoria;
        private DataGridView dataCategoria;
        private Button btnEliminarProductoInventario;
        private TextBox txtStockMax;
        private TextBox txtStockMin;
        private ComboBox cmbFiltroCategoria;
        private Label label2;
        private Label label1;
        private Button btnLimpiarfiltros;
        private Label label3;
        private TextBox txtNombreCategoria;
        private DataGridViewTextBoxColumn ColCategorias;
        private DataGridViewTextBoxColumn ColCodigo;
        private DataGridViewTextBoxColumn ColNombre;
        private DataGridViewTextBoxColumn ColPrecio;
        private DataGridViewTextBoxColumn ColStock;
        private DataGridViewTextBoxColumn ColUnidad;
        private DataGridViewTextBoxColumn Categoriaa;
    }
}
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
            dtpFechaHasta = new DateTimePicker();
            dtpFechaDesde = new DateTimePicker();
            cmbFiltroRol = new ComboBox();
            txtBuscar = new TextBox();
            label1 = new Label();
            tabControlSupervisor = new TabControl();
            tabPage1 = new TabPage();
            dgvCajero = new DataGridView();
            dgvVentas = new DataGridView();
            tabPage2 = new TabPage();
            dgvCategoria = new DataGridView();
            dgvProductosVendidos = new DataGridView();
            tabPage4 = new TabPage();
            dgvUsuarios = new DataGridView();
            IdEmpleado = new DataGridViewTextBoxColumn();
            NombreUsuario = new DataGridViewTextBoxColumn();
            ApellidoUsuario = new DataGridViewTextBoxColumn();
            RolUsuario = new DataGridViewTextBoxColumn();
            PanelMenu = new Panel();
            btnSalir = new Button();
            button3 = new Button();
            button2 = new Button();
            btnReporteVentas = new Button();
            PanelContenedor.SuspendLayout();
            tabControlSupervisor.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCajero).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCategoria).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductosVendidos).BeginInit();
            tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            PanelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelContenedor
            // 
            PanelContenedor.BackColor = Color.FromArgb(255, 224, 192);
            PanelContenedor.Controls.Add(dtpFechaHasta);
            PanelContenedor.Controls.Add(dtpFechaDesde);
            PanelContenedor.Controls.Add(cmbFiltroRol);
            PanelContenedor.Controls.Add(txtBuscar);
            PanelContenedor.Controls.Add(label1);
            PanelContenedor.Controls.Add(tabControlSupervisor);
            PanelContenedor.Dock = DockStyle.Fill;
            PanelContenedor.Location = new Point(115, 0);
            PanelContenedor.Margin = new Padding(2);
            PanelContenedor.Name = "PanelContenedor";
            PanelContenedor.Size = new Size(1114, 781);
            PanelContenedor.TabIndex = 5;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(572, 16);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(122, 27);
            dtpFechaHasta.TabIndex = 5;
            dtpFechaHasta.ValueChanged += dtpFechasReporte_ValueChanged;
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(444, 16);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(122, 27);
            dtpFechaDesde.TabIndex = 4;
            dtpFechaDesde.ValueChanged += dtpFechasReporte_ValueChanged;
            // 
            // cmbFiltroRol
            // 
            cmbFiltroRol.FormattingEnabled = true;
            cmbFiltroRol.Location = new Point(883, 16);
            cmbFiltroRol.Name = "cmbFiltroRol";
            cmbFiltroRol.Size = new Size(224, 28);
            cmbFiltroRol.TabIndex = 3;
            cmbFiltroRol.SelectedIndexChanged += cmbFiltroRol_SelectedIndexChanged_1;
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
            // tabControlSupervisor
            // 
            tabControlSupervisor.Controls.Add(tabPage1);
            tabControlSupervisor.Controls.Add(tabPage2);
            tabControlSupervisor.Controls.Add(tabPage4);
            tabControlSupervisor.Location = new Point(0, 50);
            tabControlSupervisor.Name = "tabControlSupervisor";
            tabControlSupervisor.SelectedIndex = 0;
            tabControlSupervisor.Size = new Size(1111, 731);
            tabControlSupervisor.TabIndex = 0;
            tabControlSupervisor.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(dgvCajero);
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
            // dgvCajero
            // 
            dgvCajero.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCajero.Location = new Point(3, 332);
            dgvCajero.Name = "dgvCajero";
            dgvCajero.RowHeadersWidth = 51;
            dgvCajero.Size = new Size(1091, 363);
            dgvCajero.TabIndex = 1;
            // 
            // dgvVentas
            // 
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(3, 0);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(1091, 326);
            dgvVentas.TabIndex = 0;
            dgvVentas.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvCategoria);
            tabPage2.Controls.Add(dgvProductosVendidos);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1103, 698);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Productos Vendidos";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvCategoria
            // 
            dgvCategoria.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategoria.Location = new Point(6, 346);
            dgvCategoria.Name = "dgvCategoria";
            dgvCategoria.RowHeadersWidth = 51;
            dgvCategoria.Size = new Size(1091, 344);
            dgvCategoria.TabIndex = 1;
            // 
            // dgvProductosVendidos
            // 
            dgvProductosVendidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductosVendidos.Location = new Point(6, 6);
            dgvProductosVendidos.Name = "dgvProductosVendidos";
            dgvProductosVendidos.RowHeadersWidth = 51;
            dgvProductosVendidos.Size = new Size(1091, 334);
            dgvProductosVendidos.TabIndex = 0;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(dgvUsuarios);
            tabPage4.Location = new Point(4, 29);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1103, 698);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Control de Usuarios";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { IdEmpleado, NombreUsuario, ApellidoUsuario, RolUsuario });
            dgvUsuarios.Location = new Point(1, 3);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(1096, 692);
            dgvUsuarios.TabIndex = 0;
            // 
            // IdEmpleado
            // 
            IdEmpleado.DataPropertyName = "Id Empleado";
            IdEmpleado.HeaderText = "Id Empleado";
            IdEmpleado.MinimumWidth = 6;
            IdEmpleado.Name = "IdEmpleado";
            IdEmpleado.Width = 125;
            // 
            // NombreUsuario
            // 
            NombreUsuario.DataPropertyName = "Nombre";
            NombreUsuario.HeaderText = "Nombre";
            NombreUsuario.MinimumWidth = 6;
            NombreUsuario.Name = "NombreUsuario";
            NombreUsuario.Width = 125;
            // 
            // ApellidoUsuario
            // 
            ApellidoUsuario.DataPropertyName = "Apellido";
            ApellidoUsuario.HeaderText = "Apellido";
            ApellidoUsuario.MinimumWidth = 6;
            ApellidoUsuario.Name = "ApellidoUsuario";
            ApellidoUsuario.Width = 125;
            // 
            // RolUsuario
            // 
            RolUsuario.DataPropertyName = "Rol";
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
            PanelMenu.Controls.Add(btnReporteVentas);
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
            // btnReporteVentas
            // 
            btnReporteVentas.Image = Properties.Resources.reporte;
            btnReporteVentas.Location = new Point(12, 12);
            btnReporteVentas.Name = "btnReporteVentas";
            btnReporteVentas.Size = new Size(97, 127);
            btnReporteVentas.TabIndex = 0;
            btnReporteVentas.Text = "Ventas";
            btnReporteVentas.TextAlign = ContentAlignment.BottomCenter;
            btnReporteVentas.UseVisualStyleBackColor = true;
            btnReporteVentas.Click += btnReporteVentas_Click;
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
            tabControlSupervisor.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCajero).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCategoria).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvProductosVendidos).EndInit();
            tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            PanelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelContenedor;
        private Panel PanelMenu;
        private Button btnReporteVentas;
        private TabControl tabControlSupervisor;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button button3;
        private Button button2;
        private DataGridView dgvVentas;
        private TextBox txtBuscar;
        private Label label1;
        private DataGridView dgvProductosVendidos;
        private Button btnSalir;
        private TabPage tabPage4;
        private DataGridView dgvUsuarios;
        private ComboBox cmbFiltroRol;
        private DataGridViewTextBoxColumn IdEmpleado;
        private DataGridViewTextBoxColumn NombreUsuario;
        private DataGridViewTextBoxColumn ApellidoUsuario;
        private DataGridViewTextBoxColumn RolUsuario;
        private DateTimePicker dtpFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private DataGridView dgvCajero;
        private DataGridView dgvCategoria;
    }
}
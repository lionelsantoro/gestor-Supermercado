namespace DesktopAppSupermercado.VISTASCAJERO
{
    partial class Historial
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
            dtpFechaDesde = new DateTimePicker();
            dtpFechaHasta = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtBuscarVenta = new TextBox();
            dvgVenta = new DataGridView();
            dvgDetalleVenta = new DataGridView();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dvgVenta).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dvgDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(103, 12);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(133, 27);
            dtpFechaDesde.TabIndex = 0;
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(329, 12);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(125, 27);
            dtpFechaHasta.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(85, 31);
            label1.TabIndex = 2;
            label1.Text = "Desde:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(242, 8);
            label2.Name = "label2";
            label2.Size = new Size(81, 31);
            label2.TabIndex = 3;
            label2.Text = "Hasta:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 56);
            label3.Name = "label3";
            label3.Size = new Size(239, 31);
            label3.TabIndex = 4;
            label3.Text = "Buscar por Nº Ticket:";
            // 
            // txtBuscarVenta
            // 
            txtBuscarVenta.Location = new Point(257, 60);
            txtBuscarVenta.Name = "txtBuscarVenta";
            txtBuscarVenta.Size = new Size(197, 27);
            txtBuscarVenta.TabIndex = 5;
            txtBuscarVenta.TextChanged += txtBuscarVenta_TextChanged;
            // 
            // dvgVenta
            // 
            dvgVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgVenta.Location = new Point(12, 93);
            dvgVenta.Name = "dvgVenta";
            dvgVenta.RowHeadersWidth = 51;
            dvgVenta.Size = new Size(776, 215);
            dvgVenta.TabIndex = 6;
            dvgVenta.SelectionChanged += dvgVenta_SelectionChanged;
            // 
            // dvgDetalleVenta
            // 
            dvgDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dvgDetalleVenta.Location = new Point(12, 314);
            dvgDetalleVenta.Name = "dvgDetalleVenta";
            dvgDetalleVenta.RowHeadersWidth = 51;
            dvgDetalleVenta.Size = new Size(776, 332);
            dvgDetalleVenta.TabIndex = 7;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(460, 58);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // Historial
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(800, 658);
            Controls.Add(btnBuscar);
            Controls.Add(dvgDetalleVenta);
            Controls.Add(dvgVenta);
            Controls.Add(txtBuscarVenta);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpFechaHasta);
            Controls.Add(dtpFechaDesde);
            Name = "Historial";
            Text = "VistaReportesCajero";
            Load += Historial_Load;
            ((System.ComponentModel.ISupportInitialize)dvgVenta).EndInit();
            ((System.ComponentModel.ISupportInitialize)dvgDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DateTimePicker dtpFechaDesde;
        private DateTimePicker dtpFechaHasta;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtBuscarVenta;
        private DataGridView dvgVenta;
        private DataGridView dvgDetalleVenta;
        private Button btnBuscar;
    }
}
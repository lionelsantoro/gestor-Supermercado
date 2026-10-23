namespace DesktopAppSupermercado
{
    partial class FormCodigoBarra
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
            label1 = new Label();
            label2 = new Label();
            txtBuscarProducto = new TextBox();
            dgvProducto = new DataGridView();
            cmbCategoria = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvProducto).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(11, 20);
            label1.Name = "label1";
            label1.Size = new Size(0, 31);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(29, 20);
            label2.Name = "label2";
            label2.Size = new Size(196, 31);
            label2.TabIndex = 2;
            label2.Text = "Buscar producto:";
            label2.Click += label2_Click;
            // 
            // txtBuscarProducto
            // 
            txtBuscarProducto.Location = new Point(231, 24);
            txtBuscarProducto.Name = "txtBuscarProducto";
            txtBuscarProducto.Size = new Size(382, 27);
            txtBuscarProducto.TabIndex = 3;
            // 
            // dgvProducto
            // 
            dgvProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProducto.Location = new Point(11, 68);
            dgvProducto.Name = "dgvProducto";
            dgvProducto.RowHeadersWidth = 51;
            dgvProducto.Size = new Size(870, 442);
            dgvProducto.TabIndex = 4;
            // 
            // cmbCategoria
            // 
            cmbCategoria.FormattingEnabled = true;
            cmbCategoria.Location = new Point(634, 23);
            cmbCategoria.Name = "cmbCategoria";
            cmbCategoria.Size = new Size(247, 28);
            cmbCategoria.TabIndex = 5;
            // 
            // FormCodigoBarra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(893, 522);
            Controls.Add(cmbCategoria);
            Controls.Add(dgvProducto);
            Controls.Add(txtBuscarProducto);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormCodigoBarra";
            Text = "FormCodigoBarra";
            Load += FormCodigoBarra_Load;
            ((System.ComponentModel.ISupportInitialize)dgvProducto).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtBuscarProducto;
        private DataGridView dgvProducto;
        private ComboBox cmbCategoria;
    }
}
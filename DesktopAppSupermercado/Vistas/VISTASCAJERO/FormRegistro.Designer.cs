namespace DesktopAppSupermercado
{
    partial class FormRegistro
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
            label3 = new Label();
            label4 = new Label();
            cmbNumeroCajero = new ComboBox();
            cmbNumeroCaja = new ComboBox();
            dgvRegistro = new DataGridView();
            btnConfirmarRegistro = new Button();
            btnLimpiarRegistro = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRegistro).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(5, 31);
            label1.Name = "label1";
            label1.Size = new Size(0, 31);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(402, 39);
            label2.Name = "label2";
            label2.Size = new Size(0, 31);
            label2.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(5, 19);
            label3.Name = "label3";
            label3.Size = new Size(214, 31);
            label3.TabIndex = 2;
            label3.Text = "Numero de Cajero:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(302, 19);
            label4.Name = "label4";
            label4.Size = new Size(191, 31);
            label4.TabIndex = 3;
            label4.Text = "Numero de Caja:";
            // 
            // cmbNumeroCajero
            // 
            cmbNumeroCajero.FormattingEnabled = true;
            cmbNumeroCajero.Location = new Point(216, 22);
            cmbNumeroCajero.Name = "cmbNumeroCajero";
            cmbNumeroCajero.Size = new Size(80, 28);
            cmbNumeroCajero.TabIndex = 4;
            // 
            // cmbNumeroCaja
            // 
            cmbNumeroCaja.FormattingEnabled = true;
            cmbNumeroCaja.Location = new Point(489, 22);
            cmbNumeroCaja.Name = "cmbNumeroCaja";
            cmbNumeroCaja.Size = new Size(85, 28);
            cmbNumeroCaja.TabIndex = 5;
            // 
            // dgvRegistro
            // 
            dgvRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistro.Location = new Point(5, 103);
            dgvRegistro.Name = "dgvRegistro";
            dgvRegistro.RowHeadersWidth = 51;
            dgvRegistro.Size = new Size(569, 401);
            dgvRegistro.TabIndex = 6;
            // 
            // btnConfirmarRegistro
            // 
            btnConfirmarRegistro.Location = new Point(5, 65);
            btnConfirmarRegistro.Name = "btnConfirmarRegistro";
            btnConfirmarRegistro.Size = new Size(153, 29);
            btnConfirmarRegistro.TabIndex = 7;
            btnConfirmarRegistro.Text = "Confirmar Registro";
            btnConfirmarRegistro.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarRegistro
            // 
            btnLimpiarRegistro.Location = new Point(164, 65);
            btnLimpiarRegistro.Name = "btnLimpiarRegistro";
            btnLimpiarRegistro.Size = new Size(132, 29);
            btnLimpiarRegistro.TabIndex = 8;
            btnLimpiarRegistro.Text = "Limpiar Registro";
            btnLimpiarRegistro.UseVisualStyleBackColor = true;
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(586, 516);
            Controls.Add(btnLimpiarRegistro);
            Controls.Add(btnConfirmarRegistro);
            Controls.Add(dgvRegistro);
            Controls.Add(cmbNumeroCaja);
            Controls.Add(cmbNumeroCajero);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormRegistro";
            Load += FormRegistro_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRegistro).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cmbNumeroCajero;
        private ComboBox cmbNumeroCaja;
        private DataGridView dgvRegistro;
        private Button btnConfirmarRegistro;
        private Button btnLimpiarRegistro;
    }
}
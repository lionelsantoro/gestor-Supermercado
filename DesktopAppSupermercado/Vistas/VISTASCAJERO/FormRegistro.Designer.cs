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
            dgvRegistro = new DataGridView();
            txtNombreCajero = new TextBox();
            txtNumeroCajero = new TextBox();
            label5 = new Label();
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
            label3.Location = new Point(49, 9);
            label3.Name = "label3";
            label3.Size = new Size(221, 31);
            label3.TabIndex = 2;
            label3.Text = "Numero del Cajero:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(302, 19);
            label4.Name = "label4";
            label4.Size = new Size(0, 31);
            label4.TabIndex = 3;
            // 
            // dgvRegistro
            // 
            dgvRegistro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRegistro.Location = new Point(5, 84);
            dgvRegistro.Name = "dgvRegistro";
            dgvRegistro.RowHeadersWidth = 51;
            dgvRegistro.Size = new Size(569, 420);
            dgvRegistro.TabIndex = 6;
            // 
            // txtNombreCajero
            // 
            txtNombreCajero.Location = new Point(276, 44);
            txtNombreCajero.Name = "txtNombreCajero";
            txtNombreCajero.ReadOnly = true;
            txtNombreCajero.Size = new Size(266, 27);
            txtNombreCajero.TabIndex = 7;
            // 
            // txtNumeroCajero
            // 
            txtNumeroCajero.Location = new Point(276, 13);
            txtNumeroCajero.Name = "txtNumeroCajero";
            txtNumeroCajero.ReadOnly = true;
            txtNumeroCajero.Size = new Size(266, 27);
            txtNumeroCajero.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(52, 40);
            label5.Name = "label5";
            label5.Size = new Size(218, 31);
            label5.TabIndex = 9;
            label5.Text = "Nombre del cajero:";
            // 
            // FormRegistro
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(586, 516);
            Controls.Add(label5);
            Controls.Add(txtNumeroCajero);
            Controls.Add(txtNombreCajero);
            Controls.Add(dgvRegistro);
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
        private DataGridView dgvRegistro;
        private TextBox txtNombreCajero;
        private TextBox txtNumeroCajero;
        private Label label5;
    }
}
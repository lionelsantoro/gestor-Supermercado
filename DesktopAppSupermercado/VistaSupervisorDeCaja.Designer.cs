namespace DesktopAppSupermercado
{
    partial class VistaSupervisorDeCaja
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
            dataGridView1 = new DataGridView();
            Id_anulacion = new DataGridViewTextBoxColumn();
            Id_usuario = new DataGridViewTextBoxColumn();
            Motivo = new DataGridViewTextBoxColumn();
            Fecha = new DataGridViewTextBoxColumn();
            Estado = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            IdAnulacion = new DataGridViewTextBoxColumn();
            IdUsuario = new DataGridViewTextBoxColumn();
            Motivoo = new DataGridViewTextBoxColumn();
            Fechaa = new DataGridViewTextBoxColumn();
            Monto = new DataGridViewTextBoxColumn();
            Estadoo = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Id_anulacion, Id_usuario, Motivo, Fecha, Estado });
            dataGridView1.Location = new Point(12, 45);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(677, 322);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Id_anulacion
            // 
            Id_anulacion.HeaderText = "Id_compra";
            Id_anulacion.MinimumWidth = 6;
            Id_anulacion.Name = "Id_anulacion";
            Id_anulacion.Width = 125;
            // 
            // Id_usuario
            // 
            Id_usuario.HeaderText = "Id_usuario";
            Id_usuario.MinimumWidth = 6;
            Id_usuario.Name = "Id_usuario";
            Id_usuario.Width = 125;
            // 
            // Motivo
            // 
            Motivo.HeaderText = "Motivo";
            Motivo.MinimumWidth = 6;
            Motivo.Name = "Motivo";
            Motivo.Width = 125;
            // 
            // Fecha
            // 
            Fecha.HeaderText = "Fecha";
            Fecha.MinimumWidth = 6;
            Fecha.Name = "Fecha";
            Fecha.Width = 125;
            // 
            // Estado
            // 
            Estado.HeaderText = "Estado";
            Estado.MinimumWidth = 6;
            Estado.Name = "Estado";
            Estado.Width = 125;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { IdAnulacion, IdUsuario, Motivoo, Fechaa, Monto, Estadoo });
            dataGridView2.Location = new Point(12, 425);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(804, 412);
            dataGridView2.TabIndex = 1;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // IdAnulacion
            // 
            IdAnulacion.HeaderText = "Id_anulacion";
            IdAnulacion.MinimumWidth = 6;
            IdAnulacion.Name = "IdAnulacion";
            IdAnulacion.Width = 125;
            // 
            // IdUsuario
            // 
            IdUsuario.HeaderText = "Id_usuario";
            IdUsuario.MinimumWidth = 6;
            IdUsuario.Name = "IdUsuario";
            IdUsuario.Width = 125;
            // 
            // Motivoo
            // 
            Motivoo.HeaderText = "Motivo";
            Motivoo.MinimumWidth = 6;
            Motivoo.Name = "Motivoo";
            Motivoo.Width = 125;
            // 
            // Fechaa
            // 
            Fechaa.HeaderText = "Fecha";
            Fechaa.MinimumWidth = 6;
            Fechaa.Name = "Fechaa";
            Fechaa.Width = 125;
            // 
            // Monto
            // 
            Monto.HeaderText = "Monto";
            Monto.MinimumWidth = 6;
            Monto.Name = "Monto";
            Monto.Width = 125;
            // 
            // Estadoo
            // 
            Estadoo.HeaderText = "Estado";
            Estadoo.MinimumWidth = 6;
            Estadoo.Name = "Estadoo";
            Estadoo.Width = 125;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(132, 28);
            label1.TabIndex = 2;
            label1.Text = "Anulaciones:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 380);
            label2.Name = "label2";
            label2.Size = new Size(144, 28);
            label2.TabIndex = 3;
            label2.Text = "Devoluciones:";
            // 
            // button1
            // 
            button1.Image = Properties.Resources.Screenshot_2026_08_31_1520083;
            button1.Location = new Point(750, 153);
            button1.Name = "button1";
            button1.Size = new Size(146, 147);
            button1.TabIndex = 4;
            button1.Text = "Devolucion";
            button1.TextAlign = ContentAlignment.BottomCenter;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(701, 45);
            label3.Name = "label3";
            label3.Size = new Size(259, 41);
            label3.TabIndex = 5;
            label3.Text = "Total Recaudado:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(733, 86);
            label4.Name = "label4";
            label4.Size = new Size(198, 46);
            label4.TabIndex = 6;
            label4.Text = "$2.450.000";
            label4.Click += label4_Click;
            // 
            // VistaSupervisorDeCaja
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(972, 849);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Name = "VistaSupervisorDeCaja";
            Text = "VistaSupervisorDeCaja";
            Load += VistaSupervisorDeCaja_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn IdAnulacion;
        private DataGridViewTextBoxColumn IdUsuario;
        private DataGridViewTextBoxColumn Motivoo;
        private DataGridViewTextBoxColumn Fechaa;
        private DataGridViewTextBoxColumn Monto;
        private DataGridViewTextBoxColumn Estadoo;
        private Label label1;
        private DataGridViewTextBoxColumn Id_anulacion;
        private DataGridViewTextBoxColumn Id_usuario;
        private DataGridViewTextBoxColumn Motivo;
        private DataGridViewTextBoxColumn Fecha;
        private DataGridViewTextBoxColumn Estado;
        private Label label2;
        private Button button1;
        private Label label3;
        private Label label4;
    }
}
namespace DesktopAppSupermercado.VISTASADMIN
{
    partial class VistaBackupAdmin
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
            txtBaseDatos = new Label();
            label3 = new Label();
            txtBaseDato = new TextBox();
            txtRuta = new TextBox();
            btnConectar = new Button();
            btnRuta = new Button();
            btnEjecutarBackup = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(86, 35);
            label1.Name = "label1";
            label1.Size = new Size(185, 59);
            label1.TabIndex = 0;
            label1.Text = "BackUp";
            label1.Click += label1_Click;
            // 
            // txtBaseDatos
            // 
            txtBaseDatos.AutoSize = true;
            txtBaseDatos.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBaseDatos.Location = new Point(95, 136);
            txtBaseDatos.Name = "txtBaseDatos";
            txtBaseDatos.Size = new Size(179, 32);
            txtBaseDatos.TabIndex = 1;
            txtBaseDatos.Text = "Base de Datos";
            txtBaseDatos.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(110, 207);
            label3.Name = "label3";
            label3.Size = new Size(161, 32);
            label3.TabIndex = 2;
            label3.Text = "RutaGuardar";
            label3.Click += label3_Click;
            // 
            // txtBaseDato
            // 
            txtBaseDato.Location = new Point(280, 136);
            txtBaseDato.Name = "txtBaseDato";
            txtBaseDato.Size = new Size(225, 39);
            txtBaseDato.TabIndex = 3;
            // 
            // txtRuta
            // 
            txtRuta.Location = new Point(277, 207);
            txtRuta.Name = "txtRuta";
            txtRuta.Size = new Size(475, 39);
            txtRuta.TabIndex = 4;
            // 
            // btnConectar
            // 
            btnConectar.Location = new Point(511, 132);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(150, 46);
            btnConectar.TabIndex = 5;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            // 
            // btnRuta
            // 
            btnRuta.Location = new Point(780, 203);
            btnRuta.Name = "btnRuta";
            btnRuta.Size = new Size(150, 46);
            btnRuta.TabIndex = 6;
            btnRuta.Text = "Ruta";
            btnRuta.UseVisualStyleBackColor = true;
            // 
            // btnEjecutarBackup
            // 
            btnEjecutarBackup.Location = new Point(794, 291);
            btnEjecutarBackup.Name = "btnEjecutarBackup";
            btnEjecutarBackup.Size = new Size(329, 102);
            btnEjecutarBackup.TabIndex = 7;
            btnEjecutarBackup.Text = "Back Up";
            btnEjecutarBackup.UseVisualStyleBackColor = true;
            // 
            // VistaBackupAdmin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1671, 749);
            Controls.Add(btnEjecutarBackup);
            Controls.Add(btnRuta);
            Controls.Add(btnConectar);
            Controls.Add(txtRuta);
            Controls.Add(txtBaseDato);
            Controls.Add(label3);
            Controls.Add(txtBaseDatos);
            Controls.Add(label1);
            Name = "VistaBackupAdmin";
            Text = "VistaBackupAdmin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label txtBaseDatos;
        private Label label3;
        private TextBox txtBaseDato;
        private TextBox txtRuta;
        private Button btnConectar;
        private Button btnRuta;
        private Button btnEjecutarBackup;
    }
}
namespace DesktopAppSupermercado.VISTASADMIN
{
    partial class VistaReportesAdmin
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
            panel1 = new Panel();
            btnListaUsuarios = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(88, 67);
            label1.Name = "label1";
            label1.Size = new Size(337, 32);
            label1.TabIndex = 0;
            label1.Text = "Reportes del Administrador";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(128, 255, 128);
            panel1.Controls.Add(btnListaUsuarios);
            panel1.Location = new Point(292, 133);
            panel1.Name = "panel1";
            panel1.Size = new Size(611, 310);
            panel1.TabIndex = 1;
            // 
            // btnListaUsuarios
            // 
            btnListaUsuarios.Location = new Point(136, 81);
            btnListaUsuarios.Name = "btnListaUsuarios";
            btnListaUsuarios.Size = new Size(333, 120);
            btnListaUsuarios.TabIndex = 2;
            btnListaUsuarios.Text = "Lista de usuarios";
            btnListaUsuarios.UseVisualStyleBackColor = true;
            // 
            // VistaReportesAdmin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1355, 738);
            Controls.Add(panel1);
            Controls.Add(label1);
            Name = "VistaReportesAdmin";
            Text = "VistaReportesAdmin";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Button btnListaUsuarios;
    }
}
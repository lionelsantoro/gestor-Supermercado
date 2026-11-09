namespace DesktopAppSupermercado
{
    partial class FormBorrarVenta
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
            label4 = new Label();
            btnConfirmar = new Button();
            btnSalir = new Button();
            label1 = new Label();
            txtCodigo = new TextBox();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(50, 110);
            label4.Name = "label4";
            label4.Size = new Size(0, 28);
            label4.TabIndex = 3;
            // 
            // btnConfirmar
            // 
            btnConfirmar.Location = new Point(12, 78);
            btnConfirmar.Name = "btnConfirmar";
            btnConfirmar.Size = new Size(94, 29);
            btnConfirmar.TabIndex = 10;
            btnConfirmar.Text = "Confirmar";
            btnConfirmar.UseVisualStyleBackColor = true;
            btnConfirmar.Click += btnConfirmar_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(384, 78);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 11;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 26);
            label1.Name = "label1";
            label1.Size = new Size(329, 31);
            label1.TabIndex = 12;
            label1.Text = "Ingrese codigo de supervisor:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(340, 30);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(138, 27);
            txtCodigo.TabIndex = 13;
            txtCodigo.KeyPress += txtCodigo_KeyPress;
            // 
            // FormBorrarVenta
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(490, 123);
            Controls.Add(txtCodigo);
            Controls.Add(label1);
            Controls.Add(btnSalir);
            Controls.Add(btnConfirmar);
            Controls.Add(label4);
            Name = "FormBorrarVenta";
            Text = "FormBorrarVenta";
            Load += FormBorrarVenta_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label4;
        private Button btnConfirmar;
        private Button btnSalir;
        private Label label1;
        private TextBox txtCodigo;
    }
}
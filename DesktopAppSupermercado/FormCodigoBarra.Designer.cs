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
            btnCancelarCodBarra = new Button();
            btnAgregarCodBarra = new Button();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox4 = new TextBox();
            SuspendLayout();
            // 
            // btnCancelarCodBarra
            // 
            btnCancelarCodBarra.Location = new Point(313, 227);
            btnCancelarCodBarra.Name = "btnCancelarCodBarra";
            btnCancelarCodBarra.Size = new Size(94, 29);
            btnCancelarCodBarra.TabIndex = 19;
            btnCancelarCodBarra.Text = "Cancelar";
            btnCancelarCodBarra.UseVisualStyleBackColor = true;
            btnCancelarCodBarra.Click += btnCancelarCodBarra_Click;
            // 
            // btnAgregarCodBarra
            // 
            btnAgregarCodBarra.Location = new Point(12, 227);
            btnAgregarCodBarra.Name = "btnAgregarCodBarra";
            btnAgregarCodBarra.Size = new Size(94, 29);
            btnAgregarCodBarra.TabIndex = 18;
            btnAgregarCodBarra.Text = "Agregar";
            btnAgregarCodBarra.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(178, 181);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(229, 27);
            textBox3.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(56, 177);
            label4.Name = "label4";
            label4.Size = new Size(116, 31);
            label4.TabIndex = 16;
            label4.Text = "Cantidad:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(178, 130);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(229, 27);
            textBox2.TabIndex = 15;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(178, 79);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(229, 27);
            textBox1.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(85, 126);
            label3.Name = "label3";
            label3.Size = new Size(87, 31);
            label3.TabIndex = 13;
            label3.Text = "Precio:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(64, 79);
            label2.Name = "label2";
            label2.Size = new Size(108, 31);
            label2.TabIndex = 12;
            label2.Text = "Nombre:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 27);
            label1.Name = "label1";
            label1.Size = new Size(160, 31);
            label1.TabIndex = 10;
            label1.Text = "Codigo Barra:";
            label1.Click += label1_Click;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(178, 33);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(229, 27);
            textBox4.TabIndex = 20;
            textBox4.TextChanged += textBox4_TextChanged;
            // 
            // FormCodigoBarra
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(430, 264);
            Controls.Add(textBox4);
            Controls.Add(btnCancelarCodBarra);
            Controls.Add(btnAgregarCodBarra);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormCodigoBarra";
            Text = "FormCodigoBarra";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCancelarCodBarra;
        private Button btnAgregarCodBarra;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox4;
    }
}
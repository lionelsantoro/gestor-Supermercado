namespace DesktopAppSupermercado
{
    partial class FormNuevaCategoria
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
            textBox5 = new TextBox();
            label2 = new Label();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            textBox1 = new TextBox();
            SuspendLayout();
            // 
            // textBox5
            // 
            textBox5.Location = new Point(182, 35);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 79);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 16;
            label2.Text = "Descripcion:";
            label2.Click += label2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 42);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 15;
            label1.Text = "Nombre:";
            // 
            // button2
            // 
            button2.Location = new Point(213, 115);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 22;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(40, 115);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 21;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(182, 72);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 23;
            // 
            // FormNuevaCategoria
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(326, 157);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox5);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormNuevaCategoria";
            Text = "FormNuevaCategoria";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox5;
        private Label label2;
        private Label label1;
        private Button button2;
        private Button button1;
        private TextBox textBox1;
    }
}
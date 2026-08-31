namespace DesktopAppSupermercado
{
    partial class FormNuevoProducto
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
            label5 = new Label();
            label6 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox5 = new TextBox();
            textBox6 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(55, 56);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 0;
            label1.Text = "Nombre:";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(55, 93);
            label2.Name = "label2";
            label2.Size = new Size(94, 20);
            label2.TabIndex = 1;
            label2.Text = "Id_categoria:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 170);
            label3.Name = "label3";
            label3.Size = new Size(48, 20);
            label3.TabIndex = 3;
            label3.Text = "Stock:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(55, 133);
            label4.Name = "label4";
            label4.Size = new Size(53, 20);
            label4.TabIndex = 2;
            label4.Text = "Precio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(55, 250);
            label5.Name = "label5";
            label5.Size = new Size(121, 20);
            label5.TabIndex = 5;
            label5.Text = "Codigo de barra:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(55, 208);
            label6.Name = "label6";
            label6.Size = new Size(136, 20);
            label6.TabIndex = 4;
            label6.Text = "Unidad de medida:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(197, 163);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 7;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(197, 126);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(125, 27);
            textBox3.TabIndex = 8;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(197, 49);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(125, 27);
            textBox5.TabIndex = 10;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(197, 243);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(125, 27);
            textBox6.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(55, 308);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 12;
            button1.Text = "Guardar";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(228, 308);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 13;
            button2.Text = "Eliminar";
            button2.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Almacen", "Bebibas", "Verduleria", "Envasados", "Fiambreria" });
            comboBox1.Location = new Point(197, 85);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(125, 28);
            comboBox1.TabIndex = 14;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Unidad", "Kilogramos" });
            comboBox2.Location = new Point(197, 200);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(125, 28);
            comboBox2.TabIndex = 15;
            // 
            // FormNuevoProducto
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(369, 362);
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox6);
            Controls.Add(textBox5);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormNuevoProducto";
            Text = "FormNuevoProducto";
            Load += FormNuevoProducto_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox5;
        private TextBox textBox6;
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}
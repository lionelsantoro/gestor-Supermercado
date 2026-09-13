namespace DesktopAppSupermercado
{
    partial class FormPruebaConexionBD
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
            button1 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(168, 112);
            button1.Name = "button1";
            button1.Size = new Size(173, 29);
            button1.TabIndex = 0;
            button1.Text = "Conexion a la BD";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // FormPruebaConexionBD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(521, 305);
            Controls.Add(button1);
            Name = "FormPruebaConexionBD";
            Text = "FormPruebaConexionBD";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
    }
}
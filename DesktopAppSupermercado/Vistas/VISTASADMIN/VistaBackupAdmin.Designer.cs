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
            DataGridViewCellStyle dataGridViewCellStyle21 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle22 = new DataGridViewCellStyle();
            label1 = new Label();
            lblBaseDatos = new Label();
            txtBaseDatos = new TextBox();
            btnActualizar = new Button();
            btnBackup = new Button();
            btnRestore = new Button();
            chkFiltrarFechas = new CheckBox();
            lblDesde = new Label();
            dtpDesde = new DateTimePicker();
            lblHasta = new Label();
            dtpHasta = new DateTimePicker();
            lblEstado = new Label();
            sfdBackup = new SaveFileDialog();
            dgvBackups = new DataGridView();
            colFecha = new DataGridViewTextBoxColumn();
            colTamano = new DataGridViewTextBoxColumn();
            colDuracion = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colDisponible = new DataGridViewTextBoxColumn();
            colRuta = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBackups).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(50, 18);
            label1.Name = "label1";
            label1.Size = new Size(280, 75);
            label1.TabIndex = 0;
            label1.Text = "BackUp";
            label1.Click += label1_Click;
            // 
            // lblBaseDatos
            // 
            lblBaseDatos.AutoSize = true;
            lblBaseDatos.Font = new Font("Segoe UI Black", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblBaseDatos.Location = new Point(67, 136);
            lblBaseDatos.Name = "lblBaseDatos";
            lblBaseDatos.Size = new Size(179, 32);
            lblBaseDatos.TabIndex = 1;
            lblBaseDatos.Text = "Base de Datos";
            lblBaseDatos.Click += label2_Click;
            // 
            // txtBaseDatos
            // 
            txtBaseDatos.Location = new Point(252, 136);
            txtBaseDatos.Name = "txtBaseDatos";
            txtBaseDatos.ReadOnly = true;
            txtBaseDatos.Size = new Size(360, 39);
            txtBaseDatos.TabIndex = 3;
            // 
            // btnActualizar
            // 
            btnActualizar.BackColor = Color.FromArgb(128, 255, 128);
            btnActualizar.ForeColor = SystemColors.ActiveCaptionText;
            btnActualizar.Location = new Point(618, 124);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(180, 57);
            btnActualizar.TabIndex = 5;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = false;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // btnBackup
            // 
            btnBackup.BackColor = Color.MediumPurple;
            btnBackup.Font = new Font("Arial Black", 16.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBackup.ForeColor = SystemColors.ButtonFace;
            btnBackup.Image = Properties.Resources.google_backup_and_sync_macos_bigsur_icon_190135;
            btnBackup.ImageAlign = ContentAlignment.TopCenter;
            btnBackup.Location = new Point(283, 181);
            btnBackup.Name = "btnBackup";
            btnBackup.Size = new Size(329, 165);
            btnBackup.TabIndex = 7;
            btnBackup.Text = "Back Up";
            btnBackup.TextAlign = ContentAlignment.BottomCenter;
            btnBackup.UseVisualStyleBackColor = false;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnRestore
            // 
            btnRestore.Enabled = false;
            btnRestore.Location = new Point(837, 100);
            btnRestore.Name = "btnRestore";
            btnRestore.Size = new Size(248, 197);
            btnRestore.TabIndex = 8;
            btnRestore.Text = "Restaurar";
            btnRestore.UseVisualStyleBackColor = true;
            btnRestore.Click += btnRestore_Click;
            // 
            // chkFiltrarFechas
            // 
            chkFiltrarFechas.AutoSize = true;
            chkFiltrarFechas.Location = new Point(37, 440);
            chkFiltrarFechas.Name = "chkFiltrarFechas";
            chkFiltrarFechas.Size = new Size(214, 36);
            chkFiltrarFechas.TabIndex = 9;
            chkFiltrarFechas.Text = "Filtrar por fecha";
            chkFiltrarFechas.UseVisualStyleBackColor = true;
            chkFiltrarFechas.CheckedChanged += chkFiltrarFechas_CheckedChanged;
            // 
            // lblDesde
            // 
            lblDesde.AutoSize = true;
            lblDesde.Location = new Point(311, 444);
            lblDesde.Name = "lblDesde";
            lblDesde.Size = new Size(86, 32);
            lblDesde.TabIndex = 10;
            lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            dtpDesde.Enabled = false;
            dtpDesde.Format = DateTimePickerFormat.Short;
            dtpDesde.Location = new Point(419, 439);
            dtpDesde.Name = "dtpDesde";
            dtpDesde.Size = new Size(222, 39);
            dtpDesde.TabIndex = 11;
            dtpDesde.ValueChanged += dtpDesde_ValueChanged;
            // 
            // lblHasta
            // 
            lblHasta.AutoSize = true;
            lblHasta.Location = new Point(675, 446);
            lblHasta.Name = "lblHasta";
            lblHasta.Size = new Size(78, 32);
            lblHasta.TabIndex = 12;
            lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            dtpHasta.Enabled = false;
            dtpHasta.Format = DateTimePickerFormat.Short;
            dtpHasta.Location = new Point(759, 446);
            dtpHasta.Name = "dtpHasta";
            dtpHasta.Size = new Size(180, 39);
            dtpHasta.TabIndex = 13;
            dtpHasta.ValueChanged += dtpHasta_ValueChanged;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.BackColor = Color.Red;
            lblEstado.Location = new Point(1007, 453);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(0, 32);
            lblEstado.TabIndex = 14;
            // 
            // sfdBackup
            // 
            sfdBackup.DefaultExt = "bak";
            sfdBackup.Filter = "Backup de SQL Server (*.bak)|*.bak";
            sfdBackup.Title = "Guardar copia de seguridad";
            // 
            // dgvBackups
            // 
            dgvBackups.AllowUserToAddRows = false;
            dgvBackups.AllowUserToDeleteRows = false;
            dgvBackups.AllowUserToResizeRows = false;
            dgvBackups.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBackups.BackgroundColor = Color.White;
            dgvBackups.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBackups.Columns.AddRange(new DataGridViewColumn[] { colFecha, colTamano, colDuracion, colUsuario, colDisponible, colRuta });
            dgvBackups.EnableHeadersVisualStyles = false;
            dgvBackups.Location = new Point(7, 482);
            dgvBackups.MultiSelect = false;
            dgvBackups.Name = "dgvBackups";
            dgvBackups.ReadOnly = true;
            dgvBackups.RowHeadersVisible = false;
            dgvBackups.RowHeadersWidth = 82;
            dgvBackups.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBackups.Size = new Size(1663, 255);
            dgvBackups.TabIndex = 15;
            dgvBackups.CellContentClick += dgvBackups_CellContentClick;
            dgvBackups.CellFormatting += dgvBackups_CellFormatting;
            dgvBackups.SelectionChanged += dgvBackups_SelectionChanged;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "fecha";
            dataGridViewCellStyle21.Format = "dd/MM/yyyy HH:mm";
            colFecha.DefaultCellStyle = dataGridViewCellStyle21;
            colFecha.HeaderText = "Fecha y hora";
            colFecha.MinimumWidth = 10;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.Width = 150;
            // 
            // colTamano
            // 
            colTamano.DataPropertyName = "tamano_mb";
            dataGridViewCellStyle22.Alignment = DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle22.Format = "N2";
            colTamano.DefaultCellStyle = dataGridViewCellStyle22;
            colTamano.HeaderText = "Tamaño (MB)";
            colTamano.MinimumWidth = 10;
            colTamano.Name = "colTamano";
            colTamano.ReadOnly = true;
            colTamano.Width = 110;
            // 
            // colDuracion
            // 
            colDuracion.DataPropertyName = "duracion";
            colDuracion.HeaderText = "Duración";
            colDuracion.MinimumWidth = 10;
            colDuracion.Name = "colDuracion";
            colDuracion.ReadOnly = true;
            // 
            // colUsuario
            // 
            colUsuario.DataPropertyName = "usuario";
            colUsuario.HeaderText = "Usuario SQL";
            colUsuario.MinimumWidth = 10;
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            colUsuario.Width = 180;
            // 
            // colDisponible
            // 
            colDisponible.DataPropertyName = "disponible";
            colDisponible.HeaderText = "Disponible";
            colDisponible.MinimumWidth = 10;
            colDisponible.Name = "colDisponible";
            colDisponible.ReadOnly = true;
            colDisponible.Width = 120;
            // 
            // colRuta
            // 
            colRuta.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colRuta.DataPropertyName = "ruta";
            colRuta.HeaderText = "Archivo";
            colRuta.MinimumWidth = 10;
            colRuta.Name = "colRuta";
            colRuta.ReadOnly = true;
            // 
            // VistaBackupAdmin
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 128);
            ClientSize = new Size(1671, 749);
            Controls.Add(dgvBackups);
            Controls.Add(lblEstado);
            Controls.Add(dtpHasta);
            Controls.Add(lblHasta);
            Controls.Add(dtpDesde);
            Controls.Add(lblDesde);
            Controls.Add(chkFiltrarFechas);
            Controls.Add(btnRestore);
            Controls.Add(btnBackup);
            Controls.Add(btnActualizar);
            Controls.Add(txtBaseDatos);
            Controls.Add(lblBaseDatos);
            Controls.Add(label1);
            Name = "VistaBackupAdmin";
            Text = "VistaBackupAdmin";
            Load += VistaBackupAdmin_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBackups).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblBaseDatos;
        private TextBox txtBaseDatos;
        private Button btnActualizar;
        private Button btnBackup;
        private Button btnRestore;
        private CheckBox chkFiltrarFechas;
        private Label lblDesde;
        private DateTimePicker dtpDesde;
        private Label lblHasta;
        private DateTimePicker dtpHasta;
        private Label lblEstado;
        private SaveFileDialog sfdBackup;
        private DataGridView dgvBackups;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colTamano;
        private DataGridViewTextBoxColumn colDuracion;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colDisponible;
        private DataGridViewTextBoxColumn colRuta;
    }
}
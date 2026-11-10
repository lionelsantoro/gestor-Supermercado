using DesktopAppSupermercado.Entidades;
using DesktopAppSupermercado.ReglasNegocio.Supervisor;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.Vistas.DASHBOARDS
{
    public class FormConsultarCodigoAutorizacion : Form
    {
        private TextBox txtDni;
        private TextBox txtContrasena;

        private Label lblResultado;

        private Button btnVerificar;
        private Button btnCancelar;

        private CodigoAutorizacionNegocio negocio =
            new CodigoAutorizacionNegocio();

        public FormConsultarCodigoAutorizacion()
        {
            CrearControles();
        }

        private void CrearControles()
        {
            Text = "Consultar código de autorización";

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;

            MaximizeBox = false;
            MinimizeBox = false;

            ClientSize = new Size(440, 300);

            Font = new Font("Segoe UI", 10);

            // Título.
            Label lblTitulo = new Label();

            lblTitulo.Text = "Recuperar código de autorización";
            lblTitulo.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 20);
            lblTitulo.Size = new Size(400, 30);

            // Instrucción.
            Label lblInstruccion = new Label();

            lblInstruccion.Text =
                "Ingresá tus datos para verificar tu identidad.";

            lblInstruccion.Location = new Point(20, 60);
            lblInstruccion.Size = new Size(400, 25);

            // DNI.
            Label lblDni = new Label();

            lblDni.Text = "DNI:";
            lblDni.Location = new Point(30, 105);
            lblDni.Size = new Size(110, 25);

            txtDni = new TextBox();

            txtDni.Location = new Point(150, 102);
            txtDni.Size = new Size(250, 25);
            txtDni.MaxLength = 15;

            // Contraseña.
            Label lblContrasena = new Label();

            lblContrasena.Text = "Contraseña:";
            lblContrasena.Location = new Point(30, 145);
            lblContrasena.Size = new Size(110, 25);

            txtContrasena = new TextBox();

            txtContrasena.Location = new Point(150, 142);
            txtContrasena.Size = new Size(250, 25);
            txtContrasena.UseSystemPasswordChar = true;

            // Resultado.
            lblResultado = new Label();

            lblResultado.Location = new Point(25, 185);
            lblResultado.Size = new Size(390, 40);
            lblResultado.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblResultado.ForeColor = Color.DarkGreen;

            // Botón verificar.
            btnVerificar = new Button();

            btnVerificar.Text = "Verificar identidad";
            btnVerificar.Location = new Point(150, 240);
            btnVerificar.Size = new Size(150, 35);

            btnVerificar.Click += btnVerificar_Click;

            // Botón cancelar.
            btnCancelar = new Button();

            btnCancelar.Text = "Cancelar";
            btnCancelar.Location = new Point(310, 240);
            btnCancelar.Size = new Size(100, 35);

            btnCancelar.Click += (sender, e) =>
            {
                Close();
            };

            // Agregar controles a la ventana.
            Controls.Add(lblTitulo);
            Controls.Add(lblInstruccion);

            Controls.Add(lblDni);
            Controls.Add(txtDni);

            Controls.Add(lblContrasena);
            Controls.Add(txtContrasena);

            Controls.Add(lblResultado);

            Controls.Add(btnVerificar);
            Controls.Add(btnCancelar);

            AcceptButton = btnVerificar;
            CancelButton = btnCancelar;
        }

        private void btnVerificar_Click(
            object sender,
            EventArgs e)
        {
            try
            {
                if (Sesion.UsuarioActual == null ||
                    Sesion.UsuarioActual.IdRol != 4)
                {
                    MessageBox.Show(
                        "No existe una sesión válida de supervisor.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    Close();
                    return;
                }

                string dni = txtDni.Text.Trim();

                string contrasena = txtContrasena.Text;

                string codigo =
                    negocio.ConsultarCodigoAutorizacion(
                        dni,
                        contrasena);

                if (string.IsNullOrEmpty(codigo))
                {
                    lblResultado.ForeColor = Color.DarkRed;

                    lblResultado.Text =
                        "No se pudo verificar la identidad o el usuario no tiene un código disponible.";

                    txtContrasena.Clear();

                    return;
                }

                lblResultado.ForeColor = Color.DarkGreen;

                lblResultado.Text =
                    "Tu código de autorización es: " + codigo;

                // Limpiar la contraseña ingresada.
                txtContrasena.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }
    }
}

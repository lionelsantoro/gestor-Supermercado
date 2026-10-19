using DesktopAppSupermercado.DASHBOARDS;
using DesktopAppSupermercado.Entidades;
using DesktopAppSupermercado.ReglasNegocio;
using DesktopAppSupermercado.VISTASINVENTARIO;
using System;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class MenuPrincipal : Form
    {
        private LoginNegocio loginNegocio = new LoginNegocio();
        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void MenuPrincipal_Load(object sender, EventArgs e) { }
        private void txtUsuario_TextChanged(object sender, EventArgs e) { }

        // ============================================================
        // BOTÓN LIMPIAR
        // ============================================================
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtUsuario.Focus();
        }

        // ============================================================
        // BOTÓN INGRESAR
        // ============================================================

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string nombreUsuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(nombreUsuario) ||
                string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show(
                    "Por favor, complete tanto el usuario como la contraseña.");

                return;
            }

            try
            {
                int idRol = loginNegocio.AutenticarUsuario(
                    nombreUsuario,
                    contrasena);

                if (idRol <= 0)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    return;
                }

                Usuario usuarioAutenticado =
                    usuarioNegocio.ObtenerUsuarioParaSesion(nombreUsuario);

                if (usuarioAutenticado.IdRol != idRol)
                {
                    MessageBox.Show(
                        "El rol recuperado no coincide con el usuario autenticado.");

                    return;
                }

                Sesion.UsuarioActual = usuarioAutenticado;

                AbrirVistaSegunRol(
                    usuarioAutenticado.IdRol,
                    usuarioAutenticado.NombreUsuario);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al iniciar sesión: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }


        // ============================================================
        // ABRE LA VISTA SEGÚN EL ROL DEL USUARIO
        // ============================================================
        private void AbrirVistaSegunRol(int idRol, string usuario)
        {
            Form? vistaAAbrir = null;

            switch (idRol)
            {
                case 1:
                    vistaAAbrir = new MenuGeneralAdmin();
                    break;
                case 2:
                    vistaAAbrir = new VistaCajero();
                    break;
                case 3:
                    vistaAAbrir = new VistaGestionInventario();
                    break;
                case 4:
                    vistaAAbrir = new VistaSupervisor();
                    break;
                default:
                    MessageBox.Show($"Rol no reconocido (id = {idRol}).");
                    return;
            }

            if (vistaAAbrir != null)
            {
                this.Hide();

                vistaAAbrir.FormClosed += (sender, e) =>
                {
                    txtUsuario.Clear();
                    txtContrasena.Clear();
                    this.Show();
                    txtUsuario.Focus();
                };

                vistaAAbrir.Show();
            }
        }
    }
}
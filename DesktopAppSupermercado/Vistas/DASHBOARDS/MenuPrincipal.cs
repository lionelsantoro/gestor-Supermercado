using DesktopAppSupermercado.DASHBOARDS;
using DesktopAppSupermercado.ReglasNegocio;
using System;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class MenuPrincipal : Form
    {
        private LoginNegocio loginNegocio = new LoginNegocio();

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
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete tanto el usuario como la contraseña.");
                return;
            }

            try
            {
                // Llamamos a la capa de negocio, ella se encarga de hashear y consultar a Datos
                int idRol = loginNegocio.AutenticarUsuario(usuario, contrasena);

                if (idRol > 0)
                {
                    AbrirVistaSegunRol(idRol, usuario);
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
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
                    vistaAAbrir = new MenuGeneralInventario();
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
using DesktopAppSupermercado.DASHBOARDS;
using DesktopAppSupermercado.Datos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace DesktopAppSupermercado

{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            VistaSupervisor vistaSup = new VistaSupervisor();
            vistaSup.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            MenuGeneralInventario vistaInv = new MenuGeneralInventario();
            vistaInv.Show();
        }

        private void btnCajero_Click(object sender, EventArgs e)
        {
            VistaCajero vistaCaj = new VistaCajero();
            vistaCaj.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            MenuGeneralAdmin vistaAdmin = new MenuGeneralAdmin();
            vistaAdmin.Show();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            // Borramos el texto de ambas cajas
            txtUsuario.Clear();
            txtContrasena.Clear();

            // Devolvemos el cursor a la caja de usuario para que sea más cómodo volver a escribir
            txtUsuario.Focus();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            // Validación para evitar campos vacíos
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete tanto el usuario como la contraseña.");
                return;
            }

            Conexion miConexion = new Conexion();

            try
            {
                // Conexión exclusiva a LocalDB
                using (SqlConnection conexionFisica = miConexion.ObtenerConexion())
                {
                    conexionFisica.Open();
                    string query = "SELECT id_rol FROM usuarios WHERE nombre_usuario = @usuario AND contrasena = @contrasena AND eliminado = 0";

                    using (SqlCommand comando = new SqlCommand(query, conexionFisica))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        comando.Parameters.AddWithValue("@contrasena", contrasena);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
                            // Si las credenciales son correctas, obtenemos el rol y abrimos la vista
                            int idRol = Convert.ToInt32(resultado);
                            AbrirVistaSegunRol(idRol, usuario);
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Si la base de datos falla o no existe, mostramos el error real
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }

        }

        private void AbrirVistaSegunRol(int idRol, string usuario)
        {
            switch (idRol)
            {
                case 1: // ajustar: id 1 = administrador (ejemplo)
                    MenuGeneralAdmin vistaAdmin = new MenuGeneralAdmin();
                    vistaAdmin.Show();
                    break;
                case 2: // ajustar: id 2 = cajero
                    VistaCajero vistaCaj = new VistaCajero();
                    vistaCaj.Show();
                    break;
                case 3: // ajustar: id 3 = inventario
                    MenuGeneralInventario vistaInv = new MenuGeneralInventario();
                    vistaInv.Show();
                    break;
                case 4: // ajustar: id 4 = supervisor
                    VistaSupervisor vistaSup = new VistaSupervisor();
                    vistaSup.Show();
                    break;
                default:
                    MessageBox.Show($"Rol no reconocido (id = {idRol}).");
                    break;
            }
        }
    }
}

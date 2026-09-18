using DesktopAppSupermercado.DASHBOARDS;
using DesktopAppSupermercado.Datos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
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

        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e) { }
        private void MenuPrincipal_Load(object sender, EventArgs e) { }
        private void txtUsuario_TextChanged(object sender, EventArgs e) { }

        // ============================================================
        // BOTONES DE ACCESO DIRECTO (los usás para probar sin login)
        // ============================================================
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            VistaSupervisor vistaSup = new VistaSupervisor();
            vistaSup.Show();
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
        // BOTÓN INGRESAR (LOGIN CON HASH)
        // ============================================================
        // Ahora la contraseña ingresada se hashea antes de compararla
        // contra la base. Los usuarios creados desde el formulario admin
        // ya guardan el hash, así que la comparación funciona.
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MessageBox.Show("Por favor, complete tanto el usuario como la contraseña.");
                return;
            }

            // Hasheamos la contraseña ingresada por el usuario para
            // compararla contra el hash guardado en la base
            string contrasenaHash = HashearSHA256(contrasena);

            Conexion miConexion = new Conexion();

            try
            {
                using (SqlConnection conexionFisica = miConexion.ObtenerConexion())
                {
                    conexionFisica.Open();
                    string query = @"SELECT id_rol FROM usuarios 
                                     WHERE nombre_usuario = @usuario 
                                       AND contrasena = @contrasena 
                                       AND eliminado = 0";

                    using (SqlCommand comando = new SqlCommand(query, conexionFisica))
                    {
                        comando.Parameters.AddWithValue("@usuario", usuario);
                        comando.Parameters.AddWithValue("@contrasena", contrasenaHash);

                        object resultado = comando.ExecuteScalar();

                        if (resultado != null)
                        {
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
                MessageBox.Show("Error al conectar con la base de datos: " + ex.Message);
            }
        }

        // ============================================================
        // ABRE LA VISTA SEGÚN EL ROL DEL USUARIO
        // ============================================================
        private void AbrirVistaSegunRol(int idRol, string usuario)
        {
            switch (idRol)
            {
                case 1:
                    MenuGeneralAdmin vistaAdmin = new MenuGeneralAdmin();
                    vistaAdmin.Show();
                    break;
                case 2:
                    VistaCajero vistaCaj = new VistaCajero();
                    vistaCaj.Show();
                    break;
                case 3:
                    MenuGeneralInventario vistaInv = new MenuGeneralInventario();
                    vistaInv.Show();
                    break;
                case 4:
                    VistaSupervisor vistaSup = new VistaSupervisor();
                    vistaSup.Show();
                    break;
                default:
                    MessageBox.Show($"Rol no reconocido (id = {idRol}).");
                    break;
            }
        }

        // ============================================================
        // HELPER: HASH DE CONTRASEÑA (SHA-256)
        // ============================================================
        // Mismo método que en VistaUsuariosAdmin.cs — así ambos generan
        // exactamente el mismo hash para la misma contraseña
        private string HashearSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
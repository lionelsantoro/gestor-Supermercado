using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using DesktopAppSupermercado.Datos.InicioSesion;

namespace DesktopAppSupermercado.ReglasNegocio.InicioSesion
{
    public class LoginNegocio
    {
        private LoginDatos datos = new LoginDatos();

        public int AutenticarUsuario(string usuario, string contrasenaPlana)
        {
            // 1. Encriptamos la contraseña
            string contrasenaHash = HashearSHA256(contrasenaPlana);

            // 2. Le pedimos a la capa de datos que valide
            return datos.ValidarUsuario(usuario, contrasenaHash);
        }

        internal static string HashearSHA256(string texto)
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

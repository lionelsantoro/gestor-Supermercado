using DesktopAppSupermercado.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class UsuarioAdminNegocio
    {
        private UsuarioAdminDatos datos = new UsuarioAdminDatos();

        public DataTable ObtenerListaRoles() => datos.ObtenerRoles();

        public DataTable ListarUsuarios(string nombre, int idRol, object? fechaDesde, object? fechaHasta, bool sonActivos)
        {
            int estadoEliminado = sonActivos ? 0 : 1;
            return datos.ObtenerUsuarios(nombre, idRol, fechaDesde, fechaHasta, estadoEliminado);
        }

        public bool ExisteDni(string dni, int idPersonaActual) => datos.ExisteDato("dni", "persona", dni, "id_persona", idPersonaActual);

        public bool ExisteUsuario(string usuario, int idUsuarioActual) => datos.ExisteDato("nombre_usuario", "usuarios", usuario, "id_usuario", idUsuarioActual);

        public void GuardarUsuario(int idPersona, int idUsuario, string nom, string ape, string dni, string dir, string tel, string sex, DateTime nac, string mail, int rol, string user, string pass, bool cambiaClave)
        {
            string hash = cambiaClave ? HashearSHA256(pass) : "";

            if (idUsuario == 0)
            {
                datos.GuardarNuevoUsuario(nom, ape, dni, dir, tel, sex, nac, mail, rol, user, hash);
            }
            else
            {
                datos.ModificarUsuario(idPersona, idUsuario, nom, ape, dni, dir, tel, sex, nac, mail, rol, user, hash, cambiaClave);
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            datos.BajaLogicaUsuario(idUsuario);
        }

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

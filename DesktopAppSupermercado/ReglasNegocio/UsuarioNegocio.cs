using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class UsuarioNegocio
    {
        private UsuarioDatos datos = new UsuarioDatos();

        public DataTable ListarUsuarios(string textoBuscado = "", string nombreRol = "Todos")
        {
            return datos.ObtenerUsuariosFiltrados(textoBuscado, nombreRol);
        }
    

        public Usuario ObtenerUsuarioParaSesion(string nombreUsuario)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario))
                throw new Exception("El nombre de usuario es obligatorio.");

            Usuario usuario = datos.ObtenerUsuarioParaSesion(
                nombreUsuario.Trim());

            if (usuario == null || usuario.IdUsuario <= 0)
                throw new Exception(
                    "No se pudieron recuperar los datos del usuario autenticado.");

            return usuario;
        }

    }    
} 


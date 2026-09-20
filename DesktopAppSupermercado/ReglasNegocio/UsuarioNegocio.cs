using DesktopAppSupermercado.Datos;
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
    }
}

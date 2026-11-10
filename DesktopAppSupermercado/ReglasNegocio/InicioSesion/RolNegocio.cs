using DesktopAppSupermercado.Datos.InicioSesion;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio.InicioSesion
{
    public class RolNegocio
    {
        private RolDatos datos = new RolDatos();

        public List<string> ListarNombresRoles()
        {
            return datos.ObtenerRoles();
        }
    }
}

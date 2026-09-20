using DesktopAppSupermercado.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio
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

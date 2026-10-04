using DesktopAppSupermercado.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio
{
    internal class VentaNegocio
    {
        private VentaDatos datos = new VentaDatos();

        public int GenerarIdProvisional()
        {
            return datos.ObtenerProximoIdVenta();
        }
    }
}

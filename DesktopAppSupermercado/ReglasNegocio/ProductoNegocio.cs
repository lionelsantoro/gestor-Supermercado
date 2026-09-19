using DesktopAppSupermercado.Datos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class ProductoNegocio
    {
        private ProductoDatos datos = new ProductoDatos();

        public List<string> ObtenerListaParaBuscador()
        {
            return datos.ObtenerDescripcionesAutocomplete();
        }
    }
}

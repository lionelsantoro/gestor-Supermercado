using DesktopAppSupermercado.Datos.Cajero;
using DesktopAppSupermercado.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio.Cajero
{
    internal class MedioPagoNegocio
    {
        private MediosPagoDatos datos = new MediosPagoDatos();

        public List<MedioPago> ObtenerListaMediosPago()
        {
            return datos.ObtenerMediosDePago();
        }
    }
}

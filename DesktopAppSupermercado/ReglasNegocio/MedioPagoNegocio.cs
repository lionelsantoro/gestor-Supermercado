using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio
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

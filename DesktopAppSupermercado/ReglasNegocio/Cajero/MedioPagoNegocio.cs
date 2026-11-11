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

        // Solicita a la capa Datos la lista de medios de pago disponibles.
        public List<MedioPago> ObtenerListaMediosPago()
        {
            return datos.ObtenerMediosDePago();
        }
    }
}

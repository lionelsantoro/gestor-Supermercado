using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using System;
using System.ComponentModel;

namespace DesktopAppSupermercado.ReglasNegocio
{
    internal class VentaNegocio
    {
        private VentaDatos datos = new VentaDatos();

        public int ObtenerNumeroTicketEstimado()
        {
            return datos.ObtenerNumeroTicketEstimado();
        }

        public int GuardarVentaConfirmada(
            int idUsuario,
            int idCliente,
            int idMedioPago,
            decimal montoTotal,
            BindingList<DetalleVentaVista> detalles)
        {
            if (idCliente <= 0)
                throw new Exception("El cliente no es válido.");

            if (detalles == null || detalles.Count == 0)
                throw new Exception("No se puede registrar una venta sin productos.");

            return datos.RegistrarVentaCompleta(
                idUsuario,
                idCliente,
                idMedioPago,
                montoTotal,
                detalles);
        }
    }
}
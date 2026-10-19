using DesktopAppSupermercado.Datos;
using DesktopAppSupermercado.Entidades;
using System;
using System.ComponentModel;
using System.Data;

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

        public DataTable ConsultarHistorialVentas(
            int idUsuario,
            DateTime? fechaDesde,
            DateTime? fechaHasta)
        {
            if (idUsuario <= 0)
                throw new Exception("El usuario de la sesión no es válido.");

            if (fechaDesde.HasValue &&
                fechaHasta.HasValue &&
                fechaDesde.Value.Date > fechaHasta.Value.Date)
            {
                throw new Exception(
                    "La fecha desde no puede ser posterior a la fecha hasta.");
            }

            return datos.ObtenerHistorialVentas(
                idUsuario,
                fechaDesde,
                fechaHasta);
        }

    }
}
using DesktopAppSupermercado.Datos.Supervisor_Cajero;
using DesktopAppSupermercado.Entidades;
using System;
using System.ComponentModel;
using System.Data;

namespace DesktopAppSupermercado.ReglasNegocio.Supervisor_Cajero
{
    internal class VentaNegocio
    {
        private VentaDatos datos = new VentaDatos();

        // Delega la consulta del próximo número de ticket estimado en la capa Datos.
        public int ObtenerNumeroTicketEstimado()
        {
            return datos.ObtenerNumeroTicketEstimado();
        }

        // Comprueba que exista un cliente válido y al menos un detalle antes de delegar el registro definitivo de la venta.
        public int GuardarVentaConfirmada(int idUsuario,int idCliente,int idMedioPago,decimal montoTotal,BindingList<DetalleVentaVista> detalles)
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

        // Valida el cajero y el rango de fechas antes de solicitar el historial resumido de ventas.
        public DataTable ConsultarHistorialVentas(int idUsuario,DateTime? fechaDesde,DateTime? fechaHasta)
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

        // Valida el identificador de venta y solicita los productos que componen esa operación.
        public DataTable ConsultarDetallesVenta(int idVenta)
        {
            if (idVenta <= 0)
            {
                throw new Exception("La venta seleccionada no es válida.");
            }

            return datos.ObtenerDetallesVenta(idVenta);
        }

        // Valida el cajero y las fechas antes de obtener las ventas que se muestran en el historial.
        public DataTable ConsultarVentasParaHistorial(int idUsuario,DateTime? fechaDesde,DateTime? fechaHasta)
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

            return datos.ObtenerVentasParaHistorial(
                idUsuario,
                fechaDesde,
                fechaHasta);
        }

    }
}
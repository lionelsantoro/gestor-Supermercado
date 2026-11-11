using DesktopAppSupermercado.Datos.Supervisor;
using DesktopAppSupermercado.Entidades;
using DesktopAppSupermercado.ReglasNegocio.InicioSesion;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio.Supervisor
{
    public class CodigoAutorizacionNegocio
    {
        private CodigoAutorizacionDatos datos = new CodigoAutorizacionDatos();

        // Comprueba la sesión de supervisor, valida DNI y contraseña, genera el hash y solicita el código a Datos.
        public string ConsultarCodigoAutorizacion(string dni, string contrasena)
        {
            Usuario usuarioActual = Sesion.UsuarioActual;

            // Comprobar que exista una sesión de supervisor.
            if (usuarioActual == null ||
                usuarioActual.IdUsuario <= 0 ||
                usuarioActual.IdRol != 4)
            {
                throw new InvalidOperationException(
                    "No existe una sesión válida de supervisor.");
            }

            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new ArgumentException(
                    "Debe ingresar su DNI.");
            }

            if (string.IsNullOrWhiteSpace(contrasena))
            {
                throw new ArgumentException(
                    "Debe ingresar su contraseña.");
            }

            // Generar el mismo hash utilizado en el inicio de sesión.
            string contrasenaHash =
                LoginNegocio.HashearSHA256(contrasena);

            // Consultar el código del usuario de la sesión.
            return datos.ObtenerCodigoAutorizacion(
                usuarioActual.IdUsuario,
                dni,
                contrasenaHash);
        }
    }
}

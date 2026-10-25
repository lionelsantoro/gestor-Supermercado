using DesktopAppSupermercado.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class UsuarioAdminNegocio
    {
        private UsuarioAdminDatos datos = new UsuarioAdminDatos();

        // =============================================================
        // RANGO DEL CÓDIGO: 4 DÍGITOS (1000 a 9999)
        // =============================================================
        private const int CODIGO_MINIMO = 1000;
        private const int CODIGO_MAXIMO = 10000;   // exclusivo
        private const int MAX_INTENTOS = 50;

        public DataTable ObtenerListaRoles() => datos.ObtenerRoles();

        public DataTable ListarUsuarios(string nombre, int idRol, object? fechaDesde, object? fechaHasta, bool sonActivos)
        {
            int estadoEliminado = sonActivos ? 0 : 1;
            return datos.ObtenerUsuarios(nombre, idRol, fechaDesde, fechaHasta, estadoEliminado);
        }

        public bool ExisteDni(string dni, int idPersonaActual) => datos.ExisteDato("dni", "persona", dni, "id_persona", idPersonaActual);

        public bool ExisteUsuario(string usuario, int idUsuarioActual) => datos.ExisteDato("nombre_usuario", "usuarios", usuario, "id_usuario", idUsuarioActual);

        public bool EsRolSupervisor(int idRol) => datos.EsRolSupervisor(idRol);

        public int? ObtenerCodigoDeUsuario(int idUsuario) => datos.ObtenerCodigoDeUsuario(idUsuario);

        // =============================================================
        // GENERACIÓN DEL CÓDIGO DE AUTORIZACIÓN
        // =============================================================

        /// <summary>
        /// Genera un código de 4 dígitos que no esté en uso.
        /// Usa RandomNumberGenerator y no Random: este código autoriza
        /// operaciones destructivas, así que no debe ser predecible.
        /// </summary>
        private int GenerarCodigoUnico()
        {
            for (int intento = 0; intento < MAX_INTENTOS; intento++)
            {
                int candidato = RandomNumberGenerator.GetInt32(CODIGO_MINIMO, CODIGO_MAXIMO);

                if (!datos.ExisteCodigoAutorizacion(candidato))
                    return candidato;
            }

            throw new InvalidOperationException(
                "No se pudo generar un código de autorización único. Intente nuevamente.");
        }

        // =============================================================
        // VALIDACIÓN DEL CÓDIGO (autoriza el restore)
        // =============================================================

        public bool ValidarCodigoSupervisor(int codigo)
        {
            return datos.ValidarCodigoSupervisor(codigo);
        }

        public bool HaySupervisoresConCodigo()
        {
            return datos.ContarSupervisoresConCodigo() > 0;
        }

        // =============================================================
        // ALTA Y MODIFICACIÓN
        // =============================================================

        /// <summary>
        /// Guarda o modifica el usuario. Si el rol es supervisor y todavía
        /// no tiene código, se le genera uno.
        /// Devuelve el código generado, o null si no se generó ninguno
        /// (para que la vista pueda mostrárselo al administrador).
        /// </summary>
        public int? GuardarUsuario(int idPersona, int idUsuario, string nom, string ape, string dni, string dir, string tel, string sex, DateTime nac, string mail, int rol, string user, string pass, bool cambiaClave)
        {
            string hash = cambiaClave ? HashearSHA256(pass) : "";
            bool esSupervisor = datos.EsRolSupervisor(rol);

            // ---------- ALTA ----------
            if (idUsuario == 0)
            {
                int? codigoNuevo = esSupervisor ? GenerarCodigoUnico() : (int?)null;

                datos.GuardarNuevoUsuario(nom, ape, dni, dir, tel, sex, nac, mail, rol, user, hash, codigoNuevo);
                return codigoNuevo;
            }

            // ---------- MODIFICACIÓN ----------
            // Qué pasa con el código según el cambio de rol:
            //   deja de ser supervisor  -> se borra (NULL)
            //   pasa a ser supervisor   -> se genera uno nuevo
            //   sigue siendo supervisor -> se conserva el que ya tenía
            int? codigoActual = datos.ObtenerCodigoDeUsuario(idUsuario);
            int? codigoResultante = null;
            bool actualizaCodigo = false;

            if (!esSupervisor && codigoActual.HasValue)
            {
                codigoResultante = null;
                actualizaCodigo = true;          // se le quita el código
            }
            else if (esSupervisor && !codigoActual.HasValue)
            {
                codigoResultante = GenerarCodigoUnico();
                actualizaCodigo = true;          // se le asigna uno nuevo
            }

            datos.ModificarUsuario(idPersona, idUsuario, nom, ape, dni, dir, tel, sex, nac, mail,
                                   rol, user, hash, cambiaClave, codigoResultante, actualizaCodigo);

            // Solo devolvemos el código cuando es nuevo, para informarlo
            return (actualizaCodigo && codigoResultante.HasValue) ? codigoResultante : null;
        }

        public void EliminarUsuario(int idUsuario)
        {
            datos.BajaLogicaUsuario(idUsuario);
        }

        private string HashearSHA256(string texto)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(texto);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash) sb.Append(b.ToString("x2"));
                return sb.ToString();
            }
        }
    }
}
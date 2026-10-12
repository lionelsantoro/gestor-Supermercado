using System;
using System.Data;
using System.IO;
using DesktopAppSupermercado.Datos;

namespace DesktopAppSupermercado.ReglasNegocio
{
    internal class BackupNegocio
    {
        private BackupDatos datos = new BackupDatos();

        // =============================================================
        // CONSTANTES
        // =============================================================
        public const string DISPONIBLE = "Sí";
        public const string NO_ENCONTRADO = "No encontrado";
        public const string REEMPLAZADO = "Reemplazado";
        public const string CARPETA_BACKUPS = @"C:\BackupsSupermercado";

        // =============================================================
        // DATOS GENERALES
        // =============================================================

        public string ObtenerNombreBaseDatos()
        {
            string nombre = datos.ObtenerNombreBaseDatos();

            if (string.IsNullOrWhiteSpace(nombre))
                throw new ApplicationException(
                    "La cadena de conexión no indica la base de datos.");

            return nombre;
        }

        public bool EstaDisponible(string estado)
        {
            return estado == DISPONIBLE;
        }

        // =============================================================
        // HISTORIAL + FILTRO DE FECHAS
        // =============================================================

        public DataTable ListarHistorial(string baseDatos, DateTime? desde, DateTime? hasta)
        {
            if (string.IsNullOrWhiteSpace(baseDatos))
                throw new ApplicationException("No hay base de datos seleccionada.");

            // --- Validación del rango ---
            if (desde.HasValue && hasta.HasValue && desde.Value.Date > hasta.Value.Date)
                throw new ApplicationException("La fecha 'Desde' no puede ser posterior a 'Hasta'.");

            // --- 'Hasta' incluye el día completo ---
            DateTime? desdeReal = null;
            DateTime? hastaReal = null;
            if (desde.HasValue) desdeReal = desde.Value.Date;
            if (hasta.HasValue) hastaReal = hasta.Value.Date.AddDays(1);

            DataTable tabla = datos.ListarHistorial(baseDatos, desdeReal, hastaReal);

            // --- Columna "disponible": ¿se puede restaurar este backup? ---
            tabla.Columns.Add("disponible", typeof(string));

            foreach (DataRow fila in tabla.Rows)
            {
                string ruta = fila["ruta"].ToString();
                bool sobrescrito = Convert.ToInt32(fila["sobrescrito"]) == 1;

                if (!File.Exists(ruta))
                    fila["disponible"] = NO_ENCONTRADO;
                else if (sobrescrito)
                    fila["disponible"] = REEMPLAZADO;
                else
                    fila["disponible"] = DISPONIBLE;
            }

            return tabla;
        }

        // =============================================================
        // BACKUP
        // =============================================================

        public string SugerirNombreArchivo(string baseDatos)
        {
            return baseDatos + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bak";
        }

        public string ObtenerCarpetaInicial()
        {
            if (Directory.Exists(CARPETA_BACKUPS))
                return CARPETA_BACKUPS;

            return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        }

        public void CrearBackup(string baseDatos, string rutaDestino)
        {
            if (string.IsNullOrWhiteSpace(baseDatos))
                throw new ApplicationException("No hay base de datos seleccionada.");

            if (string.IsNullOrWhiteSpace(rutaDestino))
                throw new ApplicationException("Elegí dónde guardar el backup.");

            if (Path.GetExtension(rutaDestino).ToLower() != ".bak")
                throw new ApplicationException("El archivo debe tener extensión .bak");

            string carpeta = Path.GetDirectoryName(rutaDestino);
            if (string.IsNullOrEmpty(carpeta) || !Directory.Exists(carpeta))
                throw new ApplicationException("La carpeta de destino no existe.");

            datos.CrearBackup(baseDatos, rutaDestino);
        }

        // =============================================================
        // RESTORE
        // =============================================================

        public void Restaurar(string baseDatos, string ruta, int posicion, string estado)
        {
            if (string.IsNullOrWhiteSpace(baseDatos))
                throw new ApplicationException("No hay base de datos seleccionada.");

            if (estado == REEMPLAZADO)
                throw new ApplicationException(
                    "Ese archivo fue sobrescrito por un backup posterior.\n" +
                    "Restaurarlo traería otra versión, no la de esta fila.");

            if (estado == NO_ENCONTRADO || !File.Exists(ruta))
                throw new ApplicationException(
                    "El archivo de backup ya no existe en:\n" + ruta);

            if (!datos.VerificarBackup(ruta, posicion))
                throw new ApplicationException(
                    "El archivo está dañado o no es un backup válido.\nNo se restauró nada.");

            datos.Restaurar(baseDatos, ruta, posicion);
        }
    }
}
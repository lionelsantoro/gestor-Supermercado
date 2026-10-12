using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;

namespace DesktopAppSupermercado.Datos
{
    internal class BackupDatos
    {
        // =============================================================
        // CONEXIÓN
        // =============================================================

        /// <summary>
        /// Toma la cadena de conexión de la clase Conexion existente
        /// y la redirige a master. Backup y restore se ejecutan desde
        /// master porque no se puede restaurar una base estando conectado a ella.
        /// </summary>
        private string CadenaMaster()
        {
            string original = new Conexion().ObtenerConexion().ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(original);
            builder.InitialCatalog = "master";
            return builder.ConnectionString;
        }

        /// <summary>
        /// Pone el nombre de la base entre corchetes de forma segura.
        /// BACKUP y RESTORE no aceptan parámetros para el nombre de la base.
        /// </summary>
        private string Corchetes(string nombre)
        {
            return "[" + nombre.Replace("]", "]]") + "]";
        }

        /// <summary>
        /// Devuelve el nombre de la base configurada en Conexion.cs.
        /// </summary>
        public string ObtenerNombreBaseDatos()
        {
            string original = new Conexion().ObtenerConexion().ConnectionString;
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(original);
            return builder.InitialCatalog;
        }

        // =============================================================
        // HISTORIAL DE BACKUPS (se lee de msdb)
        // =============================================================

        /// <summary>
        /// Trae los backups completos registrados en msdb.
        /// Pasar desde/hasta en null para traer todo el historial.
        /// </summary>
        public DataTable ListarHistorial(string baseDatos, DateTime? desde, DateTime? hasta)
        {
            string sql = @"
                SELECT
                    bs.backup_finish_date                               AS fecha,
                    CAST(bs.backup_size / 1048576.0 AS decimal(18,2))   AS tamano_mb,
                    CONVERT(varchar(8), DATEADD(SECOND,
                        DATEDIFF(SECOND, bs.backup_start_date, bs.backup_finish_date), 0), 108) AS duracion,
                    bs.user_name                                        AS usuario,
                    bmf.physical_device_name                            AS ruta,
                    bs.position                                         AS posicion,
                    CASE WHEN EXISTS (
                        SELECT 1
                        FROM msdb.dbo.backupset bs2
                        INNER JOIN msdb.dbo.backupmediafamily bmf2
                            ON bs2.media_set_id = bmf2.media_set_id
                        WHERE bmf2.physical_device_name = bmf.physical_device_name
                          AND bs2.backup_finish_date > bs.backup_finish_date
                          AND bs2.position <= bs.position
                    ) THEN 1 ELSE 0 END                                 AS sobrescrito
                FROM msdb.dbo.backupset bs
                INNER JOIN msdb.dbo.backupmediafamily bmf
                    ON bs.media_set_id = bmf.media_set_id
                WHERE bs.database_name = @db
                  AND bs.type = 'D'
                  AND (@desde IS NULL OR bs.backup_finish_date >= @desde)
                  AND (@hasta IS NULL OR bs.backup_finish_date <  @hasta)
                ORDER BY bs.backup_finish_date DESC;";

            DataTable tabla = new DataTable();

            using (SqlConnection cn = new SqlConnection(CadenaMaster()))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.Parameters.Add("@db", SqlDbType.NVarChar, 128).Value = baseDatos;
                cmd.Parameters.Add("@desde", SqlDbType.DateTime).Value = (object)desde ?? DBNull.Value;
                cmd.Parameters.Add("@hasta", SqlDbType.DateTime).Value = (object)hasta ?? DBNull.Value;

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(tabla);
                }
            }

            return tabla;
        }

        // =============================================================
        // CREAR BACKUP
        // =============================================================

        public void CrearBackup(string baseDatos, string rutaDestino)
        {
            string sql = "BACKUP DATABASE " + Corchetes(baseDatos) +
                         " TO DISK = @ruta WITH INIT, FORMAT, NAME = @nombre;";

            using (SqlConnection cn = new SqlConnection(CadenaMaster()))
            using (SqlCommand cmd = new SqlCommand(sql, cn))
            {
                cmd.CommandTimeout = 0;
                cmd.Parameters.AddWithValue("@ruta", rutaDestino);
                cmd.Parameters.AddWithValue("@nombre",
                    "Backup " + baseDatos + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));

                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // =============================================================
        // VERIFICAR QUE EL ARCHIVO .BAK NO ESTÉ DAÑADO
        // =============================================================

        public bool VerificarBackup(string ruta, int posicion)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(CadenaMaster()))
                using (SqlCommand cmd = new SqlCommand(
                    "RESTORE VERIFYONLY FROM DISK = @ruta WITH FILE = @posicion;", cn))
                {
                    cmd.CommandTimeout = 0;
                    cmd.Parameters.AddWithValue("@ruta", ruta);
                    cmd.Parameters.AddWithValue("@posicion", posicion);

                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        // =============================================================
        // RESTAURAR
        // =============================================================

        /// <summary>
        /// Restaura la base al estado del backup indicado.
        /// Cierra todas las conexiones, pone la base en SINGLE_USER,
        /// restaura y devuelve a MULTI_USER pase lo que pase.
        /// </summary>
        public void Restaurar(string baseDatos, string ruta, int posicion)
        {
            string db = Corchetes(baseDatos);

            // Cierra las conexiones que la propia app dejó abiertas en el pool
            SqlConnection.ClearAllPools();

            using (SqlConnection cn = new SqlConnection(CadenaMaster()))
            {
                cn.Open();

                try
                {
                    // 1) Echar a todos los usuarios conectados y restaurar
                    string sql =
                        "ALTER DATABASE " + db + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; " +
                        "RESTORE DATABASE " + db + " FROM DISK = @ruta " +
                        "WITH FILE = @posicion, REPLACE, RECOVERY;";

                    using (SqlCommand cmd = new SqlCommand(sql, cn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.Parameters.AddWithValue("@ruta", ruta);
                        cmd.Parameters.AddWithValue("@posicion", posicion);
                        cmd.ExecuteNonQuery();
                    }
                }
                finally
                {
                    // 2) Devolver la base a multiusuario SIEMPRE.
                    //    Si esto no corre, nadie más puede entrar al sistema.
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand(
                            "ALTER DATABASE " + db + " SET MULTI_USER;", cn))
                        {
                            cmd.CommandTimeout = 0;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    catch { }
                }
            }
        }
    }
}
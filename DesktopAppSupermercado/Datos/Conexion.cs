using System;
using System.Collections.Generic;
using System.Text;
using System;
using Microsoft.Data.SqlClient;

namespace DesktopAppSupermercado.Datos
{
    internal class Conexion
    {
        // Crea y devuelve una conexión nueva utilizando la cadena de conexión configurada.
        private string cadenaConexion = @"Server=(localdb)\MSSQLLocalDB; Database=SupermercadoDB; Integrated Security=True;";
        public SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadenaConexion);
        }
    }
}

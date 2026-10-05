using DesktopAppSupermercado.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopAppSupermercado.Datos
{
    internal class MediosPagoDatos
    {
        public List<MedioPago> ObtenerMediosDePago()
        {
            List<MedioPago> lista = new List<MedioPago>();
            Conexion miConexion = new Conexion();

            using (SqlConnection con = miConexion.ObtenerConexion())
            {
                con.Open();
                string query = "SELECT id_medio_pago, medio_pago FROM medios_de_pago";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new MedioPago
                            {
                                IdMedioPago = Convert.ToInt32(dr["id_medio_pago"]),
                                Nombre = dr["medio_pago"].ToString()
                            });
                        }
                    }
                }
            }
            return lista;
        }
    }
}


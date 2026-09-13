using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;                        
using DesktopAppSupermercado.Datos;                 

namespace DesktopAppSupermercado
{
    public partial class FormPruebaConexionBD : Form
    {
        public FormPruebaConexionBD()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Instanciamos la clase Conexion que creaste en la carpeta Datos
            Conexion miConexion = new Conexion();

            try
            {
                // Intentamos abrir la puerta a la base de datos
                using (SqlConnection conexionFisica = miConexion.ObtenerConexion())
                {
                    conexionFisica.Open(); // Si la base está vacía pero existe, esto funcionará
                    MessageBox.Show("¡Conexión exitosa! El proyecto ya habla con la base de datos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar: " + ex.Message);
            }
        }
    }
}

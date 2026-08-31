using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado.VISTASADMIN
{
    public partial class VistaUsuariosAdmin : Form
    {
        public VistaUsuariosAdmin()
        {
            InitializeComponent();

            // Configuración visual de las tablas
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.ReadOnly = true;

            dgvInactivos.AllowUserToAddRows = false;
            dgvInactivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInactivos.ReadOnly = true;

            // Crear las columnas para la tabla Activos (dgvUsuarios)
            dgvUsuarios.Columns.Add("idUsuario", "idUsuario");
            dgvUsuarios.Columns.Add("idPerfil", "idPerfil");
            dgvUsuarios.Columns.Add("nombre", "nombre");
            dgvUsuarios.Columns.Add("apellido", "apellido");
            dgvUsuarios.Columns.Add("usuario", "usuario");
            dgvUsuarios.Columns.Add("dni", "dni");
            dgvUsuarios.Columns.Add("email", "email");
            dgvUsuarios.Columns.Add("direccion", "direccion");

            // Crear las columnas para la tabla Inactivos (dgvInactivos)
            dgvInactivos.Columns.Add("idUsuario", "idUsuario");
            dgvInactivos.Columns.Add("idPerfil", "idPerfil");
            dgvInactivos.Columns.Add("nombre", "nombre");
            dgvInactivos.Columns.Add("apellido", "apellido");
            dgvInactivos.Columns.Add("usuario", "usuario");
            dgvInactivos.Columns.Add("dni", "dni");
            dgvInactivos.Columns.Add("email", "email");
            dgvInactivos.Columns.Add("direccion", "direccion");

            // Agregar datos estáticos a Activos
            dgvUsuarios.Rows.Add("21", "1", "fadmagul", "canteros", "fadma", "23443213", "fadmagul@gmail...", "teniente i...");
            dgvUsuarios.Rows.Add("20", "3", "gonzalo", "Vallejos", "gonzav", "43268169", "gonza18avjhgf@", "avenida a...");
            dgvUsuarios.Rows.Add("11", "3", "Gonzalo", "Perez", "gonzap", "41612228", "gonzalofabianper...", "Av. Indep...");

            // Agregar datos estáticos a Inactivos
            dgvInactivos.Rows.Add("14", "3", "Eliana", "Gonzalez", "Elianag", "40180985", "gonx-00@hotmail...", "Alberdi 205");
            dgvInactivos.Rows.Add("12", "3", "marta", "gaunas", "marta", "43256123", "marta@gmail.com", "riachuelo");
        }

        // Mantenemos estos eventos vacíos para que el archivo de Diseño no provoque 
        // la pantalla azul de error que solucionamos al principio.
        private void label5_Click(object sender, EventArgs e) { }
        private void label5_Click_1(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void textBox8_TextChanged(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
    }
}
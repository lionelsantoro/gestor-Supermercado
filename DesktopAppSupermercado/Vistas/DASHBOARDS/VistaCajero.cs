using DesktopAppSupermercado.DASHBOARDS;
using DesktopAppSupermercado.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static DesktopAppSupermercado.Entidades.Entidadescs;
using System.ComponentModel;

namespace DesktopAppSupermercado
{
    public partial class VistaCajero : Form
    {
        // Variables en memoria para mantener la venta actual
        private BindingList<DetalleVentaVista> listaDetallesVenta;
        private int idVentaProvisional = 0;
        private decimal totalVenta = 0;
        public VistaCajero()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {

        }

        private void btnPagar_Click(object sender, EventArgs e)
        {

        }

        private AutoCompleteStringCollection coleccionProductos = new AutoCompleteStringCollection();

        private void VistaCajero_Load(object sender, EventArgs e)
        {
            // Inicializar la lista y conectarla al DataGridView
            listaDetallesVenta = new BindingList<DetalleVentaVista>();
            dataGridView1.DataSource = listaDetallesVenta;

            // Ocultar columna de ID si se genera automáticamente, dejar solo las que pides
            if (dataGridView1.Columns["IdProducto"] != null)
                dataGridView1.Columns["IdProducto"].Visible = false;

            ProductoNegocio negocio = new ProductoNegocio();

            // 1. Obtenemos la lista de la base de datos
            List<string> listaDescripciones = negocio.ObtenerListaParaBuscador();

            // 2. Llenamos la colección especial de Windows Forms
            coleccionProductos.AddRange(listaDescripciones.ToArray());

            // 3. Configuramos el TextBox del Nombre
            txtNombre.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtNombre.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtNombre.AutoCompleteCustomSource = coleccionProductos;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnIconoCajero_Click(object sender, EventArgs e)
        {

        }

        private void BloquearPantallaParaTicket()
        {
            // Deshabilitamos todo el panel izquierdo y controles de carga
            btnRegistro.Enabled = false;
            btnIngresarCodigo.Enabled = false;
            btnPagar.Enabled = false;
            btnBorrarVenta.Enabled = false;
            btnAgregarProducto.Enabled = false;
            btnSalir.Enabled = false;

            // Aseguramos que el de PDF sea el único activo y lo resaltamos
            btnGenerarPDF.Enabled = true;
            btnGenerarPDF.Focus();

            MessageBox.Show("Pago registrado. Por favor, genere el ticket para finalizar la operación.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPagar_Click_1(object sender, EventArgs e)
        {
            FormPagar formPago = new FormPagar();

            if (formPago.ShowDialog() == DialogResult.OK)
            {
                BloquearPantallaParaTicket();
            }
        }

        private void btnBorrarCompra_Click(object sender, EventArgs e)
        {
            FormBorrarVenta vistaSup = new FormBorrarVenta();
            vistaSup.Show();
        }

        private void btnCargarProducto_Click(object sender, EventArgs e)
        {
            FormCodigoBarra vistaSup = new FormCodigoBarra();
            vistaSup.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LiberarPantalla()
        {
            // Reactivamos los botones
            btnRegistro.Enabled = true;
            btnIngresarCodigo.Enabled = true;
            btnPagar.Enabled = true;
            btnBorrarVenta.Enabled = true;
            btnAgregarProducto.Enabled = true;
            btnSalir.Enabled = true;

        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            // Simulación de creación de PDF
            MessageBox.Show("¡Ticket generado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Volvemos a habilitar la caja para la próxima venta
            LiberarPantalla();
        }

        private void textCant_Enter(object sender, EventArgs e)
        {
            string productoIngresado = txtNombre.Text.Trim();

            // Si está vacío o lo que escribió no está en nuestra lista de la base de datos
            if (string.IsNullOrEmpty(productoIngresado) || !coleccionProductos.Contains(productoIngresado))
            {
                // Mostramos la alerta
                MessageBox.Show("Producto no encontrado. Ingrese un producto válido primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // Forzamos al cursor a volver al campo Nombre
                txtNombre.Focus();
            }
        }
        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            VentaNegocio ventaNegocio = new VentaNegocio();

            // Obtenemos ID provisional y fecha
            idVentaProvisional = ventaNegocio.GenerarIdProvisional();
            DateTime fechaActual = DateTime.Now;

            // Actualizamos la UI
            txtNumeroCompra.Text = idVentaProvisional.ToString();
            txtFecha.Text = fechaActual.ToString("dd/MM/yyyy HH:mm");

            // Bloqueamos edición (Asumiendo que tus TextBox se llaman así)
            txtNumeroCompra.ReadOnly = true;
            txtFecha.ReadOnly = true;

            // Limpiamos venta anterior si existiera
            listaDetallesVenta.Clear();
            ActualizarTotal();

            MessageBox.Show("Nueva venta iniciada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ActualizarTotal()
        {
            totalVenta = 0;
            foreach (var item in listaDetallesVenta)
            {
                totalVenta += item.Subtotal; // O (item.Precio_Unitario * item.Cantidad)
            }

            // Asumiendo que el TextBox inferior del Total se llama txtTotal
            txtTotal.Text = "$ " + totalVenta.ToString("0.00");
        }
        private void btnAgregarProducto_Click_1(object sender, EventArgs e)
        {
            // Validar que se haya iniciado una venta
            if (idVentaProvisional == 0)
            {
                MessageBox.Show("Debe iniciar una nueva venta primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string descripcionIngresada = txtNombre.Text.Trim();

            // Validar que la cantidad sea un número válido
            if (!int.TryParse(textCant.Text, out int cantidadIngresada))
            {
                MessageBox.Show("Ingrese una cantidad numérica válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();

                // Las validaciones de BD y Stock ocurren en la capa de negocio
                Producto productoValidado = productoNegocio.ValidarYObtenerProductoParaVenta(descripcionIngresada, cantidadIngresada);

                // Si no lanzó excepción, el stock es válido. Creamos la instancia en memoria.
                DetalleVentaVista nuevoDetalle = new DetalleVentaVista
                {
                    IdProducto = productoValidado.IdProducto,
                    Nombre = productoValidado.Nombre, // Muestra el NOMBRE corto, aunque se buscó por descripción
                    Cantidad = cantidadIngresada,
                    Precio_Unitario = productoValidado.Precio,
                    Subtotal = productoValidado.Precio * cantidadIngresada
                };

                // Agregar a la lista (el DataGridView se actualiza solo)
                listaDetallesVenta.Add(nuevoDetalle);

                ActualizarTotal();

                // Limpiar campos para el siguiente producto
                txtNombre.Clear();
                textCant.Clear();
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                // Atrapa las excepciones lanzadas desde las Reglas de Negocio (Ej: Stock insuficiente)
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}

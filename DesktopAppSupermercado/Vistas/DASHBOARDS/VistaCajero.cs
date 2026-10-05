using DesktopAppSupermercado.DASHBOARDS;
using DesktopAppSupermercado.ReglasNegocio;
using DesktopAppSupermercado.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado
{
    public partial class VistaCajero : Form
    {
        private BindingList<DetalleVentaVista> listaDetallesVenta;
        private int idVentaProvisional = 0;
        private decimal totalVenta = 0;
        private AutoCompleteStringCollection coleccionProductos = new AutoCompleteStringCollection();
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

        private void VistaCajero_Load(object sender, EventArgs e)
        {
            listaDetallesVenta = new BindingList<DetalleVentaVista>();
            dataGridView1.DataSource = listaDetallesVenta;

            // Quitamos la fila vacía del final (la del asterisco) para evitar errores de edición
            dataGridView1.AllowUserToAddRows = false;

            // Ocultamos las columnas de control interno
            if (dataGridView1.Columns["IdProducto"] != null)
                dataGridView1.Columns["IdProducto"].Visible = false;

            if (dataGridView1.Columns["StockActual"] != null)
                dataGridView1.Columns["StockActual"].Visible = false;

            // Bloqueamos todas las columnas para que sean de solo lectura, EXCEPTO "Cantidad"
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name != "Cantidad")
                    col.ReadOnly = true;
            }

            ProductoNegocio negocio = new ProductoNegocio();
            List<string> listaDescripciones = negocio.ObtenerListaParaBuscador();
            coleccionProductos.AddRange(listaDescripciones.ToArray());

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

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FormRegistro vistaSup = new FormRegistro();
            vistaSup.Show();
        }

        private void BloquearPantallaParaTicket()
        {
            txtNumeroCompra.Text = "";
            txtFecha.Text = "";
            txtTotal.Text = "$ 0.00";
            txtNombre.Clear();
            textCant.Clear();
            listaDetallesVenta.Clear();
            idVentaProvisional = 0;

            btnNuevaVenta.Enabled = false;
            btnRegistro.Enabled = false;
            btnIngresarCodigo.Enabled = false;
            btnPagar.Enabled = false;
            btnBorrarVenta.Enabled = false;
            btnAgregarProducto.Enabled = false;
            btnSalir.Enabled = false;

            btnGenerarPDF.Enabled = true;
            btnGenerarPDF.Focus();

            MessageBox.Show("Pago registrado. Por favor, genere el ticket.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnPagar_Click_1(object sender, EventArgs e)
        {
            if (idVentaProvisional == 0 || listaDetallesVenta.Count == 0)
            {
                MessageBox.Show("No hay ninguna venta activa o no se agregaron productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FormPagar formPago = new FormPagar();

            if (formPago.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    VentaNegocio ventaNeg = new VentaNegocio();
                    int idCajero = Sesion.UsuarioActual != null ? Sesion.UsuarioActual.IdUsuario : 1;

                    ventaNeg.GuardarVentaConfirmada(idCajero, formPago.IdMedioPagoSeleccionado, totalVenta, listaDetallesVenta);

                    MessageBox.Show("¡Venta registrada exitosamente en la base de datos!", "Venta Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    BloquearPantallaParaTicket();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
            btnNuevaVenta.Enabled = true;

        }

        private void btnGenerarPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Ticket generado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LiberarPantalla();
        }

        private void textCant_Enter(object sender, EventArgs e)
        {
            string productoIngresado = txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(productoIngresado) || !coleccionProductos.Contains(productoIngresado))
            {
                MessageBox.Show("Producto no encontrado. Ingrese un producto válido primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
            }
        }
        private void btnNuevaVenta_Click(object sender, EventArgs e)
        {
            VentaNegocio ventaNegocio = new VentaNegocio();

            // Usamos la ID de la sesión. Si estás probando sin loguearte, usa un ID por defecto como el 1.
            int idCajeroActual = Sesion.UsuarioActual != null ? Sesion.UsuarioActual.IdUsuario : 1;
            idVentaProvisional = ventaNegocio.GenerarIdProvisional(idCajeroActual);

            DateTime fechaActual = DateTime.Now;
            txtNumeroCompra.Text = idVentaProvisional.ToString();
            txtFecha.Text = fechaActual.ToString("dd/MM/yyyy HH:mm");

            txtNumeroCompra.ReadOnly = true;
            txtFecha.ReadOnly = true;

            listaDetallesVenta.Clear();
            ActualizarTotal();

            MessageBox.Show("Nueva venta iniciada.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void ActualizarTotal()
        {
            totalVenta = 0;
            foreach (var item in listaDetallesVenta)
            {
                totalVenta += item.Subtotal;
            }
            txtTotal.Text = "$ " + totalVenta.ToString("0.00");
        }
        private void btnAgregarProducto_Click_1(object sender, EventArgs e)
        {
            if (idVentaProvisional == 0)
            {
                MessageBox.Show("Debe iniciar una nueva venta primero.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string descripcionIngresada = txtNombre.Text.Trim();

            if (!int.TryParse(textCant.Text, out int cantidadIngresada))
            {
                MessageBox.Show("Ingrese una cantidad numérica válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();
                Producto productoValidado = productoNegocio.ValidarYObtenerProductoParaVenta(descripcionIngresada, cantidadIngresada);

                DetalleVentaVista nuevoDetalle = new DetalleVentaVista
                {
                    IdProducto = productoValidado.IdProducto,
                    Nombre = productoValidado.Nombre,
                    Cantidad = cantidadIngresada,
                    Precio_Unitario = productoValidado.Precio,
                    Subtotal = productoValidado.Precio * cantidadIngresada,
                    StockActual = productoValidado.Stock // Guardamos el stock aquí
                };

                listaDetallesVenta.Add(nuevoDetalle);
                ActualizarTotal();

                txtNombre.Clear();
                textCant.Clear();
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Este evento "atrapa" el dato antes de que se guarde en la celda y lo valida
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Solo validamos si la columna que están editando es la de "Cantidad"
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                string valorIngresado = e.FormattedValue.ToString();

                // 1. Validar letras o caracteres extraños
                if (!int.TryParse(valorIngresado, out int nuevaCantidad))
                {
                    MessageBox.Show("Debe ingresar un número entero válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true; // Cancela la edición y devuelve el valor anterior
                    return;
                }

                // 2. Validar que no sea 0 ni un número negativo
                if (nuevaCantidad <= 0)
                {
                    MessageBox.Show("La cantidad no puede ser nula ni negativa.", "Cantidad inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                // 3. Validar contra el stock máximo
                var detalleActual = listaDetallesVenta[e.RowIndex];
                if (nuevaCantidad > detalleActual.StockActual)
                {
                    MessageBox.Show($"Stock insuficiente. Solo dispone de {detalleActual.StockActual} unidades.", "Falta de Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }
            }
        }

        // Este evento recalcula los totales una vez que la validación anterior fue exitosa
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Columns[e.ColumnIndex].Name == "Cantidad")
            {
                // Obtenemos la fila que se modificó
                var detalleActual = listaDetallesVenta[e.RowIndex];

                // Recalculamos el subtotal de ese producto
                detalleActual.Subtotal = detalleActual.Cantidad * detalleActual.Precio_Unitario;

                // Refrescamos visualmente la tabla para que muestre el nuevo subtotal
                dataGridView1.Refresh();

                // Recalculamos el total de toda la compra
                ActualizarTotal();
            }
        }

    }

}

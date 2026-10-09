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
        private VentaEnMemoria ventaActual;
        private bool ventaConfirmada = false;
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
            ventaActual = null;
            ventaConfirmada = false;

            dataGridView1.DataSource = listaDetallesVenta;
            dataGridView1.AllowUserToAddRows = false;

            if (dataGridView1.Columns["Cantidad"] != null)
                dataGridView1.Columns["Cantidad"].HeaderText = "Cantidad (g / u)";

            if (dataGridView1.Columns["UnidadMedida"] != null)
                dataGridView1.Columns["UnidadMedida"].HeaderText = "Unidad";

            if (dataGridView1.Columns["IdProducto"] != null)
                dataGridView1.Columns["IdProducto"].Visible = false;

            if (dataGridView1.Columns["StockActual"] != null)
                dataGridView1.Columns["StockActual"].Visible = false;

            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                if (col.Name != "Cantidad")
                    col.ReadOnly = true;
            }

            ProductoNegocio negocio = new ProductoNegocio();
            List<string> listaDescripciones =
                negocio.ObtenerListaParaBuscador();

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
            // No borrar la venta: necesitamos los datos para generar el ticket.
            txtNombre.Clear();
            textCant.Clear();

            btnNuevaVenta.Enabled = false;
            btnRegistro.Enabled = false;
            btnIngresarCodigo.Enabled = false;
            btnPagar.Enabled = false;
            btnBorrarVenta.Enabled = false;
            btnAgregarProducto.Enabled = false;
            btnSalir.Enabled = false;

            btnGenerarPDF.Enabled = true;
            btnGenerarPDF.Focus();

            MessageBox.Show(
                "Pago registrado. Por favor, genere el ticket.",
                "Atención",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnPagar_Click_1(object sender, EventArgs e)
        {
            if (ventaActual == null ||
                ventaConfirmada ||
                ventaActual.Detalles.Count == 0)
            {
                MessageBox.Show(
                    "No hay ninguna venta activa o no se agregaron productos.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            FormPagar formPago = new FormPagar();

            if (formPago.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                VentaNegocio ventaNegocio = new VentaNegocio();

                // Registrar la venta y obtener el número definitivo.
                int numeroTicketConfirmado =
                    ventaNegocio.GuardarVentaConfirmada(
                        ventaActual.IdUsuario,
                        formPago.IdMedioPagoSeleccionado,
                        ventaActual.MontoTotal,
                        ventaActual.Detalles);

                // Actualizar el estado local solamente si el guardado tuvo éxito.
                ventaActual.IdMedioPago =
                    formPago.IdMedioPagoSeleccionado;

                ventaActual.NumeroTicketEstimado =
                    numeroTicketConfirmado;

                ventaConfirmada = true;

                // El ticket real puede diferir de la estimación inicial.
                txtNumeroCompra.Text =
                    numeroTicketConfirmado.ToString();

                MessageBox.Show(
                    $"Venta registrada correctamente.\n" +
                    $"Ticket N.º {numeroTicketConfirmado}",
                    "Venta completada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                BloquearPantallaParaTicket();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Error al registrar la venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                // La compra sigue en memoria para poder reintentar.
                // No marcarla como confirmada si el guardado falló.
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
            if (!ventaConfirmada || ventaActual == null)
            {
                MessageBox.Show(
                    "No hay una venta confirmada para generar el ticket.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // Aquí debes ejecutar la generación real del PDF
            // usando ventaActual como fuente de datos.
            //
            // Si la generación falla, no limpies la venta.

            MessageBox.Show(
                $"Ticket N.º {ventaActual.NumeroTicketEstimado} generado.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Esta limpieza se ejecuta después de generar el PDF.
            listaDetallesVenta.Clear();

            txtNumeroCompra.Clear();
            txtFecha.Clear();
            txtTotal.Text = "$ 0.00";
            txtNombre.Clear();
            textCant.Clear();

            ventaActual = null;
            ventaConfirmada = false;

            btnGenerarPDF.Enabled = false;

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
            if (ventaActual != null && !ventaConfirmada && ventaActual.Detalles.Count > 0)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Hay una venta pendiente. ¿Desea descartarla e iniciar otra?",
                    "Venta pendiente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;
            }

            VentaNegocio ventaNegocio = new VentaNegocio();

            int idCajeroActual =
                Sesion.UsuarioActual != null
                    ? Sesion.UsuarioActual.IdUsuario
                    : 1;

            // Solo consulta un número estimado. No lo consume.
            int numeroTicketEstimado =
                ventaNegocio.ObtenerNumeroTicketEstimado();

            // Crear una nueva compra en memoria.
            listaDetallesVenta.Clear();

            ventaActual = new VentaEnMemoria
            {
                NumeroTicketEstimado = numeroTicketEstimado,
                IdUsuario = idCajeroActual,
                Fecha = DateTime.Now,
                MontoTotal = 0,
                IdMedioPago = 0,
                Detalles = listaDetallesVenta
            };

            ventaConfirmada = false;

            txtNumeroCompra.Text =
                ventaActual.NumeroTicketEstimado.ToString();

            txtFecha.Text =
                ventaActual.Fecha.ToString("dd/MM/yyyy HH:mm");

            txtNumeroCompra.ReadOnly = true;
            txtFecha.ReadOnly = true;

            ActualizarTotal();

            MessageBox.Show(
                "Nueva venta iniciada. El número de ticket es estimado " +
                "y quedará confirmado al realizar el pago.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        private void ActualizarTotal()
        {
            decimal total = 0;

            if (listaDetallesVenta != null)
            {
                foreach (var item in listaDetallesVenta)
                {
                    total += item.Subtotal;
                }
            }

            if (ventaActual != null)
            {
                ventaActual.MontoTotal = total;
            }

            txtTotal.Text = "$ " + total.ToString("0.00");
        }
        private void btnAgregarProducto_Click_1(object sender, EventArgs e)
        {
            if (ventaActual == null || ventaConfirmada)
            {
                MessageBox.Show(
                    "Debe iniciar una nueva venta primero.",
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string descripcionIngresada = txtNombre.Text.Trim();

            if (!int.TryParse(textCant.Text, out int cantidadIngresada) ||
                cantidadIngresada <= 0)
            {
                MessageBox.Show(
                    "Ingrese una cantidad entera mayor que cero.",
                    "Cantidad inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                ProductoNegocio productoNegocio = new ProductoNegocio();

                Producto producto =
                    productoNegocio.ValidarYObtenerProductoParaVenta(
                        descripcionIngresada,
                        cantidadIngresada);

                // Convertir a la unidad en que está expresado el stock.
                decimal nuevaCantidad =
                    ConvertirCantidadAStock(
                        cantidadIngresada,
                        producto.UnidadMedida);

                // Cantidad del mismo producto que ya está en la compra.
                decimal cantidadExistente = 0;

                foreach (var detalle in listaDetallesVenta)
                {
                    if (detalle.IdProducto == producto.IdProducto)
                    {
                        cantidadExistente += ConvertirCantidadAStock(
                            detalle.Cantidad,
                            detalle.UnidadMedida);
                    }
                }

                // No permitir superar el stock sumando todas las líneas.
                if (cantidadExistente + nuevaCantidad > producto.Stock)
                {
                    decimal disponible =
                        Math.Max(0, producto.Stock - cantidadExistente);

                    string mensajeDisponible =
                        EsProductoPorKg(producto.UnidadMedida)
                            ? $"{disponible * 1000m:0} gramos"
                            : $"{disponible:0} unidades";

                    MessageBox.Show(
                        $"Stock insuficiente para {producto.Nombre}. " +
                        $"Disponible para agregar: {mensajeDisponible}.",
                        "Falta de stock",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DetalleVentaVista nuevoDetalle = new DetalleVentaVista
                {
                    IdProducto = producto.IdProducto,
                    Nombre = producto.Nombre,
                    Cantidad = cantidadIngresada,
                    Precio_Unitario = producto.Precio,
                    UnidadMedida = producto.UnidadMedida,
                    Subtotal = CalcularSubtotal(
                        cantidadIngresada,
                        producto.Precio,
                        producto.UnidadMedida),
                    StockActual = producto.Stock
                };

                listaDetallesVenta.Add(nuevoDetalle);

                ActualizarTotal();

                txtNombre.Clear();
                textCant.Clear();
                txtNombre.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Este evento "atrapa" el dato antes de que se guarde en la celda y lo valida
        private void dataGridView1_CellValidating(
            object sender,
            DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 ||
                dataGridView1.Columns[e.ColumnIndex].Name != "Cantidad")
                return;

            if (!int.TryParse(
                    e.FormattedValue?.ToString(),
                    out int nuevaCantidad) ||
                nuevaCantidad <= 0)
            {
                MessageBox.Show(
                    "La cantidad debe ser un entero mayor que cero.",
                    "Cantidad inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                e.Cancel = true;
                return;
            }

            var detalleActual = listaDetallesVenta[e.RowIndex];

            // Sumar las cantidades de las otras líneas del mismo producto.
            decimal cantidadOtrasLineas = 0;

            for (int i = 0; i < listaDetallesVenta.Count; i++)
            {
                if (i == e.RowIndex)
                    continue;

                var otroDetalle = listaDetallesVenta[i];

                if (otroDetalle.IdProducto == detalleActual.IdProducto)
                {
                    cantidadOtrasLineas += ConvertirCantidadAStock(
                        otroDetalle.Cantidad,
                        otroDetalle.UnidadMedida);
                }
            }

            decimal nuevaCantidadEnStock =
                ConvertirCantidadAStock(
                    nuevaCantidad,
                    detalleActual.UnidadMedida);

            if (cantidadOtrasLineas + nuevaCantidadEnStock >
                detalleActual.StockActual)
            {
                decimal disponible = Math.Max(
                    0,
                    detalleActual.StockActual - cantidadOtrasLineas);

                string mensajeDisponible =
                    EsProductoPorKg(detalleActual.UnidadMedida)
                        ? $"{disponible * 1000m:0} gramos"
                        : $"{disponible:0} unidades";

                MessageBox.Show(
                    $"Stock insuficiente para {detalleActual.Nombre}. " +
                    $"Disponible para esta línea: {mensajeDisponible}.",
                    "Falta de stock",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                e.Cancel = true;
            }
        }

        // Este evento recalcula los totales una vez que la validación anterior fue exitosa
        private void dataGridView1_CellValueChanged(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || dataGridView1.Columns[e.ColumnIndex].Name != "Cantidad")
                return;

            var detalleActual = listaDetallesVenta[e.RowIndex];

            detalleActual.Subtotal = CalcularSubtotal(
                detalleActual.Cantidad,
                detalleActual.Precio_Unitario,
                detalleActual.UnidadMedida);

            dataGridView1.Refresh();

            ActualizarTotal();
        }

        private bool EsProductoPorKg(string unidadMedida)
        {
            return string.Equals(
                unidadMedida?.Trim(),
                "Kg",
                StringComparison.OrdinalIgnoreCase);
        }

        // Convierte la cantidad ingresada a la unidad del stock.
        // Kg: gramos / 1000.
        // Unidad: cantidad de unidades.
        private decimal ConvertirCantidadAStock(
            int cantidad,
            string unidadMedida)
        {
            return EsProductoPorKg(unidadMedida)
                ? cantidad / 1000m
                : cantidad;
        }

        // Calcula el subtotal con el precio por kg o por unidad.
        private decimal CalcularSubtotal(
            int cantidad,
            decimal precioUnitario,
            string unidadMedida)
        {
            decimal cantidadParaCalcular =
                ConvertirCantidadAStock(cantidad, unidadMedida);

            return decimal.Round(
                cantidadParaCalcular * precioUnitario,
                2,
                MidpointRounding.AwayFromZero);
        }

    }

}

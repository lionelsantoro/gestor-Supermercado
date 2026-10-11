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
using System.Diagnostics;

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

            txtNumeroCompra.ReadOnly = true;
            txtFecha.ReadOnly = true;
            txtCodigoCliente.MaxLength = 4;
            txtCodigoCliente.ReadOnly = false;
            txtCodigoCliente.Clear();

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

        private void btnPagar_Click_1(object sender, EventArgs e)
        {
            if (ventaActual == null ||
                ventaConfirmada ||
                ventaActual.Detalles.Count == 0)
            {
                MessageBox.Show(
                    "No hay una venta activa o no se agregaron productos.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (FormPagar formPago = new FormPagar())
            {
                if (formPago.ShowDialog() != DialogResult.OK)
                    return;

                int numeroTicketConfirmado;

                // PRIMERA FASE: guardar la venta en SQL Server.
                try
                {
                    VentaNegocio ventaNegocio = new VentaNegocio();

                    numeroTicketConfirmado =
                        ventaNegocio.GuardarVentaConfirmada(
                            ventaActual.IdUsuario,
                            ventaActual.ClienteActual.IdCliente,
                            formPago.IdMedioPagoSeleccionado,
                            ventaActual.MontoTotal,
                            ventaActual.Detalles);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        ex.Message,
                        "Error al registrar la venta",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                    // La transacción falló: conservar la venta en memoria
                    // para corregir el problema e intentarlo nuevamente.
                    return;
                }

                // La venta ya fue confirmada en la base de datos.
                ventaActual.IdMedioPago =
                    formPago.IdMedioPagoSeleccionado;

                ventaActual.NumeroTicketEstimado =
                    numeroTicketConfirmado;

                ventaConfirmada = true;

                txtNumeroCompra.Text =
                    numeroTicketConfirmado.ToString();

                // SEGUNDA FASE: generar automáticamente el PDF.
                try
                {
                    string rutaPdf =
                        TicketPdfGenerador.GenerarPdf(ventaActual);

                    // Abrir el PDF con el lector predeterminado de Windows.
                    try
                    {
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = rutaPdf,
                            UseShellExecute = true
                        });
                    }
                    catch (Exception exApertura)
                    {
                        MessageBox.Show(
                            "El PDF se creó correctamente, pero no se pudo abrir " +
                            "automáticamente.\n\n" + rutaPdf +
                            "\n\nDetalle: " + exApertura.Message,
                            "Ticket guardado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }

                    MessageBox.Show(
                        $"Venta registrada correctamente.\n" +
                        $"Ticket N.º {numeroTicketConfirmado}\n\n" +
                        $"Archivo: {rutaPdf}",
                        "Venta completada",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception exPdf)
                {
                    // La venta YA se confirmó en SQL Server.
                    // No debe intentarse registrarla nuevamente.
                    MessageBox.Show(
                        "La venta fue registrada correctamente, pero no se pudo " +
                        "generar el PDF.\n\n" +
                        "No vuelva a confirmar el pago de esta venta.\n\n" +
                        exPdf.Message,
                        "Error al generar el ticket",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

                // El cliente vuelve a quedar disponible para la próxima venta.
                // No se repite ninguna operación de escritura en SQL Server.
                FinalizarVentaEnVista();
            }
        }

        private void FinalizarVentaEnVista()
        {
            listaDetallesVenta.Clear();

            txtNumeroCompra.Clear();
            txtFecha.Clear();
            txtTotal.Text = "$ 0.00";
            txtNombre.Clear();
            textCant.Clear();

            // Liberar el código de cliente para la próxima compra.
            txtCodigoCliente.Clear();
            txtCodigoCliente.ReadOnly = false;
            txtCodigoCliente.Enabled = true;

            ventaActual = null;
            ventaConfirmada = false;

            txtCodigoCliente.Focus();

            // No deshabilitamos botones ni es necesario reactivarlos:
            // la venta ya se procesa y el PDF se genera automáticamente.
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
            // No permitir iniciar otra compra mientras exista
            // una venta pendiente que todavía no fue confirmada.
            if (ventaActual != null && !ventaConfirmada)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Hay una venta pendiente. ¿Desea descartarla?",
                    "Venta pendiente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                // Descartar solamente la venta que está en memoria.
                listaDetallesVenta.Clear();
                ventaActual = null;

                txtCodigoCliente.ReadOnly = false;
                txtCodigoCliente.Clear();

                txtNumeroCompra.Clear();
                txtFecha.Clear();
                txtTotal.Text = "$ 0.00";

                MessageBox.Show(
                    "Venta descartada. Ingrese un nuevo código de cliente " +
                    "y vuelva a iniciar la venta.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                txtCodigoCliente.Focus();
                return;
            }

            // 1. Validar el cliente antes de iniciar la compra.
            Cliente cliente;

            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();

                cliente = clienteNegocio.ObtenerClienteValido(
                    txtCodigoCliente.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cliente inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtCodigoCliente.Focus();
                txtCodigoCliente.SelectAll();
                return;
            }

            try
            {
                VentaNegocio ventaNegocio = new VentaNegocio();

                int idCajeroActual =
                    Sesion.UsuarioActual != null
                        ? Sesion.UsuarioActual.IdUsuario
                        : 1;

                // Solo consulta el número estimado. No consume el ticket.
                int numeroTicketEstimado =
                    ventaNegocio.ObtenerNumeroTicketEstimado();

                listaDetallesVenta.Clear();

                // 2. Crear la compra en memoria con el cliente validado.
                ventaActual = new VentaEnMemoria
                {
                    NumeroTicketEstimado = numeroTicketEstimado,
                    IdUsuario = idCajeroActual,
                    ClienteActual = cliente,
                    Fecha = DateTime.Now,
                    MontoTotal = 0,
                    IdMedioPago = 0,
                    Detalles = listaDetallesVenta
                };

                ventaConfirmada = false;

                txtNumeroCompra.Text =
                    numeroTicketEstimado.ToString();

                txtFecha.Text =
                    ventaActual.Fecha.ToString("dd/MM/yyyy HH:mm");

                // El cliente queda visible, pero ya no puede modificarse.
                txtCodigoCliente.ReadOnly = true;

                ActualizarTotal();

                MessageBox.Show(
                    $"Venta iniciada para {cliente.NombreCompleto}.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ventaActual = null;

                MessageBox.Show(
                    ex.Message,
                    "Error al iniciar venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
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

        private void txtCodigoCliente_KeyPress(
             object sender,
             KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                (e.KeyChar < '0' || e.KeyChar > '9'))
            {
                e.Handled = true;
            }
        }

    }

}

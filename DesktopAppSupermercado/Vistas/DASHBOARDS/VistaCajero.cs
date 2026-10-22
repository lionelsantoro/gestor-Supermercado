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
using DesktopAppSupermercado.VISTASCAJERO;

namespace DesktopAppSupermercado
{
    public partial class VistaCajero : Form
    {
        private BindingList<DetalleVentaVista> listaDetallesVenta;
        private VentaEnMemoria ventaActual;
        private bool ventaConfirmada = false;
        private AutoCompleteStringCollection coleccionProductos = new AutoCompleteStringCollection();
        private bool actualizandoComboClientes = false;
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

            dataGridView1.DataSource = listaDetallesVenta;
            dataGridView1.AllowUserToAddRows = false;

            // Configuración del ComboBox buscador de clientes
            cmbBuscarCliente.DropDownStyle = ComboBoxStyle.DropDown;
            cmbBuscarCliente.AutoCompleteMode = AutoCompleteMode.None; // Lo manejamos manualmente para soportar DNI y Letras
            cmbBuscarCliente.MaxLength = 160;
            //cmbBuscarCliente.Enabled = true;

            CargarComboClientes("");

            // Suscripción a los eventos del ComboBox (o puedes enlazarlos desde el Diseñador)
            cmbBuscarCliente.TextUpdate += cmbBuscarCliente_TextUpdate;
            cmbBuscarCliente.DropDown += cmbBuscarCliente_DropDown;
            cmbBuscarCliente.KeyPress += cmbBuscarCliente_KeyPress;
            cmbBuscarCliente.KeyDown += cmbBuscarCliente_KeyDown;

            if (dataGridView1.Columns["Cantidad"] != null)
                dataGridView1.Columns["Cantidad"].HeaderText = "Cantidad (g/u)";

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
            using (FormRegistro formulario = new FormRegistro())
            {
                formulario.ShowDialog(this);
            }
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

            // Liberar el buscador de cliente para la próxima compra.
            CargarComboClientes("");
            cmbBuscarCliente.Enabled = true;

            ventaActual = null;
            ventaConfirmada = false;

            cmbBuscarCliente.Focus();
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
            if (ventaActual != null && !ventaConfirmada)
            {
                DialogResult respuesta = MessageBox.Show(
                    "Hay una venta pendiente. ¿Desea descartarla?",
                    "Venta pendiente",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (respuesta != DialogResult.Yes)
                    return;

                listaDetallesVenta.Clear();
                ventaActual = null;

                cmbBuscarCliente.Enabled = true;
                CargarComboClientes("");

                txtNumeroCompra.Clear();
                txtFecha.Clear();
                txtTotal.Text = "$ 0.00";

                MessageBox.Show(
                    "Venta descartada. Ingrese un DNI o seleccione un cliente " +
                    "y vuelva a iniciar la venta.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                cmbBuscarCliente.Focus();
                return;
            }

            // 1. Validar el cliente antes de iniciar la compra (no permite vacío, ni DNI o nombre inexistente).
            Cliente cliente;

            try
            {
                ClienteNegocio clienteNegocio = new ClienteNegocio();
                cliente = clienteNegocio.ObtenerClienteValido(cmbBuscarCliente.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Cliente inválido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                cmbBuscarCliente.Focus();
                cmbBuscarCliente.SelectAll();
                return;
            }

            try
            {
                VentaNegocio ventaNegocio = new VentaNegocio();

                int idCajeroActual =
                    Sesion.UsuarioActual != null
                        ? Sesion.UsuarioActual.IdUsuario
                        : 1;

                int numeroTicketEstimado =
                    ventaNegocio.ObtenerNumeroTicketEstimado();

                listaDetallesVenta.Clear();

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

                txtNumeroCompra.Text = numeroTicketEstimado.ToString();
                txtFecha.Text = ventaActual.Fecha.ToString("dd/MM/yyyy HH:mm");

                // Mostramos el nombre completo y bloqueamos el ComboBox durante la venta activa
                actualizandoComboClientes = true;
                cmbBuscarCliente.Text = cliente.NombreCompleto;
                actualizandoComboClientes = false;
                cmbBuscarCliente.Enabled = false;

                ActualizarTotal();

                MessageBox.Show(
                    $"Venta iniciada para {cliente.NombreCompleto} (DNI: {cliente.Dni}).",
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

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {

            if (Sesion.UsuarioActual == null || Sesion.UsuarioActual.IdUsuario <= 0)
            {
                MessageBox.Show(
                    "No se pudo identificar al cajero que inició sesión.",
                    "Sesión inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using (Historial formulario = new Historial())
            {
                formulario.ShowDialog(this);
            }

        }

        private void CargarComboClientes(string filtroTexto, bool mantenerTexto = false)
        {
            actualizandoComboClientes = true;
            try
            {
                string textoActual = cmbBuscarCliente.Text;
                int posicionCursor = cmbBuscarCliente.SelectionStart;

                ClienteNegocio clienteNegocio = new ClienteNegocio();
                List<Cliente> clientes = clienteNegocio.ObtenerClientesPorFiltroTexto(filtroTexto);

                cmbBuscarCliente.BeginUpdate();
                cmbBuscarCliente.Items.Clear();

                foreach (Cliente cli in clientes)
                {
                    cmbBuscarCliente.Items.Add(cli); // Mostrará NombreCompleto gracias al ToString()
                }
                cmbBuscarCliente.EndUpdate();

                if (mantenerTexto)
                {
                    cmbBuscarCliente.Text = textoActual;
                    cmbBuscarCliente.SelectionStart = posicionCursor;
                    cmbBuscarCliente.SelectionLength = 0;
                }
                else
                {
                    cmbBuscarCliente.SelectedIndex = -1;
                    cmbBuscarCliente.Text = string.Empty;
                }
            }
            finally
            {
                actualizandoComboClientes = false;
            }
        }

        // 1. Si no se ingresan letras y se despliega el ComboBox, carga todos los clientes ordenados alfabéticamente
        private void cmbBuscarCliente_DropDown(object sender, EventArgs e)
        {
            if (actualizandoComboClientes) return;

            string texto = cmbBuscarCliente.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                CargarComboClientes("", mantenerTexto: true);
            }
        }

        // 2. A medida que se escriben letras, filtra por nombre y apellido en la tabla persona (solo clientes)
        private void cmbBuscarCliente_TextUpdate(object sender, EventArgs e)
        {
            if (actualizandoComboClientes) return;

            string texto = cmbBuscarCliente.Text.Trim();

            // Si está vacío, cargamos todos los clientes para cuando despliegue el combo
            if (string.IsNullOrEmpty(texto))
            {
                cmbBuscarCliente.DroppedDown = false;
                CargarComboClientes("", mantenerTexto: true);
                return;
            }

            // Si está ingresando números (DNI), cerramos el desplegable y dejamos que escriba los dígitos
            if (char.IsDigit(texto[0]))
            {
                cmbBuscarCliente.DroppedDown = false;
                return;
            }

            // Si ingresó letras, buscamos coincidencias en nombre y apellido
            CargarComboClientes(texto, mantenerTexto: true);

            if (cmbBuscarCliente.Items.Count > 0)
            {
                cmbBuscarCliente.DroppedDown = true;
                Cursor.Current = Cursors.Default;
            }
            else
            {
                cmbBuscarCliente.DroppedDown = false;
            }
        }

        // 3. Permitir solo letras/espacios (para nombres) o solo números (para DNI de hasta 8 dígitos)
        private void cmbBuscarCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar))
                return;

            string textoActual = cmbBuscarCliente.Text;

            // Si ya empezó escribiendo números, solo permitir números y limitar a 8 dígitos (DNI)
            if (textoActual.Length > 0 && char.IsDigit(textoActual[0]))
            {
                if (!char.IsDigit(e.KeyChar) || (textoActual.Length >= 8 && cmbBuscarCliente.SelectionLength == 0))
                {
                    e.Handled = true;
                }
                return;
            }

            // Si ya empezó escribiendo letras, no permitir mezclar con números
            if (textoActual.Length > 0 && char.IsLetter(textoActual[0]))
            {
                if (!char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '\'' && e.KeyChar != '-')
                {
                    e.Handled = true;
                }
                return;
            }

            // Si es el primer carácter, permitir letra o dígito
            if (!char.IsLetterOrDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // 4. Si termina de escribir un DNI y presiona Enter, valida el DNI y muestra el cliente encontrado
        private void cmbBuscarCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                try
                {
                    ClienteNegocio clienteNegocio = new ClienteNegocio();
                    Cliente cliente = clienteNegocio.ObtenerClienteValido(cmbBuscarCliente.Text);

                    // Deja seleccionado el nombre del cliente validado
                    actualizandoComboClientes = true;
                    cmbBuscarCliente.Text = cliente.NombreCompleto;
                    actualizandoComboClientes = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Cliente inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBuscarCliente.SelectAll();
                }
            }
        }

    }

}

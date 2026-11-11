using DesktopAppSupermercado.Entidades;
using DesktopAppSupermercado.ReglasNegocio.Supervisor_Cajero;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado.VISTASCAJERO
{
    public partial class Historial : Form
    {
        private readonly VentaNegocio negocio = new VentaNegocio();
        private DataTable tablaVentas = new DataTable();

        public Historial()
        {
            InitializeComponent();

            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Format = DateTimePickerFormat.Short;

            dtpFechaDesde.ShowCheckBox = true;
            dtpFechaHasta.ShowCheckBox = true;

            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Checked = false;

            ConfigurarGrillas();

            btnBuscar.Click += btnBuscar_Click;
            txtBuscarVenta.TextChanged += txtBuscarVenta_TextChanged;
            dvgVenta.SelectionChanged += dvgVenta_SelectionChanged;

            Load += Historial_Load;
        }

        // Configura las grillas de ventas y detalles como solo lectura y con selección de fila completa.
        private void ConfigurarGrillas()
        {
            dvgVenta.ReadOnly = true;
            dvgVenta.AllowUserToAddRows = false;
            dvgVenta.AllowUserToDeleteRows = false;
            dvgVenta.AutoGenerateColumns = true;
            dvgVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgVenta.MultiSelect = false;

            dvgDetalleVenta.ReadOnly = true;
            dvgDetalleVenta.AllowUserToAddRows = false;
            dvgDetalleVenta.AllowUserToDeleteRows = false;
            dvgDetalleVenta.AutoGenerateColumns = true;
            dvgDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dvgDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dvgDetalleVenta.MultiSelect = false;
        }

        // Comprueba que haya un cajero autenticado y carga su historial de ventas.
        private void Historial_Load(object sender, EventArgs e)
        {
            if (Sesion.UsuarioActual == null ||
                Sesion.UsuarioActual.IdUsuario <= 0)
            {
                MessageBox.Show(
                    "No se pudo identificar al cajero que inició sesión.",
                    "Sesión inválida",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                Close();
                return;
            }

            CargarVentas();
        }

        // Ejecuta nuevamente la consulta del historial utilizando el rango de fechas seleccionado.
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }
        
        // Valida la sesión y el rango de fechas, consulta las ventas del cajero y aplica el filtro de ticket.
        private void CargarVentas()
        {
            try
            {
                if (Sesion.UsuarioActual == null ||
                    Sesion.UsuarioActual.IdUsuario <= 0)
                {
                    MessageBox.Show(
                        "No se pudo identificar al usuario de la sesión.",
                        "Sesión inválida",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DateTime? fechaDesde = dtpFechaDesde.Checked
                    ? dtpFechaDesde.Value.Date
                    : (DateTime?)null;

                DateTime? fechaHasta = dtpFechaHasta.Checked
                    ? dtpFechaHasta.Value.Date
                    : (DateTime?)null;

                if (fechaDesde.HasValue &&
                    fechaHasta.HasValue &&
                    fechaDesde.Value > fechaHasta.Value)
                {
                    MessageBox.Show(
                        "La fecha desde no puede ser posterior a la fecha hasta.",
                        "Rango de fechas inválido",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                tablaVentas = negocio.ConsultarVentasParaHistorial(
                Sesion.UsuarioActual.IdUsuario,
                fechaDesde,
                fechaHasta);

                AplicarFiltroTicket();

                if (tablaVentas.Rows.Count == 0)
                {
                    dvgDetalleVenta.DataSource = null;

                    MessageBox.Show(
                        "No se encontraron ventas para las fechas seleccionadas.",
                        "Historial de ventas",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar el historial de ventas.\n" + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Aplica el filtro de número de ticket mientras el usuario escribe.
        private void txtBuscarVenta_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroTicket();
        }

        // Filtra localmente las ventas cargadas por coincidencia parcial del número de ticket y actualiza la grilla.
        private void AplicarFiltroTicket()
        {
            if (tablaVentas == null ||
                !tablaVentas.Columns.Contains("numero_ticket"))
            {
                return;
            }

            string ticket = txtBuscarVenta.Text.Trim();

            DataView vista = new DataView(tablaVentas);

            if (ticket.Length > 0)
            {
                string ticketSeguro = ticket.Replace("'", "''");

                vista.RowFilter =
                    "CONVERT(numero_ticket, 'System.String') LIKE '%"
                    + ticketSeguro + "%'";
            }

            dvgVenta.DataSource = vista;

            ConfigurarColumnasVentas();

            if (dvgVenta.Rows.Count == 0)
            {
                dvgDetalleVenta.DataSource = null;
            }
        }

        // Oculta el identificador interno y configura los títulos y formatos de las columnas de ventas.
        private void ConfigurarColumnasVentas()
        {
            if (dvgVenta.Columns.Contains("id_venta"))
            {
                dvgVenta.Columns["id_venta"].Visible = false;
            }

            if (dvgVenta.Columns.Contains("id_venta"))
                dvgVenta.Columns["id_venta"].HeaderText = "ID venta";

            if (dvgVenta.Columns.Contains("numero_ticket"))
                dvgVenta.Columns["numero_ticket"].HeaderText = "N.º de ticket";

            if (dvgVenta.Columns.Contains("monto_total"))
            {
                dvgVenta.Columns["monto_total"].HeaderText = "Monto total";
                dvgVenta.Columns["monto_total"].DefaultCellStyle.Format = "C2";
            }

            if (dvgVenta.Columns.Contains("creado_en"))
            {
                dvgVenta.Columns["creado_en"].HeaderText = "Fecha de venta";
                dvgVenta.Columns["creado_en"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            }
        }

        // Consulta y muestra los detalles de la venta seleccionada en la segunda grilla.
        private void dvgVenta_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dvgVenta.CurrentRow == null ||
                    dvgVenta.CurrentRow.IsNewRow ||
                    dvgVenta.CurrentRow.Cells["id_venta"].Value == null)
                {
                    dvgDetalleVenta.DataSource = null;
                    return;
                }

                int idVenta = Convert.ToInt32(
                    dvgVenta.CurrentRow.Cells["id_venta"].Value);

                DataTable detalles =
                    negocio.ConsultarDetallesVenta(idVenta);

                dvgDetalleVenta.DataSource = detalles;

                ConfigurarColumnasDetalles();
            }
            catch (Exception ex)
            {
                dvgDetalleVenta.DataSource = null;

                MessageBox.Show(
                    "No se pudieron cargar los detalles de la venta.\n"
                    + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // Deja visibles solamente las columnas relevantes del detalle y configura sus títulos y formatos.
        private void ConfigurarColumnasDetalles()
        {
            string[] columnasVisibles =
            {
              "descripcion",
              "cantidad",
              "precio_unitario",
              "subtotal"
            };

            foreach (DataGridViewColumn columna in dvgDetalleVenta.Columns)
            {
                columna.Visible = Array.Exists(
                    columnasVisibles,
                    nombre => nombre == columna.Name);
            }

            if (dvgDetalleVenta.Columns.Contains("descripcion"))
                dvgDetalleVenta.Columns["descripcion"].HeaderText = "Producto";

            if (dvgDetalleVenta.Columns.Contains("cantidad"))
                dvgDetalleVenta.Columns["cantidad"].HeaderText = "Cantidad";

            if (dvgDetalleVenta.Columns.Contains("precio_unitario"))
            {
                dvgDetalleVenta.Columns["precio_unitario"].HeaderText =
                    "Precio unitario";

                dvgDetalleVenta.Columns["precio_unitario"]
                    .DefaultCellStyle.Format = "C2";
            }

            if (dvgDetalleVenta.Columns.Contains("subtotal"))
            {
                dvgDetalleVenta.Columns["subtotal"].HeaderText = "Subtotal";

                dvgDetalleVenta.Columns["subtotal"]
                    .DefaultCellStyle.Format = "C2";
            }
        }

        // Cierra la ventana del historial de ventas.
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
    
    }
}

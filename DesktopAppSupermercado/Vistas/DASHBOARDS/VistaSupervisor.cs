using DesktopAppSupermercado.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DesktopAppSupermercado.DASHBOARDS
{
    public partial class VistaSupervisor : Form
    {
        // Tablas originales obtenidas desde la base de datos.
        private DataTable tablaVentasOriginal;
        private DataTable tablaCajerosOriginal;
        private DataTable tablaProductosOriginal;
        private DataTable tablaCategoriasOriginal;
        private DataTable tablaClientesOriginal;

        public VistaSupervisor()
        {
            InitializeComponent();
        }

        private void btnReportesC_Click(object sender, EventArgs e)
        {

        }

        private void btnSalirC_Click(object sender, EventArgs e)
        {

        }

        private void btnSalirSUPERVISOR_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void dtpFechaDesde_ValueChanged(object sender, EventArgs e)
        {
            CargarGrillasReportes();
        }

        private void dtpFechaHasta_ValueChanged(object sender, EventArgs e)
        {
            CargarGrillasReportes();
        }

        private void btnReporteProducto_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaDesde = dtpFechaDesde.Value;
                DateTime fechaHasta = dtpFechaHasta.Value;

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    sfd.Title = "Guardar Reporte de Productos y Categorías";
                    sfd.FileName = $"Reporte_Productos_Categorias_{fechaDesde:yyyyMMdd}_al_{fechaHasta:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        reporteNegocio.GenerarPdfReporteProductosYCategorias(fechaDesde, fechaHasta, sfd.FileName);

                        MessageBox.Show(
                            "El reporte de productos y categorías se generó correctamente.",
                            "Reporte Generado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        Process.Start(new ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReporteCliente_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaDesde = dtpFechaDesde.Value;
                DateTime fechaHasta = dtpFechaHasta.Value;

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    sfd.Title = "Guardar Reporte de Clientes";
                    sfd.FileName = $"Reporte_Clientes_{fechaDesde:yyyyMMdd}_al_{fechaHasta:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        reporteNegocio.GenerarPdfReporteClientes(fechaDesde, fechaHasta, sfd.FileName);

                        MessageBox.Show(
                            "El reporte de clientes se generó correctamente.",
                            "Reporte Generado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        Process.Start(new ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tabControlSupervisor_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool habiaTexto = txtBuscar.TextLength > 0;

            // Limpiar el buscador al cambiar de pestaña.
            txtBuscar.Clear();

            // Si ya estaba vacío, el evento TextChanged no se dispara.
            // En ese caso aplicamos manualmente el filtro vacío.
            if (!habiaTexto)
            {
                AplicarFiltroPestana();
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            AplicarFiltroPestana();
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

        private void VistaSupervisor_Load(object sender, EventArgs e)
        {
            dgvProductos.AutoGenerateColumns = false;

            // 1. Habilitamos la generación automática de columnas para las grillas del reporte
            dgvVentas.Columns.Clear();
            dgvVentas.AutoGenerateColumns = true;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ReadOnly = true;
            dgvVentas.AllowUserToAddRows = false;

            dgvCajero.Columns.Clear();
            dgvCajero.AutoGenerateColumns = true;
            dgvCajero.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCajero.ReadOnly = true;
            dgvCajero.AllowUserToAddRows = false;

            dgvProductos.Columns.Clear();
            dgvProductos.AutoGenerateColumns = true;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.ReadOnly = true;
            dgvProductos.AllowUserToAddRows = false;

            dgvCategoria.Columns.Clear();
            dgvCategoria.AutoGenerateColumns = true;
            dgvCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategoria.ReadOnly = true;
            dgvCategoria.AllowUserToAddRows = false;

            dgvCliente.Columns.Clear();
            dgvCliente.AutoGenerateColumns = true;
            dgvCliente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCliente.ReadOnly = true;
            dgvCliente.AllowUserToAddRows = false;

            // 2. Configuramos las fechas iniciales sin disparar el evento dos veces
            dtpFechaDesde.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpFechaHasta.Value = DateTime.Now;

            // 3. Enlazamos el evento ValueChanged para que al cambiar cualquier fecha se actualicen solas
            dtpFechaDesde.ValueChanged += dtpFechasReporte_ValueChanged;
            dtpFechaHasta.ValueChanged += dtpFechasReporte_ValueChanged;

            // 4. Cargamos las grillas de reportes por primera vez al abrir la ventana
            CargarGrillasReportes();

        }

        // Evento que actualiza ambas grillas cada vez que el usuario cambia dtpFechaDesde o dtpFechaHasta
        private void dtpFechasReporte_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFechaDesde.Value.Date > dtpFechaHasta.Value.Date)
            {
                // Descartar los resultados originales.
                tablaVentasOriginal = null;
                tablaCajerosOriginal = null;
                tablaProductosOriginal = null;
                tablaCategoriasOriginal = null;
                tablaClientesOriginal = null;

                // Limpiar las grillas.
                dgvVentas.DataSource = null;
                dgvCajero.DataSource = null;
                dgvProductos.DataSource = null;
                dgvCategoria.DataSource = null;
                dgvCliente.DataSource = null;

                return;
            }

        }

        private ReporteNegocio reporteNegocio = new ReporteNegocio();

        private void btnReporteVentas_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime fechaDesde = dtpFechaDesde.Value;
                DateTime fechaHasta = dtpFechaHasta.Value;

                // Opcional: Si también quieres refrescar tu grilla dgvVentas en pantalla:
                // dgvVentas.DataSource = reporteNegocio.ObtenerVentasValidadas(fechaDesde, fechaHasta);

                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Archivo PDF (*.pdf)|*.pdf";
                    sfd.Title = "Guardar Reporte de Ventas";
                    sfd.FileName = $"Reporte_Ventas_{fechaDesde:yyyyMMdd}_al_{fechaHasta:yyyyMMdd}.pdf";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Llamamos a la capa de negocio para validar y generar el PDF
                        reporteNegocio.GenerarPdfReporteVentas(fechaDesde, fechaHasta, sfd.FileName);

                        MessageBox.Show(
                            "El reporte de ventas se generó correctamente.",
                            "Reporte Generado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Abrimos el PDF recién creado con el visor predeterminado de Windows
                        Process.Start(new ProcessStartInfo
                        {
                            FileName = sfd.FileName,
                            UseShellExecute = true
                        });
                    }
                }
            }
            catch (ArgumentException ex)
            {
                // Errores de validación de fechas (ej. Fecha Desde > Fecha Hasta)
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                // Cuando no hay ventas registradas en ese rango
                MessageBox.Show(ex.Message, "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Cualquier otro error inesperado (BD o permisos de archivo)
                MessageBox.Show($"Ocurrió un error al generar el reporte: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarGrillasReportes()
        {
            try
            {
                DateTime fechaDesde = dtpFechaDesde.Value;
                DateTime fechaHasta = dtpFechaHasta.Value;

                // 1. Obtener primero los resultados originales desde la capa Negocio.

                tablaVentasOriginal =
                    reporteNegocio.ObtenerVentasFiltradas(fechaDesde, fechaHasta);

                tablaCajerosOriginal =
                    reporteNegocio.ObtenerResumenCajerosFiltrado(fechaDesde, fechaHasta);

                tablaProductosOriginal =
                    reporteNegocio.ObtenerProductosFiltrados(fechaDesde, fechaHasta);

                tablaCategoriasOriginal =
                    reporteNegocio.ObtenerCategoriasFiltradas(fechaDesde, fechaHasta);

                tablaClientesOriginal =
                    reporteNegocio.ObtenerClientesFiltrados(fechaDesde, fechaHasta);


                // 2. Asignar copias de los resultados a los DataGridView.

                dgvVentas.DataSource = tablaVentasOriginal.Copy();
                dgvCajero.DataSource = tablaCajerosOriginal.Copy();
                dgvProductos.DataSource = tablaProductosOriginal.Copy();
                dgvCategoria.DataSource = tablaCategoriasOriginal.Copy();
                dgvCliente.DataSource = tablaClientesOriginal.Copy();


                // 3. Configurar encabezados y formatos de dgvVentas.

                if (dgvVentas.Columns["numero_ticket"] != null)
                    dgvVentas.Columns["numero_ticket"].HeaderText = "N.º de Ticket";

                if (dgvVentas.Columns["monto_total"] != null)
                {
                    dgvVentas.Columns["monto_total"].HeaderText = "Monto";
                    dgvVentas.Columns["monto_total"].DefaultCellStyle.Format = "C2";
                }

                if (dgvVentas.Columns["creado_en"] != null)
                {
                    dgvVentas.Columns["creado_en"].HeaderText = "Fecha de Creación";
                    dgvVentas.Columns["creado_en"].DefaultCellStyle.Format =
                        "dd/MM/yyyy HH:mm";
                }


                // 4. Configurar encabezados y formatos de dgvCajero.

                if (dgvCajero.Columns["nombre_cajero"] != null)
                    dgvCajero.Columns["nombre_cajero"].HeaderText = "Cajero";

                if (dgvCajero.Columns["cantidad_ventas"] != null)
                    dgvCajero.Columns["cantidad_ventas"].HeaderText = "Cantidad de Venta";

                if (dgvCajero.Columns["monto_recaudado"] != null)
                {
                    dgvCajero.Columns["monto_recaudado"].HeaderText = "Monto Recaudado";
                    dgvCajero.Columns["monto_recaudado"].DefaultCellStyle.Format = "C2";
                }


                // 5. Configurar encabezados y formatos de dgvProductos.

                if (dgvProductos.Columns["nombre_producto"] != null)
                    dgvProductos.Columns["nombre_producto"].HeaderText = "Nombre";

                if (dgvProductos.Columns["cantidad_vendida"] != null)
                    dgvProductos.Columns["cantidad_vendida"].HeaderText = "Cantidad Vendida";

                if (dgvProductos.Columns["stock_sobrante"] != null)
                    dgvProductos.Columns["stock_sobrante"].HeaderText = "Stock Sobrante";

                if (dgvProductos.Columns["ganancia_generada"] != null)
                {
                    dgvProductos.Columns["ganancia_generada"].HeaderText = "Ganancia Generada";
                    dgvProductos.Columns["ganancia_generada"].DefaultCellStyle.Format = "C2";
                }


                // 6. Configurar encabezados y formatos de dgvCategoria.

                if (dgvCategoria.Columns["nombre_categoria"] != null)
                    dgvCategoria.Columns["nombre_categoria"].HeaderText = "Categoría";

                if (dgvCategoria.Columns["ganancia_generada"] != null)
                {
                    dgvCategoria.Columns["ganancia_generada"].HeaderText = "Ganancia Generada";
                    dgvCategoria.Columns["ganancia_generada"].DefaultCellStyle.Format = "C2";
                }


                // 7. Configurar encabezados y formatos de dgvCliente.

                if (dgvCliente.Columns["nombre_cliente"] != null)
                    dgvCliente.Columns["nombre_cliente"].HeaderText = "Nombre y Apellido";

                if (dgvCliente.Columns["telefono"] != null)
                    dgvCliente.Columns["telefono"].HeaderText = "Teléfono";

                if (dgvCliente.Columns["correo"] != null)
                    dgvCliente.Columns["correo"].HeaderText = "Correo";

                if (dgvCliente.Columns["cantidad_ventas"] != null)
                    dgvCliente.Columns["cantidad_ventas"].HeaderText = "Cantidad de Ventas";

                if (dgvCliente.Columns["monto_recaudado"] != null)
                {
                    dgvCliente.Columns["monto_recaudado"].HeaderText =
                        "Monto Total Recaudado";

                    dgvCliente.Columns["monto_recaudado"].DefaultCellStyle.Format = "C2";
                }


                // 8. Aplicar el filtro de la pestaña actualmente seleccionada.

                AplicarFiltroPestana();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void AplicarFiltroPestana()
        {
            string filtro = txtBuscar.Text.Trim();

            switch (tabControlSupervisor.SelectedIndex)
            {
                // PESTAÑA 0: VENTAS
                case 0:

                    dgvVentas.DataSource =
                        reporteNegocio.BuscarVentasPorNumeroTicket(
                            tablaVentasOriginal,
                            filtro);

                    dgvCajero.DataSource =
                        reporteNegocio.BuscarCajerosPorNombre(
                            tablaCajerosOriginal,
                            filtro);

                    break;


                // PESTAÑA 1: PRODUCTOS
                case 1:

                    dgvProductos.DataSource =
                        reporteNegocio.BuscarProductosPorNombre(
                            tablaProductosOriginal,
                            filtro);

                    dgvCategoria.DataSource =
                        reporteNegocio.BuscarCategoriasPorNombre(
                            tablaCategoriasOriginal,
                            filtro);

                    break;


                // PESTAÑA 2: CLIENTES
                case 2:

                    dgvCliente.DataSource =
                        reporteNegocio.BuscarClientesPorNombre(
                            tablaClientesOriginal,
                            filtro);

                    break;
            }
        }

    }
}

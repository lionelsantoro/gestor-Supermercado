using DesktopAppSupermercado.Datos;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System.Linq;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public class ReporteNegocio
    {
        private readonly ReporteDatos reporteDatos = new ReporteDatos();

        public DataTable ObtenerVentasValidadas(DateTime fechaDesde, DateTime fechaHasta)
        {
            DateTime inicio = fechaDesde.Date; // 00:00:00
            DateTime fin = fechaHasta.Date.AddDays(1).AddTicks(-1); // 23:59:59.999

            if (inicio > fin)
            {
                throw new ArgumentException("La 'Fecha Desde' no puede ser posterior a la 'Fecha Hasta'.");
            }

            if (inicio > DateTime.Now)
            {
                throw new ArgumentException("La fecha de inicio no puede ser una fecha futura.");
            }

            return reporteDatos.ObtenerVentasPorRango(inicio, fin);
        }

        public void GenerarPdfReporteVentas(DateTime fechaDesde, DateTime fechaHasta, string rutaArchivo)
        {
            DataTable dtVentas = ObtenerVentasValidadas(fechaDesde, fechaHasta);

            if (dtVentas.Rows.Count == 0)
            {
                throw new InvalidOperationException("No se registraron ventas en el rango de fechas seleccionado.");
            }

            QuestPDF.Settings.License = LicenseType.Community;

            // Mapeamos NumeroTicket y aseguramos el orden correlativo (1, 2, 3...)
            var listaVentas = dtVentas.AsEnumerable()
                .Select(row => new
                {
                    NumeroTicket = Convert.ToInt32(row["NumeroTicket"]),
                    FechaHora = Convert.ToDateTime(row["FechaHora"]),
                    IdUsuario = Convert.ToInt32(row["IdUsuario"]),
                    NombreUsuario = row["NombreUsuario"].ToString(),
                    NombreCajero = row["NombreCajero"].ToString(),
                    MontoTotal = Convert.ToDecimal(row["MontoTotal"])
                })
                .OrderBy(v => v.NumeroTicket)
                .ToList();

            // Métricas Generales
            int cantidadTotalVentas = listaVentas.Count;
            decimal montoTotalGeneral = listaVentas.Sum(v => v.MontoTotal);

            // Agrupación por Cajero
            var resumenPorCajero = listaVentas
                .GroupBy(v => new { v.IdUsuario, v.NombreCajero, v.NombreUsuario })
                .Select(g => new
                {
                    Cajero = g.Key.NombreCajero,
                    Usuario = g.Key.NombreUsuario,
                    CantidadVentas = g.Count(),
                    TotalRecaudado = g.Sum(x => x.MontoTotal)
                })
                .OrderByDescending(r => r.TotalRecaudado)
                .ToList();

            // Creación del documento PDF
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(35);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(10)); // Usa la fuente Lato integrada

                    // ================= ENCABEZADO =================
                    page.Header().Column(col =>
                    {
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text("REPORTE DE VENTAS").FontSize(18).Bold().FontColor(Colors.Blue.Darken3);
                                c.Item().Text($"Período consultado: {fechaDesde:dd/MM/yyyy} al {fechaHasta:dd/MM/yyyy}").FontSize(11).SemiBold();
                            });

                            row.ConstantItem(150).AlignRight().Column(c =>
                            {
                                c.Item().Text($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy}").FontSize(9).FontColor(Colors.Grey.Darken2);
                                c.Item().Text($"Hora: {DateTime.Now:HH:mm}").FontSize(9).FontColor(Colors.Grey.Darken2);
                            });
                        });

                        col.Item().PaddingTop(8).LineHorizontal(1.5f).LineColor(Colors.Blue.Darken3);
                    });

                    // ================= CONTENIDO =================
                    page.Content().PaddingVertical(15).Column(col =>
                    {
                        col.Spacing(18);

                        // 1. Tarjetas de Resumen General
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("CANTIDAD TOTAL DE VENTAS").FontSize(9).FontColor(Colors.Grey.Darken2).SemiBold();
                                c.Item().PaddingTop(4).Text(cantidadTotalVentas.ToString()).FontSize(16).Bold().FontColor(Colors.Blue.Darken3);
                            });

                            row.ConstantItem(15);

                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("MONTO TOTAL RECAUDADO").FontSize(9).FontColor(Colors.Grey.Darken2).SemiBold();
                                c.Item().PaddingTop(4).Text($"$ {montoTotalGeneral:N2}").FontSize(16).Bold().FontColor(Colors.Green.Darken3);
                            });
                        });

                        // 2. Tabla de Rendimiento por Cajero
                        col.Item().Column(c =>
                        {
                            c.Item().PaddingBottom(5).Text("Resumen de Ventas por Cajero").FontSize(13).Bold().FontColor(Colors.Blue.Darken3);

                            c.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                });

                                tabla.Header(header =>
                                {
                                    header.Cell().Background(Colors.Blue.Darken3).Padding(5).Text("Cajero").FontColor(Colors.White).SemiBold();
                                    header.Cell().Background(Colors.Blue.Darken3).Padding(5).Text("Usuario").FontColor(Colors.White).SemiBold();
                                    header.Cell().Background(Colors.Blue.Darken3).Padding(5).AlignCenter().Text("Cant. Ventas").FontColor(Colors.White).SemiBold();
                                    header.Cell().Background(Colors.Blue.Darken3).Padding(5).AlignRight().Text("Total Recaudado").FontColor(Colors.White).SemiBold();
                                });

                                foreach (var item in resumenPorCajero)
                                {
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.Cajero);
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(item.Usuario);
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignCenter().Text(item.CantidadVentas.ToString());
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignRight().Text($"$ {item.TotalRecaudado:N2}").SemiBold();
                                }
                            });
                        });

                        // 3. Tabla con el Detalle de Ventas Enumeradas por Ticket
                        col.Item().Column(c =>
                        {
                            c.Item().PaddingBottom(5).Text("Detalle de Ventas Realizadas").FontSize(13).Bold().FontColor(Colors.Blue.Darken3);

                            c.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(65); // N° Ticket
                                    columns.RelativeColumn(2);  // Fecha y Hora
                                    columns.RelativeColumn(3);  // Cajero
                                    columns.RelativeColumn(2);  // Monto
                                });

                                tabla.Header(header =>
                                {
                                    header.Cell().Background(Colors.Grey.Darken3).Padding(5).Text("N° Ticket").FontColor(Colors.White).SemiBold();
                                    header.Cell().Background(Colors.Grey.Darken3).Padding(5).Text("Fecha y Hora").FontColor(Colors.White).SemiBold();
                                    header.Cell().Background(Colors.Grey.Darken3).Padding(5).Text("Cajero").FontColor(Colors.White).SemiBold();
                                    header.Cell().Background(Colors.Grey.Darken3).Padding(5).AlignRight().Text("Monto").FontColor(Colors.White).SemiBold();
                                });

                                foreach (var venta in listaVentas)
                                {
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).Text($"#{venta.NumeroTicket}");
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).Text(venta.FechaHora.ToString("dd/MM/yyyy HH:mm"));
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).Text($"{venta.NombreCajero} ({venta.NombreUsuario})");
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).AlignRight().Text($"$ {venta.MontoTotal:N2}");
                                }
                            });
                        });
                    });

                    // ================= PIE DE PÁGINA =================
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
                });
            }).GeneratePdf(rutaArchivo);
        }

        private (DateTime inicio, DateTime fin) ValidarYObtenerRango(DateTime fechaDesde, DateTime fechaHasta)
        {
            DateTime inicio = fechaDesde.Date; // 00:00:00
            DateTime fin = fechaHasta.Date.AddDays(1).AddTicks(-1); // 23:59:59.999

            if (inicio > fin)
            {
                throw new ArgumentException("La 'Fecha Desde' no puede ser posterior a la 'Fecha Hasta'.");
            }

            if (inicio > DateTime.Now)
            {
                throw new ArgumentException("La fecha de inicio no puede ser una fecha futura.");
            }

            return (inicio, fin);
        }

        public DataTable ObtenerVentasFiltradas(DateTime fechaDesde, DateTime fechaHasta)
        {
            var rango = ValidarYObtenerRango(fechaDesde, fechaHasta);
            return reporteDatos.ObtenerVentasParaGrilla(rango.inicio, rango.fin);
        }

        public DataTable ObtenerResumenCajerosFiltrado(DateTime fechaDesde, DateTime fechaHasta)
        {
            var rango = ValidarYObtenerRango(fechaDesde, fechaHasta);
            return reporteDatos.ObtenerResumenCajerosParaGrilla(rango.inicio, rango.fin);
        }

        public DataTable ObtenerCategoriasFiltradas(DateTime fechaDesde, DateTime fechaHasta)
        {
            var rango = ValidarYObtenerRango(fechaDesde, fechaHasta);
            return reporteDatos.ObtenerCategoriasPorRango(rango.inicio, rango.fin);
        }

        public DataTable ObtenerProductosFiltrados(DateTime fechaDesde, DateTime fechaHasta)
        {
            var rango = ValidarYObtenerRango(fechaDesde, fechaHasta);
            return reporteDatos.ObtenerProductosParaGrilla(rango.inicio, rango.fin);
        }

        private string FormatearCantidadSegunUnidad(decimal valor, string unidadMedida)
        {
            bool esKg = string.Equals(unidadMedida?.Trim(), "Kg", StringComparison.OrdinalIgnoreCase);
            return esKg ? $"{valor:0.###} Kg" : $"{valor:0} u.";
        }

        public void GenerarPdfReporteProductosYCategorias(DateTime fechaDesde, DateTime fechaHasta, string rutaArchivo)
        {
            var rango = ValidarYObtenerRango(fechaDesde, fechaHasta);

            DataTable dtCategorias = reporteDatos.ObtenerCategoriasPorRango(rango.inicio, rango.fin);
            DataTable dtProductos = reporteDatos.ObtenerProductosDetalladoPorRango(rango.inicio, rango.fin);

            if (dtProductos.Rows.Count == 0)
            {
                throw new InvalidOperationException("No existen productos registrados para generar el reporte.");
            }

            QuestPDF.Settings.License = LicenseType.Community;

            // 1. Mapeo de Categorías (ya vienen ordenadas de mayor a menor ganancia)
            var listaCategorias = dtCategorias.AsEnumerable()
                .Select(row => new
                {
                    Categoria = row["nombre_categoria"].ToString(),
                    Ganancia = Convert.ToDecimal(row["ganancia_generada"])
                })
                .OrderByDescending(c => c.Ganancia)
                .ToList();

            // 2. Mapeo de Productos
            var todosLosProductos = dtProductos.AsEnumerable()
                .Select(row => new
                {
                    Nombre = row["NombreProducto"].ToString(),
                    Categoria = row["NombreCategoria"].ToString(),
                    PrecioUnitario = Convert.ToDecimal(row["PrecioUnitario"]),
                    UnidadMedida = row["UnidadMedida"].ToString(),
                    StockSobrante = Convert.ToDecimal(row["StockSobrante"]),
                    CantidadVendida = Convert.ToDecimal(row["CantidadVendida"]),
                    Ganancia = Convert.ToDecimal(row["GananciaGenerada"])
                })
                .ToList();

            // Separamos Productos Vendidos vs Productos No Vendidos en ese rango de fechas
            var productosVendidos = todosLosProductos
                .Where(p => p.CantidadVendida > 0)
                .OrderByDescending(p => p.Ganancia)
                .ToList();

            var productosNoVendidos = todosLosProductos
                .Where(p => p.CantidadVendida == 0)
                .OrderBy(p => p.Nombre)
                .ToList();

            decimal gananciaTotalGeneral = listaCategorias.Sum(c => c.Ganancia);

            // Creación del documento PDF
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(35);
                    page.Size(PageSizes.A4);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    // ================= ENCABEZADO =================
                    page.Header().Column(col =>
                    {
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Column(c =>
                            {
                                c.Item().Text("REPORTE DE PRODUCTOS Y CATEGORÍAS").FontSize(17).Bold().FontColor(Colors.Blue.Darken3);
                                c.Item().Text($"Período consultado: {fechaDesde:dd/MM/yyyy} al {fechaHasta:dd/MM/yyyy}").FontSize(11).SemiBold();
                            });

                            row.ConstantItem(150).AlignRight().Column(c =>
                            {
                                c.Item().Text($"Fecha de emisión: {DateTime.Now:dd/MM/yyyy}").FontSize(9).FontColor(Colors.Grey.Darken2);
                                c.Item().Text($"Hora: {DateTime.Now:HH:mm}").FontSize(9).FontColor(Colors.Grey.Darken2);
                            });
                        });

                        col.Item().PaddingTop(8).LineHorizontal(1.5f).LineColor(Colors.Blue.Darken3);
                    });

                    // ================= CONTENIDO =================
                    page.Content().PaddingVertical(15).Column(col =>
                    {
                        col.Spacing(18);

                        // Tarjetas de Resumen
                        col.Item().Row(row =>
                        {
                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("PRODUCTOS CON VENTAS").FontSize(9).FontColor(Colors.Grey.Darken2).SemiBold();
                                c.Item().PaddingTop(4).Text($"{productosVendidos.Count} de {todosLosProductos.Count}").FontSize(15).Bold().FontColor(Colors.Blue.Darken3);
                            });

                            row.ConstantItem(15);

                            row.RelativeItem().Border(1).BorderColor(Colors.Grey.Lighten2).Background(Colors.Grey.Lighten4).Padding(10).Column(c =>
                            {
                                c.Item().Text("GANANCIA TOTAL GENERADA").FontSize(9).FontColor(Colors.Grey.Darken2).SemiBold();
                                c.Item().PaddingTop(4).Text($"$ {gananciaTotalGeneral:N2}").FontSize(15).Bold().FontColor(Colors.Green.Darken3);
                            });
                        });

                        // 1. Tabla de Categorías ordenadas de mayor a menor ganancia
                        col.Item().Column(c =>
                        {
                            c.Item().PaddingBottom(5).Text("1. Ganancia Generada por Categoría (Mayor a Menor)").FontSize(13).Bold().FontColor(Colors.Blue.Darken3);

                            c.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(3); // Categoría
                                    columns.RelativeColumn(2); // Ganancia
                                });

                                tabla.Header(header =>
                                {
                                    header.Cell().Background(Colors.Blue.Darken3).Padding(5).Text("Categoría").FontColor(Colors.White).SemiBold();
                                    header.Cell().Background(Colors.Blue.Darken3).Padding(5).AlignRight().Text("Ganancia Generada").FontColor(Colors.White).SemiBold();
                                });

                                foreach (var cat in listaCategorias)
                                {
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).Text(cat.Categoria);
                                    tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2).Padding(5).AlignRight().Text($"$ {cat.Ganancia:N2}").SemiBold();
                                }
                            });
                        });

                        // 2. Tabla de Productos Vendidos
                        col.Item().Column(c =>
                        {
                            c.Item().PaddingBottom(5).Text("2. Productos Vendidos en el Período").FontSize(13).Bold().FontColor(Colors.Blue.Darken3);

                            if (productosVendidos.Count == 0)
                            {
                                c.Item().Padding(8).Background(Colors.Grey.Lighten4).Text("No se registraron ventas de productos en el rango de fechas seleccionado.").Italic();
                            }
                            else
                            {
                                c.Item().Table(tabla =>
                                {
                                    tabla.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(3);   // Nombre del producto
                                        columns.RelativeColumn(1.6f); // Precio por Unidad/Kg
                                        columns.RelativeColumn(1.5f); // Cantidad Vendida
                                        columns.RelativeColumn(1.5f); // Stock Sobrante
                                        columns.RelativeColumn(1.8f); // Ganancia
                                    });

                                    tabla.Header(header =>
                                    {
                                        header.Cell().Background(Colors.Grey.Darken3).Padding(5).Text("Producto").FontColor(Colors.White).SemiBold();
                                        header.Cell().Background(Colors.Grey.Darken3).Padding(5).AlignRight().Text("Precio (u/Kg)").FontColor(Colors.White).SemiBold();
                                        header.Cell().Background(Colors.Grey.Darken3).Padding(5).AlignCenter().Text("Cant. Vendida").FontColor(Colors.White).SemiBold();
                                        header.Cell().Background(Colors.Grey.Darken3).Padding(5).AlignCenter().Text("Stock Sobrante").FontColor(Colors.White).SemiBold();
                                        header.Cell().Background(Colors.Grey.Darken3).Padding(5).AlignRight().Text("Ganancia").FontColor(Colors.White).SemiBold();
                                    });

                                    foreach (var prod in productosVendidos)
                                    {
                                        string sufijoPrecio = string.Equals(prod.UnidadMedida?.Trim(), "Kg", StringComparison.OrdinalIgnoreCase) ? "/Kg" : "/u";

                                        tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).Text(prod.Nombre);
                                        tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).AlignRight().Text($"$ {prod.PrecioUnitario:N2} {sufijoPrecio}");
                                        tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).AlignCenter().Text(FormatearCantidadSegunUnidad(prod.CantidadVendida, prod.UnidadMedida));
                                        tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).AlignCenter().Text(FormatearCantidadSegunUnidad(prod.StockSobrante, prod.UnidadMedida));
                                        tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).AlignRight().Text($"$ {prod.Ganancia:N2}").SemiBold();
                                    }
                                });
                            }
                        });

                        // 3. Tabla de Productos NO Vendidos
                        col.Item().Column(c =>
                        {
                            c.Item().PaddingBottom(5).Text("3. Productos Sin Ventas en el Período").FontSize(13).Bold().FontColor(Colors.Red.Darken2);

                            if (productosNoVendidos.Count == 0)
                            {
                                c.Item().Padding(8).Background(Colors.Grey.Lighten4).Text("Todos los productos registraron al menos una venta en este período.").Italic();
                            }
                            else
                            {
                                c.Item().Table(tabla =>
                                {
                                    tabla.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(4); // Nombre del producto
                                        columns.RelativeColumn(2); // Stock Sobrante
                                    });

                                    tabla.Header(header =>
                                    {
                                        header.Cell().Background(Colors.Red.Darken2).Padding(5).Text("Producto").FontColor(Colors.White).SemiBold();
                                        header.Cell().Background(Colors.Red.Darken2).Padding(5).AlignCenter().Text("Stock Sobrante").FontColor(Colors.White).SemiBold();
                                    });

                                    foreach (var prod in productosNoVendidos)
                                    {
                                        tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).Text(prod.Nombre);
                                        tabla.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten3).Padding(4).AlignCenter().Text(FormatearCantidadSegunUnidad(prod.StockSobrante, prod.UnidadMedida));
                                    }
                                });
                            }
                        });
                    });

                    // ================= PIE DE PÁGINA =================
                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Página ");
                        x.CurrentPageNumber();
                        x.Span(" de ");
                        x.TotalPages();
                    });
                });
            }).GeneratePdf(rutaArchivo);
        }

    }
}

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
    }
}

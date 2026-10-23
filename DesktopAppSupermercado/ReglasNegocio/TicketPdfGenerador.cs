using DesktopAppSupermercado.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace DesktopAppSupermercado.ReglasNegocio
{
    internal static class TicketPdfGenerador
    {
        public static string GenerarPdf(VentaEnMemoria venta)
        {
            if (venta == null)
                throw new ArgumentNullException(nameof(venta));

            if (venta.ClienteActual == null)
                throw new Exception("La venta no tiene un cliente asociado.");

            if (venta.Detalles == null || venta.Detalles.Count == 0)
                throw new Exception("La venta no tiene detalles para imprimir.");

            CultureInfo cultura = CultureInfo.GetCultureInfo("es-AR");

            string carpeta = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.MyDocuments),
                "DesktopAppSupermercado",
                "Tickets");

            Directory.CreateDirectory(carpeta);

            string rutaPdf = Path.Combine(
                carpeta,
                $"Ticket_{venta.NumeroTicketEstimado:000000}.pdf");

            // Altura dinámica para acomodar todos los productos.
            float altoMm = 125 + venta.Detalles.Count * 12;

            Document.Create(document =>
            {
                document.Page(page =>
                {
                    page.Size(80, altoMm, Unit.Millimetre);
                    page.Margin(4, Unit.Millimetre);

                    page.DefaultTextStyle(style =>
                        style.FontFamily("Lato").FontSize(8));

                    page.Content().Column(columna =>
                    {
                        columna.Spacing(5);

                        // Encabezado.
                        columna.Item().AlignCenter()
                            .Text("SUPERMERCADO")
                            .Bold().FontSize(14);

                        columna.Item().AlignCenter()
                            .Text("TICKET DE VENTA")
                            .SemiBold().FontSize(9);

                        columna.Item().LineHorizontal(1);

                        columna.Item()
                            .Text($"TICKET N.º: {venta.NumeroTicketEstimado}")
                            .Bold().FontSize(10);

                        columna.Item()
                            .Text($"Fecha: {venta.Fecha:dd/MM/yyyy HH:mm}");

                        columna.Item()
                            .Text(
                                $"Cliente: {venta.ClienteActual.NombreCompleto}")
                            .SemiBold();

                        columna.Item().LineHorizontal(1);

                        // Detalle de la compra.
                        columna.Item().Table(tabla =>
                        {
                            tabla.ColumnsDefinition(columnas =>
                            {
                                columnas.RelativeColumn(4.0f);
                                columnas.RelativeColumn(1.4f);
                                columnas.RelativeColumn(2.1f);
                                columnas.RelativeColumn(2.1f);
                            });

                            tabla.Header(encabezado =>
                            {
                                encabezado.Cell()
                                    .Background(Colors.Grey.Lighten3)
                                    .Padding(2)
                                    .Text("Producto").SemiBold().FontSize(7);

                                encabezado.Cell()
                                    .Background(Colors.Grey.Lighten3)
                                    .Padding(2).AlignRight()
                                    .Text("Cant.").SemiBold().FontSize(7);

                                encabezado.Cell()
                                    .Background(Colors.Grey.Lighten3)
                                    .Padding(2).AlignRight()
                                    .Text("P. unit.").SemiBold().FontSize(7);

                                encabezado.Cell()
                                    .Background(Colors.Grey.Lighten3)
                                    .Padding(2).AlignRight()
                                    .Text("Importe").SemiBold().FontSize(7);
                            });

                            foreach (var item in venta.Detalles)
                            {
                                bool esKg = string.Equals(
                                    item.UnidadMedida?.Trim(),
                                    "Kg",
                                    StringComparison.OrdinalIgnoreCase);

                                // Para pesables, Cantidad representa gramos.
                                string cantidadTexto = esKg
                                    ? $"{item.Cantidad} g"
                                    : $"{item.Cantidad} u";

                                string precioTexto =
                                    "$ " + item.Precio_Unitario.ToString(
                                        "N2", cultura)
                                    + (esKg ? "/kg" : "/u");

                                string subtotalTexto =
                                    "$ " + item.Subtotal.ToString(
                                        "N2", cultura);

                                tabla.Cell().PaddingVertical(3)
                                    .Text(item.Nombre).FontSize(7);

                                tabla.Cell().AlignRight().PaddingVertical(3)
                                    .Text(cantidadTexto).FontSize(7);

                                tabla.Cell().AlignRight().PaddingVertical(3)
                                    .Text(precioTexto).FontSize(7);

                                tabla.Cell().AlignRight().PaddingVertical(3)
                                    .Text(subtotalTexto).FontSize(7);
                            }
                        });

                        columna.Item().LineHorizontal(1);

                        // Total final.
                        columna.Item().AlignRight().Text(texto =>
                        {
                            texto.Span("TOTAL: ")
                                .SemiBold().FontSize(12);

                            texto.Span(
                                "$ " + venta.MontoTotal.ToString(
                                    "N2", cultura))
                                .Bold().FontSize(13);
                        });

                        columna.Item().AlignCenter()
                            .Text("¡Gracias por su compra!")
                            .SemiBold();

                        columna.Item().AlignCenter()
                            .Text("Conserve este comprobante.")
                            .FontSize(7);
                    });
                });
            }).GeneratePdf(rutaPdf);

            return rutaPdf;
        }
    }
}

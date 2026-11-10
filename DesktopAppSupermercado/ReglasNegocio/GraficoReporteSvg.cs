using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security;
using System.Text;

namespace DesktopAppSupermercado.ReglasNegocio
{
    public static class GraficoReporteSvg
    {
        private static readonly CultureInfo Cultura =
            CultureInfo.GetCultureInfo("es-AR");

        private static string Escapar(string texto)
        {
            return SecurityElement.Escape(texto ?? "") ?? "";
        }

        private static string NumeroSvg(double valor)
        {
            return valor.ToString(
                "0.##",
                CultureInfo.InvariantCulture);
        }

        // =====================================================
        // GRÁFICO DE BARRAS HORIZONTALES
        // =====================================================

        public static string CrearBarrasHorizontales(
            IEnumerable<(string Etiqueta, decimal Valor)> datos,
            string colorBarras = "#2F75B5")
        {
            var lista = datos == null
                ? new List<(string Etiqueta, decimal Valor)>()
                : datos.ToList();

            const int ancho = 1000;
            const int margenIzquierdo = 300;
            const int margenDerecho = 180;
            const int margenSuperior = 35;
            const int altoFila = 44;

            int alto = lista.Count == 0
                ? 130
                : margenSuperior + lista.Count * altoFila + 25;

            int anchoGrafico =
                ancho - margenIzquierdo - margenDerecho;

            StringBuilder svg = new StringBuilder();

            svg.AppendLine(
                $"<svg xmlns='http://www.w3.org/2000/svg' " +
                $"width='{ancho}' height='{alto}' " +
                $"viewBox='0 0 {ancho} {alto}'>");

            svg.AppendLine(
                $"<rect width='{ancho}' height='{alto}' fill='#FFFFFF'/>");

            if (lista.Count == 0)
            {
                svg.AppendLine(
                    $"<text x='{ancho / 2}' y='65' " +
                    "text-anchor='middle' font-family='Lato' " +
                    "font-size='22' fill='#666666'>" +
                    "No hay datos para representar</text>");

                svg.AppendLine("</svg>");

                return svg.ToString();
            }

            decimal maximo = lista.Max(x => x.Valor);

            if (maximo <= 0)
                maximo = 1;

            // Líneas verticales de referencia.
            for (int i = 0; i <= 4; i++)
            {
                double x = margenIzquierdo +
                    (anchoGrafico * i / 4.0);

                svg.AppendLine(
                    $"<line x1='{NumeroSvg(x)}' y1='25' " +
                    $"x2='{NumeroSvg(x)}' y2='{alto - 15}' " +
                    "stroke='#E5E7EB' stroke-width='1'/>");
            }

            for (int i = 0; i < lista.Count; i++)
            {
                var item = lista[i];

                double y = margenSuperior + i * altoFila;

                double anchoBarra =
                    (double)(item.Valor / maximo) *
                    anchoGrafico;

                double yTexto = y + 23;

                string etiqueta = item.Etiqueta ?? "";

                if (etiqueta.Length > 32)
                    etiqueta = etiqueta.Substring(0, 29) + "...";

                string valorTexto =
                    item.Valor.ToString("C0", Cultura);

                // Nombre del elemento.
                svg.AppendLine(
                    $"<text x='15' y='{NumeroSvg(yTexto)}' " +
                    "font-family='Lato' font-size='19' " +
                    "fill='#333333'>" +
                    Escapar(etiqueta) +
                    "</text>");

                // Barra horizontal.
                svg.AppendLine(
                    $"<rect x='{margenIzquierdo}' " +
                    $"y='{NumeroSvg(y + 6)}' " +
                    $"width='{NumeroSvg(anchoBarra)}' " +
                    "height='24' rx='4' " +
                    $"fill='{colorBarras}'/>");

                // Valor al final de la barra.
                svg.AppendLine(
                    $"<text x='{NumeroSvg(margenIzquierdo + anchoBarra + 10)}' " +
                    $"y='{NumeroSvg(yTexto)}' " +
                    "font-family='Lato' font-size='18' " +
                    "font-weight='bold' fill='#333333'>" +
                    Escapar(valorTexto) +
                    "</text>");
            }

            svg.AppendLine("</svg>");

            return svg.ToString();
        }

        // =====================================================
        // GRÁFICO DE DONA
        // =====================================================

        public static string CrearGraficoDona(
            IEnumerable<(string Etiqueta, decimal Valor, string Color)> datos,
            string textoCentro)
        {
            var lista = datos == null
                ? new List<(string Etiqueta, decimal Valor, string Color)>()
                : datos.Where(x => x.Valor > 0).ToList();

            const int ancho = 900;
            const int alto = 330;

            const double centroX = 180;
            const double centroY = 160;
            const double radio = 95;
            const double grosor = 34;

            StringBuilder svg = new StringBuilder();

            svg.AppendLine(
                $"<svg xmlns='http://www.w3.org/2000/svg' " +
                $"width='{ancho}' height='{alto}' " +
                $"viewBox='0 0 {ancho} {alto}'>");

            svg.AppendLine(
                $"<rect width='{ancho}' height='{alto}' fill='#FFFFFF'/>");

            if (lista.Count == 0)
            {
                svg.AppendLine(
                    "<text x='450' y='165' text-anchor='middle' " +
                    "font-family='Lato' font-size='22' fill='#666666'>" +
                    "No hay datos para representar</text>");

                svg.AppendLine("</svg>");

                return svg.ToString();
            }

            decimal total = lista.Sum(x => x.Valor);

            double circunferencia =
                2 * Math.PI * radio;

            // Círculo de fondo.
            svg.AppendLine(
                $"<circle cx='{centroX}' cy='{centroY}' " +
                $"r='{radio}' fill='none' stroke='#E5E7EB' " +
                $"stroke-width='{grosor}'/>");

            double desplazamiento = 0;

            // Dibujar cada porción de la dona.
            foreach (var item in lista)
            {
                double longitud =
                    (double)(item.Valor / total) *
                    circunferencia;

                double espacio =
                    circunferencia - longitud;

                svg.AppendLine(
                    $"<circle cx='{centroX}' cy='{centroY}' " +
                    $"r='{radio}' fill='none' " +
                    $"stroke='{item.Color}' " +
                    $"stroke-width='{grosor}' " +
                    $"stroke-dasharray='{NumeroSvg(longitud)} {NumeroSvg(espacio)}' " +
                    $"stroke-dashoffset='-{NumeroSvg(desplazamiento)}' " +
                    $"transform='rotate(-90 {centroX} {centroY})'/>");

                desplazamiento += longitud;
            }

            // Total en el centro.
            svg.AppendLine(
                $"<text x='{centroX}' y='155' " +
                "text-anchor='middle' font-family='Lato' " +
                "font-size='30' font-weight='bold' fill='#333333'>" +
                total.ToString("N0", Cultura) +
                "</text>");

            svg.AppendLine(
                $"<text x='{centroX}' y='183' " +
                "text-anchor='middle' font-family='Lato' " +
                "font-size='16' fill='#666666'>" +
                Escapar(textoCentro) +
                "</text>");

            // Leyenda a la derecha.
            for (int i = 0; i < lista.Count; i++)
            {
                var item = lista[i];

                double y = 90 + i * 65;

                decimal porcentaje =
                    item.Valor * 100m / total;

                svg.AppendLine(
                    $"<rect x='385' y='{NumeroSvg(y - 15)}' " +
                    $"width='20' height='20' rx='3' " +
                    $"fill='{item.Color}'/>");

                svg.AppendLine(
                    $"<text x='420' y='{NumeroSvg(y)}' " +
                    "font-family='Lato' font-size='21' " +
                    "font-weight='bold' fill='#333333'>" +
                    Escapar(item.Etiqueta) +
                    "</text>");

                svg.AppendLine(
                    $"<text x='420' y='{NumeroSvg(y + 25)}' " +
                    "font-family='Lato' font-size='18' fill='#666666'>" +
                    item.Valor.ToString("N0", Cultura) +
                    " (" + porcentaje.ToString("N1", Cultura) + "%)" +
                    "</text>");
            }

            svg.AppendLine("</svg>");

            return svg.ToString();
        }
    }
}

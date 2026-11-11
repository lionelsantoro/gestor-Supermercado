using QuestPDF.Infrastructure;
using System.Globalization;

namespace DesktopAppSupermercado
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            CultureInfo culturaArgentina = CultureInfo.GetCultureInfo("es-AR");

            CultureInfo.DefaultThreadCurrentCulture = culturaArgentina;
            CultureInfo.CurrentCulture = culturaArgentina;

            QuestPDF.Settings.License = LicenseType.Community;
            ApplicationConfiguration.Initialize();
            Application.Run(new MenuPrincipal());
            
        }
    }
}
using CommunityToolkit.Maui.Markup;
using CommunityToolkit.Maui;

namespace FourSoulsStatGUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            //LoadData();
            var builder = MauiApp.CreateBuilder();
            // Initialise the toolkit
            builder.UseMauiApp<App>().UseMauiCommunityToolkitMarkup().UseMauiCommunityToolkit();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa_solid.ttf", "FontAwesome");
            });
            return builder.Build();
        }
    }
}
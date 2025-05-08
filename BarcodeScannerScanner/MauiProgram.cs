using Microsoft.Extensions.Logging;
using BarcodeScanner.Mobile;

namespace BarcodeScannerScanner;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
#if ANDROID
			.ConfigureMauiHandlers(handlers=>
			handlers.AddBarcodeScannerHandler());
#endif

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}


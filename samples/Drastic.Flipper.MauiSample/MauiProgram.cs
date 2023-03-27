using Microsoft.Extensions.Logging;

namespace Drastic.Flipper.MauiSample;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
#if IOS
        global::Flipper.FlipperProxy.Shared.InitializeProxy();
#endif
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

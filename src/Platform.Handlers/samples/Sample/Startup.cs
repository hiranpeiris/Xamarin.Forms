using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Pages;
using Sample.Services;
using Sample.ViewModel;
using Xamarin.Platform.Hosting;

namespace Sample
{
	public static class Startup
	{
		public static AppBuilder UserInit(this AppBuilder builder)
		{
			builder.ConfigureServices((context, services) =>
			{
				services.AddSingleton<ITextService, TextService>();
				services.AddTransient<MainPageViewModel>();
				services.AddTransient<MainPage>();
			});
			builder.HostBuilder.ConfigureLogging((c, l) =>
			{
				if (c.HostingEnvironment.IsDevelopment())
				{
					//l.AddConsole(o =>
					//{
					//	o.DisableColors = true;
					//});
				}
				else
				{
					//use for example AppCenter
				}
			});
			return builder; 
			//.RegisterHandler<Button, ButtonHandler>()
			//.RegisterHandlers(new Dictionary<Type, Type> { { typeof(Button), typeof(ButtonHandler) } })
		}
	}
}
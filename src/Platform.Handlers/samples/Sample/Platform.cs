using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Pages;
using Sample.Services;
using Sample.ViewModel;

namespace Sample
{
	public static class Platform
	{
		public static IHostBuilder Init(this IHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				services.AddSingleton<ITextService, TextService>();
				services.AddTransient<MainPageViewModel>();
				services.AddTransient<MainPage>();
			});
			return builder.ConfigureLogging((c, l) =>
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
			//.RegisterHandler<Button, ButtonHandler>()
			//.RegisterHandlers(new Dictionary<Type, Type> { { typeof(Button), typeof(ButtonHandler) } })
		}
	}
}
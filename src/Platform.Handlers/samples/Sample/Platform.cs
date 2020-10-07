using Microsoft.Extensions.Hosting;

namespace Sample
{
	public static class Platform
	{
		public static IHostBuilder Init(this IHostBuilder builder)
		{
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
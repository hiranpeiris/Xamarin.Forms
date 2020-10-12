using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sample.Pages;
using Xamarin.Platform;
using Xamarin.Platform.Core;

namespace Sample
{
	public class MyApp : App
	{
		public MyApp(IHost host) : base(host)
		{
		}

		public override IView CreateView()
		{
			var button = Services.GetRequiredService<MainPage>().Content as Xamarin.Forms.Button;
			return button;
		}
	}
}
using System;
using Microsoft.Extensions.Hosting;
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
			return new Xamarin.Forms.Button() { Text = "Hello I'm a button" };
		}
	}
}
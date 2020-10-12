using System.ServiceProcess;
using Android.Content;
using Xamarin.Platform.Core;
using Xamarin.Platform.Handlers;
using Xamarin.Platform.Hosting;
using AView = Android.Views.View;

namespace Xamarin.Platform
{
	public static class HandlerExtensions
	{
		public static AView? ToNative(this IView view, Context context)
		{
			if (view == null)
				return null;

			var handler = view.Handler;

			if (handler == null)
			{
				//handler = Registrar.Handlers.GetHandler(view.GetType());
				handler = App.Current?.Handlers.GetHandler(view.GetType());

				if (handler == null)
					throw new System.Exception($"Handler not found for view {view}");

				if (handler is IAndroidViewHandler ahandler)
					ahandler.SetContext(context);

				view.Handler = handler;
			}

			handler.SetView(view);

			return handler.NativeView as AView;
		}
	}
}
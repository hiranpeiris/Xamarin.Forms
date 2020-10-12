using UIKit;
using Xamarin.Platform.Core;
using Xamarin.Platform.Hosting;

namespace Xamarin.Platform
{
	public static class HandlerExtensions
	{
		public static UIView? ToNative(this IView view)
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

				view.Handler = handler;
			}

			handler.SetView(view);

			return handler.NativeView as UIView;
		}
	}
}
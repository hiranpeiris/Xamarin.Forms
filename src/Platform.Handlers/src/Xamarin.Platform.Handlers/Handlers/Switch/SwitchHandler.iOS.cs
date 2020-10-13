using System;
using UIKit;
using RectangleF = CoreGraphics.CGRect;

namespace Xamarin.Platform.Handlers
{
	public partial class SwitchHandler : AbstractViewHandler<ISwitch, UISwitch>
	{
		protected override UISwitch CreateView()
		{
			var nativeView = new UISwitch(RectangleF.Empty);
			nativeView.ValueChanged += OnControlValueChanged;
			return nativeView;
		}

		void OnControlValueChanged(object sender, EventArgs e)
		{
			if (VirtualView == null)
				return;

			if (TypedNativeView != null)
				VirtualView.IsToggled = TypedNativeView.On;

			VirtualView.Toggled();
		}
	}
}
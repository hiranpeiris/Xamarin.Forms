using System;
using AppKit;

namespace Xamarin.Platform.Handlers
{
	public partial class SwitchHandler : AbstractViewHandler<ISwitch, NSView>
	{
		protected override NSView CreateView()
		{
			if (NativeVersion.IsAtLeast(15))
			{
				var nativeSwitch = new NSSwitch();

				nativeSwitch.Activated += OnControlActivated;

				return nativeSwitch;
			}

			var nativeButton = new NSButton
			{
				AllowsMixedState = false,
				Title = string.Empty
			};

			nativeButton.SetButtonType(NSButtonType.Switch);

			nativeButton.Activated += OnControlActivated;

			return nativeButton;
		}

		void OnControlActivated(object sender, EventArgs e)
		{
			if (VirtualView == null)
				return;

			if (NativeVersion.IsAtLeast(15))
			{
				if (TypedNativeView is NSSwitch nSSwitch)
					VirtualView.IsToggled = nSSwitch.State == 1;
			}
			else
			{
				if (TypedNativeView is NSButton nSButton)
					VirtualView.IsToggled = nSButton.State == NSCellStateValue.On;
			}
		}
	}
}
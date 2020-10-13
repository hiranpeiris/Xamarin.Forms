using UIKit;

namespace Xamarin.Platform
{
	public static class SwitchExtensions
	{
		static UIColor? DefaultOnColor;
		static UIColor? DefaultThumbColor;

		public static void UpdateIsToggled(this UISwitch uiSwitch, ISwitch view)
		{
			uiSwitch.SetState(view.IsToggled, true);
		}

		public static void UpdateOnColor(this UISwitch uiSwitch, ISwitch view)
		{
			if (view == null)
				return;

			if (DefaultOnColor == null)
				DefaultOnColor = UISwitch.Appearance.OnTintColor;

			if (view.OnColor == Forms.Color.Default)
				uiSwitch.OnTintColor = DefaultOnColor;
			else
				uiSwitch.OnTintColor = view.OnColor.ToNative();
		}

		public static void UpdateThumbColor(this UISwitch uiSwitch, ISwitch view)
		{
			if (view == null)
				return;

			if (DefaultThumbColor == null)
				DefaultThumbColor = UISwitch.Appearance.ThumbTintColor;

			Forms.Color thumbColor = view.ThumbColor;
			uiSwitch.ThumbTintColor = thumbColor.IsDefault ? DefaultThumbColor : thumbColor.ToNative();
		}
	}
}

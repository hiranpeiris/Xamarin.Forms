using Android.Graphics.Drawables;
using Xamarin.Forms;
using ASwitch = Android.Widget.Switch;

namespace Xamarin.Platform
{
	public static class SwitchExtensions
	{
		static Drawable? DefaultTrackDrawable;
		static bool ChangedThumbColor;

		public static void UpdateIsToggled(this ASwitch aSwitch, ISwitch view)
		{
			aSwitch.Checked = view.IsToggled;
		}

		public static void UpdateOnColor(this ASwitch aSwitch, ISwitch view)
		{
			if(DefaultTrackDrawable == null)
				DefaultTrackDrawable = aSwitch.TrackDrawable;

			if (aSwitch.Checked)
			{
				var onColor = view.OnColor;

				if (onColor.IsDefault)
				{
					aSwitch.TrackDrawable = DefaultTrackDrawable;
				}
				else
				{
					aSwitch.TrackDrawable?.SetColorFilter(onColor.ToNative(), FilterMode.Multiply);
				}
			}
			else
			{
				aSwitch.TrackDrawable?.ClearColorFilter();
			}
		}

		public static void UpdateThumbColor(this ASwitch aSwitch, ISwitch view)
		{
			var thumbColor = view.ThumbColor;

			if (!thumbColor.IsDefault)
			{
				aSwitch.ThumbDrawable?.SetColorFilter(thumbColor, FilterMode.Multiply);
				ChangedThumbColor = true;
			}
			else
			{
				if (ChangedThumbColor)
				{
					aSwitch.ThumbDrawable?.ClearColorFilter();
					ChangedThumbColor = false;
				}
			}

			aSwitch.ThumbDrawable?.SetColorFilter(thumbColor, FilterMode.Multiply);
		}
	}
}

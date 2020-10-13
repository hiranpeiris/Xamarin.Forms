using Android.Widget;
using Xamarin.Forms;
using ASwitch = Android.Widget.Switch;

namespace Xamarin.Platform.Handlers
{
	public partial class SwitchHandler : AbstractViewHandler<ISwitch, ASwitch>
	{
		OnCheckedChangeListener? _onListener;

		protected override ASwitch CreateView()
		{
			_onListener = new OnCheckedChangeListener(this);

			var aSwitch = new ASwitch(Context);

			aSwitch.SetOnCheckedChangeListener(_onListener);

			return aSwitch;
		}

		public override void TearDown()
		{
			base.TearDown();

			_onListener?.Dispose();
			_onListener = null;
		}

		public override SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			SizeRequest sizeConstraint = base.GetDesiredSize(widthConstraint, heightConstraint);

			if (sizeConstraint.Request.Width == 0)
			{
				int width = (int)widthConstraint;

				if (widthConstraint <= 0)
					width = Context != null ? (int)Context.GetThemeAttributeDp(global::Android.Resource.Attribute.SwitchMinWidth) : 0;

				sizeConstraint = new SizeRequest(new Size(width, sizeConstraint.Request.Height), new Size(width, sizeConstraint.Minimum.Height));
			}

			return sizeConstraint;
		}

		internal void OnCheckedChanged(bool isToggled)
		{
			if (VirtualView == null)
				return;

			VirtualView.IsToggled = isToggled;
			VirtualView.Toggled();
		}
	}

	class OnCheckedChangeListener : Java.Lang.Object, CompoundButton.IOnCheckedChangeListener
	{
		readonly SwitchHandler _switchHandler;

		public OnCheckedChangeListener(SwitchHandler switchHandler)
		{
			_switchHandler = switchHandler;
		}

		void CompoundButton.IOnCheckedChangeListener.OnCheckedChanged(CompoundButton? buttonView, bool isToggled)
		{
			_switchHandler.OnCheckedChanged(isToggled);
		}
	}
}
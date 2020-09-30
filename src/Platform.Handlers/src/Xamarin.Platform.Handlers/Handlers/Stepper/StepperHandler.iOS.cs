using System;
using System.Drawing;
using UIKit;

namespace Xamarin.Platform.Handlers
{
	public partial class StepperHandler : AbstractViewHandler<IStepper, UIStepper>
	{
		protected override UIStepper CreateView()
		{
			var uIStepper = new UIStepper(RectangleF.Empty);
			uIStepper.ValueChanged += OnValueChanged;
			return uIStepper;
		}

		void OnValueChanged(object sender, EventArgs e)
		{
			if (TypedNativeView == null || VirtualView == null)
				return;

			VirtualView.Value = TypedNativeView.Value;
			VirtualView.ValueChanged();
		}
	}
}
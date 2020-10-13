using System;
using AppKit;

namespace Xamarin.Platform.Handlers
{
	public partial class StepperHandler : AbstractViewHandler<IStepper, NSStepper>
	{
		protected override NSStepper CreateView()
		{
			var nSStepper = new NSStepper();
			nSStepper.Activated += OnStepperActivated;
			return nSStepper;
		}

		void OnStepperActivated(object sender, EventArgs e)
		{
			if (VirtualView == null || TypedNativeView == null)
				return;

			VirtualView.Value = TypedNativeView.DoubleValue;
		}
	}
}
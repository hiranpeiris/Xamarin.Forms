using UIKit;
using Xamarin.Platform.Handlers;

namespace Xamarin.Platform
{
	public static class StepperExtensions
	{
		public static void UpdateMinimum(this UIStepper nativeStepper, StepperHandler handler, IStepper stepper)
		{
			nativeStepper.MinimumValue = stepper.Minimum;
		}

		public static void UpdateMaximum(this UIStepper nativeStepper, StepperHandler handler, IStepper stepper)
		{
			nativeStepper.MaximumValue = stepper.Maximum;
		}

		public static void UpdateIncrement(this UIStepper nativeStepper, StepperHandler handler, IStepper stepper)
		{
			nativeStepper.StepValue = stepper.Increment;
		}

		public static void UpdateValue(this UIStepper nativeStepper, StepperHandler handler, IStepper stepper)
		{
			if (nativeStepper.Value != stepper.Value)
				nativeStepper.Value = stepper.Value;
		}
	}
}
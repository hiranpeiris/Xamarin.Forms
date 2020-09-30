using Android.Widget;
using Xamarin.Platform.Handlers;

namespace Xamarin.Platform
{
	public static class StepperExtensions
	{
		public static void UpdateMinimum(this LinearLayout linearLayout, StepperHandler handler, IStepper stepper)
		{
			handler.UpdateButtons();
		}

		public static void UpdateMaximum(this LinearLayout linearLayout, StepperHandler handler, IStepper stepper)
		{
			handler.UpdateButtons();
		}

		public static void UpdateIncrement(this LinearLayout linearLayout, StepperHandler handler, IStepper stepper)
		{
			handler.UpdateButtons();
		}

		public static void UpdateValue(this LinearLayout linearLayout, StepperHandler handler, IStepper stepper)
		{
			handler.UpdateButtons();
		}

		public static void UpdateIsEnabled(this LinearLayout linearLayout, StepperHandler handler, IStepper stepper)
		{
			ViewHandler.MapIsEnabled(handler, stepper);
			handler.UpdateButtons();
		}
	}
}
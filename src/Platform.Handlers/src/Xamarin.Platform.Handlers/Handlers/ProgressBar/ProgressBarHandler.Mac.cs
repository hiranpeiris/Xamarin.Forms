using AppKit;

namespace Xamarin.Platform.Handlers
{
	public partial class ProgressBarHandler : AbstractViewHandler<IProgress, NSProgressIndicator>
	{
		protected override NSProgressIndicator CreateView()
		{
			return new NSProgressIndicator
			{
				IsDisplayedWhenStopped = true,
				Indeterminate = false,
				Style = NSProgressIndicatorStyle.Bar,
				MinValue = 0,
				MaxValue = 1
			};
		}
	}
}
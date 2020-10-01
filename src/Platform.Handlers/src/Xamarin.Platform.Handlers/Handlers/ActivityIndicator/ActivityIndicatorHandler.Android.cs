using Android.Widget;

namespace Xamarin.Platform.Handlers
{
	public partial class ActivityIndicatorHandler : AbstractViewHandler<IActivityIndicator, ProgressBar>
	{
		protected override ProgressBar CreateView() => new ProgressBar(Context) { Indeterminate = true };
	}
}
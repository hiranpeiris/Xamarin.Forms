using static Android.Resource;
using AProgressBar = Android.Widget.ProgressBar;

namespace Xamarin.Platform.Handlers
{
	public partial class ProgressBarHandler : AbstractViewHandler<IProgress, AProgressBar>
	{
		protected override AProgressBar CreateView()
		{
			return new AProgressBar(Context, null, Attribute.ProgressBarStyleHorizontal) { Indeterminate = false, Max = 10000 };
		}
	}
}
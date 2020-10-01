using UIKit;

namespace Xamarin.Platform.Handlers
{
	public partial class ProgressBarHandler : AbstractViewHandler<IProgress, UIProgressView>
	{
		protected override UIProgressView CreateView()
		{
			return new UIProgressView(UIProgressViewStyle.Default);
		}
	}
}
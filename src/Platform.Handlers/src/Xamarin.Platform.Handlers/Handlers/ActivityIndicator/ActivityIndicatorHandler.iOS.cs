using CoreGraphics;
using UIKit;

namespace Xamarin.Platform.Handlers
{
	public partial class ActivityIndicatorHandler : AbstractViewHandler<IActivityIndicator, UIActivityIndicatorView>
	{
		protected override UIActivityIndicatorView CreateView() => new UIActivityIndicatorView(CGRect.Empty)
		{
			ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.Gray
		};
	}
}
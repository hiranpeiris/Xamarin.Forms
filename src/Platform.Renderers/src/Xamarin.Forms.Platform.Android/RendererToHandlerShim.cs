using System;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Platform.Android;
using Xamarin.Platform;

namespace Xamarin.Forms
{
	public class RendererToHandlerShim : Xamarin.Platform.IViewHandler
	{
		internal IVisualElementRenderer VisualElementRenderer { get; private set; }

		public static IViewHandler CreateShim(object renderer)
		{
			if (renderer is IViewHandler handler)
				return handler;

			if (renderer is IVisualElementRenderer ivr)
				return new RendererToHandlerShim(ivr);

			return null;
		}

		public RendererToHandlerShim(IVisualElementRenderer visualElementRenderer)
		{
			VisualElementRenderer = visualElementRenderer;
			VisualElementRenderer.ElementChanged += OnElementChanged;

			if (VisualElementRenderer.Element is IView view)
			{
				view.Handler = this;
				this.SetView(view);
			}
			else if (VisualElementRenderer.Element != null)
				throw new Exception($"{VisualElementRenderer.Element} must implement: {nameof(Xamarin.Platform.IView)}");

		}

		void OnElementChanged(object sender, VisualElementChangedEventArgs e)
		{
			if (e.OldElement is IView view)
				view.Handler = null;

			if (e.NewElement is IView newView)
			{
				newView.Handler = this;
				this.SetView(newView);
			}
			else if (e.NewElement != null)
				throw new Exception($"{e.NewElement} must implement: {nameof(Xamarin.Platform.IView)}");

		}

		public object NativeView => VisualElementRenderer.View;

		public bool HasContainer
		{
			get;
			set;
		}

		public SizeRequest GetDesiredSize(double widthConstraint, double heightConstraint)
		{
			var returnValue = VisualElementRenderer.GetDesiredSize((int)widthConstraint, (int)heightConstraint);
			return returnValue;
		}

		public void SetFrame(Rectangle frame)
		{
			var context = VisualElementRenderer.View.Context;
			var width = MeasureSpecFactory.MakeMeasureSpec((int)Platform.Android.ContextExtensions.ToPixels(context, frame.Width), global::Android.Views.MeasureSpecMode.Exactly);
			var height = MeasureSpecFactory.MakeMeasureSpec((int)Platform.Android.ContextExtensions.ToPixels(context, frame.Height), global::Android.Views.MeasureSpecMode.Exactly);

			VisualElementRenderer.View.Measure(width, height);
		}

		public void SetView(IView view)
		{
			VisualElementRenderer.SetElement((VisualElement)view);
		}

		public void TearDown()
		{
			VisualElementRenderer.Dispose();
		}

		public void UpdateValue(string property)
		{
			if (property == "Frame")
			{
				SetFrame(VisualElementRenderer.Element.Bounds);
			}

			//_visualElementRenderer.Element.
			// need to invoke something here
			//_visualElementRenderer.ElementPropertyChanged?.in
		}
	}
}

namespace Xamarin.Platform.Handlers
{
	public partial class SwitchHandler
	{
		public static PropertyMapper<ISwitch, SwitchHandler> SwitchMapper = new PropertyMapper<ISwitch, SwitchHandler>(ViewHandler.ViewMapper)
		{
			[nameof(ISwitch.IsToggled)] = MapIsToggled,
			[nameof(ISwitch.OnColor)] = MapOnColor,
			[nameof(ISwitch.ThumbColor)] = MapThumbColor
		};

		public static void MapIsToggled(SwitchHandler handler, ISwitch view) => handler.TypedNativeView?.UpdateIsToggled(view);

		public static void MapOnColor(SwitchHandler handler, ISwitch view) => handler.TypedNativeView?.UpdateOnColor(view);

		public static void MapThumbColor(SwitchHandler handler, ISwitch view) => handler.TypedNativeView?.UpdateThumbColor(view);

		public SwitchHandler() : base(SwitchMapper)
		{

		}

		public SwitchHandler(PropertyMapper mapper) : base(mapper ?? SwitchMapper)
		{

		}
	}
}
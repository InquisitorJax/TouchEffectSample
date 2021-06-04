using Xamarin.Forms.Xaml;

namespace TouchEffectSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TouchItemWithContentView : TapCommandView
	{
		public TouchItemWithContentView()
		{
			InitializeComponent();
		}
	}
}
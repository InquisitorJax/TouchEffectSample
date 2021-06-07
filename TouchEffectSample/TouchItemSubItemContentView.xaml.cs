using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TouchEffectSample
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TouchItemSubItemContentView : TapCommandView
	{
		public static BindableProperty SubItemTapCommandProperty = BindableProperty.Create(nameof(SubItemTapCommand), typeof(ICommand), typeof(TouchItemSubItemContentView));

		public TouchItemSubItemContentView()
		{
			InitializeComponent();
		}

		public ICommand SubItemTapCommand
		{
			get => (ICommand)GetValue(SubItemTapCommandProperty);
			set => SetValue(SubItemTapCommandProperty, value);
		}

		private void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
		{
			SubItemTapCommand?.Execute(null);
		}
	}
}
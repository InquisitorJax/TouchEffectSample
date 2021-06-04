using System.Windows.Input;
using Xamarin.Forms;

namespace TouchEffectSample
{
	public class TapCommandView : ContentView
	{
		public static BindableProperty TapCommandProperty = BindableProperty.Create(nameof(TapCommand), typeof(ICommand), typeof(TapCommandView));
		public static BindableProperty IgnoreTappedEventProperty = BindableProperty.Create(nameof(IgnoreTappedEvent), typeof(bool), typeof(TapCommandView));

		public TapCommandView()
		{
			var tapGesture = new TapGestureRecognizer();
			tapGesture.Tapped += View_Tapped;
			this.GestureRecognizers.Add(tapGesture);
		}

		public ICommand TapCommand
		{
			get => (ICommand)GetValue(TapCommandProperty);
			set => SetValue(TapCommandProperty, value);
		}

		/// <summary>
		/// work-around for inconsistent behavior of XCT.TouchEffect
		/// iOS: allows parent gesture recognizers to work (so no need to hook up TouchEffect.Command)
		/// Android: disables parent gesture recognizers, so it's necessary to hook into TouchEffect.Command & CommandParameter
		/// </summary>
		public bool IgnoreTappedEvent
		{
			get => (bool)GetValue(IgnoreTappedEventProperty);
			set => SetValue(IgnoreTappedEventProperty, value);
		}

		protected void View_Tapped(object sender, System.EventArgs e)
		{
			// when TouchEffect added to child element, this event fires on iOS, but NOT on Android
			if (!IgnoreTappedEvent)
			{
				TapCommand?.Execute(BindingContext);
			}
		}
	}
}

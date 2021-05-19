using Microsoft.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


namespace Fibonacci_Calculator
{
	class CalculatorManager
	{
		public ArithmeticSchedule Schedule { get; private set; }

		private static CalculatorManager _manager;
		public static CalculatorManager Manager
		{
			get
			{
				if (_manager == null) _manager = new CalculatorManager();
				return _manager;
			}
		}

		public bool ReadyToInput { get; set; }

		private CalculatorManager()
		{
			Schedule = new ArithmeticSchedule();
			ReadyToInput = true;
		}

		public object FindName(string name)
		{
			Page page = (Page)((Frame)Window.Current.Content).Content;
			return page.FindName(name);
		}

		public void ShowTip(string text)
		{
			TeachingTip teachingTip = (TeachingTip)FindName("infoTip");
			teachingTip.Subtitle = text;
			teachingTip.IsOpen = true;
		}
	}
}

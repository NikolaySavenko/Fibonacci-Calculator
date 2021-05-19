using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Fibonacci_Calculator.Controls.Buttons
{
	public sealed partial class NumPadButton : UserControl
	{
		public string Number { get; set; }

		public NumPadButton()
		{
			this.InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Page page = (Page)((Frame)Window.Current.Content).Content;
			TextBlock numberBlock = (TextBlock)page.FindName("numberBlock");

			if (CalculatorManager.Manager.ReadyToInput)
			{
				numberBlock.Text = "";
				CalculatorManager.Manager.ReadyToInput = false;
			}

			if (numberBlock.Text.Length < 14)
			{
				numberBlock.Text += Number;
			}
		}
	}
}

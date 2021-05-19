using FibonacciNumbers.Series;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236


namespace Fibonacci_Calculator.Controls.Buttons
{
	public sealed partial class CalculatorButton : UserControl
	{
		public string Text { get; set; }
		public bool Enabled { get; set; } = true;

		public CalculatorButton()
		{
			this.InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			var numberBlock = (TextBlock)CalculatorManager.Manager.FindName("numberBlock");

			switch (Text)
			{
				case "F(n)":
					var inputNum = int.Parse(numberBlock.Text);
					const int limit = 32;
					if (inputNum < limit)
					{
						var fNum = new FibonacciSeries(inputNum).N;
						numberBlock.Text = fNum.ToString();
					}
					else CalculatorManager.Manager.ShowTip($"N should be less than {limit}");
					break;
				case "=":
					CalculatorManager.Manager.Schedule.Add(numberBlock.Text);
					CalculatorManager.Manager.Schedule.Display();
					numberBlock.Text = String.Empty;
					break;
				case "CE":
					numberBlock.Text = "0";
					break;
				case "C":
					CalculatorManager.Manager.Schedule.Clear();
					CalculatorManager.Manager.Schedule.Display();
					numberBlock.Text = String.Empty;
					break;
			}
			CalculatorManager.Manager.ReadyToInput = true;
		}
	}
}

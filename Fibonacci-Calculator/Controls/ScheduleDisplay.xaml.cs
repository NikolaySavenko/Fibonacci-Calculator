using FibonacciNumbers.FiboInt;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Fibonacci_Calculator.Controls
{
	public sealed partial class ScheduleDisplay : UserControl
	{
		public ScheduleDisplay()
		{
			this.InitializeComponent();
			CalculatorManager.Manager.Schedule.OnDisplayRequired += (List<string> schedule) =>
			{
				binDisplay.Text = String.Empty;
				decDisplay.Text = String.Empty;
				foreach (var element in schedule)
				{
					if (ulong.TryParse(element, out ulong number))
					{
						binDisplay.Text += new FiboInt(number).ToString();
					}
					else
					{
						binDisplay.Text += element;
					}
					decDisplay.Text += element;
				}
			};
		}
	}
}

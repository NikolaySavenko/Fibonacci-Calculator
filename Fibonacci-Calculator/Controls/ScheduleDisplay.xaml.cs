using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using FibonacciNumbers;

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
					else {
						binDisplay.Text += element;
					}
					decDisplay.Text += element;
				}
			};
		}
	}
}

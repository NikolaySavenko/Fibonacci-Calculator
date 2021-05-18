﻿using System;
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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Fibonacci_Calculator.Controls.Buttons
{
	public sealed partial class ArithmeticButton : UserControl
	{
		public string Action { get; set; }
		public string ActionSymbol { get; set; }

		public ArithmeticButton()
		{
			this.InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Page page = (Page)((Frame)Window.Current.Content).Content;
			TextBlock numberBlock = (TextBlock)page.FindName("numberBlock");
			if (numberBlock.Text.Length > 0)
			{

				CalculatorManager.Manager.Schedule.Add(numberBlock.Text);
				CalculatorManager.Manager.Schedule.Add(Action);
				CalculatorManager.Manager.Schedule.Display();
				CalculatorManager.Manager.ReadyToInput = true;
			}
		}
	}
}

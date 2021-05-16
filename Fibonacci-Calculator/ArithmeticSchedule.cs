using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FibonacciNumbers.FiboInt;

namespace Fibonacci_Calculator
{
	class ArithmeticSchedule
	{
		public List<string> Elements { get; private set; }

		public delegate void ScheduleUpdatedDelegate(List<string> inlineSchedule);
		public event ScheduleUpdatedDelegate OnScheduleUpdated = (List<string> inlineSchedule) => { };

		public delegate void ScheduleClearedDelegate();
		public event ScheduleClearedDelegate OnScheduleCleared = () => { };

		public delegate void DisplayRequiredDelegate(List<string> inlineSchedule);
		public event DisplayRequiredDelegate OnDisplayRequired = (List<string> inlineSchedule) => { };

		public ArithmeticSchedule() {
			Elements = new List<string>();
		}

		public void Add(string element) {
			Elements.Add(element);
			if (Elements.Count % 2 == 1 && Elements.Count > 2) {
				try
				{
					InvokeOperator();
				} 
				catch(ArgumentException e)
				{
					Elements.RemoveAt(Elements.Count - 1);
					Elements.RemoveAt(Elements.Count - 1);
				}
			}
			OnScheduleUpdated(Elements);
		}

		public void Clear() {
			Elements = new List<string>();
			OnScheduleCleared();
		}

		public void Display() {
			OnDisplayRequired(Elements);
		}

		private void InvokeOperator()
		{
			var operand0 = new FiboInt(ulong.Parse(Elements[0]));
			var arithmeticOperator = Elements[1];
			var operand1 = new FiboInt(ulong.Parse(Elements[2]));
			FiboInt result = new FiboInt();
			try
			{
				switch (arithmeticOperator)
				{
					case "+":
						result = operand0 + operand1;
						break;
					case "-":
						result = operand0 - operand1;
						break;
					case "/":
						result = operand0 / operand1;
						break;
					case "*":
						result = operand0 * operand1;
						break;
				}
				Elements.RemoveAt(0);
				Elements.RemoveAt(0);
				Elements.RemoveAt(0);
				Elements.Add(((uint)result).ToString());
			} catch(ArgumentException e)
			{
				CalculatorManager.Manager.ShowTip(e.Message);
				throw e;
			}
		}
	}
}

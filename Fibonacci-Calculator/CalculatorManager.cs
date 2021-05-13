using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Calculator
{
	class CalculatorManager
	{
		public ArithmeticSchedule Schedule { get; private set; }

		private static CalculatorManager _manager;
		public static CalculatorManager Manager { 
			get {
				if (_manager == null) _manager = new CalculatorManager();
				return _manager;
			}
		}

		private CalculatorManager()
		{
			Schedule = new ArithmeticSchedule();
		}
	}
}

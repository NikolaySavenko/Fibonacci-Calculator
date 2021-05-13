using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Calculator
{
	class CalculatorManager
	{
		private string[] _schedule;
		public string[] Schedule {
			get => _schedule;
			set {
				_schedule = value;
				OnScheduleUpdated(_schedule);
			} 
		}
		public delegate void ScheduleUpdatedDelegate(string[] schedule);
		public event ScheduleUpdatedDelegate OnScheduleUpdated = (string[] schedule) => { };
	}
}

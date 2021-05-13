using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci_Calculator
{
	class CalculatorManager
	{
		private CalculatorManager _manager;
		public CalculatorManager Manager { 
			get {
				if (_manager == null) _manager = new CalculatorManager();
				return _manager;
			}
		}

		private List<string> _schedule;
		public List<string> Schedule {
			get => _schedule;
			set {
				_schedule = value;
				OnScheduleUpdated(_schedule);
			} 
		}
		public delegate void ScheduleUpdatedDelegate(List<string> schedule);
		public event ScheduleUpdatedDelegate OnScheduleUpdated = (List<string> schedule) => { };

		private CalculatorManager()
		{
			_schedule = new List<string>();
		}
	}
}

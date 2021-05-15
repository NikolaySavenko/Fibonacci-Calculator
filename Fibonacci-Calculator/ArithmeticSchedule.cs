using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
			OnScheduleUpdated(Elements);
		}

		public void Clear() {
			Elements = new List<string>();
			OnScheduleCleared();
		}

		public void Display() {
			OnDisplayRequired(Elements);
		}
	}
}

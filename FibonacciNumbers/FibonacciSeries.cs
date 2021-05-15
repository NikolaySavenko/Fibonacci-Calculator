using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciNumbers.Series
{
	public class FibonacciSeries
	{
		public List<UInt64> Series { get; private set; }

		public int Count { get => Series.Count; }

		public UInt64 N {
			get => Series[Series.Count - 1];
		}

		public FibonacciSeries() : this(0) { }

		public FibonacciSeries(int seed) {
			Series = new List<UInt64>();
			Series.Add(1);
			Series.Add(1);
			
			for (var i = 2; i < seed; i++) {
				Series.Add(Series[i - 1] + Series[i - 2]);

			}
		}

		public UInt64 this[int index] {
			get => Series[index];
		}

		public void UpTo(UInt64 number)
		{
			while (N < number) {
				Series.Add(N + Series[Series.Count - 2]);
			}
		}

		public static UInt64 GetNumber(int n) {
			if (n < 3) return 1;
			return GetNumber(n - 2) + GetNumber(n - 1);
		}
	}
}

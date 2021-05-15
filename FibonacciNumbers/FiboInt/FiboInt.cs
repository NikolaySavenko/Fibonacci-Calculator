using System;
using System.Collections;

namespace FibonacciNumbers.FiboInt
{
	public partial struct FiboInt
	{
		private readonly UInt64 number;
		public readonly FibonacciSeries series;

		public FiboInt(UInt64 source) {
			series = new FibonacciSeries();
			number = 0;
			series.UpTo(source);
			for (var i = series.Count - 1; i >= 0; i--) {
				var fNum = series[i];
				var bitValue = source / fNum;
				number += (ulong)(1 << i) * bitValue;
				source %= fNum;
			}
		}

		public override string ToString() => Convert.ToString((long)number, 2);
	}
}

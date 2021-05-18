using System;
using System.Collections;
using FibonacciNumbers.Series;

namespace FibonacciNumbers.FiboInt
{
	public partial struct FiboInt
	{
		public static FiboInt SimpleBinaryMultiply(FiboInt a, FiboInt b) {
			if (a.number == 2) return b;
			if (b.number == 2) return a;

			var series = new FibonacciSeries(a.series.Seed + b.series.Seed - 2);
			var first = new FiboInt(series.N);
			var nextA = a.series[a.series.Seed - 3];
			var nextB = a.series[b.series.Seed - 3];
			var other = SimpleBinaryMultiply(new FiboInt(nextA), new FiboInt(nextB));
			return first + other;
		}

		public static FiboInt operator *(FiboInt a, FiboInt b)
		{
			// check for zero or one multiply
			if (a.number == 2) return b;
			if (a.number == 0) return new FiboInt(0);
			if (b.number == 2) return a;
			if (b.number == 2) return new FiboInt(0);

			// a > 0 and b > 0
			var num = new FiboInt(0);
			for (var i = a.series.Count - 1; i >= 0; i--)
			{
				if ((a.number >> i & 1) > 0)
				{
					for (var j = b.series.Count - 1; j >= 0; j--)
					{
						if ((b.number >> j & 1) > 0)
						{
							var operand0 = new FiboInt(a.series[i]);
							var operand1 = new FiboInt(b.series[j]);
							num += SimpleBinaryMultiply(operand0, operand1);
						}
					}
				}
			}
			return num;
		}
	}
}

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

			var series = new FibonacciSeries(a.series.Seed + b.series.Seed);
			var first = new FiboInt(series.N);
			var nextA = a.series[a.series.Seed - 2];
			var nextB = a.series[b.series.Seed - 2];
			var other = SimpleBinaryMultiply(new FiboInt(nextA), new FiboInt(nextB));
			return first + other;
		}
	}
}

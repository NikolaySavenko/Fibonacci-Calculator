using System;
using System.Collections;

namespace FibonacciNumbers.FiboInt
{
	public partial struct FiboInt
	{
		public static explicit operator uint(FiboInt fInt) {
			uint result = 0;
			var series = fInt.series;
			for (var i = series.Count - 1; i > 0; i--)
			{
				result += Convert.ToUInt32(series[i] * (fInt.number >> i & 1));
			}
			return result;
		}
	}
}

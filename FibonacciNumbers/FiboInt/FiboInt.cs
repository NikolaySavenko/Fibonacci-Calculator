using System;
using System.Collections;
using FibonacciNumbers.Series;

namespace FibonacciNumbers.FiboInt
{
	public partial struct FiboInt
	{
		private UInt64 number;
		public FibonacciSeries series;

		public FiboInt(UInt64 source) {
			series = new FibonacciSeries(2);
			number = 0;
			series.UpTo(source);
			for (var i = series.Count - 1; i >= 0; i--) {
				var fNum = series[i];
				var bitValue = source / fNum;
				number += (ulong)(1 << i) * bitValue;
				source %= fNum;
			}
		}

		private void Normalize() {
			for (var i = series.Count - 1; i > 0; i--)
			{
				if ((GetBit(i) & GetBit(i - 1)) > 0) {
					number -= Convert.ToUInt64(3 << (i - 1));
					number += Convert.ToUInt64(1 << (i + 1));
				}
			}
		}

		private void Expand() {
			number = (number >> 2) + (number >> 1);
		}

		public static ulong Expand(ulong number)
		{
			return (number >> 2) + (number >> 1);
		}

		private ulong GetBit(int index)
		{
			return (number >> index) & 0x1;
		}

		public static ulong Normalize(ulong binary)// DANGER !!! ITS A BINARY
		{
			var series = new FibonacciSeries(Convert.ToInt32(binary));
			for (var i = series.Count - 1; i > 0; i--)
			{
				if ((GetBit(binary, i) & GetBit(binary, i - 1)) > 0)
				{
					binary -= Convert.ToUInt64(3 << (i - 1));
					binary += Convert.ToUInt64(1 << i + 1);
				}
			}
			return binary;
		}

		public static ulong GetBit(ulong number, int index) {
			return (number >> index) & 0x1;
		}

		public override string ToString() => Convert.ToString((long)number, 2);
	}
}

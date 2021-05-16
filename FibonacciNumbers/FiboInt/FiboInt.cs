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
			var dirty = true;
			while (dirty)
			{
				dirty = false;
				for (var i = series.Count - 1; i > 0; i--)
				{
					if ((GetBit(i) & GetBit(i - 1)) > 0)
					{
						dirty = true;
						number -= Convert.ToUInt64(3 << (i - 1));
						number += Convert.ToUInt64(1 << (i + 1));
					}
					if (number % 2 > 0)
					{
						number += 1;
						dirty = true;
					}
				}
			}
				
		}

		private void Expand() {
			number = (number >> 2) + (number >> 1);
		}

		private void Expand(int i)
		{
			number -= Convert.ToUInt64(1 << i);
			number += Convert.ToUInt64(1 << (i - 1));
			if ((number & Convert.ToUInt64(1 << (i - 2))) > 0)
			{
				Expand(i - 2);
			}
			number += Convert.ToUInt64(1 << (i - 2));
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
			var dirty = true;
			while (dirty)
			{
				dirty = false;
				for (var i = series.Count - 1; i > 0; i--)
				{
					if ((GetBit(binary, i) & GetBit(binary, i - 1)) > 0)
					{
						dirty = true;
						binary -= Convert.ToUInt64(3 << (i - 1));
						binary += Convert.ToUInt64(1 << i + 1);
						
					}
				}
				if (binary % 2 > 0)
				{
					binary += 1;
					dirty = true;
				}
			}
			
			return binary;
		}

		public static ulong GetBit(ulong number, int index) {
			return (number >> index) & 0x1;
		}
	}
}

using System;
using System.Collections;

namespace FibonacciNumbers.FiboInt
{
	public partial struct FiboInt
	{
		public static FiboInt operator+(FiboInt a, FiboInt b) {
			if (a.number < b.number) {
				return b + a;
			}
			var num = a;
			for (var i = num.series.Count; i > 0; i --) {
				if ((num.number >> i & b.number >> i & 1) > 0)
				{
					num.Expand();
					num.number += Convert.ToUInt64(1 << i);
					num.Normalize();
				} else if ((b.number >> i & 1) > 0)
				{
					num.number += Convert.ToUInt64(1 << i);
					num.Normalize();
					num.series.UpTo((ulong)num);
				}
			}
			return num;
		}

		public static FiboInt operator -(FiboInt a, FiboInt b)
		{
			return new FiboInt();
		}

		public static FiboInt operator *(FiboInt a, FiboInt b)
		{
			return new FiboInt();
		}

		public static FiboInt operator /(FiboInt a, FiboInt b)
		{
			return new FiboInt();
		}
	}
}

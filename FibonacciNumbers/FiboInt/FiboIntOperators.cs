using System;
using System.Collections;

namespace FibonacciNumbers.FiboInt
{
	public partial struct FiboInt
	{
		public static FiboInt operator +(FiboInt a, FiboInt b)
		{
			if (a.number < b.number)
			{
				return b + a;
			}
			var num = a;
			for (var i = num.series.Count; i > 0; i--)
			{
				if ((num.number >> i & b.number >> i & 1) > 0)
				{
					num.Expand(i);
					num.number += Convert.ToUInt64(1 << i);
					num.Normalize();
					if (i >= num.series.Count - 2)
					{
						num.series.Up();
					}
				}
				else if ((b.number >> i & 1) > 0)
				{
					num.number += Convert.ToUInt64(1 << i);
					num.Normalize();
					if (i >= num.series.Count - 2)
					{
						num.series.Up();
					}
				}
			}
			return num;
		}

		public static FiboInt operator -(FiboInt a, FiboInt b)
		{
			if (a.number < b.number)
			{
				throw new ArgumentException("a should be bigger than b");
			}
			var num = a;
			for (var i = num.series.Count; i > 0; i--)
			{
				if ((b.number >> i & 1) > 0)
				{
					if ((num.number >> i & 1) == 0)
					{
						num.ExpandBefore(i);
					}
					num.number -= Convert.ToUInt64(1 << i);
					num.Normalize();
				}
			}
			return num;
		}

		public static FiboInt operator /(FiboInt a, FiboInt b)
		{
			return new FiboInt((uint)a / (uint)b);
		}
	}
}

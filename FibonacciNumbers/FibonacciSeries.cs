﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciNumbers
{
	public class FibonacciSeries
	{
		public List<UInt64> Series { get; private set; }

		public UInt64 N {
			get => Series[Series.Count - 1];
		}

		public FibonacciSeries(int seed) {
			Series = new List<UInt64>();
			if (seed > 0)
			{
				Series.Add(1);
				if (seed > 1)
				{
					Series.Add(1);
				}
				
				for (var i = 2; i < seed; i++)
				{
					Series.Add(Series[i - 1] + Series[i - 2]);
				}
			}
		}

		public static UInt64 GetNumber(int n) {
			if (n < 3) return 1;
			return GetNumber(n - 2) + GetNumber(n - 1);
		}
	}
}
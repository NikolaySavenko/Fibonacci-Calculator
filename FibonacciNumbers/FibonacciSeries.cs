using System;

namespace FibonacciNumbers.Series
{
	public struct FibonacciSeries
	{
		private UInt64[] seriesArray;

		public int Count { get => seriesArray.Length; }

		public int Seed { get => Count - 1; }

		public UInt64 N
		{
			get => seriesArray[seriesArray.Length - 1];
		}

		public FibonacciSeries(int seed)
		{
			seriesArray = new UInt64[2];
			seriesArray[0] = 1;
			seriesArray[1] = 1;

			for (var i = 2; i < seed; i++)
			{
				Add(seriesArray[i - 1] + seriesArray[i - 2]);
			}
		}

		public UInt64 this[int index]
		{
			get => index >= 0 ? seriesArray[index] : 0;
		}

		public void Add(UInt64 value)
		{
			Array.Resize<UInt64>(ref seriesArray, Count + 1);
			seriesArray[Count - 1] = value;
		}

		public void UpTo(UInt64 number)
		{
			while (N < number)
			{
				Add(N + seriesArray[Count - 2]);
			}
		}

		public void Up()
		{
			Add(N + seriesArray[Count - 2]);
		}

		public static UInt64 GetNumber(int n)
		{
			if (n < 3) return 1;
			return GetNumber(n - 2) + GetNumber(n - 1);
		}
	}
}

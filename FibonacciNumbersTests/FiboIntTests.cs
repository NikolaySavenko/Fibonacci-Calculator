using Xunit;
using FibonacciNumbers.FiboInt;
using System;

namespace FibonacciNumbersTests
{
	public class FiboIntTests
	{
		[Theory]
		[InlineData(1, 2)]
		[InlineData(35, 876)]
		[InlineData(1, 654)]
		[InlineData(154, 6423)]
		[InlineData(3965, 6423)]
		[InlineData(323965, 6423)]
		public void SummarizetTest(ulong first, ulong second)
		{
			var firstFiboInt = new FiboInt(first);
			var secondFiboInt = new FiboInt(second);
			Assert.Equal(first + second, (uint)(firstFiboInt + secondFiboInt));
		}

		[Theory]
		[InlineData(11, 2)]
		[InlineData(1134, 123)]
		[InlineData(11340, 1230)]
		[InlineData(121340, 12320)]
		[InlineData(1240, 120)]
		public void SubtractionTest(ulong first, ulong second)
		{
			var firstFiboInt = new FiboInt(first);
			var secondFiboInt = new FiboInt(second);
			Assert.Equal(first - second, (uint)(firstFiboInt - secondFiboInt));
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(213, 21234)]
		[InlineData(29813, 99234)]
		[InlineData(813, 934)]
		public void SubstractionExceptionTests(ulong first, ulong second)
		{
			var firstFiboInt = new FiboInt(first);
			var secondFiboInt = new FiboInt(second);
			Assert.Throws<ArgumentException>(() => firstFiboInt - secondFiboInt);
		}

		[Theory]
		[InlineData(11, 2)]
		[InlineData(34, 13)]
		[InlineData(140, 7)]
		[InlineData(124, 11)]
		[InlineData(14, 26)]
		public void MultiplyTest(ulong first, ulong second)
		{
			var firstFiboInt = new FiboInt(first);
			var secondFiboInt = new FiboInt(second);
			Assert.Equal(first * second, (uint)(firstFiboInt * secondFiboInt));
		}

		[Theory]
		[InlineData(111, 2)]
		[InlineData(4, 13)]
		[InlineData(1410, 8)]
		[InlineData(124, 101)]
		[InlineData(1444, 206)]
		public void DivideTest(ulong first, ulong second)
		{
			var firstFiboInt = new FiboInt(first);
			var secondFiboInt = new FiboInt(second);
			Assert.Equal(first / second, (uint)(firstFiboInt / secondFiboInt));
		}

		[Theory]
		[InlineData(111, 0)]
		[InlineData(4, 0)]
		[InlineData(1410, 0)]
		[InlineData(124, 0)]
		[InlineData(1444, 0)]
		public void DivideExceptionTest(ulong first, ulong second)
		{
			var firstFiboInt = new FiboInt(first);
			var secondFiboInt = new FiboInt(second);
			Assert.Throws<DivideByZeroException>(() => firstFiboInt / secondFiboInt);
		}
	}
}
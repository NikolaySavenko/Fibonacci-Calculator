﻿using System;
using System.Collections;

namespace FibonacciNumbers.FiboInt
{
	public partial struct FiboInt
	{
		private string GetDebuggerDisplay()
		{
			return $"{ToString()} \n {(uint)this}";
		}
	}
}

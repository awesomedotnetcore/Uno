using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace System
{
	public static class DEBUG
	{
		public static void Trace(string message = null, [CallerMemberName] string method = null, [CallerLineNumber] int line = 0)
			=> Console.WriteLine($"{method}@{line}: {message}");
	}
}

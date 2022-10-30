using System;
using Marinkas.Utils;

namespace StringIteratorTest
{
	// Test class
	class Program
	{
		static void Main(string[] args)
		{
			StringIterator testIterator = new StringIterator("this is a test string");

			Console.WriteLine(testIterator.Current()); // t
			Console.WriteLine(testIterator.Peek()); // h
			Console.WriteLine(testIterator.Next()); // h
			Console.WriteLine(testIterator.ReadUntil(' ')); // his
			Console.WriteLine(testIterator.Current()); // ' '
			Console.WriteLine(testIterator.Next()); // i

			testIterator.Dispose();
			Console.ReadKey();
		}
	}
}

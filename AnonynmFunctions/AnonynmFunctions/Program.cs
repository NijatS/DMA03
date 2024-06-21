using System.ComponentModel;
using System.Linq.Expressions;
using System;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using System.Threading.Channels;

namespace AnonynmFunctions
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//1)Basic Anonymous Function

			//Task: Create a simple anonymous function using a lambda expression that takes an integer and returns its square.


			//Func<int, int> GetSquare = (x) => x * x;

			//int.TryParse(Console.ReadLine(), out int number);
			//Console.WriteLine(GetSquare(number));

			//2)Anonymous Function with Multiple Parameters

			//Task: Write an anonymous function that takes two integers and returns their sum.
			//Console.ForegroundColor = ConsoleColor.Yellow;
			//Console.WriteLine("Arzu yazirr");

			//Console.ResetColor();

			//Func<int, int, int> Nicat = delegate (int x, int y)
			//{
			//	return x + y;
			//};

			//Console.WriteLine(Nicat(5, 10));



			//3)Action Anonymous Function

			//Task: Create an anonymous function using Action that takes a string and prints it to the console.

			//Action<string> PrintName = (string text) => Console.WriteLine(text);

			//PrintName(Console.ReadLine());


			//4)Filtering with Anonymous Functions

			//Task: Use an anonymous function with List<int>.Where to filter out even numbers from a list.

			//Func<int, bool> isEven = (x) => x % 2 == 0;


			//List<int> numbers = new List<int> { 2, 5, 7, 8, 21, 62, 6 };

			//numbers.Where(isEven).ToList().ForEach(x =>
			//	Console.WriteLine(x)
		 //   );





			//5)Complex Filtering and Transformation

			//Task: Use an anonymous function to filter a list of integers to only those that are prime, then multiply each prime number by 2.

			 List<int> numbers = new List<int> { 2, 5, 7, 8, 21, 62, 6 };


			Func<int, bool> isPrime = (x) =>
			{
				if (x == 1) return false;
				if(x == 2) return true;

				for (int i = 2; i < x; i++)
					if (x % i == 0)
						return false;
				return true;
			};

			Func<int, int> MultiTwo = (x) => x * 2;

			numbers.Where(isPrime).Select(MultiTwo).ToList()
				.ForEach(x => Console.WriteLine(x));


			//6)Chained Anonymous Functions

			//Task: Create a chain of anonymous functions that first filters a list of integers to even numbers, then doubles each number, and finally sums the results.
		}
	}
}

using System.Reflection.Metadata;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Delegates
{
	public delegate double Operations(double num1, double num2);
	internal class Program
	{
		static void Main(string[] args)
		{
			Operations ops = null;

			//	Creating a calculator delegate task in C# involves defining a delegate that can point to methods performing arithmetic operations, and then using this delegate to execute those operations. Here's a step-by-step guide to accomplish this:

			//Define a delegate: A delegate is a type that represents references to methods with a particular parameter list and return type.

			//Create methods for arithmetic operations: These methods should match the delegate's signature.
			//Use the delegate to invoke methods: Assign methods to the delegate and invoke them.
			bool isContinue = true;
			while (isContinue)
			{
				double res1 = new();
				double res2 = new();



				Console.WriteLine("1-(+) toplama");
				Console.WriteLine("2-(-) cixma");
				Console.WriteLine("3-(*) vurma");
				Console.WriteLine("4-(/) bolme");



				Console.WriteLine("Emelliyat nomresini daxil edin");
				int.TryParse(Console.ReadLine(), out int result);
				if(result !=0 && result <= 4)
				  (res1, res2) = InsertData();

				switch (result)
				{
					case 1:
						ops = Sum;
						break;

					case 2:
						ops = Subs;
						break;
					case 3:
						ops = Multiplication;
						break;
					case 4:
						ops = Divide;
						break;
					case 0:
						isContinue = false;
						break;

					default:
						Console.WriteLine("duzgun nomre daxil edin");
						break;

				}
				if (ops != null)
				{
					Console.WriteLine(ops.Invoke(res1, res2));

				}
			}
		}

		public static double Sum(double num1, double num2)
		{
			return num1 + num2;

		}

		public static double Multiplication(double num1, double num2)

		{ return num1 * num2; }

		public static double Divide(double num1, double num2)
		{
			if (num2 == 0)
			{
				throw new DivideByZeroException();

			}
			return num1 / num2;
		}
		public static double Subs(double num1, double num2)
		{
			return (num1 - num2);
		}

		private static (double, double) InsertData()
		{
			Console.WriteLine("1ci ededi daxil edin");
			double.TryParse(Console.ReadLine(), out double res1);
			Console.WriteLine("2ci ededi daxil edin");
			double.TryParse(Console.ReadLine(), out double res2);
			return (res1, res2);

		}

	}
}

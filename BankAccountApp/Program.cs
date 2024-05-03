using BankAccountApp.Models;

namespace BankAccountApp
{
	internal class Program
	{
		static double ReadNumber()
		{

			while (true)
			{
				try
				{

					double value = double.Parse(Console.ReadLine());

					return value;
				}
				catch (Exception ex)
				{

					Console.BackgroundColor = ConsoleColor.Red;
					Console.ForegroundColor = ConsoleColor.White;
					Console.WriteLine(ex.Message);
					Console.Write("Verilen sechimlerden birini sechin ");
					Console.ResetColor();
				}
			}


		}
		static void Main(string[] args)
		{
			bool finishOperations = false;
			Account account1 = null;

			while (!finishOperations)
			{
				Console.WriteLine("1.Hesab yaratmaq.\n2.Balansi gostermek.\n3.Hesaba mebleg medaxil etmek.\n4.Hesabdan mebleg mexaric etmek.\n5.Emeliyyatlari gostermek uchun.\n0.Hesabdan chixish etmek.");

				Console.Write("\nZehmet olmasa sechimlerden birini sechin: ");
				
				int.TryParse(ReadNumber().ToString(), out int userChoice);


				switch (userChoice)
				{
					case 1:

						if (account1 != null) break;

                        Console.Write("Ad: ");
						string firstName = Console.ReadLine();

						Console.Write("Soyad: ");
						string lastName = Console.ReadLine();

						Console.Write("Ilkin balans: ");
						double initialBalance = ReadNumber();

						account1 = new Account($"{firstName} {lastName}", initialBalance);

						break;
					case 2:
						if (account1 is null)
						{
							Console.WriteLine("Cari hesab yoxdur, ilk once hesab yaradin");
							break;
						}

						Console.WriteLine($"Sizin cari balansiniz {account1.GetBalance()}");

						break;
					case 3:
						if (account1 is null)
						{
							Console.WriteLine("Cari hesab yoxdur, ilk once hesab yaradin");
							break;
						}

                        Console.Write("Medaxil meblegini daxil edin: ");
                        double depositAmount = ReadNumber();
						account1.MakeDeposite(depositAmount);
						break;
					case 4:
						if (account1 is null)
						{
							Console.WriteLine("Cari hesab yoxdur, ilk once hesab yaradin");
							break;
						}
						Console.Write("Mexaric meblegini daxil edin: ");
						double withdrawalAmount = ReadNumber();
						account1.MakeDeposite(withdrawalAmount);

						break;
					case 5:
						if (account1 is null)
						{
							Console.WriteLine("Cari hesab yoxdur, ilk once hesab yaradin");
							break;
						}

						account1.GetTransactions();
						break;

					case 0:
                        Console.WriteLine("Hesabdan chixish etmek istediyinize eminsiniz mi? (y/n)");

						//char userInput = char.Console.ReadLine()

						char.TryParse(Console.ReadLine(), out char userInput);

						if(userInput == 'y')
						{
                            Console.WriteLine("Hesabdan chixilir...");
							Thread.Sleep(2000);
							finishOperations = true;
                        }
                        break;
					default:
						Console.BackgroundColor = ConsoleColor.Red;
						Console.ForegroundColor = ConsoleColor.White;
						Console.WriteLine("Zehmet olmasa, duzgun sechim edin.");
						Console.ResetColor();
						break;
				}
			}
		}
	}
}

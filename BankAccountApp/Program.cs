using BankAccountApp.Models;

namespace BankAccountApp
{
	internal class Program
	{
		
		static void Main(string[] args)
		{
            Console.Write("Please enter your name:\t");
            string username = Console.ReadLine();
            Console.Write("Please enter your current balance:\t");
            double userbalance = double.Parse(Console.ReadLine());
			Account account = new Account(username,userbalance);
			account.MakeDeposite(200);
            Console.WriteLine(account.GetBalance());
            account.MakeWithdraw(120);
            Console.WriteLine(account.GetBalance());
			account.GetTransactions();
        }
	}
}

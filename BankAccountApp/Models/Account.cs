using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.Models
{
	internal class Account
	{
		public Guid Id { get;}
		public string OwnerName { get;}
		private double _balance;
		private List <Transaction> transactions = new List<Transaction> ();

		public Account(string ownerName, double initialBalance)
        {
			this.Id = Guid.NewGuid();
			this.OwnerName = ownerName;
			this._balance = initialBalance;

            Console.WriteLine("Hesab yaradilir...");
			Thread.Sleep (2000);
            Console.WriteLine($"Hesab ugurla yaradildi");

        }

		public double GetBalance() {
			Transaction transaction = new Transaction(0, $"Sizin balansiniza baxildi.");
			transactions.Add( transaction );
			return _balance;
		}

		public void MakeDeposite(double amount)
		{
			_balance += amount;
			Transaction transaction = new Transaction(amount, $"{amount} is extracted. Your current balance: {_balance}");
			transactions.Add( transaction );
		}

		public void MakeWithdraw(double amount)
		{
			Transaction transaction = null;
			if (amount <= _balance)
			{
				_balance -= amount;
				transaction = new Transaction(amount, $"{amount} is withdrawed. Your current balance: {_balance}");
				transactions.Add( transaction);
			}
			else
			{
				transaction = new Transaction(amount, $"Ugursuz emeliyyat. Balansinizdan {amount} chixarila bilmedi. Cari balans: {_balance}");
				transactions.Add(transaction);
				throw new Exception("Your balance is under this amount.");
			}
			
		}

		public void GetTransactions()
		{
            foreach (var transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp.Models
{
	internal class Transaction
	{
		public Guid Id { get; set; }
		public double Amount { get; set; }

		public DateTime Date { get; set; }

		public string Description { get; set; }


        public Transaction( double amount, string description)
        {
			this.Id = Guid.NewGuid();
			this.Amount = amount;
			this.Date=DateTime.Now;	
			this.Description = description;
        }
		public override string ToString()
		{
			if(this.Amount == 0)
			{
				return $"Date: {Date} -  Description: {Description}";
			}
			else
			{
				return $"Amount: {Amount} - Date: {Date} -  Description: {Description}";
			}
		}
	}
}

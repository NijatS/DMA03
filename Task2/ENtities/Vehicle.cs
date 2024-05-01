using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.ENtities
{
	internal class Vehicle
	{
		protected string Status;

		public string GetStatus()
		{
			return Status;
		}

		public void SetStatus(string status)
		{
			this.Status = status;
		}
	}
}

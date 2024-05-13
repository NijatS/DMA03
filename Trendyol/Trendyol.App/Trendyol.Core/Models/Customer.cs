using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models.BaseModel;

namespace Trendyol.Core.Models
{
	public class Customer : BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }


		public override string ToString()
		{
			return "Id: " + Id + "  Name: " + Name + "  Surname: " + Surname + "  Address: " + Address;
		}
	}
}

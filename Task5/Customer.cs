using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
	public class Customer
	{
		private string _name;
		private string _surname;
		private string _pin;
		private string _email;


		public string Name { get { return _name; } set { if(Checkstring(value))_name = value; } }
		public string Surname { get { return _surname; } set { if (Checkstring(value)) _surname = value; } }
		public string Pin { get { return _pin; } set { if (Checkstring(value)) _pin = value; } }
		public string Email { get { return _email; } set { if (Checkstring(value)) _email = value; } }

		public bool Checkstring (string value)
		{
			if(string.IsNullOrWhiteSpace(value)) return false;
			return true;

		}
	}
}

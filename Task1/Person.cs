using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
	//Task 7. Bir Person sinifi yaradın. Bu sinifin içində, ad və yaş kimi məlumatları saxlayan private dəyişənlər olsun. Daha sonra, bu dəyişənlərə müraciət etmək üçün public metodlar əlavə edin.
	public class Person
	{
		private int _id;
		private string _name;


        public int GetId()
		{
			return _id;
		}
		public void SetId(int id)
		{ if (id <= 0)
			{
				throw new ArgumentException("Duzgun id daxil edin");
			}
			_id = id;
			
		}
		 public string GetName()
		{
			return _name;
		}
		public void SetName(string name)
		{
			if(string.IsNullOrWhiteSpace(name)){
				throw new ArgumentNullException("name");
			}
			_name = name;

		}

    }
}

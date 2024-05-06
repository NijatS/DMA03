using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
	public interface IRestaurantService
	{
		public void Add();
		public void Update();
		public void Delete();
		public void GetById();
		public void GetAll();

	}
}

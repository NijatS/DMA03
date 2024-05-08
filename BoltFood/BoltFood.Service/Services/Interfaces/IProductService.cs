using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoltFood.Service.Services.Interfaces
{
	public interface IProductService
	{
		public void Add();
		public void Update();
		public void GetByID();
		public void GetAll();
		public void Delete();
	}
}

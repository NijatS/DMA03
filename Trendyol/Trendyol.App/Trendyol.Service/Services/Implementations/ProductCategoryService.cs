using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models;
using Trendyol.Data.Repositories.Implementations;
using Trendyol.Data.Repositories.Interfaces;
using Trendyol.Service.Services.Interfaces;

namespace Trendyol.Service.Services.Implementations
{
	public class ProductCategoryService : IProductCategoryService
	{

		private readonly IProductCategoryRepository _repository;
        public ProductCategoryService()
        {
			_repository = new ProductCategoryRepository();
        }
        public void Add()
		{


            Console.WriteLine("Enter Product Category name:");

			string name=Console.ReadLine();

			_repository.Add(new ProductCategory() { Name = name, CreatedDate = DateTime.Now });

        }

		public void Delete()
		{
            Console.WriteLine("Select ID:");
			int.TryParse(Console.ReadLine(),out int id);
			_repository.Delete(id);
		}

		public void Get()
		{
            Console.WriteLine("Select ID:");
			int.TryParse(Console.ReadLine(), out int id);

		   ProductCategory category=_repository.GetById(id);

			if(category != null) 
			{
                Console.WriteLine("Category ID:"+ category.Id+ "Category Name:"+category.Name);
            }

		}

		public void GetAll()
		{
			ICollection<ProductCategory> Category = _repository.GetAll();
			foreach(ProductCategory category in Category)
			{
                
				Console.WriteLine("Category ID:" + category.Id + "Category Name:" + category.Name);
			}
		}

		public void Update()
		{
            Console.WriteLine("Select Id:");
			int.TryParse(Console.ReadLine(), out int id);
			ProductCategory uptadetproductcategory=_repository.GetById(id);
			if(uptadetproductcategory != null)
			{
				Console.WriteLine("Enter Product Category name:");

				string name = Console.ReadLine();

				uptadetproductcategory.Name = name;

				uptadetproductcategory.UpdatedDate = DateTime.Now;
				_repository.Update(uptadetproductcategory);

			}

		}
	}
}

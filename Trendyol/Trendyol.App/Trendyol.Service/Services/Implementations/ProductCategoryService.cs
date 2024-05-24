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
        public async Task AddAsync()
		{
            Console.WriteLine("Enter Product Category name:");

			string name=Console.ReadLine();

			await _repository.AddAsync(new ProductCategory() { Name = name, CreatedDate = DateTime.Now });
        }

		public async Task DeleteAsync()
		{
            Console.WriteLine("Select ID:");
			int.TryParse(Console.ReadLine(),out int id);
			await _repository.DeleteAsync(id);
		}

		public async Task GetAsync()
		{
            Console.WriteLine("Select ID:");
			int.TryParse(Console.ReadLine(), out int id);

		   ProductCategory category=await _repository.GetByIdAsync(id);

			if(category != null) 
			{
                Console.WriteLine("Category ID:"+ category.Id+ " Category Name:"+category.Name);
            }

		}

		public async Task GetAllAsync()
		{
			ICollection<ProductCategory> Category = await _repository.GetAllAsync();
			foreach(ProductCategory category in Category)
			{
				Console.WriteLine("Category ID:" + category.Id + " Category Name:" + category.Name);
			}
		}

		public async Task UpdateAsync()
		{
            Console.WriteLine("Select Id:");
			int.TryParse(Console.ReadLine(), out int id);
			ProductCategory uptadetproductcategory=await _repository.GetByIdAsync(id);
			if(uptadetproductcategory != null)
			{
				Console.WriteLine("Enter Product Category name:");

				string name = Console.ReadLine();

				uptadetproductcategory.Name = name;

				uptadetproductcategory.UpdatedDate = DateTime.Now;
				await _repository.UpdateAsync(uptadetproductcategory);

			}

		}
	}
}

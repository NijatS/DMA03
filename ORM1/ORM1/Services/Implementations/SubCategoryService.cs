using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Entities;
using Trendyol.App.Exceptions;
using Trendyol.App.Repositories.Implementations;
using Trendyol.App.Repositories.Interfaces;
using Trendyol.App.Services.Interfaces;

namespace Trendyol.App.Services.Implementations
{
    public class SubCategoryService : IService<SubCategory>
    {
        private readonly ISubCategoryRepository _repository;
        public SubCategoryService()
        {
            _repository = new SubCategoryRepository();
        }
        public async Task AddAsync()
        {
            SubCategory category = new SubCategory();
            Console.WriteLine("Enter SubCategory Name:");
            category.Name = Console.ReadLine();
            Console.WriteLine("Category ID:");
            category.CategoryId = Convert.ToInt32(Console.ReadLine());
            await _repository.AddAsync(category);
        }

        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SubCategory> GetAsync()
        {
            Console.WriteLine("Enter Id:");
            int id = Convert.ToInt32(Console.ReadLine());
            SubCategory category = await _repository.GetAsync(x=>x.Id==id && !x.isDeleted);
            if (category != null) throw new EntityNotFoundException();
            Console.WriteLine($"ID: {category.Id} Name: {category.Name} CategoryID: {category.CategoryId}");
            return category;
        }

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

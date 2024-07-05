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
    public class CategoryService : IService<Category>
    {
        private readonly ICategoryRepository _repository;
        public CategoryService()
        {
            _repository = new CategoryRepository();
        }
        public async Task AddAsync()
        {
            Console.WriteLine("Category Name:");
            Category category = new Category();
            category.Name = Console.ReadLine();
            await _repository.AddAsync(category);
            await _repository.SaveAsync();
        }

        public async Task DeleteAsync()
        {
            Category category = await GetAsync();
            category.isDeleted = true;
            await _repository.SaveAsync();
        }

        public async Task GetAllAsync()
        {
           ICollection<Category> categories = await _repository.GetAllAsync(x=>!x.isDeleted);
            foreach (Category category in categories)
            {
                Console.WriteLine($"ID:{category.Id} - Name: {category.Name}");
            }
        }

        public async Task<Category> GetAsync()
        {
            Console.WriteLine("Enter ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Category category = await _repository.GetAsync(x => x.Id == id && !x.isDeleted);
            if (category == null) throw new EntityNotFoundException();
            Console.WriteLine($"ID:{category.Id} - Name: {category.Name}");
            return category;
        }

        public async Task UpdateAsync()
        {
            Category category = await GetAsync();
            Console.WriteLine("Updated name:");
            category.Name = Console.ReadLine();
            _repository.Update(category);    
            await _repository.SaveAsync();
        }
    }
}

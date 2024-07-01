using ORM1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Repositories.Implementations;
using Trendyol.App.Repositories.Interfaces;
using Trendyol.App.Services.Interfaces;

namespace Trendyol.App.Services.Implementations
{
    public class CustomerService : IService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService()
        {
            _repository = new CustomerRepository();
        }
        public async Task AddAsync()
        {
            Console.Write("Enter Name:");
            string name = Console.ReadLine();

            Console.Write("Surname:");
            string surname = Console.ReadLine();

            Console.Write("Address:");
            string address = Console.ReadLine();

            Console.Write("Phone:");
            string phone = Console.ReadLine();

            await _repository.AddAsync(new Customer()
            {
                Name = name,
                Surname = surname,
                Address = address,
                CreatedDate = DateTime.Now,
                Phone = phone,
            });

            await _repository.SaveAsync();
        }

        public Task DeleteAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync()
        {
            throw new NotImplementedException();
        }
    }
}

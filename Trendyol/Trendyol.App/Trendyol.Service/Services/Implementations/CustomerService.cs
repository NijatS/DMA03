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
	public class CustomerService : ICustomerService
	{
		private readonly ICustomerRepository _customerRepository;
		public CustomerService()
		{
			_customerRepository = new CustomerRepository();
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


			await _customerRepository.AddAsync(new()
			{
				Name = name,
				Surname = surname,
				Address = address,
				Phone = phone,
				CreatedDate = DateTime.Now,
			});
		}

		public async Task DeleteAsync()
		{
			Console.Write("Enter Customer Id: ");
			int.TryParse(Console.ReadLine(), out int id);
			if (id != 0)
				await _customerRepository.DeleteAsync(id);
		}

		public async Task GetAsync()
		{
			Console.Write("Enter Customer Id: ");
			int.TryParse(Console.ReadLine(), out int id);
			Customer customer = await _customerRepository.GetByIdAsync(id);

			if (customer != null)
				Console.WriteLine(customer);
		}

		public async Task GetAllAsync()
		{
			ICollection<Customer> customers = await _customerRepository.GetAllAsync();
			foreach (Customer customer in customers)
				Console.WriteLine(customer);
		}

		public async Task UpdateAsync()
		{
			Console.Write("Enter Customer Id: ");
			int.TryParse(Console.ReadLine(), out int id);

			Customer updatedCustomer = await _customerRepository.GetByIdAsync(id);
			if (updatedCustomer != null)
			{
				Console.Write("Enter Name:");
				string name = Console.ReadLine();

				Console.Write("Surname:");
				string surname = Console.ReadLine();

				Console.Write("Address:");
				string address = Console.ReadLine();

				Console.Write("Phone:");
				string phone = Console.ReadLine();

				updatedCustomer.Name = name;
				updatedCustomer.Surname = surname;
				updatedCustomer.Address = address;
				updatedCustomer.Phone = phone;
				updatedCustomer.UpdatedDate = DateTime.Now;
				await _customerRepository.UpdateAsync(updatedCustomer);
			}

		}
	}
}

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
		public void Add()
		{
			Console.Write("Enter Name:");
			string name = Console.ReadLine();

			Console.Write("Surname:");
			string surname = Console.ReadLine();

			Console.Write("Address:");
			string address = Console.ReadLine();

			Console.Write("Phone:");
			string phone = Console.ReadLine();


			_customerRepository.Add(new()
			{
				Name = name,
				Surname = surname,
				Address = address,
				Phone = phone,
				CreatedDate = DateTime.Now,
			});
		}

		public void Delete()
		{
			Console.Write("Enter Customer Id: ");
			int.TryParse(Console.ReadLine(), out int id);
			if (id != 0)
				_customerRepository.Delete(id);
		}

		public void Get()
		{
			Console.Write("Enter Customer Id: ");
			int.TryParse(Console.ReadLine(), out int id);
			Customer customer = _customerRepository.GetById(id);

			if (customer != null)
				Console.WriteLine(customer);
		}

		public void GetAll()
		{
			ICollection<Customer> customers = _customerRepository.GetAll();
			foreach (Customer customer in customers)
				Console.WriteLine(customer);
		}

		public void Update()
		{
			Console.Write("Enter Customer Id: ");
			int.TryParse(Console.ReadLine(), out int id);

			Customer updatedCustomer = _customerRepository.GetById(id);
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
				_customerRepository.Update(updatedCustomer);
			}

		}
	}
}

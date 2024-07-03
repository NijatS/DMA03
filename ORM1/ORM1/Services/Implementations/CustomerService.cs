using ORM1.Entities;
using Trendyol.App.Exceptions;
using Trendyol.App.Repositories.Implementations;
using Trendyol.App.Repositories.Interfaces;
using Trendyol.App.Services.Interfaces;

namespace Trendyol.App.Services.Implementations
{
    public class CustomerService : IService<Customer>
    {
        private readonly ICustomerRepository _repository ;
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
                Phone = phone,
            });

            await _repository.SaveAsync();
        }

        public async Task DeleteAsync()
        {
            Customer customer = await GetAsync();

            customer.isDeleted = true;
            await _repository.SaveAsync();
        }

        public async Task GetAllAsync()
        {
          ICollection<Customer> customers = await _repository.GetAllAsync(c=>!c.isDeleted);

            foreach (Customer c in customers)
            {
                Console.WriteLine("Id:"+c.Id+ "  FullName:"+c.Name+" "+c.Surname+ "  Phone:"+c.Phone);
            }
        }

        public async Task<Customer> GetAsync()
        {
            Console.Write("Enter Customer Id:");
            int.TryParse(Console.ReadLine(), out int id);

            Customer c = await _repository.GetAsync(c => c.Id == id && !c.isDeleted);

            if(c is null)
                throw new EntityNotFoundException("Customer is not found");

            Console.WriteLine("Id:" + c.Id + "  FullName:" + c.Name + " " + c.Surname + "  Phone:" + c.Phone);
            return c;
        }

        public async Task UpdateAsync()
        {
            Customer c = await GetAsync();

            Console.Write("Enter New Name:");
            string name = Console.ReadLine();

            Console.Write("Surname:");
            string surname = Console.ReadLine();

            Console.Write("Address:");
            string address = Console.ReadLine();

            Console.Write("Phone:");
            string phone = Console.ReadLine();

            c.Name = name;
            c.Address = address;
            c.Surname = surname;
            c.Phone = phone;
            _repository.Update(c);
            await _repository.SaveAsync();
        }
    }
}

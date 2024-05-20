using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.Core.Models;
using Trendyol.Data.Repositories.Interfaces;

namespace Trendyol.Data.Repositories.Implementations
{
	public class CustomerRepository: GenericRepository<Customer>,ICustomerRepository
	{
        public CustomerRepository()
        {
            Customer customer = new Customer();
            customer.Name = "Aci";
            customer.Surname = "Acili";
            customer.Address = "Hazi";
            customer.CreatedDate = DateTime.Now;

            _entities.Add(customer);
            
        }
    }
}

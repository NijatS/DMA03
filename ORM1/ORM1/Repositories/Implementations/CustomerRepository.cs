using ORM1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Repositories.Interfaces;

namespace Trendyol.App.Repositories.Implementations
{
    public class CustomerRepository : Repository<Customer>,ICustomerRepository
    {

    }
}

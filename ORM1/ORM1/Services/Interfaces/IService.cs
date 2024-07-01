using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trendyol.App.Services.Interfaces
{
    public interface IService
    {
        Task AddAsync();
        Task UpdateAsync();
        Task DeleteAsync();
        Task GetAsync();
        Task GetAllAsync();
    }
}

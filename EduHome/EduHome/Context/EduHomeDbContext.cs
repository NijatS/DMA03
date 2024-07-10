using EduHome.Models;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Context
{
    public class EduHomeDbContext : DbContext
    {
        DbSet<Slider> Sliders { get; set; }
    
        public EduHomeDbContext(DbContextOptions<EduHomeDbContext> options):base(options)
        {
            
        }
    }
}

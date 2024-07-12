using EduHome.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

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

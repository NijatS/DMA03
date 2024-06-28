using Microsoft.EntityFrameworkCore;
using ORM1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Entities;

namespace ORM1.Context
{
    public class TrendyolDbContext : DbContext
    {
        private static readonly string connectionString = "Server=DESKTOP-NIJAT;Database=TrendyolDb;Integrated Security=true;TrustServerCertificate= true;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}

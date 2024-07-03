using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ORM1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trendyol.App.Entities;
using Trendyol.App.Entities.BaseEntities;

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
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }



        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                    data.Entity.CreatedDate = DateTime.Now;
                else if (data.State == EntityState.Modified)
                    data.Entity.UpdatedDate = DateTime.Now;

            }

            return base.SaveChangesAsync(cancellationToken);
        }


    }
}

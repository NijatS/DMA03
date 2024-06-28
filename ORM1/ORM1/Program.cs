using ORM1.Context;
using Trendyol.App.Entities;

namespace ORM1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TrendyolDbContext context = new TrendyolDbContext();



            //context.Shops.Add(new Shop()
            //{
            //    Name = "Jet 1001 xirdavat",
            //    Description = "Ne alirsan 1 manat, 7/24 aciqdir",
            //    CreatedDate = DateTime.Now,
            //    Rating = 10,
            //});
            //context.SaveChanges();



            //context.Shops.Update(new Shop
            //{
            //    Id = 1,
            //    Name = "Jet 1001 xirdavat Genclik",
            //    Description = "Ne alirsan 1 manat, 7/24 aciqdir",
            //    CreatedDate = DateTime.Now,
            //    Rating = 10,
            //});

            //Shop updatedShop = context.Shops.FirstOrDefault(s => s.Id == 1);

            //updatedShop.isDeleted = true;

            //context.Update(updatedShop);

            //context.SaveChanges();

            //Shop removed = context.Shops.FirstOrDefault(s => s.Id == 1);
            //context.Remove(removed);
            //context.SaveChanges();


            Shop? updatedshop = context.Shops.FirstOrDefault(s=>s.Id == 2);
            updatedshop.isDeleted = true;


            context.Shops.Update(updatedshop);
            context.SaveChanges();







            List<Shop> shops =  context.Shops.Where(s=>!s.isDeleted ).ToList();



            foreach (var shop in shops)
            {
                Console.WriteLine($"Id:{shop.Id}  Name:{shop.Name}");
            }




        }
    }
}

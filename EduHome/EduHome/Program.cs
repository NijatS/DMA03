using EduHome.Context;
using Microsoft.EntityFrameworkCore;

namespace EduHome
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<EduHomeDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapAreaControllerRoute(
                     name: "Admin",
                     areaName: "Admin",
                     pattern: "admin/{controller=Home}/{action=Index}/{id?}")
                    ;
                endpoint.MapControllerRoute(
                      name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}"
                    );
            });

        

            app.Run();
        }
    }
}

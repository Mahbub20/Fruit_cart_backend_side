using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Data;
using fruit_cart_backend.Models;

namespace fruit_cart_backend.Seeds
{
    public static class DataSeeder
    {
        public static void SeedData(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<EComDBContext>();

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>
                {
                    new() {Name = "Mango", Description = "Juicy Mango", Price = 2, Quantity = 1, Stock = 5000, Image = "./assets/img/mango.png"},
                    new() {Name = "Apple", Description = "Fresh Apple", Price = 3, Quantity = 1, Stock = 5000, Image = "./assets/img/apple.png"},
                    new() {Name = "Banana", Description = "Ripe Banana", Price = 1.5m, Quantity = 1, Stock = 5000, Image = "./assets/img/banana.png"}
                });

                    context.SaveChanges();
                }
            }
        }
    }
}
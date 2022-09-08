using DungeonForceWoW.Data.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace DungeonForceWoW.Data
{
    public class ExempelSeeder
    {
        private readonly DungeonForceContext context;
        private readonly IWebHostEnvironment hosting;

        public ExempelSeeder(DungeonForceContext context, IWebHostEnvironment hosting)
        {
            this.context = context;
            this.hosting = hosting;
        }
        public void Seed()
        {
            context.Database.EnsureCreated();
            if (!context.Products.Any())
            {
                var filePath = Path.Combine(hosting.ContentRootPath, "Data/art.json"); // beroende på var filen jag vill seeda ligger
                var json = File.ReadAllText(filePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);

                context.Products.AddRange(products);

                var order = context.Orders.Where(o => o.Id == 1).FirstOrDefault();
                if(order != null)
                {
                    order.Items = new List<OrderItem>();
                    {
                        new OrderItem()
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        };
                    }
                }
                
                context.SaveChanges();
            }
        }
    }
}

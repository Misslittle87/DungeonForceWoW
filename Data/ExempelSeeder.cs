using DungeonForceWoW.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Text.Json;

namespace DungeonForceWoW.Data
{
    public class ExempelSeeder
    {
        private readonly DungeonForceContext context;
        private readonly IWebHostEnvironment hosting;
        private readonly UserManager<IdentityUser> userManager;

        public ExempelSeeder(DungeonForceContext context, IWebHostEnvironment hosting, UserManager<IdentityUser> userManager)
        {
            this.context = context;
            this.hosting = hosting;
            this.userManager = userManager;
        }
        public async Task SeedAsync()
        {
            context.Database.EnsureCreated();
            IdentityUser user = await userManager.FindByEmailAsync("sofia_hansson_87@hotmail.com");

            if (user == null)
            {
                user = new IdentityUser()
                {
                    ////FirstName = "Sofia",
                    ////LastName = "Hansson",
                    Email = "sofia_hansson_87@hotmail.com",
                    UserName = "sofia_hansson_87@hotmail.com"
                };

                var result = await userManager.CreateAsync(user, "abc123");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create new user in Seeder");
                }
            }
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

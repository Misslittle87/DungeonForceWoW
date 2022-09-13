using DungeonForceWoW.Data.Entities;
using Microsoft.EntityFrameworkCore;
// repository istället för context
namespace DungeonForceWoW.Data
{
    public class DungeonForceContext : DbContext
    {
        private readonly IConfiguration config;

        public DungeonForceContext(IConfiguration config)
        {
            this.config = config;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(config.GetConnectionString("DungeonForceContextDb"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Order>()
                        .HasData(new Order()
                        {
                            Id = 1,
                            OrderDate = DateTime.Now,
                            OrderNumber = "12345"
                        });
        }
    }
}

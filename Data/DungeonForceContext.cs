using DungeonForceWoW.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DungeonForceWoW.Data
{
    public class DungeonForceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

using DungeonForceWoW.Data.Entities;
// repository istället för context
namespace DungeonForceWoW.Data
{
    public class ExempelRepository : IExempelRepository
    {
        private readonly DungeonForceContext context;
        private readonly ILogger<ExempelRepository> logger;

        public ExempelRepository(DungeonForceContext context, ILogger<ExempelRepository> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
                logger.LogInformation("GetAllProducts was called!");
                return context.Products
                    .OrderBy(p => p.Artist)
                    .ToList();
            }
            catch (Exception ex)
            {
                logger.LogError($"Failed to get all products: {ex}");
                return null;
            }
        }
        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return context.Products
                .Where(p => p.Category == category)
                .ToList();
        }
        public bool SaveAll()
        {
            return context.SaveChanges() > 0;
        }
    }
}

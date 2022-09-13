using DungeonForceWoW.Data.Entities;

namespace DungeonForceWoW.Data
{
    public interface IExempelRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);
        bool SaveAll();
    }
}
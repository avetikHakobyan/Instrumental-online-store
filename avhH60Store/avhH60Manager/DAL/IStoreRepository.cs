using avhH60Manager.DTO;
using avhH60Manager.Models;

namespace avhH60Manager.DAL
{
    public interface IStoreRepository
    {
        #region Product
        Task<IEnumerable<Product>> GetProducts();
        Task<Product> GetProductById(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(int id, Product product);
        Task DeleteProduct(int id);
        Task UpdatePrice(string buyPrice, string sellPrice, Product product);
        Task UpdateStock(int amount, Product product);
        Task<IEnumerable<Product>> FilterProducts(string? searchString, int categoryId, int priceSortChoice);
        Task<IEnumerable<Product>> GetProductsForCategory(int id);
        #endregion
    }
}

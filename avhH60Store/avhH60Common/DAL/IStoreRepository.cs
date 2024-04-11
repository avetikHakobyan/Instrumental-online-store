using avhH60Common.DTO;
using avhH60Common.Models;

namespace avhH60Common.DAL
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

        #region Category
        Task<IEnumerable<ProductCategory>> GetCategories();
        Task<IEnumerable<ProductCategoryDTO>> GetProductCategories();
        Task<ProductCategory> GetCategoryById(int id);
        Task CreateCategory(ProductCategory category);
        Task UpdateCategory(int id, ProductCategory category);
        Task DeleteCategory(int id);
        #endregion

        #region Customer
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<int> GetCustomerIdByEmail(string email);
        Task CreateCustomer(Customer customer);
        Task UpdateCustomer(int id, Customer customer);
        Task DeleteCustomer(int id);
        #endregion

        #region Shopping Cart
        Task<ShoppingCart> GetShoppingCart(int customerId);
        Task CreateShoppingCart(int customerId);
        Task DeleteShoppingCart(int customerId);

        #endregion

        #region Cart Item
        
        Task<CartItem> GetCartItem(int cartItemId);
        Task CreateCartItem(int customerId, int productId, int quantity);
        Task DeleteCartItem(int cartItemId);
        #endregion

        #region Order
        Task<Order> GetOrder(int orderId);
        Task <IEnumerable<Order>> GetOrdersByDateFulfilled(DateTime date);
        Task <IEnumerable<Order>> GetOrdersByCustomer(int customerId);
        Task<Order> CreateOrder(Order order);
        Task CompleteOrder(int orderId);
        #endregion

        #region Order Items
        Task <OrderItem> GetOrderItemById(int orderItemId);
        #endregion
    }
}

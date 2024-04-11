using avhH60Common.DAL;
using avhH60Common.DTO;
using avhH60Common.Models;
using System.Net.Http.Json;

namespace avhH60Common.DAL
{
    public class StoreRestRepository : IStoreRepository
    {
        private readonly string _productUri = "http://localhost:23179/api/Products";
        private readonly string _categoryUri = "http://localhost:23179/api/ProductCategories";
        private readonly string _customerUri = "http://localhost:23179/api/Customers";
        private readonly string _cartItemUri = "http://localhost:23179/api/CartItems";
        private readonly string _shoppingCartUri = "http://localhost:23179/api/ShoppingCarts";
        private readonly string _orderUri = "http://localhost:23179/api/Orders";

        #region Products

        public async Task<IEnumerable<Product>> GetProducts()
        {
            HttpClient client = new();
            return await client.GetFromJsonAsync<IEnumerable<Product>>(_productUri) ?? throw new NullReferenceException();
        }

        public async Task<Product> GetProductById(int id)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"{_productUri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
                return null;
            } else
            {
                return await response.Content.ReadFromJsonAsync<Product>();
            }
        }

        public async Task CreateProduct(Product product)
        {
            HttpClient client = new();
            var response = await client.PostAsJsonAsync(_productUri, product);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task UpdateProduct(int id, Product newProduct)
        {
            HttpClient client = new();
            var product = await GetProductById(id);
            product.Description = newProduct.Description;
            product.Manufacturer = newProduct.Manufacturer;
            product.ProdCatId = newProduct.ProdCatId;
            var response = await client.PutAsJsonAsync($"{_productUri}/{id}", product);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task UpdatePrice(string buyPrice, string sellPrice, Product product)
        {
            HttpClient client = new();
            var response = await client.PutAsJsonAsync($"{_productUri}/UpdatePrice/{product.ProductId}?buyPrice={buyPrice}&sellPrice={sellPrice}", product);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task UpdateStock(int amount, Product product)
        {
            HttpClient client = new();
            var response = await client.PutAsJsonAsync($"{_productUri}/UpdateStock/{product.ProductId}?amount={amount}", product);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task DeleteProduct(int id)
        {
            HttpClient client = new();
            var response = await client.DeleteAsync($"{_productUri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task<IEnumerable<Product>> FilterProducts(string? searchString, int categoryId, int priceSortChoice)
        {
            HttpClient client = new();
            return await client.GetFromJsonAsync<IEnumerable<Product>>($"{_productUri}/FilterProducts?search={searchString}&id={categoryId}&sort={priceSortChoice}") ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<Product>> GetProductsForCategory(int id)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"{_productUri}/categories/{id}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<Product>>();

        }

        #endregion

        #region Category

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            HttpClient client = new();
            return await client.GetFromJsonAsync<IEnumerable<ProductCategory>>(_categoryUri) ?? throw new NullReferenceException();
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetProductCategories()
        {
            HttpClient client = new();
            return await client.GetFromJsonAsync<IEnumerable<ProductCategoryDTO>>($"{_categoryUri}/products") ?? throw new NullReferenceException();
        }

        public async Task<ProductCategory> GetCategoryById(int id)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"{_categoryUri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
                return null;
            } else
            {
                return await response.Content.ReadFromJsonAsync<ProductCategory>();
            }
        }

        public async Task CreateCategory(ProductCategory category)
        {
            HttpClient client = new();
            var response = await client.PostAsJsonAsync($"{_categoryUri}", category);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task UpdateCategory(int id, ProductCategory category)
        {
            HttpClient client = new();
            var response = await client.PutAsJsonAsync($"{_categoryUri}/{id}", category);
            if (!response.IsSuccessStatusCode)
            {

                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task DeleteCategory(int id)
        {
            HttpClient client = new();
            var response = await client.DeleteAsync($"{_categoryUri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        #endregion

        #region Customer
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            HttpClient client = new();
            return await client.GetFromJsonAsync<IEnumerable<Customer>>(_customerUri) ?? throw new NullReferenceException();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"{_customerUri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
                return null;
            } else
            {
                return await response.Content.ReadFromJsonAsync<Customer>();
            }
        }
        public async Task<int> GetCustomerIdByEmail(string email)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"{_customerUri}/{email}/id");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
                return 0;
            } else
            {
                return int.Parse(await response.Content.ReadAsStringAsync());
            }
        }

        public async Task CreateCustomer(Customer customer)
        {
            HttpClient client = new();
            var response = await client.PostAsJsonAsync($"{_customerUri}", customer);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task UpdateCustomer(int id, Customer customer)
        {
            HttpClient client = new();
            var response = await client.PutAsJsonAsync($"{_customerUri}/{id}", customer);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task DeleteCustomer(int id)
        {
            HttpClient client = new();
            var response = await client.DeleteAsync($"{_customerUri}/{id}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        #endregion

        #region Shopping Cart

        public async Task<ShoppingCart> GetShoppingCart(int customerId)
        {
            HttpClient client = new();
            return await client.GetFromJsonAsync<ShoppingCart>($"{_shoppingCartUri}/{customerId}") ?? throw new NullReferenceException();
        }

        public async Task CreateShoppingCart(int customerId)
        {
            HttpClient client = new();
            var response = await client.PostAsync($"{_shoppingCartUri}/{customerId}", null);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task DeleteShoppingCart(int customerId)
        {
            HttpClient client = new();
            var response = await client.DeleteAsync($"{_shoppingCartUri}/{customerId}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }
        #endregion

        #region Cart Item

        public async Task<CartItem> GetCartItem(int cartItemId)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"{_cartItemUri}/{cartItemId}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
                return null;
            } else
            {
                return await response.Content.ReadFromJsonAsync<CartItem>();
            }
        }

        public async Task CreateCartItem(int customerId, int productId, int quantity)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.PostAsync($"{_cartItemUri}/customerId={customerId}&productId={productId}&quantity={quantity}", null);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }

        public async Task DeleteCartItem(int cartItemId)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.DeleteAsync($"{_cartItemUri}/{cartItemId}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }
        #endregion

        #region Order

        public async Task<Order> GetOrder(int orderId)
        {
            HttpClient client = new();
            HttpResponseMessage response = await client.GetAsync($"{_orderUri}/{orderId}");
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
                return null;
            } else
            {
                return await response.Content.ReadFromJsonAsync<Order>();
            }
        }

        public Task<IEnumerable<Order>> GetOrdersByDateFulfilled(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            HttpClient client = new();
            var response = await client.PostAsJsonAsync(_orderUri, order);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
            return await response.Content.ReadFromJsonAsync<Order>();
        }

        public async Task CompleteOrder(int orderId)
        {
            HttpClient client = new();
            var response = await client.PutAsync($"{_orderUri}/{orderId}/complete", null);
            if (!response.IsSuccessStatusCode)
            {
                await Validation.HandleHttpErrors(response);
            }
        }
        #endregion

        #region Order Item

        public Task<OrderItem> GetOrderItemById(int orderItemId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

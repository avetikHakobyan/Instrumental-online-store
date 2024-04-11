using avhH60Manager.Models;
using System.Net.Http.Json;

namespace avhH60Manager.DAL
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
    }
}

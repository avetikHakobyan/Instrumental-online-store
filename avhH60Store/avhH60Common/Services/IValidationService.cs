using avhH60Common.Models;

namespace avhH60Common.Services
{
    public interface IValidationService
    {
        public bool ValidateBuyPrice(string buyPrice);
        public bool ValidateSellPrice(string sellPrice);
        public bool ValidatePrice(string price, string property);

        public void ValidateBuyPriceAndSellPrice(decimal? buyPrice, decimal? sellPrice);

        public void ValidateDuplicateProduct(IEnumerable<Product> products, Product newProduct);

        public void ValidateStock(int currentStock);

        public void ValidateDuplicateCategory(IEnumerable<ProductCategory> categories, ProductCategory newProductCategory);
        public void ValidateDuplicateCustomer(IEnumerable<Customer> customers, Customer newCustomer);
        public void ValidateQuanitity(int quantity, int stock);

        public void IsShoppingCartEmpty(int count);
    }
}

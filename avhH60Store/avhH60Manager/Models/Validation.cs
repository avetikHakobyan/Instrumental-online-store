using avhH60Manager.Models;

namespace avhH60Manager.Models
{
    public class Validation : IValidationService
    {
        public bool ValidateBuyPrice(string buyPrice)
        {
            return ValidatePrice(buyPrice, "Buy Price");
        }

        public bool ValidateSellPrice(string sellPrice)
        {
            return ValidatePrice(sellPrice, "Sell Price");
        }

        public bool ValidatePrice(string price, string property)
        {
            decimal priceDecimal;
            if (!Decimal.TryParse(price, out _))
            {
                throw new ArithmeticException($"{property} should be a number");
            } else
            {
                priceDecimal = Convert.ToDecimal(price);
            }
            bool isValid;
            if (priceDecimal < 0)
            {
                throw new ArgumentException($"{property} should be a positive number");
            } else
            {
                isValid = true;
            }
            return isValid;
        }

        public void ValidateBuyPriceAndSellPrice(decimal? buyPrice, decimal? sellPrice)
        {
            if (sellPrice < buyPrice)
                throw new Exception("Sell price is less than the Buy price");
        }

        public void ValidateDuplicateProduct(IEnumerable<Product> products, Product newProduct)
        {
            if (products.Any(p => p.Description == newProduct.Description && p.Manufacturer == newProduct.Manufacturer))
                throw new Exception($"Product with the description \"{newProduct.Description}\" already exists");
        }

        public void ValidateStock(int currentStock)
        {
            if (currentStock < 0)
                throw new Exception("Stock can not be negative");
        }

        public void ValidateDuplicateCategory(IEnumerable<ProductCategory> categories, ProductCategory newProductCategory)
        {
            if (categories.Any(c => c.ProdCat == newProductCategory.ProdCat))
                throw new Exception($"Category with the name \"{newProductCategory.ProdCat}\" already exists");
        }

        public void ValidateDuplicateCustomer(IEnumerable<Customer> customers, Customer newCustomer) {
            if (customers.Any(c => c.Email == newCustomer.Email))
                throw new Exception($"Customer with an email address \"{newCustomer.Email}\" already exists");
        }

        public static bool ValidateProvince(IEnumerable<Province> provinces, string provinceCode)
        {
            return provinces.Any(p => p.Code == provinceCode);
        }

        public static async Task HandleHttpErrors(HttpResponseMessage response)
        {
            string message = await response.Content.ReadAsStringAsync();
            if ((int)response.StatusCode == 404)
                throw new NullReferenceException(message);
            else
                throw new Exception(message);
        }

        public void ValidateQuanitity(int quantity, int stock)
        {
            if (quantity < 1)
                throw new InvalidOperationException("Quantity must be a number greater than 1");
            if (quantity > stock)
                throw new InvalidOperationException("Quantity exceeds the amount of stock available");
        }

        public void IsShoppingCartEmpty(int count)
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Shopping cart is empty");
            }
        }
    }
}

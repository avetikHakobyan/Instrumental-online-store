using avhH60Common.DAL;
using avhH60Common.DTO;
using avhH60Common.Models;
using avhH60Common.Services;
using CheckCreditCardService;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.ServiceModel.Channels;
using System.ServiceModel;
using CalculateTaxesService;

namespace avhH60Services.DAL
{
    public class StoreDbRepository : IStoreRepository
    {
        private readonly H60Assignment3DB_avhContext _context;
        private readonly IValidationService _validation;

        public StoreDbRepository(H60Assignment3DB_avhContext context, IValidationService validation)
        {
            _context = context;
            _validation = validation;
        }

        #region General
        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        #endregion General

        #region Product
        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context.Products.Include(p => p.ProdCat).OrderBy(pc => pc.Description).ToListAsync();
        }

        private async Task<IEnumerable<Product>> GetProductsByName(string? productName)
        {
            var products = await GetProducts();
            if (!string.IsNullOrEmpty(productName))
            {
                return products.Where(p => p.Description.ToLower().Contains(productName.ToLower()));
            } else
            {
                return products;
            }
        }

        public async Task<Product> GetProductById(int id)
        {
            if (!ProductExists(id))
            {
                throw new NullReferenceException("Product was not found");
            }
            return await _context.Products
            .Include(p => p.ProdCat)
            .FirstOrDefaultAsync(m => m.ProductId == id);
        }

        public async Task CreateProduct(Product product)
        {
            _validation.ValidateDuplicateProduct(await GetProducts(), product);
            _validation.ValidateStock(product.Stock);
            _validation.ValidateBuyPriceAndSellPrice(product.BuyPrice, product.SellPrice);
            _context.Add(product);
            await Save();
        }

        public async Task UpdateProduct(int id, Product newProduct)
        {
            var product = await GetProductById(id);
            //Source: https://learn.microsoft.com/en-us/ef/ef6/saving/change-tracking/property-values#setting-current-or-original-values-from-another-object
            _context.Entry(product).CurrentValues.SetValues(newProduct);
            await Save();
        }

        public async Task DeleteProduct(int id)
        {
            var product = await GetProductById(id);
            _context.Products.Remove(product);
            await Save();
        }

        public async Task UpdatePrice(string buyPriceArg, string sellPriceArg, Product product)
        {
            decimal buyPrice;
            decimal sellPrice;
            if (_validation.ValidateBuyPrice(buyPriceArg) && _validation.ValidateSellPrice(sellPriceArg))
            {
                buyPrice = Math.Round(Convert.ToDecimal(buyPriceArg), 2);
                sellPrice = Math.Round(Convert.ToDecimal(sellPriceArg), 2);
                _validation.ValidateBuyPriceAndSellPrice(buyPrice, sellPrice);
                product.BuyPrice = buyPrice;
                product.SellPrice = sellPrice;
                await UpdateProduct(product.ProductId, product);
            }
        }

        public async Task UpdateStock(int amount, Product product)
        {
            int currentStock = product.Stock;

            if (amount >= 0)
            {
                currentStock += amount;
            } else if (amount < 0)
            {
                currentStock -= Math.Abs(amount);
            }
            _validation.ValidateStock(currentStock);
            product.Stock = currentStock;
            await UpdateProduct(product.ProductId, product);
        }

        public async Task<IEnumerable<Product>> GetProductsForCategory(int id)
        {
            if (!ProductCategoryExists(id))
            {
                throw new NullReferenceException("Product category was not found");
            }
            var products = await GetProducts();
            return products.Where(pc => pc.ProdCatId == id);
        }

        private IEnumerable<Product> FilterByCategory(IEnumerable<Product> products, int categoryId = 0)
        {
            if (categoryId != 0)
            {
                return products.Where(p => p.ProdCatId == categoryId).OrderBy(pc => pc.Description).ToList();
            }
            return products;
        }

        private IEnumerable<Product> SortPrice(IEnumerable<Product> products, int choice = 0)
        {
            switch (choice)
            {
                case 1:
                    return products.OrderBy(p => p.SellPrice).ThenBy(p => p.Description).ToList();
                case 2:
                    return products.OrderByDescending(p => p.SellPrice).ThenBy(p => p.Description).ToList();
                default:
                    return products;
            }
        }

        public async Task<IEnumerable<Product>> FilterProducts(string? searchString, int categoryId = 0, int priceSortChoice = 0)
        {
            var products = await GetProductsByName(searchString);
            products = FilterByCategory(products, categoryId);
            products = SortPrice(products, priceSortChoice);
            return products;
        }

        #endregion Product

        #region Category

        public bool ProductCategoryExists(int id)
        {
            return (_context.ProductCategories?
                            .Any(e => e.CategoryId == id))
                            .GetValueOrDefault();
        }

        public async Task<IEnumerable<ProductCategory>> GetCategories()
        {
            return await _context.ProductCategories
                                 .OrderBy(pd => pd.ProdCat)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<ProductCategoryDTO>> GetProductCategories()
        {
            return await _context.ProductCategories
                                 .Include(pc => pc.Products
                                 .OrderBy(p => p.Description))
                                 .OrderBy(pc => pc.ProdCat)
                                 .Select(pc => new ProductCategoryDTO(pc))
                                 .ToListAsync();
        }

        public async Task<ProductCategory> GetCategoryById(int id)
        {
            if (!ProductCategoryExists(id))
            {
                throw new NullReferenceException("Product category was not found");
            }
            return await _context.ProductCategories
                                 .FirstOrDefaultAsync(m => m.CategoryId == id);
        }

        public async Task CreateCategory(ProductCategory category)
        {
            _validation.ValidateDuplicateCategory(await GetCategories(), category);
            _context.Add(category);
            await Save();
        }

        public async Task UpdateCategory(int id, ProductCategory newCategory)
        {
            _validation.ValidateDuplicateCategory(await GetCategories(), newCategory);
            var category = await GetCategoryById(id);
            //Source: https://learn.microsoft.com/en-us/ef/ef6/saving/change-tracking/property-values#setting-current-or-original-values-from-another-object
            _context.Entry(category).CurrentValues.SetValues(newCategory);
            await Save();
        }

        public async Task DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);
            var productsToRemove = GetProductsForCategory(id);
            if (productsToRemove != null)
            {
                foreach (var product in await productsToRemove)
                {
                    _context.Products.Remove(product);
                }
            }
            _context.ProductCategories.Remove(category);
            await Save();
        }

        #endregion Category

        #region Customer
        private bool CustomerExists(int id)
        {
            return (_context.Customer?.Any(e => e.CustomerId == id)).GetValueOrDefault();
        }

        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            return await _context.Customer.Include(c => c.Orders).Include(c => c.ShoppingCart).OrderBy(c => c.FirstName).ThenBy(c => c.LastName).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            if (!CustomerExists(id))
            {
                throw new NullReferenceException("Customer was not found");
            }
            return await _context.Customer
            .Include(c => c.Orders)
            .Include(c => c.ShoppingCart)
            .FirstOrDefaultAsync(m => m.CustomerId == id);
        }

        public async Task<int> GetCustomerIdByEmail(string email)
        {
            return (await _context.Customer.FirstOrDefaultAsync(c => c.Email == email)).CustomerId;
        }

        public async Task CreateCustomer(Customer customer)
        {
            _validation.ValidateDuplicateCustomer(await GetCustomers(), customer);
            _context.Add(customer);
            await Save();
        }

        public async Task UpdateCustomer(int id, Customer newCustomer)
        {
            var customer = await GetCustomerById(id);
            //Source: https://learn.microsoft.com/en-us/ef/ef6/saving/change-tracking/property-values#setting-current-or-original-values-from-another-object
            _context.Entry(customer).CurrentValues.SetValues(newCustomer);
            await Save();
        }

        public async Task DeleteCustomer(int id)
        {
            var customer = await GetCustomerById(id);
            var message = "Failed to delete customer at this moment because they have an exisiting";
            if (!ShoppingCardExists(id) && !OrderExists(id))
            {
                _context.Remove(customer);
                await Save();
            } else if (ShoppingCardExists(id) && OrderExists(id))
                throw new InvalidOperationException($"{message} shopping card and order");
            else if (ShoppingCardExists(id))
                throw new InvalidOperationException($"{message} shopping card");
            else if (OrderExists(id))
                throw new InvalidOperationException($"{message} order");
        }

        #endregion

        #region Shopping Cart

        private bool ShoppingCardExists(int customerId)
        {
            return (_context.ShoppingCart?.Any(s => s.CustomerId == customerId)).GetValueOrDefault();
        }

        public async Task<ShoppingCart> GetShoppingCart(int customerId)
        {
            var customer = await GetCustomerById(customerId);
            if (!ShoppingCardExists(customerId))
            {
                await CreateShoppingCart(customerId);
            }
            var shoppingCart = await _context.ShoppingCart
                    .Include(s => s.Customer)
                    .Include(s => s.CartItems)
                    .ThenInclude(s => s.Product)
                    .ThenInclude(s => s.ProdCat)
                    .FirstOrDefaultAsync(s => s.CustomerId == customerId);
            return shoppingCart;
        }

        public async Task CreateShoppingCart(int customerId)
        {
            await GetCustomerById(customerId);
            if (ShoppingCardExists(customerId))
            {
                throw new InvalidOperationException("Shopping cart already exists");
            }
            var shoppingCart = new ShoppingCart()
            {
                CustomerId = customerId,
                DateCreated = DateTime.Now
            };
            _context.Add(shoppingCart);
            await Save();
        }

        public async Task DeleteShoppingCart(int customerId)
        {
            var shoppingCart = await GetShoppingCart(customerId);
            if (shoppingCart.CartItems.Any())
            {
                throw new InvalidOperationException("Failed to delete shopping cart because it contains items, please first remove the items");
            }
            _context.Remove(shoppingCart);
            await Save();
        }

        #endregion

        #region Cart Item

        private bool CartItemExists(int id)
        {
            return (_context.CartItem?.Any(e => e.CartItemId == id)).GetValueOrDefault();
        }

        public async Task<CartItem> GetCartItem(int cartItemId)
        {
            if (CartItemExists(cartItemId))
            {
                return await _context.CartItem
                    .Include(c => c.Product)
                    .ThenInclude(c => c.ProdCat)
                    .FirstOrDefaultAsync(c => c.CartItemId == cartItemId);
            }
            throw new NullReferenceException("Cart item was not found");
        }

        public async Task CreateCartItem(int customerId, int productId, int quantity)
        {
            var customer = await GetCustomerById(customerId);
            var shoppingCart = await GetShoppingCart(customerId);
            var product = await GetProductById(productId);
            _validation.ValidateQuanitity(quantity, product.Stock);
            var cartItemWithProduct = shoppingCart.CartItems.FirstOrDefault(c => c.ProductId == product.ProductId);
            if (cartItemWithProduct != null)
            {
                await UpdateCartItem(cartItemWithProduct.CartItemId, customerId, quantity);
            } else
            {
                var cartItem = new CartItem()
                {
                    ShoppingCartId = shoppingCart.ShoppingCartId,
                    ProductId = product.ProductId,
                    Quantity = quantity,
                    Price = (decimal)product.SellPrice
                };
                _context.Add(cartItem);
                await UpdateStock(-quantity, product);
            }
        }

        private async Task UpdateCartItem(int cartItemId, int customerId, int quantity)
        {
            await GetCustomerById(customerId);
            await GetShoppingCart(customerId);
            var cartItem = await GetCartItem(cartItemId);
            try
            {
                var amount = cartItem.Quantity - quantity;
                var newCartItem = cartItem;
                newCartItem.Quantity = quantity;
                _context.Entry(cartItem).CurrentValues.SetValues(newCartItem);
                await UpdateStock(-amount, cartItem.Product);
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task DeleteCartItem(int cartItemId)
        {
            var cartitem = await GetCartItem(cartItemId);
            await UpdateStock(cartitem.Quantity, await GetProductById(cartitem.ProductId));
            _context.Remove(cartitem);
            await Save();
        }

        #endregion

        #region Order

        private bool OrderExists(int orderId)
        {
            return (_context.Order?
                .Any(o => o.OrderId == orderId))
                .GetValueOrDefault();
        }

        public async Task<Order> GetOrder(int orderId)
        {
            return await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .ThenInclude(o => o.Product)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByDateFulfilled(DateTime date)
        {
            return await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .Where(o => o.DateFulfilled == date).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetOrdersByCustomer(int customerId)
        {
            return await _context.Order
                .Include(o => o.Customer)
                .Include(o => o.OrderItems)
                .Where(o => o.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<Order> CreateOrder(Order order)
        {
            var customer = await GetCustomerById(order.CustomerId);
            var shoppingCart = await GetShoppingCart(order.CustomerId);
            _validation.IsShoppingCartEmpty(shoppingCart.CartItems.Count());
            var total = shoppingCart.CartItems.Select(c => c.Price * c.Quantity).Sum();
            order.DateCreated = DateTime.Now;
            order.Total = total;
            await CheckCreditCard(customer.CreditCard);
            order.Taxes = await CalculateTaxes(total, shoppingCart.Customer.Province);

            _context.Add(order);
            await Save();

            foreach (var item in shoppingCart.CartItems)
            {
                await CreateOrderItem(order.OrderId, item);
                _context.Remove(item);
            }
            await Save();
            await DeleteShoppingCart(order.CustomerId);
            return order;
        }

        public async Task CompleteOrder(int orderId)
        {
            if (!OrderExists(orderId))
                throw new NullReferenceException("Order was not found");
            var order = await GetOrder(orderId);
            if (order.DateFulfilled != null)
            {
                throw new InvalidOperationException("Order was already completed");
            }
            order.DateFulfilled = DateTime.Now;
            _context.Update(order);
            await Save();
        }

        #endregion

        #region Order Item
        public async Task<OrderItem> GetOrderItemById(int orderItemId)
        {
            return await _context.OrderItem
                .FirstOrDefaultAsync(oi => oi.OrderItemId == orderItemId);
        }

        private async Task CreateOrderItem(int orderId, CartItem cartItem)
        {
            if (!OrderExists(orderId))
            {
                throw new NullReferenceException("Order was not found");
            }
            var orderItem = new OrderItem()
            {
                OrderId = orderId,
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Price = cartItem.Price
            };
            _context.Add(orderItem);
        }


        #endregion

        #region SOAP Services

        private async Task<int> CheckCreditCard(string creditCardNum)
        {
            Binding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            EndpointAddress endpoint = new("https://csdev.cegep-heritage.qc.ca/cartService/checkCreditCard.asmx");
            var client = new CheckCreditCardSoapClient(binding, endpoint);
            var result = await client.CreditCardCheckAsync(creditCardNum);
            return result;
        }

        private async Task<decimal> CalculateTaxes(decimal amount, string provinceCode)
        {
            Binding binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            EndpointAddress endpoint = new("https://csdev.cegep-heritage.qc.ca/cartService/calculateTaxes.asmx");
            var client = new CalculateTaxesSoapClient(binding, endpoint);
            var result = await client.CalculateTaxAsync((double)amount, provinceCode);
            return (decimal) result;
        }

        #endregion
    }
}

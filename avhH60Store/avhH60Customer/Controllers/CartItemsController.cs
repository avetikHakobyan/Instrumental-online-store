using avhH60Common.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace avhH60Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class CartItemsController : Controller
    {
        private readonly IStoreRepository _storeRestRepository;
        private readonly string _customerEmail;
        public CartItemsController(IStoreRepository storeRepository, IHttpContextAccessor httpContext)
        {
            _storeRestRepository = storeRepository;
            //Source: https://stackoverflow.com/questions/44683318/httpcontext-null-in-constructor
            _customerEmail = httpContext.HttpContext.User.Identity.Name;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddToCart(int productId, int quantity)
        {
            try
            {
                await _storeRestRepository.CreateCartItem(await _storeRestRepository.GetCustomerIdByEmail(_customerEmail), productId, quantity);
                TempData["SuccessMessage"] = "Product added successfully to the cart";
                return RedirectToAction("Index", "Products");
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Add to Cart failed: " + ex.Message;
                return RedirectToAction("Index", "Products");
            }
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            try
            {
                await _storeRestRepository.DeleteCartItem(id);
                TempData["SuccessMessage"] = "Item removed successfully from the cart";
                return RedirectToAction("Index", "ShoppingCarts");
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Item removal failed: " + ex.Message + $" {id}";
                return RedirectToAction("Index", "ShoppingCarts");
            }
        }
    }
}

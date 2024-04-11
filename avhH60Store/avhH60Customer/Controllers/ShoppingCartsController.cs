using avhH60Common.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace avhH60Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ShoppingCartsController : Controller
    {
        private readonly IStoreRepository _storeRestRepository;
        private readonly string _customerEmail;
        public ShoppingCartsController(IStoreRepository storeRestRepository, IHttpContextAccessor httpContext)
        {
            _storeRestRepository = storeRestRepository;
            //Source: https://stackoverflow.com/questions/44683318/httpcontext-null-in-constructor
            _customerEmail = httpContext.HttpContext.User.Identity.Name;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var shoppingCart = await _storeRestRepository.GetShoppingCart(await _storeRestRepository.GetCustomerIdByEmail(_customerEmail));
                return View(shoppingCart);
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Products");
            }
        }
    }
}

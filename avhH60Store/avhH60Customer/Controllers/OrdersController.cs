using avhH60Common.DAL;
using avhH60Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace avhH60Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class OrdersController : Controller
    {
        private readonly IStoreRepository _storeRestRepository;
        private readonly string _customerEmail;
        public OrdersController(IStoreRepository storeRepository, IHttpContextAccessor httpContext)
        {
            _storeRestRepository = storeRepository;
            //Source: https://stackoverflow.com/questions/44683318/httpcontext-null-in-constructor
            _customerEmail = httpContext.HttpContext.User.Identity.Name;
        }

        [HttpGet]
        public async Task<IActionResult> CreateOrder()
        {
            var order = new Order();
            order.CustomerId = await _storeRestRepository.GetCustomerIdByEmail(_customerEmail);
            order = await _storeRestRepository.CreateOrder(order);
            return RedirectToAction("ConfirmOrder", new { id = order.OrderId });
        }

        public async Task<IActionResult> ConfirmOrder(int id)
        {
            return View(await _storeRestRepository.GetOrder(id));
        }

        public async Task<IActionResult> CompleteOrder(int id)
        {
            try
            {
                await _storeRestRepository.CompleteOrder(id);
                TempData["SuccessMessage"] = "Your order is being processed and will be delivered";
                return RedirectToAction("Index", "Products");
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("ConfirmOrder", new {id = id });
            }
        }
    }
}

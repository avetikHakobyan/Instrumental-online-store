using Microsoft.AspNetCore.Mvc;
using avhH60Common.Models;
using Microsoft.AspNetCore.Authorization;
using avhH60Common.DAL;

namespace avhH60Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ProductCategoriesController : Controller
    {
        private readonly IStoreRepository _storeRestRepository;
        public ProductCategoriesController(IStoreRepository storeRestRepository)
        {
            _storeRestRepository = storeRestRepository;
        }

        // GET: ProductCategories
        public async Task<IActionResult> Index()
        {
            var productCategories = await _storeRestRepository.GetCategories();
            TempData["BackController"] = "ProductCategories";
            TempData["BackAction"] = "Index";
            return productCategories != null ?
                        View(productCategories) :
                        Problem("Entity set 'H60AssignmentDB_avhContext.ProductCategories'  is null.");
        }
    }
}

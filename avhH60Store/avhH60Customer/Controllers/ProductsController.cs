using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using avhH60Common.Models;
using Microsoft.AspNetCore.Authorization;
using avhH60Common.DAL;
using avhH60Common.DTO;

namespace avhH60Customer.Controllers
{
    [Authorize(Roles = "Customer")]
    public class ProductsController : Controller
    {
        private readonly IStoreRepository _storeRestRepository;

        public ProductsController(IStoreRepository storeRestRepository)
        {
            _storeRestRepository = storeRestRepository;
        }

        // GET: Products
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _storeRestRepository.GetProducts();
            var productsDto = products.Select(p => new ProductCartDTO(p));
            ViewData["categories"] = await GetSelectListCategoriesFilter();
            ViewData["priceChoices"] = await GetSelectListSortPrice();
            TempData["BackController"] = "Products";
            TempData["BackAction"] = "Index";
            return View(productsDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string searchString, int filterChoice, int priceSortChoice)
        {
            var products = await _storeRestRepository.FilterProducts(searchString, filterChoice, priceSortChoice);
            var productsDto = products.Select(p => new ProductCartDTO(p));
            ViewData["categories"] = await GetSelectListCategoriesFilter(filterChoice);
            ViewData["priceChoices"] = await GetSelectListSortPrice(priceSortChoice);
            ViewData["searchString"] = searchString;
            return View(productsDto);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return View("ProductNotFound");
            }
            try
            {
                return View(new ProductCartDTO(await _storeRestRepository.GetProductById(id)));
            } catch (NullReferenceException)
            {
                return View("ProductNotFound");
            }
        }

        public async Task<List<SelectListItem>> GetSelectListSortPrice(int value = 0)
        {
            List<string> sortOptions = new() { "Default", "Low to High", "High to Low" };
            List<SelectListItem> sortOptionsList = new();
            for (int i = 0; i < sortOptions.Count; i++)
            {
                sortOptionsList.Add(new SelectListItem { Text = sortOptions[i], Value = i.ToString(), Selected = i == value });
            }
            return sortOptionsList;
        }

        public async Task<List<SelectListItem>> GetSelectListCategoriesFilter(int value = 0)
        {
            List<SelectListItem> categoriesList = new List<SelectListItem>();
            foreach (var category in await _storeRestRepository.GetCategories())
            {
                categoriesList.Add(new SelectListItem
                {
                    Text = category.ProdCat,
                    Value = category.CategoryId.ToString(),
                    Selected = category.CategoryId == value
                });
            }
            return categoriesList;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using avhH60Common.Models;
using Microsoft.AspNetCore.Authorization;
using avhH60Common.DAL;

namespace avhH60Store.Controllers
{
    [Authorize(Roles = "Manager, Clerk")]
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

        // GET: ProductCategories/Products
        public async Task<IActionResult> Products()
        {
            var productCategories = await _storeRestRepository.GetProductCategories();
            TempData["BackController"] = "ProductCategories";
            TempData["BackAction"] = "Products";
            return View(productCategories);
        }

        // GET: ProductCategories/Create
        public IActionResult Create()
        {
            TempData["BackController"] = "ProductCategories";
            TempData["BackAction"] = "Index";
            return View();
        }

        // POST: ProductCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,ProdCat")] ProductCategory newProductCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _storeRestRepository.CreateCategory(newProductCategory);
                    TempData["SuccessMessage"] = "Category added successfully";
                    return RedirectToAction(nameof(Index));
                } catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View(newProductCategory);
                }
            }
            return View(newProductCategory);
        }

        // GET: ProductCategories/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return View("CategoryNotFound");
            }

            try
            {
                return View(await _storeRestRepository.GetCategoryById(id));
            } catch (NullReferenceException)
            {
                return View("CategoryNotFound");
            }
        }

        // POST: ProductCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,ProdCat")] ProductCategory productCategory)
        {
            if (id != productCategory.CategoryId)
            {
                return View("CategoryNotFound");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _storeRestRepository.UpdateCategory(id, productCategory);
                    TempData["SuccessMessage"] = "Category updated successfully";
                    return RedirectToAction(nameof(Index));
                } catch (NullReferenceException)
                {
                    return View("CategoryNotFound");
                } catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View(productCategory);
                }
            }
            return View(productCategory);
        }

        // GET: ProductCategories/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return View("CategoryNotFound");
            }

            try
            {
                var productCategory = await _storeRestRepository.GetCategoryById(id);
                ViewBag.Products = await _storeRestRepository.GetProductsForCategory(productCategory.CategoryId);
                return View(productCategory);
            } catch (NullReferenceException)
            {
                return View("CategoryNotFound");
            }
        }

        // POST: ProductCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _storeRestRepository.DeleteCategory(id);
                TempData["SuccessMessage"] = "Category deleted successfully";
                return RedirectToAction(nameof(Index));
            } catch (NullReferenceException)
            {
                return View("CategoryNotFound");
            }
        }
    }
}

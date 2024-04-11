using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using avhH60Common.Models;
using Microsoft.AspNetCore.Authorization;
using avhH60Common.DAL;

namespace avhH60Store.Controllers
{
    [Authorize(Roles = "Manager, Clerk")]
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
            ViewData["categories"] = await GetSelectListCategoriesFilter();
            ViewData["priceChoices"] = await GetSelectListSortPrice();
            TempData["BackController"] = "Products";
            TempData["BackAction"] = "Index";
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(string searchString, int filterChoice, int priceSortChoice)
        {
            var products = await _storeRestRepository.FilterProducts(searchString, filterChoice, priceSortChoice);
            ViewData["categories"] = await GetSelectListCategoriesFilter(filterChoice);
            ViewData["priceChoices"] = await GetSelectListSortPrice(priceSortChoice);
            ViewData["searchString"] = searchString;
            return View(products);
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
                return View(await _storeRestRepository.GetProductById(id));
            } catch (NullReferenceException)
            {
                return View("ProductNotFound");
            }
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ViewData["ProdCatId"] = new SelectList(await _storeRestRepository.GetCategories(), "CategoryId", "ProdCat");
            TempData["BackController"] = "Products";
            TempData["BackAction"] = "Index";
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice")] Product product)
        {
            ViewData["ProdCatId"] = new SelectList(await _storeRestRepository.GetCategories(), "CategoryId", "ProdCat", product.ProdCatId);
            if (ModelState.IsValid)
            {
                try
                {
                    await _storeRestRepository.CreateProduct(product);
                    TempData["SuccessMessage"] = "Product added successfully";
                    return RedirectToAction(nameof(Index));
                } catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View(product);
                }
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return View("ProductNotFound");
            }

            try
            {
                var product = await _storeRestRepository.GetProductById(id);
                ViewData["ProdCatId"] = new SelectList(await _storeRestRepository.GetCategories(), "CategoryId", "ProdCat", product.ProdCatId);
                return View(product);
            } catch (NullReferenceException)
            {
                return View("ProductNotFound");
            }
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProdCatId,Description,Manufacturer,Stock,BuyPrice,SellPrice")] Product newProduct)
        {
            if (id != newProduct.ProductId)
            {
                return View("ProductNotFound");
            }
            ViewData["ProdCatId"] = new SelectList(await _storeRestRepository.GetCategories(), "CategoryId", "ProdCat", newProduct.ProdCatId);
            if (ModelState.IsValid)
            {
                try
                {
                    await _storeRestRepository.UpdateProduct(id, newProduct);
                    TempData["SuccessMessage"] = " Product updated successfully";
                    return RedirectToAction(nameof(Index));
                } catch (NullReferenceException)
                {
                    return View("ProductNotFound");
                } catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View(newProduct);
                }
            }
            return View(newProduct);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return View("ProductNotFound");
            }

            try
            {
                var product = await _storeRestRepository.GetProductById(id);
                TempData["BackController"] = "Products";
                TempData["BackAction"] = "Index";
                return View(product);
            } catch (NullReferenceException)
            {
                return View("ProductNotFound");
            }
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var product = await _storeRestRepository.GetProductById(id);
                await _storeRestRepository.DeleteProduct(product.ProductId);
                TempData["SuccessMessage"] = "Product deleted successfully";
                return RedirectToAction(nameof(Index));
            } catch (NullReferenceException)
            {
                return View("ProductNotFound");
            }
        }

        // GET: Products/UpdateStock/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdateStock(int id)
        {
            if (id == 0)
            {
                return View("ProductNotFound");
            }

            try
            {
                var product = await _storeRestRepository.GetProductById(id);
                TempData["BackController"] = "Products";
                TempData["BackAction"] = "Index";
                return View(product);
            } catch (NullReferenceException)
            {
                return View("ProductNotFound");
            }
        }

        // POST: Products/UpdateStock/5
        [Authorize(Roles = "Manager")]
        [HttpPost, ActionName("UpdateStock")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateStock(int id, int stock)
        {
            Product? product = null;
            try
            {
                product = await _storeRestRepository.GetProductById(id);
                TempData["BackController"] = "Products";
                TempData["BackAction"] = "Index";
                if (ModelState.IsValid)
                {
                    await _storeRestRepository.UpdateStock(stock, product);
                    TempData["SuccessMessage"] = "Product stock updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            } catch (NullReferenceException)
            {
                return View("ProductNotFound");
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Update stock failed: " + ex.Message;
                return View(product);
            }
        }

        // GET: Products/UpdatePrice/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> UpdatePrice(int id)
        {
            if (id == 0)
            {
                return View("ProductNotFound");
            }

            try
            {
                var product = await _storeRestRepository.GetProductById(id);
                TempData["BackController"] = "Products";
                TempData["BackAction"] = "Index";
                return View(product);
            } catch (NullReferenceException)
            {
                return View("ProductNotFound");
            }
        }

        // POST: Products/UpdateStock/5
        [Authorize(Roles = "Manager")]
        [HttpPost, ActionName("UpdatePrice")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdatePrice(int id, string buyPrice, string sellPrice)
        {
            Product? product = null;
            try
            {
                product = await _storeRestRepository.GetProductById(id);
                TempData["BackController"] = "Products";
                TempData["BackAction"] = "Index";
                if (ModelState.IsValid)
                {
                    await _storeRestRepository.UpdatePrice(buyPrice, sellPrice, product);
                    TempData["SuccessMessage"] = "Product price updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                return View(product);
            } catch (NullReferenceException)
            {
                return View("ProductNotFound");
            } catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Update price failed: " + ex.Message;
                return View(product);
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

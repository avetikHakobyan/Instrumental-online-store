using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using avhH60Common.Models;
using Microsoft.AspNetCore.Authorization;
using avhH60Common.DAL;
using Microsoft.AspNetCore.Identity;
using avhH60Store.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace avhH60Store.Controllers
{
    public class CustomersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserStore<IdentityUser> _userStore;
        private readonly IUserEmailStore<IdentityUser> _emailStore;
        private readonly IEmailSender _emailSender;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IStoreRepository _storeRestRepository;

        public CustomersController(IStoreRepository storeRestRepository, UserManager<IdentityUser> userManager,
            IUserStore<IdentityUser> userStore,
            IEmailSender emailSender,
            ILogger<RegisterModel> logger)
        {
            _storeRestRepository = storeRestRepository;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = (IUserEmailStore<IdentityUser>) _userStore;
            _emailSender = emailSender;
            _logger = logger;
        }

        [Authorize(Roles = "Manager, Clerk")]
        // GET: Customers
        public async Task<IActionResult> Index()
        {
              return View(await _storeRestRepository.GetCustomers());
        }

        [Authorize(Roles = "Manager, Clerk")]
        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return View("NotFoundError");
            }

            try
            {
                return View(await _storeRestRepository.GetCustomerById(id));
            } catch (NullReferenceException)
            {
                return View("NotFoundError");
            }
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewBag.Provinces = Customer.GetProvincesSelectList();
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerAccountViewModel customer)
        {
            ViewBag.Provinces = Customer.GetProvincesSelectList();
            if (ModelState.IsValid)
            {
                try
                {
                    var user = Activator.CreateInstance<IdentityUser>();
                    await RegisterModel.RegisterUserAsync(_userManager, _userStore, _emailStore, _logger, user, customer.Email, customer.Password, "Customer");
                    await RegisterModel.SendConfirmEmail(_userManager, _emailSender, user, Url, Request, "/");
                    await _storeRestRepository.CreateCustomer(new Customer(customer));
                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return Redirect($"/Identity/Account/RegisterConfirmation?email={customer.Email}");
                    } else
                    {
                        TempData["SuccessMessage"] = "Customer added successfully";
                        return RedirectToAction(nameof(Index));
                    }
                } catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View(customer);
                }
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        [Authorize(Roles = "Manager, Clerk")]
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.Provinces = Customer.GetProvincesSelectList();
            if (id == 0)
            {
                return View("NotFoundError");
            }

            try
            {
                return View(await _storeRestRepository.GetCustomerById(id));
            } catch (NullReferenceException)
            {
                return View("NotFoundError");
            }
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Manager, Clerk")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,FirstName,LastName,Email,PhoneNumber,Province,CreditCard")] Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return View("NotFoundError");
            }
            ViewBag.Provinces = Customer.GetProvincesSelectList();
            if (ModelState.IsValid)
            {
                try
                {
                    await _storeRestRepository.UpdateCustomer(id, customer);
                    TempData["SuccessMessage"] = "Customer updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (NullReferenceException)
                {
                    return View("NotFoundError");
                } catch (Exception ex)
                {
                    TempData["ErrorMessage"] = ex.Message;
                    return View(customer);
                }
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        [Authorize(Roles = "Manager, Clerk")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0)
            {
                return View("NotFoundError");
            }

            try
            {
                var customer = await _storeRestRepository.GetCustomerById(id);
                return View(customer);
            } catch (NullReferenceException)
            {
                return View("NotFoundError");
            }
        }

        // POST: Customers/Delete/5
        [Authorize(Roles = "Manager, Clerk")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Customer? customer = null;
            try
            {
                customer = await _storeRestRepository.GetCustomerById(id);
                await _storeRestRepository.DeleteCustomer(customer.CustomerId);
                var user = await _userManager.FindByEmailAsync(customer.Email);
                var result = await _userManager.DeleteAsync(user);
                var userId = await _userManager.GetUserIdAsync(user);
                TempData["SuccessMessage"] = "Customer deleted successfully";
                return RedirectToAction(nameof(Index));
            } catch (NullReferenceException)
            {
                return View("NotFoundError");
            } catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View(customer);
            }
        }
    }
}

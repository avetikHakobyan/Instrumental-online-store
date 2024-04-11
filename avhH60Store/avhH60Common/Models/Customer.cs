using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace avhH60Common.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [DisplayName("First Name")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        public string? LastName { get; set; }

        public string? Email { get; set; }

        [DisplayName("Phone Number")]
        public string? PhoneNumber { get; set; }

        public string? Province { get; set; }

        [DisplayName("Credit Card")]
        public string? CreditCard { get; set; }

        [JsonIgnore]
        public virtual ICollection<Order>? Orders { get; set; }
        [JsonIgnore]
        public virtual ShoppingCart? ShoppingCart { get; set; }

        public Customer() { }

        public Customer(CustomerAccountViewModel accountViewModel)
        {
            FirstName = accountViewModel.FirstName;
            LastName = accountViewModel.LastName;
            Email = accountViewModel.Email;
            PhoneNumber = accountViewModel.PhoneNumber;
            Province = accountViewModel.Province;
            CreditCard = accountViewModel.CreditCard;
        }

        public static IEnumerable<Province> GetProvincesList()
        {
            List<Province> provinceList = new()
            {
                new Province { Code = "ON", Name = "Ontario" },
                new Province { Code = "QC", Name = "Quebec" },
                new Province { Code = "NB", Name = "New Brunswick" },
                new Province { Code = "MB", Name = "Manitoba" }
            };

            return provinceList;
        }

        public static SelectList GetProvincesSelectList()
        {
            return new SelectList(GetProvincesList(), "Code", "Name");
        }

        public static async Task RegisterCustomer(CustomerAccountViewModel account, UserManager<IdentityUser> _userManager, IUserStore<IdentityUser> _userStore, IUserEmailStore<IdentityUser> _emailStore)
        {
            var user = Activator.CreateInstance<IdentityUser>();

            if (await _userStore.FindByNameAsync(account.Email.ToUpper(), CancellationToken.None) == null)
                await _userStore.SetUserNameAsync(user, account.Email, CancellationToken.None);

            if (await _emailStore.FindByEmailAsync(account.Email.ToUpper(), CancellationToken.None) == null)
                await _emailStore.SetEmailAsync(user, account.Email, CancellationToken.None);

            var result = await _userManager.CreateAsync(user, account.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Customer");
            }
        }


    }
}

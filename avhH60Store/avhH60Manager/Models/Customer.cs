using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace avhH60Manager.Models
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


    }
}

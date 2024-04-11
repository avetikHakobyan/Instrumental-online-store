using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace avhH60Manager.Models
{
    public partial class ProductCategory
    {
        public int CategoryId { get; set; }
        [Display(Name = "Category")]
        [DataType(DataType.Text)]
        [StringLength(60, ErrorMessage = "Category must be at most 60 characters")]
        public string ProdCat { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }

        public ProductCategory()
        {
            Products = new HashSet<Product>();
        }
    }
}

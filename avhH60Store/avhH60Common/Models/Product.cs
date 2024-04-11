using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace avhH60Common.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Please select a category")]
        [DisplayName("Category")]
        public int ProdCatId { get; set; }

        [DataType(DataType.Text)]
        [StringLength(80, ErrorMessage = "Description must be at most 80 characters")]
        public string? Description { get; set; }

        [DataType(DataType.Text)]
        [StringLength(80, ErrorMessage = "Manufacturer must be at most 80 characters")]
        public string? Manufacturer { get; set; }

        [Required]
        public int Stock { get; set; }

        [DisplayName("Buy Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? BuyPrice { get; set; }

        [DisplayName("Sell Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? SellPrice { get; set; }

        [DisplayName("Category")]
        public virtual ProductCategory? ProdCat { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<CartItem>? CartItems { get; set; }
        [JsonIgnore]
        public virtual ICollection<OrderItem>? OrderItems { get; set; }

        public Product()
        {
        }
    }
}

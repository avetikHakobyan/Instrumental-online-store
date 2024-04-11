using avhH60Manager.Models;
using System.ComponentModel.DataAnnotations;

namespace avhH60Manager.DTO
{
    public class ProductCartDTO
    {
        public int ProductId { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
        public int Stock { get; set; }
        [Display(Name = "Sell Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? SellPrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Quantity should be a number greater than 1")]
        public int Quantity { get; set; }

        public ProductCartDTO()
        {
        }

        public ProductCartDTO(Product product)
        {
            ProductId = product.ProductId;
            CategoryName = product.ProdCat.ProdCat;
            Description = product.Description;
            Manufacturer = product.Manufacturer;
            Stock = product.Stock;
            SellPrice = product.SellPrice;
        }
    }
}

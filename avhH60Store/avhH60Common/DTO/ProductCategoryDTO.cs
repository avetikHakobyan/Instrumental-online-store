using avhH60Common.Models;

namespace avhH60Common.DTO
{
    public class ProductCategoryDTO
    {
        public int CategoryId { get; set; }
        public string ProdCat { get; set; } = null!;
        public ICollection<Product>? Products { get; set; }
        public ProductCategoryDTO()
        {
        }

        public ProductCategoryDTO(ProductCategory productCategory)
        {
            CategoryId = productCategory.CategoryId;
            ProdCat = productCategory.ProdCat;
            Products = productCategory.Products;
        }


    }
}

using avhH60Manager.Models;

namespace avhH60Manager.DTO
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

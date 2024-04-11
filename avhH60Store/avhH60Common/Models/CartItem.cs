using Microsoft.EntityFrameworkCore;

namespace avhH60Common.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }
        public int ShoppingCartId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Precision(8,2)]
        public decimal Price { get; set; }
        public virtual Product? Product { get; set; }
    }
}

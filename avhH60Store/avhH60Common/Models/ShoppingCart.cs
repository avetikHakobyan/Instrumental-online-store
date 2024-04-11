using System.ComponentModel.DataAnnotations;

namespace avhH60Common.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime DateCreated { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual IEnumerable<CartItem> CartItems { get; set; }
    }
}

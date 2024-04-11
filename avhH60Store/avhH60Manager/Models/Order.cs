using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace avhH60Manager.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        public DateTime? DateCreated { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DateFulfilled { get; set; }
        public decimal? Total { get; set; }
        public decimal? Taxes { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}

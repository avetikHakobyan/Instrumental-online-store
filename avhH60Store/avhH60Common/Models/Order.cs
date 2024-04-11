using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace avhH60Common.Models
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
        [Precision(10, 2)]
        public decimal? Total { get; set; }
        [Precision(8, 2)]
        public decimal? Taxes { get; set; }
        public virtual ICollection<OrderItem>? OrderItems { get; set; }
        public virtual Customer? Customer { get; set; }
    }
}

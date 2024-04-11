﻿using Microsoft.EntityFrameworkCore;

namespace avhH60Common.Models
{
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [Precision(8, 2)]
        public decimal Price { get; set; }

        public virtual Product? Product { get; set; }
    }
}

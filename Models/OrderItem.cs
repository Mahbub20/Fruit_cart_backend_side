using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fruit_cart_backend.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Price at the time of purchase
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        // public Order Order { get; set; } = null!;
        // public Product Product { get; set; } = null!;
    }
}
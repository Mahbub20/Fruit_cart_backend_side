using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fruit_cart_backend.Dtos
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Price at the time of purchase
        public decimal TotalPrice { get; set; }
    }
}
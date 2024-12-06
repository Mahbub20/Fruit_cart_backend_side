using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fruit_cart_backend.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public decimal? PaymentAmount { get; set; }
        public string PaymentStatus { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Models;

namespace fruit_cart_backend.Dtos
{
    public class OrderRequestDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>(); 
        public decimal SubTotal { get; set; }   
        public decimal TotalAmount { get; set; }
        public decimal PaymentAmount { get; set; }
    }
}
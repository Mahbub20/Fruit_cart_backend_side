using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using fruit_cart_backend.Data;
using fruit_cart_backend.Dtos;
using Microsoft.EntityFrameworkCore;

namespace fruit_cart_backend.Services.orders
{
    public class OrderService : IOrderService
    {
        private readonly EComDBContext _context;
        public OrderService(EComDBContext context)
        {
            _context = context;
        }
        public async Task<List<OrderDto>> GetOrders()
        {
            var orders = await (from order in _context.Orders
                                join payment in _context.PaymentDetails on order.Id equals payment.OrderId
                                select new OrderDto
                                {
                                    Id = order.Id,
                                    CustomerName = payment != null ? payment.CustomerName : "N/A",
                                    CustomerEmail = payment != null ? payment.CustomerEmail : "N/A",
                                    PaymentAmount = payment.PaymentAmount != null ? payment.PaymentAmount : 0,
                                    PaymentStatus = payment.PaymentStatus ?? "Pending",
                                    SubTotal = order.SubTotal,
                                    TotalAmount = order.TotalAmount,
                                    CreatedAt = order.CreatedAt,
                                    OrderItems = (from item in _context.OrderItems
                                                  where item.OrderId == order.Id
                                                  select new OrderItemDto
                                                  {
                                                      Id = item.Id,
                                                      Name = item.ProductName, 
                                                      Quantity = item.Quantity,
                                                      UnitPrice = item.UnitPrice,
                                                      TotalPrice = item.TotalPrice
                                                  }).ToList()
                                }).OrderByDescending(x=>x.Id).ToListAsync();

            // var log = orders.ToString(); // For checking the raw query in VS Code.
            // Console.WriteLine("Query log: "+log);


            return orders;
        }
    }
}
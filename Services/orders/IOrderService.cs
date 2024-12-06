using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Dtos;

namespace fruit_cart_backend.Services.orders
{
    public interface IOrderService
    {
        Task<List<OrderDto>> GetOrders();
    }
}
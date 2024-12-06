using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Services.orders;
using Microsoft.AspNetCore.Mvc;

namespace fruit_cart_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("get_orders")]
        public async Task<IActionResult> GetOrdersAsync()
        {
            var orders = await _orderService.GetOrders();
            return Ok(orders);
        }
    }
}
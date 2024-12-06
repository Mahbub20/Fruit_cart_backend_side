using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Data;
using fruit_cart_backend.Dtos;
using fruit_cart_backend.Models;
using fruit_cart_backend.Services.payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stripe;

namespace fruit_cart_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckoutController : ControllerBase
    {
        private readonly EComDBContext _context;
        private readonly IPaymentService _paymentService;

        public CheckoutController(EComDBContext context, IPaymentService paymentService)
        {
            _context = context;
            _paymentService = paymentService;
        }
        [HttpPost]
        [Route("process_order")]
        public async Task<IActionResult> ProcessOrder([FromBody] OrderRequestDto request)
        {

            var productIds = request.OrderItems.Select(ci => ci.ProductId).ToList();
            var products = await _context.Products.Where(p => productIds.Contains(p.Id)).ToListAsync();

            // Process payment using Stripe
            var paymentClientSecret = await _paymentService.ProcessPaymentAsync(request);
            if (paymentClientSecret == null)
                return StatusCode(500, "Payment failed.");

            // Create and save order
            var order = new Order
            {
                SubTotal = request.SubTotal,
                TotalAmount = request.TotalAmount,
                // PaymentStatus = "Completed",
                // PaymentIntentId = paymentClientSecret,
                CreatedAt = DateTime.UtcNow,
            };

            foreach (var item in request.OrderItems)
            {
                order.OrderItems.Add(new OrderItem
                {
                    ProductName = item.Name,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = products.First(p => p.Id == item.ProductId).Price,
                    TotalPrice = item.TotalPrice
                });

                // Update stock
                // var product = products.First(p => p.ProductId == item.ProductId);
                // product.Stock -= item.Quantity;
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            //Save payment details
            var paymentDetails = new PaymentDetails
            {
                OrderId = order.Id,
                CustomerName = request.UserName,
                CustomerEmail = request.UserEmail,
                PaymentAmount = request.PaymentAmount,
                PaymentStatus = "Completed",
                StripeClientSecret = paymentClientSecret
            };

            _context.PaymentDetails.Add(paymentDetails);
            await _context.SaveChangesAsync();

            return Ok(new { clientSecret = paymentClientSecret });
        }

    }
}
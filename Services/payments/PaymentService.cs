using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Dtos;

namespace fruit_cart_backend.Services.payments
{
    public class PaymentService : IPaymentService
    {
        public async Task<string?> ProcessPaymentAsync(OrderRequestDto reqDto, string currency = "usd")
        {
            var options = new Stripe.PaymentIntentCreateOptions
            {
                Amount = (long)(reqDto.PaymentAmount * 100), // Stripe expects the amount in cents
                Currency = currency,
                PaymentMethodTypes = new List<string> { "card" },
            };

            var service = new Stripe.PaymentIntentService();
            var paymentIntent = await service.CreateAsync(options);
            return paymentIntent.ClientSecret;
        }
    }
}
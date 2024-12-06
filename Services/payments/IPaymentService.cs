using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Dtos;

namespace fruit_cart_backend.Services.payments
{
    public interface IPaymentService
    {
        Task<string?> ProcessPaymentAsync(OrderRequestDto reqDto, string currency = "usd");
    }
}
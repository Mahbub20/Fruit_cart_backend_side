using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Dtos;

namespace fruit_cart_backend.Services.products
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
    }
}
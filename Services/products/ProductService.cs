using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fruit_cart_backend.Data;
using fruit_cart_backend.Dtos;
using Microsoft.EntityFrameworkCore;

namespace fruit_cart_backend.Services.products
{
    public class ProductService : IProductService
    {
        private readonly EComDBContext _context;
        public ProductService(EComDBContext context)
        {
            _context = context;
        }
        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _context.Products.Select(x=>new ProductDto{
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price,
                Quantity = x.Quantity,
                Stock = x.Stock,
                Image = x.Image,
            }).ToListAsync();
            return products;
        }
    }
}
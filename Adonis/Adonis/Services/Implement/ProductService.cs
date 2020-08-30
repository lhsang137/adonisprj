using Adonis.Models;
using Adonis.Models.Entities;
using Adonis.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonis.Services.Implement
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> CreateProduct(Product product)
        {
            _context.Products.Add(product);
            var created = await _context.SaveChangesAsync();

            return created > 0;
        }

        public async Task<Product> GetById(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<bool> DeleteProduct(int id)
        {
           
            var product = await GetById(id);

            if (product is null)
            {
                return false;
            }

            _context.Products.Remove(product);
            var deleted = await _context.SaveChangesAsync();

            return deleted > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            var updated = await _context.SaveChangesAsync();
            return updated > 0;

        }
    }
}

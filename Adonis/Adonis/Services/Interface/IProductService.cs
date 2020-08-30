using Adonis.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adonis.Services.Interface
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProduct();

        Task<Product> GetById(int id);

        Task<bool> CreateProduct(Product product);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(int id);
    }
}

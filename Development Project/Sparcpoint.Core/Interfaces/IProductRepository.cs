using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sparcpoint.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<List<Product>> GetProductsWithMetadata(List<string> metadata);
        Task<Product> AddProduct(Product product);
        Task<List<Product>> AddProducts(List<Product> products);
    }
}

using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sparcpoint.Interfaces
{
    public interface IProductService
    {
        public Task<List<Product>> GetProducts();
        public Task<List<Product>> GetProductsWithMetadata(List<string> metadata);
        public Task<Product> AddProduct(Product product);
        public Task<List<Product>> AddProducts(List<Product> products);
    }
}

using Sparcpoint.Interfaces;
using Sparcpoint.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sparcpoint.Services
{
    public class ProductService : IProductService
    {
        public ProductService(IProductService productService)
        {
            _productService = productService;
        }

        private readonly IProductService _productService;

        public async Task<List<Product>> GetProducts() => await _productService.GetProducts();

        public async Task<List<Product>> GetProductsWithMetadata(List<string> metadata) => await _productService.GetProductsWithMetadata(metadata);

        public async Task<Product> AddProduct(Product product) => await _productService.AddProduct(product);

        public async Task<List<Product>> AddProducts(List<Product> products) => await _productService.AddProducts(products);
    }
}

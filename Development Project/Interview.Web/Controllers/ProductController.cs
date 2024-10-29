using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sparcpoint.Models;
using Sparcpoint.Interfaces;

namespace Interview.Web.Controllers
{
    [Route("api/v1/products")]
    public class ProductController : Controller
    {
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        private IProductService _productService;
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productService.GetProducts();
        }

        [HttpGet("metadata")]
        public async Task<List<Product>> GetProductsWithMetadata(List<string> metadata)
        {
            return await _productService.GetProductsWithMetadata(metadata);
        }

        [HttpPost("single")]
        public async Task<Product> AddProduct(Product product)
        {
            return await _productService.AddProduct(product);
        }

        [HttpPost("multiple")]
        public async Task<List<Product>> AddProduct(List<Product> products)
        {
            return await _productService.AddProducts(products);
        }
    }
}

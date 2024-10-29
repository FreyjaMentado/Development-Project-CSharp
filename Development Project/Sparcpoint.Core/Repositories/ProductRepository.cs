using Sparcpoint.Interfaces;
using Sparcpoint.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace Sparcpoint.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductService(ProductDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly ProductDbContext _dbContext;

        public async Task<List<Product>> GetProducts()
        {
            return await _dbContext.Products
                .Include(p => p.Categories)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsWithMetadata(List<string> metadata)
        {
            return await _dbContext.Products
                .Include(p => p.Categories)
                .Where(product => product.Metadata.Any(metaData => metadata.Contains(metadata)))
                .ToListAsync();
        }

        public async Task<Product> AddProduct(Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Products 
                .Include(p => p.Categories)
                .SingleAsync(p => p.Id == product.Id);
        }

        public async Task<List<Product>> AddProducts(List<Product> products)
        {
            var productIds = products.Select(product => product.Id).ToList();
            await _dbContext.Products.AddRangeAsync(products);
            await _dbContext.SaveChangesAsync();
            return await _dbContext.Products
                .Include(p => p.Categories)
                .Where(product => productIds.Contains(product.Id))
                .ToListAsync();
        }
    }
}

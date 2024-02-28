using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Products.Domain.Entities;
using VictorVentral.Products.Domain.Interfaces.Repositories.Products;
using VictorVentral.Products.Infrastructure.Persistence.Context;

namespace VictorVentral.Products.Infrastructure.Repositories.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext _productsDbContext;

        public ProductRepository(ProductsDbContext productsDbContext)
        {
            _productsDbContext = productsDbContext;
        }

        public async Task<Product> AddAsync(Product product)
        {
            await _productsDbContext.Products.AddAsync(product);
            await _productsDbContext.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _productsDbContext.Products.FindAsync(id);
            _productsDbContext.Set<Product>().Remove(product);
            await _productsDbContext.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productsDbContext.Set<Product>().ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productsDbContext.Set<Product>().FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _productsDbContext.Entry(product).State = EntityState.Modified;
            await _productsDbContext.SaveChangesAsync();
        }
    }
}

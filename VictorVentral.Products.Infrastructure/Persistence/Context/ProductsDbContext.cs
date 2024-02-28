using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Products.Domain.Entities;

namespace VictorVentral.Products.Infrastructure.Persistence.Context
{
    public interface IProductsDbContext : IDbContext { }

    public class ProductsDbContext : DbContext
    {
        public ProductsDbContext(DbContextOptions<ProductsDbContext> options) : base(options) {}

        public DbSet<Product> Products { get; set; }
    }
}

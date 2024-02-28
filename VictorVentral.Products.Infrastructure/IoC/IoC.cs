using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Products.Domain.Interfaces.Repositories.Products;
using VictorVentral.Products.Infrastructure.Repositories.Products;

namespace VictorVentral.Products.Infrastructure.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IProductRepository, ProductRepository>();
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Products.Application.Products.Interfaces;
using VictorVentral.Products.Application.Products.Services;

namespace VictorVentral.Products.Application.IoC
{
    public static class IoC
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            return services
                .AddScoped<IProductService, ProductService>();
        }
    }
}

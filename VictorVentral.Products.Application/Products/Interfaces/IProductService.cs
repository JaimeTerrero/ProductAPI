using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Products.Application.Products.DTOs;
using VictorVentral.Products.Domain.Entities;

namespace VictorVentral.Products.Application.Products.Interfaces
{
    public interface IProductService : IService<Product, ProductDto>
    {
    }
}

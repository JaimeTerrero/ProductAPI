using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VictorVentral.Products.Application.Products.DTOs
{
    public class ProductDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float UnitPrice { get; set; }
        public int AvailableStock { get; set; }
        public string Category { get; set; }
    }
}

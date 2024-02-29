using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VictorVentral.Products.Application.Products.DTOs;
using VictorVentral.Products.Application.Products.Interfaces.Products;
using VictorVentral.Products.Domain.Entities;
using VictorVentral.Products.Domain.Interfaces.Repositories.Products;

namespace VictorVentral.Products.Application.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<Product> Add(ProductDto productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            await _productRepository.AddAsync(product);
            return product;
        }

        public async Task Delete(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<List<Product>> GetAll()
        {
            var productList = await _productRepository.GetAllAsync();

            return productList;
        }

        public async Task<Product> GetById(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);

            Product pr = new();
            pr.Id = product.Id;
            pr.Name = product.Name;
            pr.Description = product.Description;
            pr.UnitPrice = product.UnitPrice;
            pr.AvailableStock = product.AvailableStock;
            pr.Category = product.Category;

            return pr;
        }

        public async Task Update(int id, ProductDto productDto)
        {
            Product product = await _productRepository.GetByIdAsync(id);

            _mapper.Map(productDto, product);

            await _productRepository.UpdateAsync(product);
        }
    }
}

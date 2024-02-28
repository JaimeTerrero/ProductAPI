using Microsoft.AspNetCore.Mvc;
using VictorVentral.Products.Application.Products.DTOs;
using VictorVentral.Products.Application.Products.Interfaces;

namespace VictorVentral.Products.Api.Controllers.Products
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<ActionResult> GetAllProducts()
        {
            var product = await _productService.GetAll();

            return Ok(product);
        }

        [HttpPost("CreateProduct")]
        public async Task<ActionResult> CreateProduct(ProductDto productDto)
        {
            var product = await _productService.Add(productDto);

            return Ok(product);
        }

        [HttpGet("GetProductById/{id:int}")]
        public async Task<ActionResult> GetProductById(int id)
        {
            var product = await _productService.GetById(id);

            return Ok(product);
        }

        [HttpPut("UpdateProduct/{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, ProductDto productDto)
        {
            await _productService.Update(id, productDto);

            return NoContent();
        }

        [HttpDelete("DeleteProduct/{id:int}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            await _productService.Delete(id);

            return NoContent();
        }
    }
}

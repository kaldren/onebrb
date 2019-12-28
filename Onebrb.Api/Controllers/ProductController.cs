using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductController(IProductRepository productRepository, ILogger<ProductController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _productRepository = productRepository;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Profile>> CreateProductAsync([FromBody] Product product)
        {
            Product productCreated = await _productRepository.CreateProductAsync(product);

            return CreatedAtAction(nameof(GetProductByIdAsync), productCreated);
        }

        public async Task<ActionResult<Profile>> GetProductByIdAsync(Product product)
        {
            var productFetched = await _productRepository.GetProductAsync(product.ProductId);

            return Ok(productFetched);
        }
    }
}

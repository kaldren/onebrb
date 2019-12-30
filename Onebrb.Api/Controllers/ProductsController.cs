using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onebrb.Core.Entities;
using Onebrb.Core.Interfaces;
using Onebrb.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AutoMapper.IMapper _mapper;

        public ProductsController(IProductRepository productRepository, 
                                 ILogger<ProductsController> logger, 
                                 IHttpContextAccessor httpContextAccessor,
                                 AutoMapper.IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<Profile>> CreateProductAsync([FromBody] Product product)
        {
            Product productCreated = await _productRepository.CreateProductAsync(product);

            return CreatedAtAction(nameof(GetProductByIdAsync), productCreated);
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductModel>> GetProductByIdAsync(int productId)
        {
            Product product = await _productRepository.GetProductAsync(productId);

            return _mapper.Map<ProductModel>(product);
        }
    }
}

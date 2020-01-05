using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Onebrb.Core.Entities;
using Onebrb.Core.Exceptions;
using Onebrb.Core.Interfaces;
using Onebrb.Core.Interfaces.Repos;
using Onebrb.Core.Models;
using Onebrb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onebrb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductsController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _dbContext;
        private readonly AutoMapper.IMapper _mapper;

        public ProductsController(IProductRepository productRepository, 
                                 ILogger<ProductsController> logger, 
                                 IHttpContextAccessor httpContextAccessor,
                                 ApplicationDbContext dbContext,
                                 AutoMapper.IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ProductModel>> CreateProductAsync([FromBody] ProductModel product)
        {
            try
            {
                ApplicationUser owner = await _dbContext.Users.FindAsync(product.UserId);
                Category category = await _dbContext.Categories.FindAsync(product.CategoryId);

                if (owner == null)
                {
                    _logger.LogWarning($"Owner with Id {product.UserId} doesn't exist.");
                    return BadRequest();
                }

                if (category == null)
                {
                    _logger.LogWarning($"Category with Id {product.CategoryId} doesn't exist.");
                    return BadRequest();
                }

                Product productToCreate = _mapper.Map<Product>(product);

                productToCreate.Owner = owner;
                productToCreate.Category = category;

                int entriesCreated = await _productRepository.CreateProductAsync(productToCreate);

                if (entriesCreated == 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }

                ProductModel productModel = _mapper.Map<ProductModel>(productToCreate);

                return CreatedAtRoute(nameof(GetProductByIdAsync), new { productId = productToCreate.Id }, productModel);
            }
            catch (CouldNotCreateProductException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{productId}", Name = "GetProductByIdAsync")]
        public async Task<ActionResult<ProductModel>> GetProductByIdAsync(int productId)
        {
            Product product = await _productRepository.GetProductAsync(productId);

            return _mapper.Map<ProductModel>(product);
        }
    }
}

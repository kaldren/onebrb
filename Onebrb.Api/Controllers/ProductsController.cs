﻿using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<Profile>> CreateProductAsync([FromBody] Product product)
        {
            try
            {
                ApplicationUser owner = await _dbContext.Users.FirstOrDefaultAsync(u => u.Id == product.Owner.Id);
                Category category = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == product.Category.Id);

                if (owner == null)
                {
                    _logger.LogWarning($"Owner with Id {product.Owner.Id} doesn't exist.");
                    return BadRequest();
                }

                if (category == null)
                {
                    _logger.LogWarning($"Category with Id {product.Category.Id} doesn't exist.");
                    return BadRequest();
                }

                product.Owner = owner;
                product.Category = category;

                Product productCreated = await _productRepository.CreateProductAsync(product);
                return Created(nameof(GetProductByIdAsync), productCreated);
            }
            catch (CouldNotCreateProductException ex)
            {
                _logger.LogError(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{productId}")]
        public async Task<ActionResult<ProductModel>> GetProductByIdAsync(int productId)
        {
            Product product = await _productRepository.GetProductAsync(productId);

            return _mapper.Map<ProductModel>(product);
        }
    }
}

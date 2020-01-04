using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Onebrb.Core.Entities;
using Onebrb.Core.Exceptions;
using Onebrb.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Onebrb.Core.Enumerations;
using Onebrb.Core.Models;
using Microsoft.Extensions.Configuration;
using Onebrb.Core.Interfaces.Repos;

namespace Onebrb.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ILogger<ProfilesController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _config;
        private readonly AutoMapper.IMapper _mapper;

        public ProfilesController(IProfileRepository profileRepository, 
                                  ILogger<ProfilesController> logger, 
                                  IHttpContextAccessor httpContextAccessor,
                                  IProductRepository productRepository,
                                  IConfiguration config,
                                  AutoMapper.IMapper mapper)
        {
            _profileRepository = profileRepository;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _config = config;
            _mapper = mapper;
        }

        [HttpGet("{profileId:int}")]
        public async Task<ActionResult<ProfileModel>> Get(int profileId)
        {
            ApplicationUser profile = await _profileRepository.GetProfileAsync(profileId);

            return (profile == null) ? null : _mapper.Map<ProfileModel>(profile);
        }

        [HttpGet("{nickname}")]
        public async Task<ActionResult<ProfileModel>> GetProfileByNickname(string nickname)
        {
            ApplicationUser profile = await _profileRepository.GetProfileAsync(nickname);

            if (profile == null) 
            {
                return BadRequest("Invalid username");
            }

            return Ok(_mapper.Map<ProfileModel>(profile));
        }

        [HttpGet("{nickname}/products")]
        public async Task<IEnumerable<ProductModel>> GetAllProducts(string nickname)
        {
            IEnumerable<Product> allProducts =  await _productRepository.GetAllProductsAsync(nickname);

            return (allProducts == null) ? null : _mapper.Map<IEnumerable<ProductModel>>(allProducts);
        }
    }
}

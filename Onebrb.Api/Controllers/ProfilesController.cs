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

namespace Onebrb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        private readonly ILogger<ProfilesController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProductRepository _productRepository;
        private readonly AutoMapper.IMapper _mapper;

        public ProfilesController(IProfileRepository profileRepository, 
                                  ILogger<ProfilesController> logger, 
                                  IHttpContextAccessor httpContextAccessor,
                                  IProductRepository productRepository,
                                  AutoMapper.IMapper mapper)
        {
            _profileRepository = profileRepository;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("{profileId:int}")]
        public async Task<ActionResult<ProfileModel>> Get(int profileId)
        {
            try
            {
                Profile profile = await _profileRepository.GetProfileAsync(profileId);
                string ipAddress = HttpContext.Connection.RemoteIpAddress.ToString();

                if (profile == null)
                {
                    _logger.LogWarning($"{ipAddress}: Couldn't fetch profile with id {profileId}");
                    return StatusCode(StatusCodes.Status404NotFound, "Profile not found");
                }

                string currUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _logger.LogInformation($"Currently logged in user id {currUserId}");

                if (currUserId != null && int.TryParse(currUserId, out int userIdNumeric) && userIdNumeric == profileId)
                {
                    profile.ProfileType = ProfileTypeEnum.OwnProfile;
                }
                else
                {
                    profile.ProfileType = ProfileTypeEnum.NotOwnProfile;
                }

                return _mapper.Map<ProfileModel>(profile);
            }
            catch (CouldNotGetProfileException ex)
            {
                _logger.LogWarning($"Couldn't get profile with id {profileId}", ex.StackTrace);
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        public async Task<ActionResult<ProfileModel>> GetProfileByNickname(string nickname)
        {
            Profile profile = await _profileRepository.GetProfileAsync(nickname);

            return (profile == null) ? null : _mapper.Map<ProfileModel>(profile);
        }

        [HttpGet("{nickname}/products")]
        public async Task<IEnumerable<ProductModel>> GetAllProducts(string nickname)
        {
            IEnumerable<Product> allProducts =  await _productRepository.GetAllProductsAsync(nickname);

            return (allProducts == null) ? null : _mapper.Map<IEnumerable<ProductModel>>(allProducts);
        }
    }
}

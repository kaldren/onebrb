using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IList<CategoryModel>>> GetAllCategoriesAsync()
        {
            var category = await _categoryRepository.GetAllCategoriesAsync();

            return _mapper.Map<List<CategoryModel>>(category);
        }
    }
}

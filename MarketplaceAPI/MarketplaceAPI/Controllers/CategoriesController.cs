using AutoMapper;
using MarketplaceAPI.Data;
using MarketplaceAPI.Dtos;
using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController<Category, ICategoriesRepository>
    {
        private readonly IMapper _mapper;

        public CategoriesController(ICategoriesRepository repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        // POST: api/[controller]
        [HttpPost]
        public  async Task<IActionResult> Add(CategoryForAddDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);

            await _repository.Add(category);
            return Ok();
        }
    }
}

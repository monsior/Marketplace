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
        public CategoriesController(ICategoriesRepository repository) : base(repository){}

        // POST: api/[controller]
        [HttpPost]
        public  async Task<IActionResult> Add(CategoryForAddDto categoryForAdd)
        {
            var createdCategory = new Category
            {
                Name = categoryForAdd.Name
            };

            await _repository.Add(createdCategory);
            return Ok(createdCategory);
        }
    }
}

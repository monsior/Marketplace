using AutoMapper;
using MarketplaceAPI.Data;
using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Controllers
{
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController<TEntity, TDto, TRepository> : ControllerBase
        where TEntity : class
        where TDto : class
        where TRepository : IBaseRepository<TEntity>
    {
        private readonly TRepository _repository;
        private IMapper _mapper;

        public BaseController(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);

            await _repository.Add(entity);

            return Ok();
        }

        // GET: api/[controller]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<TDto>>> Get()
        {
            var entities = await _repository.GetAll();
            var dto = _mapper.Map<IEnumerable<TDto>>(entities);

            return Ok(dto);
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<TDto>> Get(int id)
        {
            var entity = await _repository.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            var dto = _mapper.Map<TDto>(entity);

            return Ok(dto);
        }

    }
}

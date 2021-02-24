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
    public abstract class BaseController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity
        where TRepository : IBaseRepository<TEntity>
    {
        protected readonly TRepository _repository;

        public BaseController(TRepository repository)
        {
            _repository = repository;
        }

        // GET: api/[controller]
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return Ok(await _repository.GetAll());
        }

        // GET: api/[controller]/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await _repository.Get(id);

            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

    }
}

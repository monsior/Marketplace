using AutoMapper;
using MarketplaceAPI.Data;
using MarketplaceAPI.Dtos;
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

    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class AuctionsController : BaseController<Auction, IAuctionsRepository>
    {
        private readonly IMapper _mapper;

        public AuctionsController(IAuctionsRepository repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AuctionDto auctionDto)
        {
            var auction = _mapper.Map<Auction>(auctionDto);

            await _repository.Add(auction);

            return Ok();
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            return Ok(await _repository.GetByCategory(categoryId));
        }
        
        [HttpGet("page/{pageNumber}")]
        public async Task<ActionResult<IEnumerable<Auction>>> GetByPage(int pageNumber)
        {
            return Ok(await _repository.GetAll(pageNumber));
        }
    }
}

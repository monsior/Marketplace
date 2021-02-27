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
    public class AuctionsController : BaseController<Auction, AuctionDto, IAuctionsRepository>
    {
        private readonly IAuctionsRepository _repository;
        private IMapper _mapper;

        public AuctionsController(IAuctionsRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        
        [HttpGet("page/{pageNumber}")]
        public async Task<ActionResult<IEnumerable<AuctionDto>>> GetByPage(int pageNumber)
        {
            var auctions = await _repository.GetAll(pageNumber);

            var auctionsDto = _mapper.Map<IEnumerable<AuctionDto>>(auctions);

            return Ok(auctionsDto);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            var auctions = await _repository.GetByCategory(categoryId);

            var auctionsDto = _mapper.Map<IEnumerable<AuctionDto>>(auctions);

            return Ok(auctionsDto);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUser(int userId)
        {
            var auctions = await _repository.GetByUser(userId);

            var auctionsDto = _mapper.Map<IEnumerable<AuctionDto>>(auctions);

            return Ok(auctionsDto);
        }
    }
}

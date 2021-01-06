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
    public class AuctionsController : ControllerBase
    {
        private readonly IAuctionsRepository _repository;

        public AuctionsController(IAuctionsRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddAuction(AuctionToAddDto auctionToAddDto)
        {
            var auctionToCreate = new Auction()
            {
                Name = auctionToAddDto.Name,
                AddDate = DateTime.Now,
                CategoryId = auctionToAddDto.CategoryId,
                Description = auctionToAddDto.Description
            };

            await _repository.Add(auctionToCreate);

            return Ok(auctionToCreate);
        }
    }
}

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
        public AuctionsController(IAuctionsRepository auctionsRepository) : base(auctionsRepository) {}

        [HttpPost]
        public async Task<IActionResult> Add(AuctionForAddDto auctionForAdd)
        {
            var createdAuction = new Auction()
            {
                Name = auctionForAdd.Name,
                AddDate = auctionForAdd.AddDate,
                CategoryId = auctionForAdd.CategoryId,
                Description = auctionForAdd.Description,
                Price = auctionForAdd.Price,
                City = auctionForAdd.City,
                UserId = auctionForAdd.UserId
            };

            await _repository.Add(createdAuction);

            return Ok(createdAuction);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategory(int categoryId)
        {
            return Ok(await _repository.GetByCategory(categoryId));
        }
    }
}

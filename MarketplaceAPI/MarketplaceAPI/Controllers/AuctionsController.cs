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
        public AuctionsController(IAuctionsRepository repository) : base(repository){}

        [HttpPost]
        public override async Task<IActionResult> Add(Auction auction)
        {
            var auctionToCreate = new Auction()
            {
                Name = auction.Name,
                AddDate = DateTime.Now,
                CategoryId = auction.CategoryId,
                Description = auction.Description
            };

            await _repository.Add(auctionToCreate);

            return Ok(auctionToCreate);
        }
    }
}

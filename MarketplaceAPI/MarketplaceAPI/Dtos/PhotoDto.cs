using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Dtos
{
    public class PhotoDto
    {
        public int Id { get; set; }
        public string PublicId { get; set; }
        public string Url { get; set; }
        public IFormFile File { get; set; }
        public int AuctionId { get; set; }
    }
}

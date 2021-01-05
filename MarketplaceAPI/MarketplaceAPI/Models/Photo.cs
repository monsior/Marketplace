using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Models
{
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int AuctionId { get; set; }
        public Auction Auction { get; set; }
    }
}

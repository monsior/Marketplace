using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Models
{
    public class Photo : IEntity
    {
        public int Id { get; set; }
        [Required]
        public string PublicId { get; set; }
        [Required]
        [Url]
        public string Url { get; set; }
        [Required]
        public int AuctionId { get; set; }
        [Required]
        public virtual Auction Auction { get; set; }
    }
}

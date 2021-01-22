using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Username { get; set; }
        [Required]
        [RegularExpression(@"/\(? ([0 - 9]{3})\)? ([ .-]?) ([0 - 9]{3})\2([0 - 9]{ 4})/")]
        public string Phone { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public virtual ICollection<Auction> Auctions { get; set; }
    }
}

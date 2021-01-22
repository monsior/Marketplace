using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Models
{
    public class Auction : IEntity
    {
        private readonly ILazyLoader _lazyLoader;

        public Auction()
        {
        }

        public Auction(ILazyLoader lazyLoader)
        {
            _lazyLoader = lazyLoader;
        }

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime AddDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public virtual Category Category { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public virtual User User { get; set; }
        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string City { get; set; }
        [Required]
        [Range(0, 999999999)]
        public string Price { get; set; }
        [Required]
        private List<Photo> _photos;
        [Required]
        public virtual List<Photo> Photos
        {
            get => _lazyLoader.Load(this, ref _photos);
            set => _photos = value;
        }

    }
}

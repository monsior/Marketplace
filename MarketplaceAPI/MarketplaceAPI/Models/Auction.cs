using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
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
        public string Name { get; set; }
        public DateTime AddDate { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Price { get; set; }
        private List<Photo> _photos;
        public virtual List<Photo> Photos
        {
            get => _lazyLoader.Load(this, ref _photos);
            set => _photos = value;
        }

    }
}

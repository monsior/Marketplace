using MarketplaceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Data
{
    public class PhotosRepository : BaseRepository<Photo>, IPhotosRepository
    {
        public PhotosRepository(AppDbContext context) : base(context) { }

        public async Task<Photo> GetFirstPhoto(int auctionId)
        {
            var photo = await _context.Photos.FirstOrDefaultAsync(a => a.AuctionId == auctionId);

            return photo;
        }
    }
}

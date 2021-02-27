using MarketplaceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Data
{
    public class AuctionsRepository : BaseRepository<Auction>, IAuctionsRepository
    {
        public AuctionsRepository(AppDbContext context) : base(context){}

        public async Task<IEnumerable<Auction>> GetAll(int pageNumber, int pageSize)
        {
            return await _context.Set<Auction>()
                .Skip((pageNumber*pageSize)-pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<IEnumerable<Auction>> GetByCategory(int categoryId)
        {
            var auctions = await _context.Auctions.Where(a => a.CategoryId == categoryId).ToListAsync();
            //var auctions = await GetAll(pageNumber, pageSize);
            //var categoryAuctions = auctions.Where(a => a.Category.Id == categoryId);

            return auctions;
        }

        public async Task<IEnumerable<Auction>> GetByUser(int userId)
        {
            var auctions = await _context.Auctions.Where(a => a.UserId == userId).ToListAsync();

            return auctions;
        }


    }
}

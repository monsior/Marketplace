using MarketplaceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Data
{
    public interface IAuctionsRepository : IBaseRepository<Auction>
    {
        Task<IEnumerable<Auction>> GetByCategory(Category category);
    }
}

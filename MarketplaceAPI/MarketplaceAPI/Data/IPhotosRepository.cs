using MarketplaceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Data
{
    public interface IPhotosRepository : IBaseRepository<Photo>
    {
        Task<Photo> GetFirstPhoto(int auctionId);
    }
}

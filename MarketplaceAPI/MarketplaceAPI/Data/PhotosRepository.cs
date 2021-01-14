using MarketplaceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Data
{
    public class PhotosRepository : BaseRepository<Photo>, IPhotosRepository
    {
        public PhotosRepository(AppDbContext context) : base(context) { }
    }
}

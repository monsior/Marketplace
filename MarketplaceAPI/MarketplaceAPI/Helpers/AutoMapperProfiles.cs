using AutoMapper;
using MarketplaceAPI.Dtos;
using MarketplaceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<AuctionDto, Auction>().ReverseMap();
            CreateMap<CategoryDto, Category>();
        }
    }
}

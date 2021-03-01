using MarketplaceAPI.Controllers;
using MarketplaceAPI.Data;
using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

//[assembly: TestFramework("MarketplaceAPI.Startup", "MarketplaceAPI")]
namespace MarketplaceTests
{

    public class AuctionRepositoryTests 
    {
        private void Seed(AppDbContext context)
        {
            Auction auction = new Auction()
            {
                Id = 0,
                Name = "test",
                AddDate = DateTime.Now,
                CategoryId = 0,
                UserId = 0,
                Description = "testt",
                City = "testtt",
                Price = "5"
            };

            context.AddRange(auction);
            context.SaveChanges();
        }

        private IAuctionsRepository GetInMemoryAuctionRepository()
        {
            DbContextOptions<AppDbContext> options;
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("TestDb");
            options = builder.Options;
            AppDbContext dbContext = new AppDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();
            return new AuctionsRepository(dbContext);
        }


        [Fact]
        public async Task Add_ShouldWork()
        {
            IAuctionsRepository sut = GetInMemoryAuctionRepository();
            Auction expected = new Auction()
            {
                Id = 0,
                Name = "test2",
                AddDate = DateTime.Now,
                CategoryId = 0,
                UserId = 0,
                Description = "testt",
                City = "testtt",
                Price = "5"
            };

            await sut.Add(expected);
            await sut.SaveAll();

            Auction actual = await sut.Get(-1);

            Assert.Equal(expected, actual);

        }
    }
}

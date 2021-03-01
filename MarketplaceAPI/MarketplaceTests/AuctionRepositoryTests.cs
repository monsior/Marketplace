using Bogus;
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

namespace MarketplaceTests
{

    public class AuctionRepositoryTests 
    {
        private Faker<Auction> testAuction { get; set; }

        private IAuctionsRepository GetInMemoryAuctionRepository()
        {
            DbContextOptions<AppDbContext> options;
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase("TestDb");
            options = builder.Options;
            AppDbContext dbContext = new AppDbContext(options);
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            testAuction = new Faker<Auction>()
                .RuleFor(a => a.Name, a => a.Vehicle.Model())
                // Gets a date from last 5 days
                .RuleFor(a => a.AddDate, a => a.Date.Recent(5))
                .RuleFor(a => a.CategoryId, a => a.Random.Int(0, 10))
                .RuleFor(a => a.UserId, a => a.Random.Int(0, 10))
                .RuleFor(a => a.Description, a => a.Lorem.Sentences(5))
                .RuleFor(a => a.City, a => a.Address.City())
                .RuleFor(a => a.Price, a => a.Random.Int(5000, 300000).ToString());

            return new AuctionsRepository(dbContext);
        }

        [Fact]
        public async void GetPaginated_ShouldWork()
        {
            // Arrange
            IAuctionsRepository sut = GetInMemoryAuctionRepository();

            IEnumerable<Auction> auctions = new List<Auction>()
            {
                testAuction.Generate(),
                testAuction.Generate(),
                testAuction.Generate(),
                testAuction.Generate(),
            };

            IEnumerable<Auction> expected = auctions.ToList().GetRange(2, 2);

            auctions.ToList().ForEach(async auction => {await sut.Add(auction);});
            await sut.SaveAll();

            // Act
            IEnumerable<Auction> actual = await sut.GetAll(2, 2);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}

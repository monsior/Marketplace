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

        private List<Auction> Populate(int items)
        {
            List<Auction> auctions = new List<Auction>();

            for (int i = 0; i < items; i++)
            {
                auctions.Add(testAuction.Generate());
            }

            return auctions;
        }

        private async Task AddToInMemory(IEnumerable<Auction> auctions, IAuctionsRepository sut)
        {
            auctions.ToList().ForEach(async auction => { await sut.Add(auction); });
            await sut.SaveAll();
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

            IEnumerable<Auction> auctions = Populate(4);

            IEnumerable<Auction> expected = auctions.ToList().GetRange(2, 2);

            await AddToInMemory(auctions, sut);

            // Act
            IEnumerable<Auction> actual = await sut.GetAll(2, 2);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void GetByCategory_ShouldWork()
        {
            // Arrange
            IAuctionsRepository sut = GetInMemoryAuctionRepository();

            IEnumerable<Auction> auctions = Populate(4);

            auctions.ToList().ForEach(a => a.CategoryId = 1);
            auctions.ToList().First().CategoryId = 0;

            IEnumerable<Auction> expected = auctions.ToList().GetRange(1, 3);

            await AddToInMemory(auctions, sut);

            // Act
            IEnumerable<Auction> actual = await sut.GetByCategory(1);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void GetByUser_ShouldWork()
        {
            // Arrange
            IAuctionsRepository sut = GetInMemoryAuctionRepository();

            IEnumerable<Auction> auctions = Populate(4);

            auctions.ToList().ForEach(a => a.UserId = 1);
            auctions.ToList().First().UserId = 0;

            IEnumerable<Auction> expected = auctions.ToList().GetRange(1, 3);

            await AddToInMemory(auctions, sut);

            // Act
            IEnumerable<Auction> actual = await sut.GetByUser(1);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}

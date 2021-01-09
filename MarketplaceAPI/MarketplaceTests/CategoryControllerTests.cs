using AutoFixture.Xunit2;
using MarketplaceAPI.Controllers;
using MarketplaceAPI.Data;
using MarketplaceAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

[assembly: TestFramework("MarketplaceAPI.Startup", "MarketplaceAPI")]
namespace MarketplaceTests
{

    public class CategoryControllerTests
    {
        private readonly CategoriesController _controller;
        private readonly Mock<ICategoriesRepository> _categoryMock = new Mock<ICategoriesRepository>();

        public CategoryControllerTests()
        {
            _controller = new CategoriesController(_categoryMock.Object);
        }

        [Theory, AutoData]
        public async Task Add_Should_Return_Ok(string expectedName)
        {
            Category category = new Category()
            {
                Name = expectedName
            };

            var response = await _controller.Add(category);

            Assert.IsType<OkObjectResult>(response);
        }
    }
}

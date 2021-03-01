using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketplaceAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace MarketplaceTests
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategoriesRepository, CategoriesRepository>();
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDb"));
        }
    }
}

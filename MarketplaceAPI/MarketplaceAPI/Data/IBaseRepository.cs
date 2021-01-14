using MarketplaceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketplaceAPI.Data
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> Add(T entity);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task<User> GetUser(int id);
    }
}

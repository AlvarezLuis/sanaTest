using sanaTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sanaTest.Services.Interfaces
{
    public interface IProductService
    {
        Task<Product> Add(Product product, Boolean useCache);
        Task<List<Product>> GetAll(Boolean useCache);
    }
}

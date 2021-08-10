using sanaTest.Models;
using sanaTest.Repositories.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sanaTest.Repositories.Interfaces
{
    public interface IProductRespository
    {
        Task<Product> Add(Product product);
        Task<List<Product>> GetAll();
    }

    public delegate IProductRespository ServiceResolver(RepositoryType repositoryType);
}

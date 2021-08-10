using Microsoft.EntityFrameworkCore;
using sanaTest.Data;
using sanaTest.Models;
using sanaTest.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sanaTest.Repositories
{
    public class ProductPersistenceRespository : IProductRespository
    {
        private readonly SanaContext sanaContext;

        public ProductPersistenceRespository(SanaContext sanaContext)
        {
            this.sanaContext = sanaContext;
        }

        public async Task<Product> Add(Product product)
        {
            await sanaContext.Set<Product>().AddAsync(product);
            await sanaContext.SaveChangesAsync();
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            return await sanaContext.Set<Product>().ToListAsync();
        }
    }
}


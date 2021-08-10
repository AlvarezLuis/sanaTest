using sanaTest.Models;
using sanaTest.Repositories.Enum;
using sanaTest.Repositories.Interfaces;
using sanaTest.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sanaTest.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRespository productRespositoryPersistence;
        private readonly IProductRespository productRespositoryInMemory;

        public ProductService(
            ServiceResolver productRespositoryPersistence,
            ServiceResolver productRespositoryInMemory)
        {
            this.productRespositoryPersistence = productRespositoryPersistence(RepositoryType.ProductPersistenceRespository);
            this.productRespositoryInMemory = productRespositoryInMemory(RepositoryType.ProductInMemoryRepository);
        }

        public async Task<Product> Add(Product product, Boolean useCache)
        {
            var productRepository = useCache ? productRespositoryInMemory : productRespositoryPersistence;
            return await productRepository.Add(product);
        }

        public async Task<List<Product>> GetAll(Boolean useCache)
        {
            
            
            var productRepository = useCache ? productRespositoryInMemory : productRespositoryPersistence;
            return await productRepository.GetAll();
        }
    }
}

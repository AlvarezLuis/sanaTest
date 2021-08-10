using Newtonsoft.Json;
using sanaTest.Models;
using sanaTest.Repositories.Interfaces;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sanaTest.Repositories
{
    public class ProductInMemoryRepository : IProductRespository
    {
        private readonly IConnectionMultiplexer _redis;
        private readonly IDatabase db;
        private const string PRODUTC = "product";

        public ProductInMemoryRepository(IConnectionMultiplexer redis)
        {
            _redis = redis;
            db = _redis.GetDatabase();
        }

        public async Task<Product> Add(Product product)
        {
            product.Id = GetNewId();
            await db.StringSetAsync(product.Id.ToString(), JsonConvert.SerializeObject(product));
            return product;
        }

        public async Task<List<Product>> GetAll()
        {
            var result = new List<Product>();
            var keys = GetAllKeys();
            string[] keysArr = keys.Select(key => (string)key).ToArray();
            result.AddRange(from string key in keysArr
                            select JsonConvert.DeserializeObject<Product>(db.StringGet(key)));
            return result;
        }

        private int GetNewId()
        {
            var result = GetAllKeys();
            return result.Count() + 1;
        }

        private IEnumerable<RedisKey> GetAllKeys()
        {
            var endpoints = _redis.GetEndPoints();
            var server = _redis.GetServer(endpoints.First());
            return (IEnumerable<RedisKey>)server.KeysAsync();
        }
    }
}

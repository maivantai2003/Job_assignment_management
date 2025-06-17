using Job_assignment_management.Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Job_assignment_management.Application.Services
{
    public class RedisService : IRedisService
    {
        private readonly IDistributedCache _distributedCache;
        public RedisService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;   
        }
        public async Task<T> GetCacheAsync<T>(string key)
        {
            var cacheValue=await _distributedCache.GetStringAsync(key);
            if (string.IsNullOrEmpty(cacheValue))
            {
                return default;
            }
            return JsonSerializer.Deserialize<T>(cacheValue);
        }

        public async  Task RemoveCacheAsync(string key)
        {
            await _distributedCache.RemoveAsync(key);
        }

        public async Task SetCacheAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration ?? TimeSpan.FromMinutes(30),
            };
            var serializedValue = JsonSerializer.Serialize(value);
            await _distributedCache.SetStringAsync(key, serializedValue, options);
        }
    }
}

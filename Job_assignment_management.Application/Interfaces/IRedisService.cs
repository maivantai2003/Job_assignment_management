using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_assignment_management.Application.Interfaces
{
    public interface IRedisService
    {
        public Task SetCacheAsync<T>(string key, T value, TimeSpan? expiration = null);
        public Task<T> GetCacheAsync<T>(string key);
        public Task RemoveCacheAsync(string key);
    }
}

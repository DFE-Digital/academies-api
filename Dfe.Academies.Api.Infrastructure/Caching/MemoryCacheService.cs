using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;
using Dfe.Academies.Domain.Interfaces.Caching;

namespace Dfe.Academies.Infrastructure.Caching
{
    [ExcludeFromCodeCoverage]
    public class MemoryCacheService(
        IMemoryCache memoryCache,
        ILogger<MemoryCacheService> logger,
        IOptions<CacheSettings> cacheSettings)
        : ICacheService
    {
        private readonly CacheSettings _cacheSettings = cacheSettings.Value;

        public async Task<T> GetOrAddAsync<T>(string cacheKey, Func<Task<T>> fetchFunction, string methodName)
        {
            if (memoryCache.TryGetValue(cacheKey, out T cachedValue))
            {
                logger.LogInformation("Cache hit for key: {CacheKey}", cacheKey);
                return cachedValue;
            }

            logger.LogInformation("Cache miss for key: {CacheKey}. Fetching from source...", cacheKey);
            T result = await fetchFunction();

            if (result == null) return result;
            var cacheDuration = GetCacheDurationForMethod(methodName);
            memoryCache.Set(cacheKey, result, cacheDuration);
            logger.LogInformation("Cached result for key: {CacheKey} for duration: {CacheDuration}", cacheKey, cacheDuration);

            return result;
        }

        public void Remove(string cacheKey)
        {
            memoryCache.Remove(cacheKey);
            logger.LogInformation("Cache removed for key: {CacheKey}", cacheKey);
        }

        private TimeSpan GetCacheDurationForMethod(string methodName)
        {
            if (_cacheSettings.Durations.TryGetValue(methodName, out int durationInSeconds))
            {
                return TimeSpan.FromSeconds(durationInSeconds);
            }
            return TimeSpan.FromSeconds(_cacheSettings.DefaultDurationInSeconds);
        }
    }
}

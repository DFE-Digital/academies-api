using Dfe.Academies.Application.Common.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Dfe.Academies.Infrastructure.Caching
{
    [ExcludeFromCodeCoverage]
    public class MemoryCacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<MemoryCacheService> _logger;
        private readonly CacheSettings _cacheSettings;

        public MemoryCacheService(IMemoryCache memoryCache, ILogger<MemoryCacheService> logger, IOptions<CacheSettings> cacheSettings)
        {
            _memoryCache = memoryCache;
            _logger = logger;
            _cacheSettings = cacheSettings.Value;
        }

        public async Task<T> GetOrAddAsync<T>(string cacheKey, Func<Task<T>> fetchFunction, string methodName)
        {
            if (_memoryCache.TryGetValue(cacheKey, out T cachedValue))
            {
                _logger.LogInformation("Cache hit for key: {CacheKey}", cacheKey);
                return cachedValue;
            }

            _logger.LogInformation("Cache miss for key: {CacheKey}. Fetching from source...", cacheKey);
            T result = await fetchFunction();

            if (result != null)
            {
                var cacheDuration = GetCacheDurationForMethod(methodName);
                _memoryCache.Set(cacheKey, result, cacheDuration);
                _logger.LogInformation("Cached result for key: {CacheKey} for duration: {CacheDuration}", cacheKey, cacheDuration);
            }

            return result;
        }

        public void Remove(string cacheKey)
        {
            _memoryCache.Remove(cacheKey);
            _logger.LogInformation("Cache removed for key: {CacheKey}", cacheKey);
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

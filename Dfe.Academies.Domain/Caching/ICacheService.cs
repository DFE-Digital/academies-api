namespace Dfe.Academies.Domain.Caching
{
    public interface ICacheService
    {
        Task<T> GetOrAddAsync<T>(string cacheKey, Func<Task<T>> fetchFunction, string methodName);
        void Remove(string cacheKey);
    }
}

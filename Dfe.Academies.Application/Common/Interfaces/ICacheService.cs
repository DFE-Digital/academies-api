namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface ICacheService
    {
        Task<T> GetOrAddAsync<T>(string cacheKey, Func<Task<T>> fetchFunction, string methodName);
        void Remove(string cacheKey);
    }
}

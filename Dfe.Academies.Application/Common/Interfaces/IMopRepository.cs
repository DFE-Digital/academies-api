namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface IMopRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
    }
}

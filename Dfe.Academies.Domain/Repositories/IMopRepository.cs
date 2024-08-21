namespace Dfe.Academies.Domain.Repositories
{
    public interface IMopRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
    }
}

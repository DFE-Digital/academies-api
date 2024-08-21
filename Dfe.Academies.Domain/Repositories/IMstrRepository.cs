namespace Dfe.Academies.Domain.Repositories
{
    public interface IMstrRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
    }
}

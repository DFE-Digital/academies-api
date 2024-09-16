namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface IMstrRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
    }
}

namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface IMopRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
    }
}

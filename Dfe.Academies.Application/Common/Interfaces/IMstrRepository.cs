namespace Dfe.Academies.Application.Common.Interfaces
{
    public interface IMstrRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
    }
}

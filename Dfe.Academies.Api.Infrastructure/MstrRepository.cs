using Dfe.Academies.Infrastructure.Repositories;
using Dfe.Academies.Domain.Interfaces.Repositories;

namespace Dfe.Academies.Infrastructure
{
    public class MstrRepository<TEntity>(MstrContext dbContext) : Repository<TEntity, MstrContext>(dbContext), IMstrRepository<TEntity> where TEntity : class, new();
}

using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Infrastructure.Repositories;

namespace Dfe.Academies.Infrastructure
{
    public class MopRepository<TEntity>(MopContext dbContext) : Repository<TEntity, MopContext>(dbContext), IMopRepository<TEntity> where TEntity : class, new();
}

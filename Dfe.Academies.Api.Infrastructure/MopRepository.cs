using Dfe.Academies.Domain.Common;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Infrastructure.Repositories;

namespace Dfe.Academies.Infrastructure
{
    public class MopRepository<TAggregate, TId>(MopContext dbContext)
        : Repository<TAggregate, TId, MopContext>(dbContext), IMopRepository<TAggregate, TId>
        where TAggregate : class, IAggregateRoot<TId>
        where TId : ValueObject
    {

    }
}

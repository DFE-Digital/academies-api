using Dfe.Academies.Infrastructure.Repositories;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Domain.Common;

namespace Dfe.Academies.Infrastructure
{
    public class MstrRepository<TAggregate, TId>(MstrContext dbContext)
        : Repository<TAggregate, TId, MstrContext>(dbContext), IMstrRepository<TAggregate, TId>
        where TAggregate : class, IAggregateRoot<TId>
        where TId : ValueObject
    {
    }
}

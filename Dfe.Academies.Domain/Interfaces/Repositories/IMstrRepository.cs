using Dfe.Academies.Domain.Common;

namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface IMstrRepository<TAggregate, TId> : IRepository<TAggregate, TId>
        where TAggregate : IAggregateRoot<TId>
        where TId : ValueObject
    {
    }
}

using Dfe.Academies.Domain.Common;

namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface IMopRepository<TAggregate, TId> : IRepository<TAggregate, TId>
        where TAggregate : class, IAggregateRoot<TId>
        where TId : ValueObject
    {
    }
}

namespace Dfe.Academies.Domain.Common
{
    public interface IAggregateRoot<TId> : IEntity<TId> where TId : ValueObject
    {
    }
}

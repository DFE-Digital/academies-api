namespace Dfe.Academies.Domain.Common
{
    public interface IAggregateRoot<out TId> : IEntity<TId> where TId : ValueObject
    {
    }
}

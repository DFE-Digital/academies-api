namespace Dfe.Academies.Domain.Common
{
    public interface IEntity<TId> where TId : ValueObject
    {
        TId Id { get; }
    }
}

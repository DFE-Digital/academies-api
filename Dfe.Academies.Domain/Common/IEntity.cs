namespace Dfe.Academies.Domain.Common
{
    public interface IEntity<out TId> where TId : ValueObject
    {
        TId Id { get; }
    }
}

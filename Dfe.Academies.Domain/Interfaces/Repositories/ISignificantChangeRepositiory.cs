namespace Dfe.Academies.Domain.Interfaces.Repositories;

public interface ISignificantChangeRepositiory
{
    Task<SignificantChange.SignificantChange?> Search(string deliveryofficer, CancellationToken cancellationToken);
}

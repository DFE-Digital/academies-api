namespace Dfe.Academies.Domain.Interfaces.Repositories;

public interface ISignificantChangeRepositiory
{
    Task<(IEnumerable<SignificantChange.SignificantChange>, int)> SearchSignificantChanges(string deliveryofficer, bool orderByChangeEditDate = false, int page = 1, int count = 10, CancellationToken cancellationToken = default);
}

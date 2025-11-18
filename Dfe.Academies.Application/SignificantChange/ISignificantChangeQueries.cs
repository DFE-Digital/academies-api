using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.SignificantChange;

namespace Dfe.Academies.Application.SignificantChange;
public interface ISignificantChangeQueries
{
    Task<(IEnumerable<SignificantChangeDto>, int)> SearchSignificantChanges(string deliveryOfficer, bool orderByChangeEditDate = false, bool isDescending = false,int page = 1, int count = 10, CancellationToken cancellationToken = default);
}

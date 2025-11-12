using GovUK.Dfe.CoreLibs.Contracts.Academies.V5.Establishments;
namespace Dfe.Academies.Application.Establishment.V5
{
    public interface IEstablishmentQueries
    {
        Task<(List<EstablishmentDto>, int)> Search(string name, string ukPrn, string urn, bool? excludeClosed, bool? matchAny, CancellationToken cancellationToken);
    }
}

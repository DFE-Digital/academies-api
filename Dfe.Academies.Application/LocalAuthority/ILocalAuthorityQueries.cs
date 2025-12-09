using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Establishments;

namespace Dfe.Academies.Application.LocalAuthority
{
    public interface ILocalAuthorityQueries
    {
        Task<NameAndCodeDto?> GetByCode(string code, CancellationToken cancellationToken);
        Task<(List<NameAndCodeDto>, int)> Search(string name, string code, CancellationToken cancellationToken);
    }
}

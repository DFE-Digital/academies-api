using Dfe.Academies.Domain.Establishment;

namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface ILocalAuthorityRepository
    {
        Task<LocalAuthority?> GetLocalAuthorityByCode(string code, CancellationToken cancellationToken);
        Task<(List<LocalAuthority>, int)> Search(string name, string code, CancellationToken cancellationToken);
    }
}

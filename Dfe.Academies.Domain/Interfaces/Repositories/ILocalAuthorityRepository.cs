namespace Dfe.Academies.Domain.Interfaces.Repositories
{
    public interface ILocalAuthorityRepository
    {
        Task<(List<Establishment.LocalAuthority>, int)> Search(string name, string code, CancellationToken cancellationToken);
    }
}

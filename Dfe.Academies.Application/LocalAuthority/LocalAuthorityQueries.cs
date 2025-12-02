using Dfe.Academies.Domain.Interfaces.Repositories;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Establishments;

namespace Dfe.Academies.Application.LocalAuthority
{
    public class LocalAuthorityQueries(ILocalAuthorityRepository _localAuthorityRepository) : ILocalAuthorityQueries
    {
        public async Task<(List<NameAndCodeDto>, int)> Search(string name, string code, CancellationToken cancellationToken)
        {
            var (localAuthorities, recordCount) = await _localAuthorityRepository.Search(name, code, cancellationToken);

            return (localAuthorities.Select(x => MapToNameAndCodeDto(x)).ToList(), recordCount);
        }

        private static NameAndCodeDto MapToNameAndCodeDto(Domain.Establishment.LocalAuthority localAuthority)
        {
            return new NameAndCodeDto()
            {
                Name = localAuthority.Name!,
                Code = localAuthority.Code!
            };
        }
    }
}

using Dfe.Academies.Domain.Interfaces.Repositories;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Establishments;

namespace Dfe.Academies.Application.LocalAuthority
{
    public class DioceseQueries(IEstablishmentRepository _establishmentRepository) : IDioceseQueries
    {
        public async Task<NameAndCodeDto?> GetByCode(string code, CancellationToken cancellationToken)
        {
            var diocese = await _establishmentRepository.GetDioceseByCode(code, cancellationToken).ConfigureAwait(false);
            return diocese == null ? null : MapToNameAndCodeDto(diocese);
        }
        public async Task<(List<NameAndCodeDto>, int)> Search(string name, string code, CancellationToken cancellationToken)
        {
            var (dioceses, recordCount) = await _establishmentRepository.SearchDioceses(name, code, cancellationToken);

            return (dioceses.Select(x => MapToNameAndCodeDto(x)).ToList(), recordCount);
        }

        private static NameAndCodeDto MapToNameAndCodeDto(Domain.Establishment.Diocese diocese)
        {
            return new NameAndCodeDto()
            {
                Name = diocese.Name!,
                Code = diocese.Code!
            };
        }
    }
}

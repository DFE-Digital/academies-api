using Dfe.Academies.Contracts.V4;
using Dfe.Academies.Contracts.V4.Trusts;
using Dfe.Academies.Domain.Trust;

namespace Dfe.Academies.Application.Trust
{
    public class TrustQueries : ITrustQueries
    {
        private readonly ITrustRepository _trustRepository;

        public TrustQueries(ITrustRepository trustRepository)
        {
            _trustRepository = trustRepository;
        }
        public async Task<TrustDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            var trust = await _trustRepository.GetTrustByUkprn(ukprn, cancellationToken).ConfigureAwait(false);
            return trust == null ? null : MapToTrustDto(trust);
        }
        public async Task<TrustDto?> GetByCompaniesHouseNumber(string companiesHouseNumber, CancellationToken cancellationToken)
        {
            var trust = await _trustRepository.GetTrustByCompaniesHouseNumber(companiesHouseNumber, cancellationToken).ConfigureAwait(false);
            return trust == null ? null : MapToTrustDto(trust);
        }

        public async Task<(List<TrustDto>, int)> Search(int page, int count, string name, string ukPrn, string companiesHouseNumber, CancellationToken cancellationToken)
        {
            var (trusts, recordCount) = await _trustRepository.Search(page, count, name, ukPrn, companiesHouseNumber, cancellationToken).ConfigureAwait(false);

            return (trusts.Select(x => MapToTrustDto(x)).ToList(), recordCount);
        }

        public async Task<List<TrustDto>> GetByUkprns(string[] ukprns, CancellationToken cancellationToken)
        {
            var trusts = await _trustRepository.GetTrustsByUkprns(ukprns, cancellationToken).ConfigureAwait(false);

            return trusts.Select(x => MapToTrustDto(x)).ToList();
        }
        public async Task<TrustDto?> GetByTrustReferenceNumber(string trustReferenceNumber, CancellationToken cancellationToken)
        {
            var trust = await _trustRepository.GetTrustByTrustReferenceNumber(trustReferenceNumber, cancellationToken).ConfigureAwait(false);
            return trust == null ? null : MapToTrustDto(trust);
        }

        private static TrustDto MapToTrustDto(Domain.Trust.Trust trust)
        {
            return new TrustDto()
            {
                Name = trust.Name,
                CompaniesHouseNumber = trust.CompaniesHouseNumber,
                ReferenceNumber = trust.GroupID,
                Ukprn = trust.UKPRN,
                Type = new Contracts.V4.Establishments.NameAndCodeDto() { Code = trust.TrustType?.Code, Name = trust.TrustType?.Name },
                Address = new AddressDto()
                {
                    Street = trust.AddressLine1,
                    Town = trust.Town,
                    Postcode = trust.Postcode,
                    County = trust.County,
                    Additional = trust.AddressLine2,
                    Locality = trust.AddressLine3
                }
            };
        }
    }
}

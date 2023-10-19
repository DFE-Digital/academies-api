using Dfe.Academies.Contracts.Trusts;
using Dfe.Academies.Domain.Trust;

namespace Dfe.Academies.Application.Queries.Trust
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

        public async Task<(List<TrustDto>, int)> Search(int page, int count, string name, string ukPrn, string companiesHouseNumber, CancellationToken cancellationToken)
        {
            var trusts = await _trustRepository.Search(page, count, name, ukPrn, companiesHouseNumber, cancellationToken).ConfigureAwait(false);

            return (trusts.Select(x => MapToTrustDto(x)).ToList(), trusts.Count);
        }

        private static TrustDto MapToTrustDto(Domain.Trust.Trust trust)
        {
            return new TrustDto()
            {
                Name = trust.Name,
                CompaniesHouseNumber = trust.CompaniesHouseNumber,
                ReferenceNumber = trust.GroupID,
                Ukprn = trust.UKPRN,
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

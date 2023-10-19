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

            return trust == null ? null : new TrustDto()
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

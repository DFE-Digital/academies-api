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

        public async Task<TrustDto?> GetByCompaniesHouseNumber(string companiesHouseNumber,
            CancellationToken cancellationToken)
        {
            var trust = await _trustRepository.GetTrustByCompaniesHouseNumber(companiesHouseNumber, cancellationToken)
                .ConfigureAwait(false);
            return trust == null ? null : MapToTrustDto(trust);
        }

        public async Task<(List<TrustDto>, int)> Search(int page, int count, string name, string ukPrn,
            string companiesHouseNumber, TrustStatus status, CancellationToken cancellationToken)
        {
            var (trusts, recordCount) = await _trustRepository
                .Search(page, count, name, ukPrn, companiesHouseNumber, status, cancellationToken)
                .ConfigureAwait(false);

            return (trusts.Select(x => MapToTrustDto(x)).ToList(), recordCount);
        }

        public async Task<List<TrustDto>> GetByUkprns(string[] ukprns, CancellationToken cancellationToken)
        {
            var trusts = await _trustRepository.GetTrustsByUkprns(ukprns, cancellationToken).ConfigureAwait(false);

            return trusts.Select(x => MapToTrustDto(x)).ToList();
        }

        public async Task<TrustDto?> GetByTrustReferenceNumber(string trustReferenceNumber,
            CancellationToken cancellationToken)
        {
            var trust = await _trustRepository.GetTrustByTrustReferenceNumber(trustReferenceNumber, cancellationToken)
                .ConfigureAwait(false);
            return trust == null ? null : MapToTrustDto(trust);
        }

        public async Task<TrustDto?> GetByTrustGroupUID(string groupUID, CancellationToken cancellationToken)
        {
            var trust = await _trustRepository.GetTrustByGroupUID(groupUID, cancellationToken).ConfigureAwait(false);
            return trust == null ? null : MapToTrustDto(trust);
        }

        public async Task<List<TrustIdentifiers>?> GetTrustIdentifiers(string identifer,
            CancellationToken cancellationToken)
        {
            var trusts = new List<Domain.Trust.Trust>();
            
            var ukprnTrust = await _trustRepository.GetTrustByUkprn(identifer, cancellationToken).ConfigureAwait(false);
            if (ukprnTrust is not null)
            {
                trusts.Add(ukprnTrust);
            }
            var trustReferenceTrust = await _trustRepository.GetTrustByTrustReferenceNumber(identifer, cancellationToken)
                .ConfigureAwait(false);
            if (trustReferenceTrust is not null)
            {
                trusts.Add(trustReferenceTrust);
            }
            var groupUIDTrust = await _trustRepository.GetTrustByGroupUID(identifer, cancellationToken).ConfigureAwait(false);
            if (groupUIDTrust is not null)
            {
                trusts.Add(groupUIDTrust);
            }

            var trustIdentifiersList = trusts.Select(mapToIdentifiers).ToList();

            return trustIdentifiersList.Count > 0 ? trustIdentifiersList : null;
        }

        private static TrustDto MapToTrustDto(Domain.Trust.Trust trust)
        {
            return new TrustDto()
            {
                Name = trust.Name,
                CompaniesHouseNumber = trust.CompaniesHouseNumber,
                ReferenceNumber = trust.GroupID,
                Ukprn = trust.UKPRN,
                Type = new Contracts.V4.Establishments.NameAndCodeDto()
                    { Code = trust.TrustType?.Code, Name = trust.TrustType?.Name },
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
        
        private static TrustIdentifiers mapToIdentifiers(Domain.Trust.Trust trust)
        {
            return new TrustIdentifiers(UID: trust.GroupUID, UKPRN: trust.UKPRN, TR: trust.GroupID);
        }
    }

    public record TrustIdentifiers(
        string? UID,
        string? UKPRN,
        string? TR
    );
}

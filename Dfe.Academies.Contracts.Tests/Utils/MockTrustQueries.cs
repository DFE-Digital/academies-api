using Dfe.Academies.Application.Queries.Trust;
using Dfe.Academies.Contracts.Trusts;
using Dfe.Academies.Domain.Trust;

namespace Dfe.Academies.Contracts.Tests.Utils
{
    internal class MockTrustQueries : ITrustQueries
    {
        private readonly ITrustRepository _trustRepository;

        public MockTrustQueries(ITrustRepository trustRepository)
        {
            _trustRepository = trustRepository;
        }
        public Task<TrustDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            return Task.FromResult(new TrustDto()
            {
                Name = "someTrustName",
                CompaniesHouseNumber = "someCompaniesHouseNumber",
                ReferenceNumber = "someReferenceNumber",
                Ukprn = "someUKPRN",
                Address = new AddressDto()
                {
                    Street = "someStreet",
                    Town = "someTown",
                    Postcode = "somePostcode",
                    County = "someCounty",
                    Additional = "someAdditional",
                    Locality = "someLocality"
                }
            });
        }

        public Task<List<TrustDto>> GetByUkprns(string[] ukprns, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<(List<TrustDto>, int)> Search(int page, int count, string name, string ukPrn, string companiesHouseNumber, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

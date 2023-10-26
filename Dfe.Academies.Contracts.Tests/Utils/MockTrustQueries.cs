using Dfe.Academies.Application.Queries.Trust;
using Dfe.Academies.Contracts.Trusts;

namespace Dfe.Academies.Contracts.Tests.Utils
{
    public class MockTrustQueries : ITrustQueries
    {
        public Task<TrustDto?> GetByUkprn(string ukprn, CancellationToken cancellationToken)
        {
            if (ukprn.Equals("999999"))
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
            else
            {
                return Task.FromResult<TrustDto>(null);
            }
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

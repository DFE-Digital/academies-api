using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using Dfe.Academies.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Dfe.Academies.Infrastructure.Tests.Repositories
{
    public class TrustRepositoryTests : IDisposable
    {
        private readonly SqliteConnection _connection;
        private readonly MstrContext _context;
        private readonly TrustRepository _sut;

        private readonly TrustType _multiAcademyTrustType;
        private readonly TrustType _singleAcademyTrustType;
        private readonly TrustType _otherTrustType;

        public TrustRepositoryTests()
        {
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            var options = new DbContextOptionsBuilder<MstrContext>()
                .UseSqlite(_connection)
                .Options;

            _context = new MstrContext(options);
            _context.Database.EnsureCreated();

            _multiAcademyTrustType = new TrustType { SK = 1, Name = "Multi-academy trust", Code = "MAT" };
            _singleAcademyTrustType = new TrustType { SK = 2, Name = "Single-academy trust", Code = "SAT" };
            _otherTrustType = new TrustType { SK = 3, Name = "Other", Code = "OTH" };

            _context.TrustTypes.AddRange(_multiAcademyTrustType, _singleAcademyTrustType, _otherTrustType);
            _context.SaveChanges();

            _sut = new TrustRepository(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
            _connection.Dispose();
        }

        [Fact]
        public async Task GetTrustByUkprn_WhenTrustExists_ReturnsTrustWithTrustType()
        {
            var trust = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "12345678", _multiAcademyTrustType);
            await SeedTrustsAsync(trust);

            var result = await _sut.GetTrustByUkprn("10000001", CancellationToken.None);

            result.Should().NotBeNull();
            result!.Name.Should().Be("Alpha Trust");
            result.UKPRN.Should().Be("10000001");
            result.TrustType.Should().NotBeNull();
            result.TrustType!.Name.Should().Be("Multi-academy trust");
        }

        [Fact]
        public async Task GetTrustByUkprn_WhenTrustDoesNotExist_ReturnsNull()
        {
            var result = await _sut.GetTrustByUkprn("missing", CancellationToken.None);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetTrustByCompaniesHouseNumber_WhenTrustExists_ReturnsTrust()
        {
            var trust = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "12345678", _multiAcademyTrustType);
            await SeedTrustsAsync(trust);

            var result = await _sut.GetTrustByCompaniesHouseNumber("12345678", CancellationToken.None);

            result.Should().NotBeNull();
            result!.CompaniesHouseNumber.Should().Be("12345678");
            result.Name.Should().Be("Alpha Trust");
        }

        [Fact]
        public async Task GetTrustByCompaniesHouseNumber_WhenTrustDoesNotExist_ReturnsNull()
        {
            var result = await _sut.GetTrustByCompaniesHouseNumber("00000000", CancellationToken.None);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetTrustByTrustReferenceNumber_WhenTrustExists_ReturnsTrust()
        {
            var trust = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "12345678", _multiAcademyTrustType);
            await SeedTrustsAsync(trust);

            var result = await _sut.GetTrustByTrustReferenceNumber("TR00001", CancellationToken.None);

            result.Should().NotBeNull();
            result!.GroupID.Should().Be("TR00001");
            result.Name.Should().Be("Alpha Trust");
        }

        [Fact]
        public async Task GetTrustByTrustReferenceNumber_WhenTrustDoesNotExist_ReturnsNull()
        {
            var result = await _sut.GetTrustByTrustReferenceNumber("TR99999", CancellationToken.None);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetTrustsByUkprns_WhenMatchesExist_ReturnsMatchingTrusts()
        {
            var trust1 = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType);
            var trust2 = CreateTrust(2, "Beta Trust", "10000002", "TR00002", "22222222", _singleAcademyTrustType);
            var trust3 = CreateTrust(3, "Gamma Trust", "10000003", "TR00003", "33333333", _multiAcademyTrustType);
            await SeedTrustsAsync(trust1, trust2, trust3);

            var result = await _sut.GetTrustsByUkprns(new[] { "10000001", "10000003" }, CancellationToken.None);

            result.Should().HaveCount(2);
            result.Select(t => t.UKPRN).Should().BeEquivalentTo(new[] { "10000001", "10000003" });
        }

        [Fact]
        public async Task GetTrustsByUkprns_WhenNoMatches_ReturnsEmptyList()
        {
            var trust = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType);
            await SeedTrustsAsync(trust);

            var result = await _sut.GetTrustsByUkprns(new[] { "99999999" }, CancellationToken.None);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetTrustsByTrns_WhenMatchesExist_ReturnsMatchingTrusts()
        {
            var trust1 = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType);
            var trust2 = CreateTrust(2, "Beta Trust", "10000002", "TR00002", "22222222", _singleAcademyTrustType);
            var trust3 = CreateTrust(3, "Gamma Trust", "10000003", "TR00003", "33333333", _multiAcademyTrustType);
            await SeedTrustsAsync(trust1, trust2, trust3);

            var result = await _sut.GetTrustsByTrns(new[] { "TR00002", "TR00003" }, CancellationToken.None);

            result.Should().HaveCount(2);
            result.Select(t => t.GroupID).Should().BeEquivalentTo(new[] { "TR00002", "TR00003" });
        }

        [Fact]
        public async Task GetTrustsByTrns_WhenNoMatches_ReturnsEmptyList()
        {
            var trust = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType);
            await SeedTrustsAsync(trust);

            var result = await _sut.GetTrustsByTrns(new[] { "TR99999" }, CancellationToken.None);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task GetTrustsByEstablishmentUrns_WhenLinksExist_ReturnsTrustsKeyedByUrn()
        {
            var trust1 = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType,
                addressLine1: "1 High Street", town: "London", postcode: "E1 1AA", county: "Greater London",
                addressLine2: "Floor 2", addressLine3: "Suite A");
            var trust2 = CreateTrust(2, "Beta Trust", "10000002", "TR00002", "22222222", _singleAcademyTrustType,
                addressLine1: "2 Low Road", town: "Manchester", postcode: "M1 1BB");

            var establishment1 = new Establishment { SK = 10, URN = 100001, EstablishmentName = "School A" };
            var establishment2 = new Establishment { SK = 20, URN = 100002, EstablishmentName = "School B" };
            var establishmentWithoutTrust = new Establishment { SK = 30, URN = 100003, EstablishmentName = "School C" };

            _context.Trusts.AddRange(trust1, trust2);
            _context.Establishments.AddRange(establishment1, establishment2, establishmentWithoutTrust);
            _context.EducationEstablishmentTrusts.AddRange(
                new EducationEstablishmentTrust { SK = 1, EducationEstablishmentId = 10, TrustId = 1 },
                new EducationEstablishmentTrust { SK = 2, EducationEstablishmentId = 20, TrustId = 2 });
            await _context.SaveChangesAsync();

            var result = await _sut.GetTrustsByEstablishmentUrns(new List<int> { 100001, 100002, 100003 }, CancellationToken.None);

            result.Should().HaveCount(2);
            result[100001].Name.Should().Be("Alpha Trust");
            result[100001].CompaniesHouseNumber.Should().Be("11111111");
            result[100001].GroupID.Should().Be("TR00001");
            result[100001].UKPRN.Should().Be("10000001");
            result[100001].AddressLine1.Should().Be("1 High Street");
            result[100001].Town.Should().Be("London");
            result[100001].Postcode.Should().Be("E1 1AA");
            result[100001].County.Should().Be("Greater London");
            result[100001].AddressLine2.Should().Be("Floor 2");
            result[100001].AddressLine3.Should().Be("Suite A");
            result[100001].TrustType!.Name.Should().Be("Multi-academy trust");

            result[100002].Name.Should().Be("Beta Trust");
            result.Should().NotContainKey(100003);
        }

        [Fact]
        public async Task GetTrustsByEstablishmentUrns_WhenNoMatches_ReturnsEmptyDictionary()
        {
            var result = await _sut.GetTrustsByEstablishmentUrns(new List<int> { 999999 }, CancellationToken.None);

            result.Should().BeEmpty();
        }

        [Fact]
        public async Task Search_WhenNoFiltersProvided_ReturnsAllTrustsPaginated()
        {
            var trust1 = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType, groupUid: "G2");
            var trust2 = CreateTrust(2, "Beta Trust", "10000002", "TR00002", "22222222", _otherTrustType, groupUid: "G1");
            var trust3 = CreateTrust(3, "Gamma Trust", "10000003", "TR00003", "33333333", _singleAcademyTrustType, groupUid: "G3");
            await SeedTrustsAsync(trust1, trust2, trust3);

            var (trusts, totalCount) = await _sut.Search(1, 2, null, null, null, TrustStatus.All, CancellationToken.None);

            totalCount.Should().Be(3);
            trusts.Should().HaveCount(2);
            trusts.Select(t => t.GroupUID).Should().Equal("G1", "G2");
        }

        [Fact]
        public async Task Search_WhenNoFiltersProvided_AppliesPaginationOffset()
        {
            var trust1 = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType, groupUid: "G1");
            var trust2 = CreateTrust(2, "Beta Trust", "10000002", "TR00002", "22222222", _multiAcademyTrustType, groupUid: "G2");
            var trust3 = CreateTrust(3, "Gamma Trust", "10000003", "TR00003", "33333333", _multiAcademyTrustType, groupUid: "G3");
            await SeedTrustsAsync(trust1, trust2, trust3);

            var (trusts, totalCount) = await _sut.Search(2, 2, null, null, null, TrustStatus.All, CancellationToken.None);

            totalCount.Should().Be(3);
            trusts.Should().HaveCount(1);
            trusts.Single().GroupUID.Should().Be("G3");
        }

        [Fact]
        public async Task Search_ByName_ReturnsMatchingAcademyTrusts()
        {
            var matching = CreateTrust(1, "Alpha Academy Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType);
            var nonMatchingName = CreateTrust(2, "Beta Trust", "10000002", "TR00002", "22222222", _multiAcademyTrustType);
            var wrongType = CreateTrust(3, "Alpha Foundation", "10000003", "TR00003", "33333333", _otherTrustType);
            await SeedTrustsAsync(matching, nonMatchingName, wrongType);

            var (trusts, totalCount) = await _sut.Search(1, 10, "Alpha", null, null, TrustStatus.All, CancellationToken.None);

            totalCount.Should().Be(1);
            trusts.Should().ContainSingle().Which.Name.Should().Be("Alpha Academy Trust");
        }

        [Fact]
        public async Task Search_ByUkPrn_ReturnsMatchingAcademyTrusts()
        {
            var matching = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "11111111", _singleAcademyTrustType);
            var nonMatching = CreateTrust(2, "Beta Trust", "10000002", "TR00002", "22222222", _multiAcademyTrustType);
            await SeedTrustsAsync(matching, nonMatching);

            var (trusts, totalCount) = await _sut.Search(1, 10, null, "000001", null, TrustStatus.All, CancellationToken.None);

            totalCount.Should().Be(1);
            trusts.Should().ContainSingle().Which.UKPRN.Should().Be("10000001");
        }

        [Fact]
        public async Task Search_ByCompaniesHouseNumber_ReturnsMatchingAcademyTrusts()
        {
            var matching = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType);
            var nonMatching = CreateTrust(2, "Beta Trust", "10000002", "TR00002", "22222222", _multiAcademyTrustType);
            await SeedTrustsAsync(matching, nonMatching);

            var (trusts, totalCount) = await _sut.Search(1, 10, null, null, "1111", TrustStatus.All, CancellationToken.None);

            totalCount.Should().Be(1);
            trusts.Should().ContainSingle().Which.CompaniesHouseNumber.Should().Be("11111111");
        }

        [Fact]
        public async Task Search_WhenStatusIsOpen_ReturnsOnlyOpenTrusts()
        {
            var openTrust = CreateTrust(1, "Open Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType, trustStatus: "Open");
            var closedTrust = CreateTrust(2, "Closed Trust", "10000002", "TR00002", "22222222", _multiAcademyTrustType, trustStatus: "Closed");
            await SeedTrustsAsync(openTrust, closedTrust);

            var (trusts, totalCount) = await _sut.Search(1, 10, "Trust", null, null, TrustStatus.Open, CancellationToken.None);

            totalCount.Should().Be(1);
            trusts.Should().ContainSingle().Which.Name.Should().Be("Open Trust");
        }

        [Fact]
        public async Task Search_WhenStatusIsAll_ReturnsOpenAndClosedTrusts()
        {
            var openTrust = CreateTrust(1, "Open Trust", "10000001", "TR00001", "11111111", _multiAcademyTrustType, trustStatus: "Open");
            var closedTrust = CreateTrust(2, "Closed Trust", "10000002", "TR00002", "22222222", _multiAcademyTrustType, trustStatus: "Closed");
            await SeedTrustsAsync(openTrust, closedTrust);

            var (trusts, totalCount) = await _sut.Search(1, 10, "Trust", null, null, TrustStatus.All, CancellationToken.None);

            totalCount.Should().Be(2);
            trusts.Select(t => t.Name).Should().BeEquivalentTo(new[] { "Open Trust", "Closed Trust" });
        }

        [Fact]
        public async Task Search_WhenTrustHasNoCompaniesHouseNumber_IsExcludedFromFilteredSearch()
        {
            var withoutCompaniesHouse = CreateTrust(1, "Alpha Trust", "10000001", "TR00001", null, _multiAcademyTrustType);
            await SeedTrustsAsync(withoutCompaniesHouse);

            var (trusts, totalCount) = await _sut.Search(1, 10, "Alpha", null, null, TrustStatus.All, CancellationToken.None);

            totalCount.Should().Be(0);
            trusts.Should().BeEmpty();
        }

        private static Trust CreateTrust(
            long sk,
            string name,
            string ukprn,
            string groupId,
            string? companiesHouseNumber,
            TrustType trustType,
            string groupUid = "G1",
            string trustStatus = "Open",
            string? addressLine1 = null,
            string? addressLine2 = null,
            string? addressLine3 = null,
            string? town = null,
            string? county = null,
            string? postcode = null)
        {
            return new Trust
            {
                SK = sk,
                Name = name,
                UKPRN = ukprn,
                GroupID = groupId,
                GroupUID = groupUid,
                CompaniesHouseNumber = companiesHouseNumber,
                TrustStatus = trustStatus,
                TrustTypeId = trustType.SK,
                AddressLine1 = addressLine1,
                AddressLine2 = addressLine2,
                AddressLine3 = addressLine3,
                Town = town,
                County = county,
                Postcode = postcode
            };
        }

        private async Task SeedTrustsAsync(params Trust[] trusts)
        {
            _context.Trusts.AddRange(trusts);
            await _context.SaveChangesAsync();
        }
    }
}

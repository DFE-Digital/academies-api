using AutoFixture;
using Dfe.Academies.Application.Establishment;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Interfaces.Repositories;
using DfE.CoreLibs.Contracts.Academies.V4.Establishments;
using FluentAssertions;
using Moq;
using System.Globalization; 

namespace Dfe.Academies.Application.Tests.Queries.Establishment
{
    public class EstablishmentQueriesTests
    { 
        private Fixture _fixture;
        private MisEstablishment _misEstablishment; 
        private EducationEstablishmentLink _educationEstablishmentLink;

        public EstablishmentQueriesTests()
        {
            _fixture = new Fixture();

            _fixture.Behaviors
                .OfType<ThrowingRecursionBehavior>()
                .ToList()
                .ForEach(b => _fixture.Behaviors.Remove(b));

            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            _misEstablishment = _fixture.Create<MisEstablishment>();
            _educationEstablishmentLink = _fixture.Create<EducationEstablishmentLink>();
        }


        [Fact]
        public async Task GetByUkprn_WhenEstablishmentReturnedFromRepo_EstablishmentDtoIsReturned()
        {
            // Arrange
            var establishment = _fixture.Create<Domain.Establishment.Establishment?>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();
            var mockCensusRepo = new Mock<ICensusDataRepository>();

            string ukprn = "1010101";
            mockRepo.Setup(x => x.GetEstablishmentByUkprn(It.Is<string>(v => v == ukprn), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishment));
            mockRepo.Setup(x => x.GetMisEstablishmentByURN(establishment!.URN)).Returns(_misEstablishment);
            mockRepo.Setup(x => x.GetEducationEstablishmentLinksByURN(establishment!.URN)).Returns(_educationEstablishmentLink);
            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object, mockCensusRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetByUkprn(
                ukprn,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(EstablishmentDto));
            Assert.True(HasMappedCorrectly(result, establishment, _misEstablishment, _educationEstablishmentLink));
        }

        [Fact]
        public async Task GetByUrn_WhenEstablishmentReturnedFromRepo_EstablishmentDtoIsReturned()
        {
            // Arrange
            var establishment = _fixture.Create<Domain.Establishment.Establishment?>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();
            var mockCensusRepo = new Mock<ICensusDataRepository>();
            string urn = "1010101";
            mockRepo.Setup(x => x.GetEstablishmentByUrn(It.Is<string>(v => v == urn), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishment));
            mockRepo.Setup(x => x.GetMisEstablishmentByURN(establishment!.URN)).Returns(_misEstablishment);
            mockRepo.Setup(x => x.GetEducationEstablishmentLinksByURN(establishment!.URN)).Returns(_educationEstablishmentLink);
            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object, mockCensusRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetByUrn(
                urn,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(EstablishmentDto));
            Assert.True(HasMappedCorrectly(result, establishment, _misEstablishment, _educationEstablishmentLink));
        }

        [Fact]
        public async Task Search_WhenEstablishmentsReturnedFromRepo_EstablishmentDtoListAndCountIsReturned()
        {
            // Arrange
            var establishments = _fixture.Create<List<Domain.Establishment.Establishment>>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();
            var mockCensusRepo = new Mock<ICensusDataRepository>();

            string urn = "1010101";
            string name = "Test name";
            string ukPrn = "Test UkPrn";
            bool? excludeClosed = null;
            mockRepo.Setup(x => x.Search(It.Is<string>(v => v == name), It.Is<string>(v => v == ukPrn), It.Is<string>(v => v == urn), It.Is<bool?>(x => x == excludeClosed), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishments));
            mockRepo.Setup(x => x.GetMisEstablishmentByURN(It.IsAny<int?>())).Returns(_misEstablishment);
            mockRepo.Setup(x => x.GetEducationEstablishmentLinksByURN(It.IsAny<int?>())).Returns(_educationEstablishmentLink);

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object, mockCensusRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.Search(
                name,
                ukPrn,
                urn,
                excludeClosed,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof((List<EstablishmentDto>, int)));
            foreach (var establishmentDto in result.Item1)
            {
                var establishment = establishments.Single(x => x.URN.ToString() == establishmentDto.Urn);
                Assert.True(HasMappedCorrectly(establishmentDto, establishment, _misEstablishment, _educationEstablishmentLink));
            }
        }

        [Fact]
        public async Task GetURNsByRegion_WhenEstablishmentUrnsReturnedFromRepo_IEnumebrableOfIntIsReturned()
        {
            // Arrange
            string[] regions = _fixture.Create<string[]>();
            var establishmentUrns = _fixture.Create<List<int>>().AsEnumerable();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();
            mockRepo.Setup(x => x.GetURNsByRegion(It.Is<string[]>(v => v == regions), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishmentUrns));
            mockRepo.Setup(x => x.GetMisEstablishmentByURN(It.IsAny<int?>())).Returns(_misEstablishment);
            var mockCensusRepo = new Mock<ICensusDataRepository>();
            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object, mockCensusRepo.Object);
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetURNsByRegion(
                regions,
                cancellationToken);

            // Assert
            result.Should().BeAssignableTo(typeof(IEnumerable<int>));
            result.Should().BeEquivalentTo(establishmentUrns);

        }

        [Fact]
        public async Task GetByUrns_WhenEstablishmentsReturnedFromRepo_ListOfEstablishmentDtoIsReturned()
        {
            // Arrange
            int[] Urns = _fixture.Create<int[]>();
            var establishments = _fixture.Create<List<Domain.Establishment.Establishment>>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();
            var mockCensusRepo = new Mock<ICensusDataRepository>();

            mockRepo.Setup(x => x.GetByUrns(It.Is<int[]>(v => v == Urns), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishments));
            mockRepo.Setup(x => x.GetMisEstablishmentByURN(It.IsAny<int?>())).Returns(_misEstablishment);
            mockRepo.Setup(x => x.GetEducationEstablishmentLinksByURN(It.IsAny<int?>())).Returns(_educationEstablishmentLink);
            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object, mockCensusRepo.Object);
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);
            // Act
            var result = await establishmentQueries.GetByUrns(
                Urns, cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(List<EstablishmentDto>));
            foreach (var establishmentDto in result)
            {
                var establishment = establishments.Single(x => x.URN.ToString() == establishmentDto.Urn);
                Assert.True(HasMappedCorrectly(establishmentDto, establishment, _misEstablishment, _educationEstablishmentLink));
            }
        }

        [Fact]
        public async Task BulkGetByUkprns_WhenEstablishmentsAreNotFound_ReturnsEmptyListOfEstablishmentDtos()
        {
            // Arrange
            var establishments = new List<Domain.Establishment.Establishment>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();
            var mockCensusRepo = new Mock<ICensusDataRepository>();

            string[] ukprns = { "1010101", "111111" };

            mockRepo.Setup(x => x.GetByUkprns(It.Is<string[]>(v => v == ukprns), It.IsAny<CancellationToken>())).ReturnsAsync(establishments);
            mockRepo.Setup(x => x.GetMisEstablishmentByURN(It.IsAny<int?>())).Returns(_misEstablishment);
            mockRepo.Setup(x => x.GetEducationEstablishmentLinksByURN(It.IsAny<int?>())).Returns(_educationEstablishmentLink);
            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object, mockCensusRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetByUkprns(
                ukprns,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(List<EstablishmentDto>));
            result.Should().HaveCount(0);

        }

        [Fact]
        public async Task BulkGetByUkprns_WhenEstablishmentsAreFound_ReturnsListOfEstablishmentDtos()
        {
            // Arrange
            var establishments = _fixture.Create<List<Domain.Establishment.Establishment>>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();
            var mockCensusRepo = new Mock<ICensusDataRepository>();

            string[] ukprns = { "1010101", "111111" };

            mockRepo.Setup(x => x.GetByUkprns(It.Is<string[]>(v => v == ukprns), It.IsAny<CancellationToken>())).ReturnsAsync(establishments);
            mockRepo.Setup(x => x.GetMisEstablishmentByURN(It.IsAny<int?>())).Returns(_misEstablishment);
            mockRepo.Setup(x => x.GetEducationEstablishmentLinksByURN(It.IsAny<int?>())).Returns(_educationEstablishmentLink);
            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object, mockCensusRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetByUkprns(
                ukprns,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(List<EstablishmentDto>));

            Assert.All(result, x =>
            {
                var establishment = establishments.Single(es => es.UKPRN == x.Ukprn);
                Assert.True(HasMappedCorrectly(x, establishment, _misEstablishment, _educationEstablishmentLink));
            });
        }


        private bool HasMappedCorrectly(EstablishmentDto dto, Domain.Establishment.Establishment establishment, MisEstablishment misEstablishment, EducationEstablishmentLink educationEstablishmentLink)
        {
            return (
                dto.Name == establishment.EstablishmentName &&
                dto.Urn == establishment.URN.ToString() &&

                dto.OfstedRating == establishment.OfstedRating &&
                dto.OfstedLastInspection == establishment.OfstedLastInspection &&
                dto.StatutoryLowAge == establishment.StatutoryLowAge &&
                dto.StatutoryHighAge == establishment.StatutoryHighAge &&
                dto.SchoolCapacity == establishment.SchoolCapacity &&
                dto.Pfi == establishment.IfdPipeline?.DeliveryProcessPFI &&
                dto.EstablishmentNumber == establishment.EstablishmentNumber.ToString() &&
                dto.Pan == establishment.IfdPipeline?.DeliveryProcessPAN &&
                dto.Deficit == establishment.IfdPipeline?.ProjectTemplateInformationDeficit &&
                dto.ViabilityIssue == establishment.IfdPipeline?.ProjectTemplateInformationViabilityIssue &&

                dto.LocalAuthorityCode == establishment.LocalAuthority?.Code &&
                dto.LocalAuthorityName == establishment.LocalAuthority?.Name &&

                dto.Diocese.Name == establishment.Diocese &&

                dto.EstablishmentType.Name == establishment.EstablishmentType?.Name &&
                dto.EstablishmentType.Code == establishment.EstablishmentType?.Code &&

                dto.Gor.Name == establishment.GORregion &&

                dto.PhaseOfEducation.Name == establishment.PhaseOfEducation &&

                dto.ReligiousCharacter.Name == establishment.ReligiousCharacter &&

                dto.ParliamentaryConstituency.Name == establishment.ParliamentaryConstituency &&

                dto.Census.NumberOfPupils == establishment.NumberOfPupils &&
                dto.Census.PercentageFsm == establishment.PercentageFSM &&

                dto.MISEstablishment.DateOfLatestSection8Inspection == misEstablishment.DateOfLatestSection8Inspection?.ToString(new CultureInfo("en-GB")) &&
                dto.MISEstablishment.InspectionEndDate == null &&
                dto.MISEstablishment.OverallEffectiveness == misEstablishment.OverallEffectiveness?.ToString() &&
                dto.MISEstablishment.QualityOfEducation == misEstablishment.QualityOfEducation?.ToString() &&
                dto.MISEstablishment.BehaviourAndAttitudes == misEstablishment.BehaviourAndAttitudes?.ToString() &&
                dto.MISEstablishment.PersonalDevelopment == misEstablishment.PersonalDevelopment?.ToString() &&
                dto.MISEstablishment.EffectivenessOfLeadershipAndManagement == misEstablishment.EffectivenessOfLeadershipAndManagement?.ToString() &&
                dto.MISEstablishment.EarlyYearsProvision == misEstablishment.EarlyYearsProvisionWhereApplicable?.ToString() &&
                dto.MISEstablishment.SixthFormProvision == misEstablishment.SixthFormProvisionWhereApplicable?.ToString() &&
                dto.MISEstablishment.Weblink == misEstablishment.WebLink &&

                dto.Address.Street == establishment.AddressLine1 &&
                dto.Address.Town == establishment.Town &&
                dto.Address.Postcode == establishment.Postcode &&
                dto.Address.County == establishment.County &&
                dto.Address.Additional == establishment.AddressLine2 &&
                dto.PreviousEstablishment.Urn == educationEstablishmentLink.LinkURN.ToString()
                );
        }

    }
}

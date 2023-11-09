using AutoFixture;
using Dfe.Academies.Application.Queries.Establishment;
using Dfe.Academies.Contracts.Establishments;
using Dfe.Academies.Contracts.Trusts;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Trust;
using FluentAssertions;
using Moq;
using System.Runtime.CompilerServices;

namespace Dfe.Academies.Application.Tests.Queries.Establishment
{
    public class EstablishmentQueriesTests
    {

        private Fixture _fixture;

        public EstablishmentQueriesTests()
        {
            _fixture = new Fixture();
        }


        [Fact]
        public async Task GetByUkprn_WhenEstablishmentReturnedFromRepo_EstablishmentDtoIsReturned()
        {
            // Arrange
            var establishment = _fixture.Create<Domain.Establishment.Establishment?>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();

            string ukprn = "1010101";
            mockRepo.Setup(x => x.GetEstablishmentByUkprn(It.Is<string>(v => v == ukprn), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishment));

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetByUkprn(
                ukprn,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(EstablishmentDto));
            Assert.True(HasMappedCorrectly(result, establishment));
        }

        [Fact]
        public async Task GetByUrn_WhenEstablishmentReturnedFromRepo_EstablishmentDtoIsReturned()
        {
            // Arrange
            var establishment = _fixture.Create<Domain.Establishment.Establishment?>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();
            string urn = "1010101";
            mockRepo.Setup(x => x.GetEstablishmentByUrn(It.Is<string>(v => v == urn), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishment));

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.GetByUrn(
                urn,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(EstablishmentDto));
            Assert.True(HasMappedCorrectly(result, establishment));
        }

        [Fact]
        public async Task Search_WhenEstablishmentsReturnedFromRepo_EstablishmentDtoListAndCountIsReturned()
        {
            // Arrange
            var establishments = _fixture.Create<List<Domain.Establishment.Establishment>>();
            var mockRepo = new Mock<IEstablishmentRepository>();
            var mockTrustRepo = new Mock<ITrustRepository>();           
            string urn = "1010101";
            string name = "Test name";
            string ukPrn = "Test UkPrn";
            mockRepo.Setup(x => x.Search(It.Is<string>(v => v == name), It.Is<string>(v => v == ukPrn), It.Is<string>(v => v == urn), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishments));

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object);

            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);

            // Act
            var result = await establishmentQueries.Search(
                name,
                ukPrn,
                urn,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof((List<EstablishmentDto>, int)));
            foreach (var establishmentDto in result.Item1) {
                var establishment = establishments.Single(x => x.URN.ToString() == establishmentDto.Urn);
                Assert.True(HasMappedCorrectly(establishmentDto, establishment));
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

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object);
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
            mockRepo.Setup(x => x.GetByUrns(It.Is<int[]>(v => v == Urns), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishments));

            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockTrustRepo.Object);
            CancellationToken cancellationToken = default(global::System.Threading.CancellationToken);
            // Act
            var result = await establishmentQueries.GetByUrns(
                Urns, cancellationToken);

            // Assert
            result.Should().BeOfType(typeof(List<EstablishmentDto>));
            foreach (var establishmentDto in result)
            {
                var establishment = establishments.Single(x => x.URN.ToString() == establishmentDto.Urn);
                Assert.True(HasMappedCorrectly(establishmentDto, establishment));
            }
        }

        private bool HasMappedCorrectly(EstablishmentDto dto, Domain.Establishment.Establishment establishment)
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

                dto.MISEstablishment.DateOfLatestSection8Inspection == establishment.DateOfLatestShortInspection?.ToString() &&
                dto.MISEstablishment.InspectionEndDate == establishment.InspectionEndDate?.ToString() &&
                dto.MISEstablishment.OverallEffectiveness == establishment.OverallEffectiveness?.ToString() &&
                dto.MISEstablishment.QualityOfEducation == establishment.QualityOfEducation?.ToString() &&
                dto.MISEstablishment.BehaviourAndAttitudes == establishment.BehaviourAndAttitudes?.ToString() &&
                dto.MISEstablishment.PersonalDevelopment == establishment.PersonalDevelopment?.ToString() &&
                dto.MISEstablishment.EffectivenessOfLeadershipAndManagement == establishment.EffectivenessOfLeadershipAndManagement?.ToString() &&
                dto.MISEstablishment.EarlyYearsProvision == establishment.EarlyYearsProvisionWhereApplicable?.ToString() &&
                dto.MISEstablishment.SixthFormProvision == establishment.SixthFormProvisionWhereApplicable?.ToString() &&

                dto.Address.Street == establishment.AddressLine1 &&
                dto.Address.Town == establishment.Town &&
                dto.Address.Postcode == establishment.Postcode &&
                dto.Address.County == establishment.County &&
                dto.Address.Additional == establishment.AddressLine2
                );
        }

    }
}

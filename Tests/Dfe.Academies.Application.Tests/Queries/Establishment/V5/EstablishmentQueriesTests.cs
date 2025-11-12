using AutoFixture;
using Dfe.Academies.Application.Establishment.V5;
using Dfe.Academies.Domain.Establishment;
using Dfe.Academies.Domain.Interfaces.Repositories;
using Dfe.Academies.Utils.Extensions;
using FluentAssertions;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V5.Establishments;
using Moq;
using System.Globalization;

namespace Dfe.Academies.Application.Tests.Queries.Establishment.V5
{
    public class EstablishmentQueriesTests
    { 
        private Fixture _fixture;
        private MisEstablishment _misEstablishment; 
        private EducationEstablishmentLink _educationEstablishmentLink;
        private ReportCardMock _reportCardMock;

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
            _reportCardMock = _fixture.Create<ReportCardMock>();

        } 

        [Fact]
        public async Task Search_WhenEstablishmentsReturnedFromRepo_EstablishmentDtoListAndCountIsReturned()
        {
            // Arrange
            var establishments = _fixture.Create<List<Domain.Establishment.Establishment>>();
            var mockRepo = new Mock<IEstablishmentRepository>(); 
            var mockCensusRepo = new Mock<ICensusDataRepository>();

            string urn = "1010101";
            string name = "Test name";
            string ukPrn = "Test UkPrn";
            bool? excludeClosed = null;
            bool? matchAny = null;
            mockRepo.Setup(x => x.Search(It.Is<string>(v => v == name), It.Is<string>(v => v == ukPrn), It.Is<string>(v => v == urn), It.Is<bool?>(x => x == excludeClosed), It.Is<bool?>(x => x == matchAny), It.IsAny<CancellationToken>())).Returns(Task.FromResult(establishments));
            mockRepo.Setup(x => x.GetMisEstablishmentByURN(It.IsAny<int?>())).Returns(_misEstablishment);
            mockRepo.Setup(x => x.GetEducationEstablishmentLinksByURN(It.IsAny<long?>())).Returns(_educationEstablishmentLink);
            mockRepo.Setup(x => x.GetMockReportCardsByURN(It.IsAny<int?>())).Returns(_reportCardMock);
            var establishmentQueries = new EstablishmentQueries(
                mockRepo.Object, mockCensusRepo.Object);

            CancellationToken cancellationToken = default;

            // Act
            var result = await establishmentQueries.Search(
                name,
                ukPrn,
                urn,
                excludeClosed,
                matchAny,
                cancellationToken);

            // Assert
            result.Should().BeOfType(typeof((List<EstablishmentDto>, int)));
            foreach (var establishmentDto in result.Item1)
            {
                var establishment = establishments.Single(x => x.URN.ToString() == establishmentDto.Urn);
                Assert.True(HasMappedCorrectly(establishmentDto, establishment, _misEstablishment, _educationEstablishmentLink, _reportCardMock));
            }
        } 

        private static bool HasMappedCorrectly(EstablishmentDto dto, Domain.Establishment.Establishment establishment, MisEstablishment misEstablishment, EducationEstablishmentLink educationEstablishmentLink, ReportCardMock reportCardMock)
        {
            return
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
                dto.PreviousEstablishment!.Urn == educationEstablishmentLink.LinkURN.ToString() &&

                dto.ReportCard != null &&
                dto.ReportCard.WebLink == reportCardMock.WebLink &&
                dto.ReportCard.PreviousSafeguarding == reportCardMock.PreviousSafeguarding &&
                dto.ReportCard.PreviousPersonalDevelopmentAndWellbeing == reportCardMock.PreviousPersonalDevelopmentAndWellbeing &&
                dto.ReportCard.PreviousLeadershipAndGovernance == reportCardMock.PreviousLeadershipAndGovernance &&
                dto.ReportCard.LatestInspectionDate == reportCardMock.LatestInspectionDate.ToResponseDate() &&
                dto.ReportCard.LatestCurriculumAndTeaching == reportCardMock.LatestCurriculumAndTeaching &&
                dto.ReportCard.LatestAttendanceAndBehaviour == reportCardMock.LatestAttendanceAndBehaviour &&
                dto.ReportCard.LatestPersonalDevelopmentAndWellbeing == reportCardMock.LatestPersonalDevelopmentAndWellbeing &&
                dto.ReportCard.LatestLeadershipAndGovernance == reportCardMock.LatestLeadershipAndGovernance &&
                dto.ReportCard.LatestInclusion == reportCardMock.LatestInclusion &&
                dto.ReportCard.LatestAchievement == reportCardMock.LatestAchievement &&
                dto.ReportCard.LatestEarlyYearsProvision == reportCardMock.LatestEarlyYearsProvision &&
                dto.ReportCard.LatestSafeguarding == reportCardMock.LatestSafeguarding &&
                dto.ReportCard.PreviousInspectionDate == reportCardMock.PreviousInspectionDate.ToResponseDate() &&
                dto.ReportCard.PreviousCurriculumAndTeaching == reportCardMock.PreviousCurriculumAndTeaching &&
                dto.ReportCard.PreviousAttendanceAndBehaviour == reportCardMock.PreviousAttendanceAndBehaviour &&
                dto.ReportCard.PreviousInclusion == reportCardMock.PreviousInclusion &&
                dto.ReportCard.PreviousAchievement == reportCardMock.PreviousAchievement &&
                dto.ReportCard.PreviousEarlyYearsProvision == reportCardMock.PreviousEarlyYearsProvision;
        }

    }
}

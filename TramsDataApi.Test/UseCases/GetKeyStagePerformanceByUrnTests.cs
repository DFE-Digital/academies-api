using System;
using System.Linq;
using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.EducationalPerformance;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetKeyStagePerformanceByUrnTests
    {
        
        public GetKeyStagePerformanceByUrnTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));
        }
        
        [Fact]
        public void TestGetKeyStagePerformanceByUrn_ReturnsNull_WhenNoAccountIsFound()
        {
            var urn = "mockurn";
            var mockEducationPerformanceGateway = new Mock<IEducationPerformanceGateway>();
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetAccountByUrn(urn)).Returns(() => null);
            var useCase = new GetKeyStagePerformanceByUrn(mockEducationPerformanceGateway.Object);

            useCase.Execute(urn).Should().BeNull();
        }
        
        [Fact]
        public void TestGetKeyStagePerformanceByUrn_ReturnsAEducationPerformanceResponse_WhenDataIsFound()
        {
            var urn = "123453";
            var guid = Guid.NewGuid();
            var account = Builder<Account>.CreateNew()
                .With(a => a.SipUrn = urn)
                .With(a => a.Id = guid)
                .Build();
            var phonics = Builder<SipPhonics>.CreateListOfSize(5)
                .All()
                .With(ph => ph.SipUrn = urn)
                .Build();

            var educationPerformanceData = Builder<SipEducationalperformancedata>.CreateListOfSize(1)
                .All()
                .With(epd => epd.SipParentaccountid = guid)
                .Build();
            
            var mockEducationPerformanceGateway = new Mock<IEducationPerformanceGateway>();
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetAccountByUrn(urn)).Returns(() => account);
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetPhonicsByUrn(urn)).Returns(() => phonics);
            mockEducationPerformanceGateway.Setup(gateway => gateway.GetEducationalPerformanceForAccount(account)).Returns(() => educationPerformanceData);

            var expectedKs1 = phonics.Select(ph => new KeyStage1PerformanceResponse
            {
                Year = ph.SipYear,
                Reading = ph.SipKs1readingpercentageresults,
                Writing = ph.SipKs1writingpercentageresults,
                Maths = ph.SipKs1mathspercentageresults
            }).ToList();

            var expectedKs2 = educationPerformanceData.Select(epd => new KeyStage2PerformanceResponse
            {
                Year = epd.SipName,
                PercentageMeetingExpectedStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = epd.SipMeetingexpectedstandardinrwm,
                    Disadvantaged = epd.SipMeetingexpectedstandardinrwmdisadv
                },
                PercentageAchievingHigherStdInRWM = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = epd.SipMeetinghigherstandardinrwm,
                    Disadvantaged = epd.SipMeetinghigherstandardrwmdisadv
                },
                ProgressScore = new DisadvantagedPupilsResponse
                {
                    NotDisadvantaged = epd.SipProgress8score,
                    Disadvantaged = epd.SipProgress8score
                }
            }).ToList();
            
            var expected = new EducationalPerformanceResponse
            {
                SchoolName = account.Name,
                KeyStage1 = expectedKs1,
                KeyStage2 = expectedKs2
            };
            
            var useCase = new GetKeyStagePerformanceByUrn(mockEducationPerformanceGateway.Object);
            var result = useCase.Execute(urn);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
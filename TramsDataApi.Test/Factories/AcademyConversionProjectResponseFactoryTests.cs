using System;
using AutoFixture;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class AcademyConversionProjectResponseFactoryTests
    {
        [Fact]
        public void ReturnsAnAcademyConversionProjectResponse_WhenGivenAnAcademyConversionProject()
        {
            var fixture = new Fixture();
            var ifdPipeline = fixture.Build<IfdPipeline>().With(x => x.GeneralDetailsUrn, "12345").Create();

            var expectedResponse = new AcademyConversionProjectResponse
            {
                Id = (int)ifdPipeline.Sk,
                Urn = int.Parse(ifdPipeline.GeneralDetailsUrn),
                SchoolName = ifdPipeline.GeneralDetailsProjectName,
                LocalAuthority = ifdPipeline.GeneralDetailsLocalAuthority,
                ApplicationReceivedDate = ifdPipeline.InterestDateOfInterest,
                AssignedDate = ifdPipeline.ApprovalProcessApplicationDate,
                ProjectStatus = "Pre-HTB",
                RationaleForProject = ifdPipeline.ProjectTemplateInformationRationaleForProject,
                RationaleForTrust = ifdPipeline.ProjectTemplateInformationRationaleForSponsor
            };

            var academyConversionProjectResponse = AcademyConversionProjectResponseFactory.Create(ifdPipeline);

            academyConversionProjectResponse.Should().BeEquivalentTo(expectedResponse);
        }
    }
}

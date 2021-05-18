using System;
using System.Collections.Generic;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class CreateAcademyTransferProjectTests 
    {
        [Fact]
        public void ShouldCreateAndReturnAnAcademyTransferProject_WhenGivenACreateOrUpdateAcademyTransferProjectRequest()
        {
            var randomGenerator = new RandomGenerator();

            var gateway = new Mock<IAcademyTransferProjectGateway>();
            var createRequest = Builder<CreateOrUpdateAcademyTransferProjectRequest>.CreateNew()
                .With(c => c.ProjectUrn = null)
                .With(c => c.Benefits = Builder<AcademyTransferProjectBenefitsRequest>.CreateNew().Build())
                .With(c => c.Dates = Builder<AcademyTransferProjectDatesRequest>.CreateNew().Build())
                .With(c => c.Rationale = Builder<AcademyTransferProjectRationaleRequest>.CreateNew().Build())
                .With(c => c.TransferringAcademies = (List<TransferringAcademiesRequest>) Builder<TransferringAcademiesRequest>.CreateListOfSize(5).Build())
                .Build();

            var convertedAcademyTransferProject = AcademyTransferProjectFactory.Create(createRequest);
            var createdAcademyTransferProject = AcademyTransferProjectFactory.Create(createRequest);
            createdAcademyTransferProject.Id = randomGenerator.Int();
            createdAcademyTransferProject.Urn = randomGenerator.Int();

            var expected = AcademyTransferProjectResponseFactory.Create(createdAcademyTransferProject);
        
            gateway.Setup(g => g.CreateAcademyTransferProject(convertedAcademyTransferProject)).Returns(createdAcademyTransferProject); 
            
        
            var useCase = new CreateAcademyTransferProject(gateway.Object);
            var result = useCase.Execute(createRequest);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
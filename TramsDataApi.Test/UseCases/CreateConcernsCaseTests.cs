using System;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class CreateConcernsCaseTests
    {
        [Fact]
        public void ShouldCreateAndReturnAConcernsCase_WhenGivenAConcernsCaseRequest()
        {
            var concernsCaseGateway = new Mock<IConcernsCaseGateway>();
            var concernsStatusGateway = new Mock<IConcernsStatusGateway>();
            
            var createRequest = Builder<ConcernCaseRequest>.CreateNew()
                .With(c => c.CreatedAt = new DateTime(2022,10,13))
                .With(c => c.UpdatedAt = new DateTime(2022,06,07))
                .With(c => c.ReviewAt = new DateTime(2022,07,10))
                .With(c => c.CreatedBy = "7654")
                .With(c => c.Description = " Test Description for case")
                .With(c => c.CrmEnquiry = "3456")
                .With(c => c.TrustUkprn = "17654")
                .With(c => c.ReasonAtReview = "Test concerns")
                .With(c => c.DeEscalation = new DateTime(2022,04,01))
                .With(c => c.Issue = "Here is the issue")
                .With(c => c.CurrentStatus = "Case status")
                .With(c => c.CaseAim = "Here is the aim")
                .With(c => c.DeEscalationPoint = "Point of de-escalation")
                .With(c => c.NextSteps = "Here are the next steps")
                .With(c => c.DirectionOfTravel = "Up")
                .With(c => c.StatusUrn = 2)
                .Build();

            var status = Builder<ConcernsStatus>.CreateNew().Build();
            
            var createdConcernsCase = ConcernsCaseFactory.Create(createRequest, status);
            var expected = ConcernsCaseResponseFactory.Create(createdConcernsCase);
            
            concernsCaseGateway.Setup(g => g.SaveConcernsCase(It.IsAny<ConcernsCase>())).Returns(createdConcernsCase);
            concernsStatusGateway.Setup(g => g.GetStatusByUrn(It.IsAny<int>())).Returns(status);
            
            var useCase = new CreateConcernsCase(concernsCaseGateway.Object, concernsStatusGateway.Object);
            var result = useCase.Execute(createRequest);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
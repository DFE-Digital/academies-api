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
    public class CreateConcernsRecordTests
    {
        [Fact]
        public void ShouldCreateAndReturnAConcernsRecord_WhenGivenAConcernsRecordRequest()
        {
            var concernsRecordGateway = new Mock<IConcernsRecordGateway>();
            var concernsCaseGateway = new Mock<IConcernsCaseGateway>();
            var concernsTypeGateway = new Mock<IConcernsTypeGateway>();
            var concernsRatingGateway = new Mock<IConcernsRatingGateway>();
            
            var createRequest = Builder<ConcernsRecordRequest>.CreateNew().Build();
            var concernsCase = Builder<ConcernsCase>.CreateNew().Build();
            var concernsType = Builder<ConcernsType>.CreateNew().Build();
            var concernsRating = Builder<ConcernsRating>.CreateNew().Build();
            
            var createdConcernsRecord = ConcernsRecordFactory.Create(createRequest, concernsCase, concernsType, concernsRating);
            var expected = ConcernsRecordResponseFactory.Create(createdConcernsRecord);
            
            concernsRecordGateway.Setup(g => g.SaveConcernsCase(It.IsAny<ConcernsRecord>())).Returns(createdConcernsRecord);
            concernsCaseGateway.Setup(g => g.GetConcernsCaseByUrn(It.IsAny<int>())).Returns(concernsCase);
            concernsTypeGateway.Setup(g => g.GetConcernsTypeByUrn(It.IsAny<int>())).Returns(concernsType);
            concernsRatingGateway.Setup(g => g.GetRatingByUrn(It.IsAny<int>())).Returns(concernsRating);

            var useCase = new CreateConcernsRecord(
                concernsRecordGateway.Object, 
                concernsCaseGateway.Object, 
                concernsTypeGateway.Object, 
                concernsRatingGateway.Object);
            
            var result = useCase.Execute(createRequest);
            result.Should().BeEquivalentTo(expected);
        }
    }
}
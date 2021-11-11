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
            var concernsStatusGateway = new Mock<IConcernsStatusGateway>();
            
            var createRequest = Builder<ConcernsRecordRequest>.CreateNew().Build();
            var status = Builder<ConcernsStatus>.CreateNew().Build();
            
            var createdConcernsRecord = ConcernsRecordFactory.Create(createRequest, status);
            var expected = ConcernsRecordResponseFactory.Create(createdConcernsRecord);
            
            concernsRecordGateway.Setup(g => g.SaveConcernsCase(It.IsAny<ConcernsRecord>())).Returns(createdConcernsRecord);
            concernsStatusGateway.Setup(g => g.GetStatusByUrn(It.IsAny<int>())).Returns(status);
            
            var useCase = new CreateConcernsRecord(concernsRecordGateway.Object, concernsStatusGateway.Object);
            var result = useCase.Execute(createRequest);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
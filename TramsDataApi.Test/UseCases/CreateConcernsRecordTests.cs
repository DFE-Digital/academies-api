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
            
            var createRequest = Builder<ConcernsRecordRequest>.CreateNew().Build();
            var concernsCase = Builder<ConcernsCase>.CreateNew().Build();
            var concernsType = Builder<ConcernsType>.CreateNew().Build();
            
            var createdConcernsRecord = ConcernsRecordFactory.Create(createRequest, concernsCase, concernsType);
            var expected = ConcernsRecordResponseFactory.Create(createdConcernsRecord);
            
            concernsRecordGateway.Setup(g => g.SaveConcernsCase(It.IsAny<ConcernsRecord>())).Returns(createdConcernsRecord);
            concernsCaseGateway.Setup(g => g.GetConcernsCaseByUrn(It.IsAny<int>())).Returns(concernsCase);
            concernsTypeGateway.Setup(g => g.GetConcernsTypeByUrn(It.IsAny<int>())).Returns(concernsType);

            var useCase = new CreateConcernsRecord(concernsRecordGateway.Object, concernsCaseGateway.Object, concernsTypeGateway.Object);
            var result = useCase.Execute(createRequest);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
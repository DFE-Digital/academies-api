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
            var gateway = new Mock<IConcernsRecordGateway>();

            var createRequest = Builder<ConcernsRecordRequest>.CreateNew().Build();
            
            var createdConcernsRecord = ConcernsRecordFactory.Create(createRequest);
            var expected = ConcernsRecordResponseFactory.Create(createdConcernsRecord);
            
            gateway.Setup(g => g.SaveConcernsCase(It.IsAny<ConcernsRecord>())).Returns(createdConcernsRecord);
            
            var useCase = new CreateConcernsRecord(gateway.Object);
            var result = useCase.Execute(createRequest);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
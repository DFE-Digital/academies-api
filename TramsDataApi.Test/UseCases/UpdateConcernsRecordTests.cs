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
    public class UpdateConcernsRecordTests
    {
        [Fact]
        public void ShouldSaveAConcernsRecord_WhenGivenAModelToUpdate()
        {
            var recordUrn = 345;
            var recordGateway = new Mock<IConcernsRecordGateway>();
            var caseGateway = new Mock<IConcernsCaseGateway>();
            var typeGateway = new Mock<IConcernsTypeGateway>();
            var ratingGateway = new Mock<IConcernsRatingGateway>();
            
            var concernsRecord = Builder<ConcernsRecord>.CreateNew().With(r => r.Urn = recordUrn).Build();
            var updateRequest = Builder<ConcernsRecordRequest>.CreateNew().Build();
            var concernsCase = Builder<ConcernsCase>.CreateNew().Build();
            var concernsType = Builder<ConcernsType>.CreateNew().Build();
            var concernsRating = Builder<ConcernsRating>.CreateNew().Build();

            var concernsRecordToUpdate = ConcernsRecordFactory.Update(concernsRecord, updateRequest, concernsCase, concernsType, concernsRating);
            
            recordGateway.Setup(g => g.GetConcernsRecordByUrn(recordUrn)).Returns(concernsRecord);
            recordGateway.Setup(g => g.Update(It.IsAny<ConcernsRecord>())).Returns(concernsRecordToUpdate);
            caseGateway.Setup(g => g.GetConcernsCaseByUrn(It.IsAny<int>())).Returns(concernsCase);
            typeGateway.Setup(g => g.GetConcernsTypeByUrn(It.IsAny<int>())).Returns(concernsType);
            ratingGateway.Setup(g => g.GetRatingByUrn(It.IsAny<int>())).Returns(concernsRating);

            
            var expected = ConcernsRecordResponseFactory.Create(concernsRecordToUpdate);
            
            var useCase = new UpdateConcernsRecord(recordGateway.Object, caseGateway.Object, typeGateway.Object, ratingGateway.Object);
            var result = useCase.Execute(recordUrn, updateRequest);

            result.Should().BeEquivalentTo(expected);
        }
    }
}
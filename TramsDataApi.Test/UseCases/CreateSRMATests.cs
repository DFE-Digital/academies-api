using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.SRMA;
using TramsDataApi.ResponseModels.CaseActions.SRMA;
using TramsDataApi.UseCases.CaseActions;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class CreateSRMATests
	{
	    [Fact]
        public void CreateSRMA_ShouldCreateAndReturnSRMAResponse_WhenGivenCreateSRMARequest()
        {
			var status = Enums.SRMAStatus.Deployed;
			var datetOffered = DateTime.Now.AddDays(-5);

			var createSRMARequest = Builder<CreateSRMARequest>
	            .CreateNew()
	            .With(r => r.Status = status)
	            .With(r => r.DateOffered = datetOffered)
	            .Build();

			var srmaDbModel = new SRMACase
			{
				StatusId = (int)status,
				DateOffered = datetOffered
            };

            var expectedResult = new SRMAResponse
            {
				DateOffered = datetOffered,
				Status = status
			};
			
			var mockGateway = new Mock<ISRMAGateway>();
            
            mockGateway.Setup(g => g.CreateSRMA(It.IsAny<SRMACase>())).Returns(Task.FromResult(srmaDbModel));
            
            var useCase = new CreateSRMA(mockGateway.Object);
            
            var result = useCase.Execute(createSRMARequest);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
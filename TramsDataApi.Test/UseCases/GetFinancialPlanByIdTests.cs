using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases.CaseActions;
using Xunit;


namespace TramsDataApi.Test.UseCases
{
    public class GetFinancialPlanByIdTests
    {
        [Fact]
        public void GetFinancialPlanId_ShouldReturnFinancialPlanResponse_WhenGivenFinancialPlanId()
        {
            var fpId = 123;

            var matchingFP = new FinancialPlanCase
            {
                Id = fpId,
                Notes = "test notes xyz"
            };

            var fps = new List<FinancialPlanCase> {
                matchingFP,

                new FinancialPlanCase {
                    Id = 222,
                    Notes = "Financial Plan 2"
                },
                new FinancialPlanCase {
                    Id = 456,
                    Notes = "Financial plan 3"
                }
            };

            var expectedResult = FinancialPlanFactory.CreateResponse(matchingFP);

            var mockFPGateway = new Mock<IFinancialPlanGateway>();
            mockFPGateway.Setup(g => g.GetFinancialPlanById(fpId)).Returns(Task.FromResult(fps.Single(fp => fp.Id == fpId)));

            var useCase = new GetFinancialPlanById(mockFPGateway.Object);

            var result = useCase.Execute(fpId);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }

    }
}

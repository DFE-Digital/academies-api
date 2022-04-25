using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.SRMA;
using TramsDataApi.ResponseModels.CaseActions.SRMA;
using TramsDataApi.UseCases.CaseActions;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetSRMAsByCaseIdTests
    {
        [Fact]
        public void GetSRMAByCaseId_ShouldReturnSRMAResponse_WhenGivenCaseId()
        {
            var caseId = 123;

            var matchingSRMA = new SRMACase
            {
                CaseId = caseId,
                Notes = "match"
            };

            var srmas = new List<SRMACase> {
                matchingSRMA,
                new SRMACase {
                    CaseId = 222,
                    Notes = "SRMA 1"
                },
                new SRMACase {
                    CaseId = 456,
                    Notes = "SRMA 2"
                }
            };

            var expectedResult = SRMAFactory.CreateResponse(matchingSRMA);

            var mockSRMAGateway = new Mock<ISRMAGateway>();
            mockSRMAGateway.Setup(g => g.GetSRMAsByCaseId(caseId)).Returns(Task.FromResult((ICollection<SRMACase>)srmas.Where(s => s.CaseId == caseId).ToList()));

            var useCase = new GetSRMAsByCaseId(mockSRMAGateway.Object);

            var result = useCase.Execute(caseId);

            result.Should().NotBeNull();
            result.Count.Should().Be(1);
            result.First().Should().BeEquivalentTo(expectedResult);
        }
    }
}

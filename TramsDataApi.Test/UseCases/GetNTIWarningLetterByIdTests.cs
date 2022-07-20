using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases.CaseActions.NTI.WarningLetter;
using Xunit;


namespace TramsDataApi.Test.UseCases
{
    public class GetNTIWarningLetterByIdTests
    {
        [Fact]
        public void GetNTIWarningLetterById_ShouldReturnNTIWarningLetterResponse_WhenGivenNTIWarningLetterId()
        {
            var warningLetterId = 544;
            var reasonMappings = new List<NTIWarningLetterReasonMapping>() { new NTIWarningLetterReasonMapping() { NTIWarningLetterReasonId = 1 } };
            var conditionMappings = new List<NTIWarningLetterConditionMapping>() { new NTIWarningLetterConditionMapping() { NTIWarningLetterConditionId = 1 } };


            var warningLetter = new NTIWarningLetter
            {
                Id = warningLetterId,
                Notes = "test warning letter id",
                WarningLetterReasonsMapping = reasonMappings,
                WarningLetterConditionsMapping = conditionMappings
            };

            var expectedResult = NTIWarningLetterFactory.CreateResponse(warningLetter);

            var mockGateway = new Mock<INTIWarningLetterGateway>();
            mockGateway.Setup(g => g.GetNTIWarningLetterById(warningLetterId)).Returns(Task.FromResult(warningLetter));

            var useCase = new GetNTIWarningLetterById(mockGateway.Object);
            var result = useCase.Execute(warningLetterId);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }

    }
}

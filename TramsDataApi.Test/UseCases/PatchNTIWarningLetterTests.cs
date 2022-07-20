using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using Xunit;
using System;
using TramsDataApi.RequestModels.CaseActions.NTI.WarningLetter;
using System.Threading.Tasks;
using TramsDataApi.UseCases.CaseActions.NTI.WarningLetter;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.ResponseModels.CaseActions.NTI.WarningLetter;

namespace TramsDataApi.Test.UseCases
{
    public class PatchNTIWarningLetterTests
    {
        [Fact]
        public void ShouldPatchNTIWarningLetterAndReturnNTIWarningLetterResponse_WhenGivenPatchNTIWarningLetterRequest()
        {
            var id = 123;
            var caseUrn = 544;
            var now = DateTime.Now;
            var statusId = 1;
            var notes = "Notes";
            var createdBy = "Test User";
            var reasons = new List<int>() { 1, 3 };
            var conditions = new List<int>() { 1, 3 };


            var patchNTIWarningLetterRequest = Builder<PatchNTIWarningLetterRequest>
                .CreateNew()
                .With(r => r.Id = id)
                .With(r => r.CaseUrn = caseUrn)
                .With(r => r.StatusId = statusId)
                .With(r => r.CreatedAt = now)
                .With(r => r.DateLetterSent = now)
                .With(r => r.Notes = notes) 
                .With(r => r.CreatedBy = createdBy)
                .With(r => r.WarningLetterReasonsMapping = reasons)
                .With(r => r.WarningLetterConditionsMapping = conditions)
                .Build();

            var warningLetterDbModel = new NTIWarningLetter
            {
                Id = id,
                CaseUrn = caseUrn,
                CreatedAt = now,
                Notes = notes,
                CreatedBy = createdBy,
                WarningLetterReasonsMapping = reasons.Select(r => {
                    return new NTIWarningLetterReasonMapping()
                    {
                        NTIWarningLetterReasonId = r
                    };
                }).ToList(),
                WarningLetterConditionsMapping = conditions.Select(r => {
                    return new NTIWarningLetterConditionMapping()
                    {
                        NTIWarningLetterConditionId = r
                    };
                }).ToList(),
            };

            var expectedResult = new NTIWarningLetterResponse
            {
                Id = id,
                CaseUrn = caseUrn,
                CreatedAt = now,
                Notes = notes,
                CreatedBy = createdBy,
                WarningLetterReasonsMapping = reasons,
                WarningLetterConditionsMapping = conditions
            };

            var mockGateway = new Mock<INTIWarningLetterGateway>();
            mockGateway.Setup(g => g.PatchNTIWarningLetter(It.IsAny<NTIWarningLetter>())).Returns(Task.FromResult(warningLetterDbModel));

            var useCase = new PatchNTIWarningLetter(mockGateway.Object);
            var result = useCase.Execute(patchNTIWarningLetterRequest);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
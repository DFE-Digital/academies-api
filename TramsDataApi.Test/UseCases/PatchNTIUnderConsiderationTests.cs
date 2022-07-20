using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using Xunit;
using System;
using TramsDataApi.RequestModels.CaseActions.NTI.UnderConsideration;
using System.Threading.Tasks;
using TramsDataApi.UseCases.CaseActions;
using System.Collections.Generic;
using System.Linq;
using TramsDataApi.ResponseModels.CaseActions.NTI.UnderConsideration;

namespace TramsDataApi.Test.UseCases
{
    public class PatchNTIUnderConsiderationTests
    {

        [Fact]
        public void ShouldPatchNTIUnderConsiderationAndReturnNTIUnderConsiderationResponse_WhenGivenPatchNTIUnderConsiderationRequest()
        {
            var id = 123;
            var caseUrn = 544;
            var now = DateTime.Now;
            var notes = "Notes";
            var createdBy = "Test User";
            var reasons = new List<int>() { 1, 3 };

            var patchNTIUnderConsiderationRequest = Builder<PatchNTIUnderConsiderationRequest>
                .CreateNew()
                .With(r => r.Id = id)
                .With(r => r.CaseUrn = caseUrn)
                .With(r => r.CreatedAt = now)
                .With(r => r.Notes = notes)
                .With(r => r.CreatedBy = createdBy)
                .With(r => r.UnderConsiderationReasonsMapping = reasons)
                .Build();

            var considerationDbModel = new NTIUnderConsideration
            {
                Id = id,
                CaseUrn = caseUrn,
                CreatedAt = now,
                Notes = notes,
                CreatedBy = createdBy,
                UnderConsiderationReasonsMapping = reasons.Select(r => {
                    return new NTIUnderConsiderationReasonMapping()
                    {
                        NTIUnderConsiderationReasonId = r
                    };
                }).ToList()
            };

            var expectedResult = new NTIUnderConsiderationResponse
            {
                Id = id,
                CaseUrn = caseUrn,
                CreatedAt = now,
                Notes = notes,
                CreatedBy = createdBy,
                UnderConsiderationReasonsMapping = reasons
            };

            var mockGateway = new Mock<INTIUnderConsiderationGateway>();
            mockGateway.Setup(g => g.PatchNTIUnderConsideration(It.IsAny<NTIUnderConsideration>())).Returns(Task.FromResult(considerationDbModel));

            var useCase = new PatchNTIUnderConsideration(mockGateway.Object);
            var result = useCase.Execute(patchNTIUnderConsiderationRequest);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
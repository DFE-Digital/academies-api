using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetA2BApplyingSchoolTests
    {
        [Fact]
        public void GetA2BApplyingSchool_ShouldReturnNull_WhenApplyingSchoolIdIsNotFound()
        {
            const string applyingSchoolId = "10001";
            var mockGateway = new Mock<IA2BApplyingSchoolGateway>();

            mockGateway.Setup(g => g.GetByApplyingSchoolId(applyingSchoolId));
           
            var useCase = new GetA2BApplyingSchool(mockGateway.Object);
            var result = useCase.Execute(applyingSchoolId);

            result.Should().BeNull();
        }

        [Fact]
        public void GetA2BApplyingSchool_ShouldReturnA2BApplyingSchoolResponse_WhenApplyingSchoolIdIsFound()
        {
            const string applyingSchoolId = "10001";
            var mockGateway = new Mock<IA2BApplyingSchoolGateway>();
            var applyingSchool = Builder<A2BApplyingSchool>
                .CreateNew()
                .With(a => a.ApplyingSchoolId == applyingSchoolId)
                .With(a => a.SchoolDeclarationBodyAgree = 907660000)
                .With(a => a.SchoolDeclarationTeacherChair = 907660000)
                .With(a => a.SchoolDeclarationBodyAgreeOption = new A2BSelectOption { Id = 907660000, Name = "Yes"})
                .With(a => a.SchoolDeclarationTeacherChairOption = new A2BSelectOption { Id = 907660000, Name = "Yes"})
                .Build();
            
            var expected = A2BApplyingSchoolResponseFactory.Create(applyingSchool);

            mockGateway.Setup(g => g.GetByApplyingSchoolId(applyingSchoolId)).Returns(applyingSchool);
            
            var useCase = new GetA2BApplyingSchool(mockGateway.Object);
            var result = useCase.Execute(applyingSchoolId);
            
            result.Should().BeEquivalentTo(expected);
        }
    }
}
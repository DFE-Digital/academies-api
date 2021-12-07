using FizzWare.NBuilder;
using FluentValidation.TestHelper;
using TramsDataApi.RequestModels;
using TramsDataApi.Validators;
using Xunit;

namespace TramsDataApi.Test.Validators
{
    public class ConcernsCaseRequestValidatorTest
    {
        [Fact]
        public void ShouldHaveError_WhenRatingUrnIs0()
        {
            var validator = new ConcernsCaseRequestValidator();
            
            var request = Builder<ConcernCaseRequest>.CreateNew()
                .With(c => c.RatingUrn = 0)
                .Build();
            
            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(c => c.RatingUrn)
                .WithErrorCode("GreaterThanOrEqualValidator");
        }
    }
}
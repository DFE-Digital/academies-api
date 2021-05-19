using FizzWare.NBuilder;
using FluentValidation.TestHelper;
using TramsDataApi.RequestModels;
using TramsDataApi.Validators;
using Xunit;

namespace TramsDataApi.Test.Validators
{
    public class AcademyTransferProjectRequestValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenOutgoingUkprnIsNull()
        {
            var validator = new AcademyTransferProjectRequestValidator();
            var request = Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(atp => atp.OutgoingTrustUkprn = null)
                .Build();
            
            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(atp => atp.OutgoingTrustUkprn)
                .WithErrorCode("NotNullValidator");
        }
        
        [Fact]
        public void ShouldHaveError_WhenOutgoingUkprnIsNot8CharactersLong()
        {
            var validator = new AcademyTransferProjectRequestValidator();
            var request = Builder<AcademyTransferProjectRequest>.CreateNew()
                .With(atp => atp.OutgoingTrustUkprn = "0000")
                .Build();
            
            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(atp => atp.OutgoingTrustUkprn)
                .WithErrorCode("ExactLengthValidator");;
        }

    }
}
using FizzWare.NBuilder;
using FluentValidation.TestHelper;
using TramsDataApi.RequestModels;
using TramsDataApi.Validators;
using Xunit;

namespace TramsDataApi.Test.Validators
{
    public class TransferringAcademiesRequestValidatorTests
    {
        [Fact]
        public void ShouldHaveError_WhenOutgoingAcademyUkprnIsNull()
        {
            var validator = new TransferringAcademiesRequestValidator();
            
            var request = Builder<TransferringAcademiesRequest>.CreateNew()
                .With(atp => atp.OutgoingAcademyUkprn = null)
                .Build();
            
            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(ta => ta.OutgoingAcademyUkprn)
                .WithErrorCode("NotNullValidator");
        }
        
        [Fact]
        public void ShouldHaveError_WhenOutgoingAcademyUkprnIsNot8CharactersLong()
        {
            var validator = new TransferringAcademiesRequestValidator();
            var request = Builder<TransferringAcademiesRequest>.CreateNew()
                .With(atp => atp.OutgoingAcademyUkprn = "1102")
                .Build();
            
            var result = validator.TestValidate(request);
            result.ShouldHaveValidationErrorFor(atp => atp.OutgoingAcademyUkprn)
                .WithErrorCode("ExactLengthValidator");;
        }
    }
}
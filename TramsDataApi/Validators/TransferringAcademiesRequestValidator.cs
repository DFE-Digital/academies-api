using FluentValidation;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Validators
{
    public class TransferringAcademiesRequestValidator : AbstractValidator<TransferringAcademiesRequest>
    {
        public TransferringAcademiesRequestValidator()
        {
            RuleFor(x => x.OutgoingAcademyUkprn).Length(8)
                .WithMessage("OutgoingTrustUkprn must be length 8")
                .NotNull().WithMessage("OutgoingTrustUkprn must not be null");
        }
    }
}
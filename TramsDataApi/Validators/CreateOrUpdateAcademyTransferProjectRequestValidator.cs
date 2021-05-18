using FluentValidation;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Validators
{
    public class CreateOrUpdateAcademyTransferProjectRequestValidator : AbstractValidator<CreateOrUpdateAcademyTransferProjectRequest>
    {
        public CreateOrUpdateAcademyTransferProjectRequestValidator()
        {
            RuleFor(x => x.OutgoingTrustUkprn).Length(8)
                .WithMessage("OutgoingTrustUkprn must be length 8")
                .NotNull().WithMessage("OutgoingTrustUkprn must not be null");
        }
    }
}
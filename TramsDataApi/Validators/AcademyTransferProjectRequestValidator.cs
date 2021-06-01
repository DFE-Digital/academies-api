using System.Linq;
using FluentValidation;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Validators
{
    public class AcademyTransferProjectRequestValidator : AbstractValidator<AcademyTransferProjectRequest>
    {
        public AcademyTransferProjectRequestValidator()
        {
            RuleFor(x => x.OutgoingTrustUkprn).Length(8)
                .WithMessage("OutgoingTrustUkprn must be length 8")
                .NotNull().WithMessage("OutgoingTrustUkprn must not be null");

            RuleForEach(x => x.TransferringAcademies).SetValidator(new TransferringAcademiesRequestValidator());
        }
    }
}
using Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn;
using Dfe.Academies.Utils.Enums;
using Dfe.Academies.Utils.Helpers;
using FluentValidation;

namespace Dfe.Academies.Application.Trust.Queries.GetAllPersonsAssociatedWithTrustByTrnOrUkprn
{
    public class GetAllPersonsAssociatedWithTrustByTrnOrUkprnValidator : AbstractValidator<GetAllPersonsAssociatedWithTrustByTrnOrUkprnQuery>
    {
        public GetAllPersonsAssociatedWithTrustByTrnOrUkprnValidator()
        {
            RuleFor(query => query.Id)
                .NotEmpty().WithMessage("An identifier must be provided.")
                .Must(id => TrustIdValidator.GetTrustIdValidators()[TrustIdType.Trn](id)
                            || TrustIdValidator.GetTrustIdValidators()[TrustIdType.UkPrn](id))
                .WithMessage("The identifier must be either a valid TRN (TR{5 digits}) or a valid UKPRN (8 digits).");
        }
    }
}
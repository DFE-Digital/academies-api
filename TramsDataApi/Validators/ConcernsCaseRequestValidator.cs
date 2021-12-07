using FluentValidation;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Validators
{
    public class ConcernsCaseRequestValidator : AbstractValidator<ConcernCaseRequest>
    {
        public ConcernsCaseRequestValidator()
        {
            RuleFor(x => x.RatingUrn).GreaterThanOrEqualTo(1)
                .WithMessage("Ratings Urn can not be 0");
        }
    }
}
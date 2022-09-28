using System;
using FluentValidation;
using TramsDataApi.RequestModels;

namespace TramsDataApi.Validators
{
    [Obsolete("This is planned to be moved into the Concerns Casework API. If it is accessed by other APIs, please let the Concerns team know.")]
    public class ConcernsCaseRequestValidator : AbstractValidator<ConcernCaseRequest>
    {
        public ConcernsCaseRequestValidator()
        {
            RuleFor(x => x.RatingUrn).GreaterThanOrEqualTo(1)
                .WithMessage("Ratings Urn can not be 0");
        }
    }
}
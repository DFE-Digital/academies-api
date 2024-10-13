using FluentValidation;

namespace Dfe.Academies.Application.Establishment.Queries.GetMemberOfParliamentBySchool
{
    public class GetMemberOfParliamentBySchoolQueryValidator : AbstractValidator<GetMemberOfParliamentBySchoolQuery>
    {
        public GetMemberOfParliamentBySchoolQueryValidator()
        {
            RuleFor(query => query.Urn)
                .GreaterThan(0).WithMessage("URN must be greater than 0.")
                .NotEmpty().WithMessage("URN is required.");
        }
    }
}
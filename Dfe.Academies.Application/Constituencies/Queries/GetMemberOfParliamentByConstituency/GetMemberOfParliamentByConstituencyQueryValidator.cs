using FluentValidation;

namespace Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituency
{
    public class GetMemberOfParliamentByConstituencyQueryValidator : AbstractValidator<GetMemberOfParliamentByConstituencyQuery>
    {
        public GetMemberOfParliamentByConstituencyQueryValidator()
        {
            RuleFor(x => x.ConstituencyName)
                .NotNull().WithMessage("Constituency name cannot be null.")
                .NotEmpty().WithMessage("Constituency name cannot be empty.");
        }
    }
}

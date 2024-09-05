using FluentValidation;

namespace Dfe.Academies.Application.Constituencies.Queries.GetMemberOfParliamentByConstituencies
{
    public class GetMemberOfParliamentByConstituenciesValidator : AbstractValidator<GetMembersOfParliamentByConstituenciesQuery>
    {
        public GetMemberOfParliamentByConstituenciesValidator()
        {
            RuleFor(x => x.ConstituencyNames)
                .NotNull().WithMessage("Constituency names cannot be null.")
                .NotEmpty().WithMessage("Constituency names cannot be empty.")
                .Must(c => c.Any()).WithMessage("At least one constituency must be provided.");
        }
    }
}

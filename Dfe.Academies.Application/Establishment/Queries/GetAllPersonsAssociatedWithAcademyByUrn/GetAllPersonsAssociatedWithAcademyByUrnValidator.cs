using FluentValidation;

namespace Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn
{
    public class GetAllPersonsAssociatedWithAcademyByUrnValidator : AbstractValidator<GetAllPersonsAssociatedWithAcademyByUrnQuery>
    {
        public GetAllPersonsAssociatedWithAcademyByUrnValidator()
        {
            RuleFor(query => query.Urn)
                .GreaterThan(0).WithMessage("URN must be greater than 0.")
                .NotEmpty().WithMessage("URN is required.");
        }
    }
}

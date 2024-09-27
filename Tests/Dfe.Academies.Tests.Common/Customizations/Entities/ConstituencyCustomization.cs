using AutoFixture;
using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Domain.ValueObjects;

namespace Dfe.Academies.Tests.Common.Customizations.Entities
{
    public class ConstituencyCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customize<Constituency>(composer => composer.FromFactory(() =>
            {
                var constituencyId = fixture.Create<ConstituencyId>();
                var memberId = fixture.Create<MemberId>();
                var nameDetails = new NameDetails(
                    "Doe, John",
                    "John Doe",
                    "Mr. John Doe MP"
                );

                return new Constituency(
                    constituencyId,
                    memberId,
                    fixture.Create<string>(),
                    nameDetails,
                    fixture.Create<DateTime>(),
                    DateOnly.FromDateTime(fixture.Create<DateTime>().Date),
                    fixture.Create<MemberContactDetails>()
                );
            }));
        }
    }
}

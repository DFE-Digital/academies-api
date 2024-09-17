using Dfe.Academies.Domain.Constituencies;
using Dfe.Academies.Domain.ValueObjects;
using Dfe.Academies.Testing.Common.Attributes;
using Dfe.Academies.Testing.Common.Customizations;
using Dfe.Academies.Testing.Common.Customizations.Models;

namespace Dfe.Academies.Domain.Tests.Aggregates
{
    public class ConstituencyTests
    {
        [Theory]
        [CustomAutoData(typeof(MemberOfParliamentCustomization), typeof(DateOnlyCustomization))]
        public void Constructor_ShouldThrowArgumentNullException_WhenConstituencyIdIsNull(
            MemberId memberId,
            string constituencyName,
            NameDetails nameDetails,
            DateTime lastRefresh,
            DateOnly? endDate,
            MemberContactDetails memberContactDetails)
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new Constituency(null!, memberId, constituencyName, nameDetails, lastRefresh, endDate, memberContactDetails));

            Assert.Equal("constituencyId", exception.ParamName);
        }

        [Theory]
        [CustomAutoData(typeof(MemberOfParliamentCustomization), typeof(DateOnlyCustomization))]
        public void Constructor_ShouldThrowArgumentNullException_WhenMemberIdIsNull(
            ConstituencyId constituencyId,
            string constituencyName,
            NameDetails nameDetails,
            DateTime lastRefresh,
            DateOnly? endDate,
            MemberContactDetails memberContactDetails)
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new Constituency(constituencyId, null!, constituencyName, nameDetails, lastRefresh, endDate, memberContactDetails));

            Assert.Equal("memberId", exception.ParamName);
        }

        [Theory]
        [CustomAutoData(typeof(MemberOfParliamentCustomization), typeof(DateOnlyCustomization))]
        public void Constructor_ShouldThrowArgumentNullException_WhenNameDetailsIsNull(
            ConstituencyId constituencyId,
            MemberId memberId,
            string constituencyName,
            DateTime lastRefresh,
            DateOnly? endDate,
            MemberContactDetails memberContactDetails)
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() =>
                new Constituency(constituencyId, memberId, constituencyName, null!, lastRefresh, endDate, memberContactDetails));

            Assert.Equal("nameDetails", exception.ParamName);
        }
    }
}

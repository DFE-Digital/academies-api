using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels.Concerns.TeamCasework;
using TramsDataApi.Gateways;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    public class GetConcernsTeamCaseworkSelectedUsersTests
    {
        [Fact]
        public async Task Execute_When_Team_Found_Returns_ConcernsCaseworkTeam()
        {
            var ownerId = "john.doe";
            var mockGateway = new Mock<IConcernsTeamCaseworkGateway>();
            var useCase = new GetConcernsTeamCaseworkSelectedUsers(mockGateway.Object);

            mockGateway
            .Setup(g => g.GetByOwnerId(ownerId, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ConcernsCaseworkTeam
            {
                Id = ownerId,
                TeamMembers = new List<ConcernsCaseworkTeamMember>
                {
                    new ConcernsCaseworkTeamMember { TeamMember = "user.one" } ,
                    new ConcernsCaseworkTeamMember { TeamMember = "user.two" } ,
                    new ConcernsCaseworkTeamMember { TeamMember = "user.three" }
                }
            });

            var sut = new GetConcernsTeamCaseworkSelectedUsers(mockGateway.Object);
            var result = await sut.Execute(ownerId, CancellationToken.None);

            result.Should().NotBeNull();
            result.OwnerId.Should().Be(ownerId);
            result.TeamMembers.Length.Should().Be(3);
            result.TeamMembers.Should().Contain("user.one");
            result.TeamMembers.Should().Contain("user.two");
            result.TeamMembers.Should().Contain("user.three");
        }
        [Fact]
        public async Task Execute_When_Teamw_NotFound_Returns_Null()
        {
            var ownerId = "john.doe";
            var mockGateway = new Mock<IConcernsTeamCaseworkGateway>();
            var useCase = new GetConcernsTeamCaseworkSelectedUsers(mockGateway.Object);

            mockGateway
                .Setup(g => g.GetByOwnerId(ownerId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(ConcernsCaseworkTeam));

            var sut = new GetConcernsTeamCaseworkSelectedUsers(mockGateway.Object);
            var result = await sut.Execute(ownerId, CancellationToken.None);

            result.Should().BeNull();
        }
    }
}

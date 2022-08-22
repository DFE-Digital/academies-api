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
        public async Task Execute_When_Teamwork_Selections_Found_Returns_ConcernsTeamCaseworkSelectedUsers()
        {
            var ownerId = "john.doe";
            var mockGateway = new Mock<IConcernsTeamCaseworkGateway>();
            var useCase = new GetConcernsTeamCaseworkSelectedUsers(mockGateway.Object);

            mockGateway
                .Setup(g => g.GetByOwnerId(ownerId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ConcernsTeamCaseworkTeamMember[] { 
                    new ConcernsTeamCaseworkTeamMember { TeamMember = "user.one" } ,
                    new ConcernsTeamCaseworkTeamMember { TeamMember = "user.two" } ,
                    new ConcernsTeamCaseworkTeamMember { TeamMember = "user.three" } ,
            });

            var sut = new GetConcernsTeamCaseworkSelectedUsers(mockGateway.Object);
            var result = await sut.Execute(ownerId, CancellationToken.None);

            result.Should().NotBeNull();
            result.OwnerId.Should().Be(ownerId);
            result.SelectedTeamMembers.Length.Should().Be(3);
            result.SelectedTeamMembers.Should().Contain("user.one");
            result.SelectedTeamMembers.Should().Contain("user.two");
            result.SelectedTeamMembers.Should().Contain("user.three");
        }
        [Fact]
        public async Task Execute_When_Teamwork_Selections_NotFound_Returns_Null()
        {
            var ownerId = "john.doe";
            var mockGateway = new Mock<IConcernsTeamCaseworkGateway>();
            var useCase = new GetConcernsTeamCaseworkSelectedUsers(mockGateway.Object);

            mockGateway
                .Setup(g => g.GetByOwnerId(ownerId, It.IsAny<CancellationToken>()))
                .ReturnsAsync(default(ConcernsTeamCaseworkTeamMember[]));

            var sut = new GetConcernsTeamCaseworkSelectedUsers(mockGateway.Object);
            var result = await sut.Execute(ownerId, CancellationToken.None);

            result.Should().BeNull();
        }
    }
}

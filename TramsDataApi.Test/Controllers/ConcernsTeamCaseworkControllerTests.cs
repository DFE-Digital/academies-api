using FizzWare.NBuilder;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.Controllers.V2;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.Concerns.TeamCasework;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.Controllers
{
    public class ConcernsTeamCaseworkControllerTests
    {
        private Mock<ILogger<ConcernsTeamCaseworkController>> _mockLogger = new Mock<ILogger<ConcernsTeamCaseworkController>>();

        [Fact]
        public async Task Get_Returns200WhenSuccessfullyFetchedData()
        {
            // arrange
            var expectedOwnerId = "john.smith";
            var expectedData = new ConcernsTeamCaseworkSelectedUsersResponse() { OwnerId = expectedOwnerId, SelectedTeamMembers = new[] { "john.doe", "jane.doe", "fred.flintstone" } };
            
            var getCommand = new Mock<IGetConcernsTeamCaseworkSelectedUsers>();
            getCommand.Setup(x => x.Execute(expectedOwnerId, It.IsAny<CancellationToken>())).ReturnsAsync(expectedData);

            var updateCommand = new Mock<IUpdateConcernsTeamCaseworkSelectedUsers>();

            var controller = new ConcernsTeamCaseworkController(
                _mockLogger.Object,
                getCommand.Object,
                updateCommand.Object
            );

            // act
            var actionResult = await controller.Get("john.smith", CancellationToken.None);
            var expectedResponse = new ApiSingleResponseV2<ConcernsTeamCaseworkSelectedUsersResponse>(expectedData);

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            okResult.StatusCode.Value.Should().Be(StatusCodes.Status200OK);
            (okResult.Value as ApiSingleResponseV2<ConcernsTeamCaseworkSelectedUsersResponse>).Should().NotBeNull();
            ((ApiSingleResponseV2<ConcernsTeamCaseworkSelectedUsersResponse>)okResult.Value).Data.Should().BeEquivalentTo(expectedData);
        }
    }
}

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
using TramsDataApi.RequestModels.Concerns.TeamCasework;
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
            var expectedData = new ConcernsCaseworkTeamResponse() { OwnerId = expectedOwnerId, TeamMembers = new[] { "john.doe", "jane.doe", "fred.flintstone" } };
            
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
            var expectedResponse = new ApiSingleResponseV2<ConcernsCaseworkTeamResponse>(expectedData);

            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            okResult.StatusCode.Value.Should().Be(StatusCodes.Status200OK);
            (okResult.Value as ApiSingleResponseV2<ConcernsCaseworkTeamResponse>).Should().NotBeNull();
            ((ApiSingleResponseV2<ConcernsCaseworkTeamResponse>)okResult.Value).Data.Should().BeEquivalentTo(expectedData);
        }


        [Fact]
        public async Task Get_ReturnsNoContentWhenNoDataAvailable()
        {
            // arrange
            var expectedOwnerId = "john.smith";
            var expectedData = new ConcernsCaseworkTeamResponse() { OwnerId = expectedOwnerId, TeamMembers = new[] { "john.doe", "jane.doe", "fred.flintstone" } };

            var getCommand = new Mock<IGetConcernsTeamCaseworkSelectedUsers>();
            getCommand.Setup(x => x.Execute(expectedOwnerId, It.IsAny<CancellationToken>())).ReturnsAsync(default(ConcernsCaseworkTeamResponse));

            var updateCommand = new Mock<IUpdateConcernsTeamCaseworkSelectedUsers>();

            var controller = new ConcernsTeamCaseworkController(
                _mockLogger.Object,
                getCommand.Object,
                updateCommand.Object
            );

            // act
            var actionResult = await controller.Get("john.smith", CancellationToken.None);
            Assert.IsType<NoContentResult>(actionResult.Result);
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_When_OwnerId_Differs_From_Model()
        {
            // arrange            
            var getCommand = new Mock<IGetConcernsTeamCaseworkSelectedUsers>();
            var updateCommand = new Mock<IUpdateConcernsTeamCaseworkSelectedUsers>();

            var controller = new ConcernsTeamCaseworkController(
                _mockLogger.Object,
                getCommand.Object,
                updateCommand.Object
            );

            var updateModel = new ConcernsCaseworkTeamUpdateRequest
            {
                OwnerId = "different.ownerId",
                TeamMembers = new[] { "Barny.Rubble" }
            };

            // act
            var actionResult = await controller.Put("john.smith", updateModel, CancellationToken.None);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Put_ReturnsBadRequest_When_Model_IsNull()
        {
            // arrange
            var getCommand = new Mock<IGetConcernsTeamCaseworkSelectedUsers>();

            var updateCommand = new Mock<IUpdateConcernsTeamCaseworkSelectedUsers>();

            var controller = new ConcernsTeamCaseworkController(
                _mockLogger.Object,
                getCommand.Object,
                updateCommand.Object
            );

            // act
            var actionResult = await controller.Put("john.smith", null, CancellationToken.None);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Put_ReturnsOK_When_UpdateCommand_Executed()
        {
            // arrange
            var expectedOwnerId = "john.smith";
            var expectedModel = new ConcernsCaseworkTeamUpdateRequest() { OwnerId = expectedOwnerId, TeamMembers = new[] { "john.doe", "jane.doe", "fred.flintstone" } };

            var getCommand = new Mock<IGetConcernsTeamCaseworkSelectedUsers>();
            var updateCommand = new Mock<IUpdateConcernsTeamCaseworkSelectedUsers>();
            updateCommand.Setup(x => x.Execute(expectedModel, It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ConcernsCaseworkTeamResponse { OwnerId = expectedModel.OwnerId, TeamMembers = expectedModel.TeamMembers });

            var controller = new ConcernsTeamCaseworkController(
                _mockLogger.Object,
                getCommand.Object,
                updateCommand.Object
            );

            // act
            var actionResult = await controller.Put(expectedOwnerId, expectedModel, CancellationToken.None);
            var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
            (okResult.Value as ApiSingleResponseV2<ConcernsCaseworkTeamResponse>).Should().NotBeNull();
            ((ApiSingleResponseV2<ConcernsCaseworkTeamResponse>)okResult.Value).Data.Should().BeEquivalentTo(expectedModel);
        }
    }
}

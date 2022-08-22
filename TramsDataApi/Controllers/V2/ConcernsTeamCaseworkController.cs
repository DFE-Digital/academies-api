using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using TramsDataApi.RequestModels.Concerns.TeamCasework;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.Concerns.TeamCasework;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/concerns-team-casework")]

    public class ConcernsTeamCaseworkController : ControllerBase
    {
        private ILogger<ConcernsTeamCaseworkController> _logger;
        private readonly IGetConcernsTeamCaseworkSelectedUsers _getCommand;
        private readonly IUpdateConcernsTeamCaseworkSelectedUsers _updateCommand;

        public ConcernsTeamCaseworkController(ILogger<ConcernsTeamCaseworkController> logger, IGetConcernsTeamCaseworkSelectedUsers getCommand,
            IUpdateConcernsTeamCaseworkSelectedUsers updateCommand)
        {
            _logger=logger ?? throw new ArgumentNullException(nameof(logger));
            _getCommand = getCommand ?? throw new ArgumentNullException(nameof(getCommand));
            _updateCommand = updateCommand ?? throw new ArgumentNullException(nameof(updateCommand));
        }

        [HttpGet("owner/{ownerId}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ApiSingleResponseV2<ConcernsTeamCaseworkSelectedUsersResponse>>> Get(string ownerId, CancellationToken cancellationToken)
        {
            return await LogAndInvoke(async () =>
            {
                var result = await _getCommand.Execute(ownerId, cancellationToken);
                if (result is null)
                {
                    return NotFound();
                }

                var responseData = new ApiSingleResponseV2<ConcernsTeamCaseworkSelectedUsersResponse>(result);
                return Ok(responseData);
            });
        }

        [HttpPut("owner/{ownerId}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ApiSingleResponseV2<ConcernsTeamCaseworkSelectedUsersResponse>>> Put(
            string ownerId,
            [FromBody] ConcernsTeamCaseworkSelectedUsersUpdateRequest updateModel,
            CancellationToken cancellationToken)
        {
            return await LogAndInvoke(async () =>
            {
                if (updateModel == null || updateModel.OwnerId != ownerId)
                {
                    return BadRequest(new { Error = "update model does not match ownerId" });
                }

                var result = await _updateCommand.Execute(updateModel, cancellationToken);
                var responseData = new ApiSingleResponseV2<ConcernsTeamCaseworkSelectedUsersResponse>(result);
                return Ok(responseData);
            });
        }

        private async Task<ActionResult> LogAndInvoke(Func<Task<ActionResult>> method, [CallerMemberName] string caller = "")
        {
            _logger.LogInformation($"Invoking {caller}");
            var result = await method();
            _logger.LogInformation($"Returning from {caller}");
            return result;
        }
    }
}

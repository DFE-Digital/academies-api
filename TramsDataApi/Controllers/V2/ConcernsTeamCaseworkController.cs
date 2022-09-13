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
        private readonly IGetConcernsCaseworkTeam _getCommand;
        private readonly IGetConcernsCaseworkTeamOwners _getTeamOwnersCommand;
        private readonly IUpdateConcernsCaseworkTeam _updateCommand;

        public ConcernsTeamCaseworkController(ILogger<ConcernsTeamCaseworkController> logger, 
            IGetConcernsCaseworkTeam getTeamCommand,
            IGetConcernsCaseworkTeamOwners getTeamOwnersCommand,
            IUpdateConcernsCaseworkTeam updateCommand)
        {
            _logger=logger ?? throw new ArgumentNullException(nameof(logger));
            _getCommand = getTeamCommand ?? throw new ArgumentNullException(nameof(getTeamCommand));
            _getTeamOwnersCommand = getTeamOwnersCommand ?? throw  new ArgumentNullException(nameof(getTeamOwnersCommand));
            _updateCommand = updateCommand ?? throw new ArgumentNullException(nameof(updateCommand));
        }

        [HttpGet("owners/{ownerId}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ApiSingleResponseV2<ConcernsCaseworkTeamResponse>>> Get(string ownerId, CancellationToken cancellationToken)
        {
            return await LogAndInvoke(async () =>
            {
                var result = await _getCommand.Execute(ownerId, cancellationToken);
                if (result is null)
                {
                    // successful, but nothing to return as no team created yet.
                    return NoContent();
                }

                var responseData = new ApiSingleResponseV2<ConcernsCaseworkTeamResponse>(result);
                return Ok(responseData);
            });
        }

        [HttpGet("owners")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ApiSingleResponseV2<string[]>>> Get(CancellationToken cancellationToken)
        {
            return await LogAndInvoke(async () =>
            {
                var result = await _getTeamOwnersCommand.Execute(cancellationToken);
                if (result is null)
                {
                    // successful, but nothing to return as no team created yet.
                    return NoContent();
                }

                var responseData = new ApiSingleResponseV2<string[]>(result);
                return Ok(responseData);
            });
        }

        [HttpPut("owners/{ownerId}")]
        [MapToApiVersion("2.0")]
        public async Task<ActionResult<ApiSingleResponseV2<ConcernsCaseworkTeamResponse>>> Put(
            string ownerId,
            [FromBody] ConcernsCaseworkTeamUpdateRequest updateModel,
            CancellationToken cancellationToken)
        {
            return await LogAndInvoke(async () =>
            {
                if (updateModel == null || updateModel.OwnerId != ownerId)
                {
                    return BadRequest(new { Error = "update model does not match ownerId" });
                }

                var result = await _updateCommand.Execute(updateModel, cancellationToken);
                var responseData = new ApiSingleResponseV2<ConcernsCaseworkTeamResponse>(result);
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

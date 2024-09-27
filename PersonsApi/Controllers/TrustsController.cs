using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn;
using Dfe.Academies.Application.Trust.Queries.GetAllPersonsAssociatedWithTrustByTrnOrUkprn;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PersonsApi.Controllers
{
    [ApiController]
    [Authorize(Policy = "API.Read")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class TrustsController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Retrieve All Members Associated With a Trust by Either UKPRN or TRN
        /// </summary>
        /// <param name="id">The identifier (UKPRN or TRN).</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("{id}/getAssociatedPersons")]
        [SwaggerResponse(200, "A Collection of Persons Associated With the Trust.", typeof(List<TrustGovernance>))]
        [SwaggerResponse(404, "Trust not found.")]
        public async Task<IActionResult> GetAllPersonsAssociatedWithTrustByTrnOrUkPrnAsync([FromRoute] string id, CancellationToken cancellationToken)
        {
            var result = await sender.Send(new GetAllPersonsAssociatedWithTrustByTrnOrUkprnQuery(id), cancellationToken);

            return result is null ? NotFound() : Ok(result);
        }
    }
}

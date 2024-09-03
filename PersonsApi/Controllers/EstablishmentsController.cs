using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn;
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
    public class EstablishmentsController : ControllerBase
    {
        private readonly ISender _sender;

        public EstablishmentsController(ISender sender)
        {
            _sender = sender;
        }

        /// <summary>
        /// Retrieve All Members Associated With an Academy by Urn
        /// </summary>
        /// <param name="urn">The URN.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("{urn}/getAssociatedPersons")]
        [SwaggerResponse(200, "A Collection of Persons Associated With the Academy.", typeof(List<AcademyGovernance>))]
        [SwaggerResponse(404, "Academy not found.")]
        public async Task<IActionResult> GetAllPersonsAssociatedWithAcademyByUrnAsync([FromRoute] int urn, CancellationToken cancellationToken)
        {
            var result = await _sender.Send(new GetAllPersonsAssociatedWithAcademyByUrnQuery(urn), cancellationToken);

            return result is null ? NotFound() : Ok(result);
        }
    }
}

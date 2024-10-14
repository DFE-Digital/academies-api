using Dfe.Academies.Application.Common.Exceptions;
using Dfe.Academies.Application.Common.Models;
using Dfe.Academies.Application.Establishment.Queries.GetAllPersonsAssociatedWithAcademyByUrn;
using Dfe.Academies.Application.Establishment.Queries.GetMemberOfParliamentBySchool;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace PersonsApi.Controllers
{
    [ApiController]
    [Authorize(Policy = "API.Read")]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class EstablishmentsController(ISender sender) : ControllerBase
    {
        /// <summary>
        /// Retrieve All Members Associated With an Academy by Urn
        /// </summary>
        /// <param name="urn">The URN.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("{urn}/getAssociatedPersons")]
        [SwaggerResponse(200, "A Collection of Persons Associated With the Academy.", typeof(List<AcademyGovernance>))]
        [SwaggerResponse(404, "Academy not found.")]
        [SwaggerResponse(404, "Constituency not found for the given establishment.")]
        public async Task<IActionResult> GetAllPersonsAssociatedWithAcademyByUrnAsync([FromRoute] int urn, CancellationToken cancellationToken)
        {
            var result = await sender.Send(new GetAllPersonsAssociatedWithAcademyByUrnQuery(urn), cancellationToken);

            return !result.IsSuccess ? NotFound(new CustomProblemDetails(HttpStatusCode.NotFound, result.Error)) : Ok(result.Value);
        }

        /// <summary>
        /// Get Member of Parliament by School (Urn)
        /// </summary>
        /// <param name="urn">The URN.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("{urn}/getMpBySchool")]
        [SwaggerResponse(200, "Member of Parliament", typeof(MemberOfParliament))]
        [SwaggerResponse(404, "School Not found.")]
        public async Task<IActionResult> GetMemberOfParliamentBySchoolUrnAsync([FromRoute] int urn, CancellationToken cancellationToken)
        {
            var result = await sender.Send(new GetMemberOfParliamentBySchoolQuery(urn), cancellationToken);

            return !result.IsSuccess ? NotFound(new CustomProblemDetails(HttpStatusCode.NotFound, result.Error)) : Ok(result.Value);
        }
    }
}

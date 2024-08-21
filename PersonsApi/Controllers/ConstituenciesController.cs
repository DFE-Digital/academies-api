using Dfe.Academies.Application.Models;
using Dfe.Academies.Application.Constituencies;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PersonsApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ConstituenciesController : ControllerBase
    {
        private readonly IConstituencyQueries _personQueries;

        public ConstituenciesController(IConstituencyQueries personQueries)
        {
            _personQueries = personQueries;
        }

        /// <summary>
        /// Retrieve Member of Parliament by constituency name
        /// </summary>
        /// <param name="constituencyName">The constituency name.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        [HttpGet("{constituencyName}/mp")]
        [SwaggerResponse(200, "A Person object representing the Member of Parliament.", typeof(MemberOfParliament))]
        [SwaggerResponse(404, "Constituency not found.")]
        [SwaggerResponse(400, "Constituency cannot be null or empty.")]
        public async Task<IActionResult> GetMemberOfParliamentByConstituencyAsync([FromRoute] string constituencyName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(constituencyName))
            {
                return BadRequest();
            }

            var result = await _personQueries.GetMemberOfParliamentByConstituencyAsync(constituencyName, cancellationToken);

            return result is null ? NotFound() : Ok(result);
        }
    }
}

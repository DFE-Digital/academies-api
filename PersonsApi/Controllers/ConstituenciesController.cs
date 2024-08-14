using Dfe.Academies.Application.Models;
using Dfe.Academies.Application.Persons;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PersonsApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    public class ConstituenciesController : ControllerBase
    {
        private readonly IPersonsQueries _personQueries;

        public ConstituenciesController(IPersonsQueries personQueries)
        {
            _personQueries = personQueries;
        }

        [HttpGet("{constituencyName}/mp")]
        [SwaggerOperation(Summary = "Retrieve Member of Parliament by constituency name", Description = "Receives a constituency name and returns a Person object representing the Member of Parliament.")]
        [SwaggerResponse(200, "A Person object representing the Member of Parliament.", typeof(MemberOfParliament))]
        [SwaggerResponse(404, "Constituency not found")]
        [SwaggerResponse(400, "Constituency cannot be null or empty")]
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

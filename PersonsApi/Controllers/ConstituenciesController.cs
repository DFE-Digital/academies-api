using Dfe.Academies.Application.Models;
using Dfe.Academies.Application.Persons;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace PersonsApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/[controller]")]
    [SwaggerTag("Persons Endpoints")]
    public class ConstituenciesController : ControllerBase
    {
        private readonly IPersonsQueries _personQueries;

        public ConstituenciesController(IPersonsQueries personQueries)
        {
            _personQueries = personQueries;
        }

        [HttpGet("{constituencyName}/mp")]
        [SwaggerOperation(Summary = "Retrieve Member of Parliament by constituency name", Description = "Receives a constituency name and returns a Person object representing the Member of Parliament.")]
        [SwaggerResponse(200, "A Person object representing the Member of Parliament.", typeof(Person))]
        [SwaggerResponse(404, "Constituency not found")]
        public async Task<IActionResult> GetAsync([FromRoute] string constituencyName, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(constituencyName))
            {
                return BadRequest("Constituency cannot be null or empty");
            }

            var result = await _personQueries.GetMemberOfParliamentByConstituencyAsync(constituencyName, cancellationToken);

            return result is null ? NotFound() : Ok(result);
        }
    }
}

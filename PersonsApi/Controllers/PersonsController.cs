using Dfe.Academies.Application.Models;
using Dfe.Academies.Application.Persons;
using Microsoft.AspNetCore.Mvc;
using PersonsApi.RequestModels;
using Swashbuckle.AspNetCore.Annotations;

namespace PersonsApi.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/")]
    [SwaggerTag("Persons Endpoints")]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonsQueries _personQueries;

        private readonly ILogger<PersonsController> _logger;

        public PersonsController(IPersonsQueries personQueries, ILogger<PersonsController> logger)
        {
            _personQueries = personQueries;
            _logger = logger;
        }

        [HttpGet]
        [Route("get-mp-from-constituency")]
        [SwaggerOperation(Summary = "Retrieve person information", Description = "Receives a string and returns a Person object.")]
        [SwaggerResponse(200, "A Person object.")]
        [SwaggerResponse(404, "Constituency not found")]
        public async Task<ActionResult<Person>> GetAsync([FromQuery] GetMpFromConstituencyRequest request, CancellationToken cancellationToken)
        {
            var result = await _personQueries.GetMemberOfParliamentByConstituencyAsync(request.Constituency, cancellationToken);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}

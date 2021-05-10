using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Controllers
{
    [ApiController]
    public class AcademiesController : ControllerBase
    {
        private readonly IAcademyGateway _academyGateway;
        public AcademiesController(IAcademyGateway academyGateway)
        {
            _academyGateway = academyGateway;
        }

        [HttpGet]
        [Route("academy/{ukprn}")]
        public IActionResult GetByUkprn(string ukprn)
        {
            var academy = _academyGateway.GetByUkprn(ukprn);

            if (academy == null)
            {
                return NotFound();
            }

            return Ok(academy);
        }
    }
}
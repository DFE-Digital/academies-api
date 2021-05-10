using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("trust")]
    public class AcademiesController : ControllerBase
    {
        private readonly IAcademyGateway _academyGateway;
        public AcademiesController(IAcademyGateway academyGateway)
        {
            _academyGateway = academyGateway;
        }

        public IActionResult GetByUkprn(string ukprn)
        {
            return NotFound();
        }
    }
}
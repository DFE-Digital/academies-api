using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Controllers
{
    [ApiController]
    public class AcademiesController : ControllerBase
    {
        private readonly IEstablishmentGateway _establishmentGateway;
        public AcademiesController(IEstablishmentGateway establishmentGateway)
        {
            _establishmentGateway = establishmentGateway;
        }

        [HttpGet]
        [Route("establishment/{ukprn}")]
        public IActionResult GetByUkprn(string ukprn)
        {
            var establishment = _establishmentGateway.GetByUkprn(ukprn);

            if (establishment == null)
            {
                return NotFound();
            }

            return Ok(establishment);
        }
    }
}
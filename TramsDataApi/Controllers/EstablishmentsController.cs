using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    public class AcademiesController : ControllerBase
    {
        private readonly IGetEstablishmentByUkprn _getEstablishmentByUkprn;
        public AcademiesController(IGetEstablishmentByUkprn getEstablishmentByUkprn)
        {
            _getEstablishmentByUkprn = getEstablishmentByUkprn;
        }

        [HttpGet]
        [Route("establishment/{ukprn}")]
        public IActionResult GetByUkprn(string ukprn)
        {
            var establishment = _getEstablishmentByUkprn.Execute(ukprn);

            if (establishment == null)
            {
                return NotFound();
            }

            return Ok(establishment);
        }
    }
}
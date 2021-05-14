using Microsoft.AspNetCore.Mvc;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    public class EstablishmentsController : ControllerBase
    {
        private readonly IGetEstablishmentByUkprn _getEstablishmentByUkprn;
        public EstablishmentsController(IGetEstablishmentByUkprn getEstablishmentByUkprn)
        {
            _getEstablishmentByUkprn = getEstablishmentByUkprn;
        }

        [HttpGet]
        [Route("establishment/{ukprn}")]
        public ActionResult<EstablishmentResponse> GetByUkprn(string ukprn)
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
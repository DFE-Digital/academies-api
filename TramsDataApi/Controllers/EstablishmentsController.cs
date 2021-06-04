using Microsoft.AspNetCore.Mvc;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    public class EstablishmentsController : ControllerBase
    {
        private readonly IGetEstablishmentByUkprn _getEstablishmentByUkprn;
        private readonly IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse> _getEstablishmentByUrn;

        public EstablishmentsController(
            IGetEstablishmentByUkprn getEstablishmentByUkprn, 
            IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse> getEstablishmentByUrn)
        {
            _getEstablishmentByUkprn = getEstablishmentByUkprn;
            _getEstablishmentByUrn = getEstablishmentByUrn;
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

        [HttpGet]
        [Route("establishment/urn/{urn}")]
        public ActionResult<EstablishmentResponse> GetByUrn(int urn)
        {
            var establishment = _getEstablishmentByUrn.Execute(new GetEstablishmentByUrnRequest { URN = urn });

            if (establishment == null)
            {
                return NotFound();
            }

            return Ok(establishment);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
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
        private readonly IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>> _searchEstablishments;

        public EstablishmentsController(
            IGetEstablishmentByUkprn getEstablishmentByUkprn, 
            IUseCase<GetEstablishmentByUrnRequest, EstablishmentResponse> getEstablishmentByUrn,
            IUseCase<SearchEstablishmentsRequest, IList<EstablishmentSummaryResponse>> searchEstablishments)
        {
            _getEstablishmentByUkprn = getEstablishmentByUkprn;
            _getEstablishmentByUrn = getEstablishmentByUrn;
            _searchEstablishments = searchEstablishments;
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

        [HttpGet]
        [Route("establishments")]
        public ActionResult<List<EstablishmentSummaryResponse>> SearchEstablishments(SearchEstablishmentsRequest request)
        {
            return Ok(_searchEstablishments.Execute(request));
        }
    }
}
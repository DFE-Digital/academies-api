using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("trust")]
    public class TrustsController : ControllerBase
    {
        private readonly ITrustGateway _trustGateway;

        public TrustsController(ITrustGateway trustGateway)
        {
            _trustGateway = trustGateway;
        }
        
        [HttpGet]
        [Route("{ukprn}")]
        public ActionResult<TrustResponse> Get(string ukprn)
        {
            var trust = _trustGateway.GetByUkprn(ukprn);

            if (trust == null)
            {
                return NotFound();
            }

            return Ok(trust);
        }
    }
}
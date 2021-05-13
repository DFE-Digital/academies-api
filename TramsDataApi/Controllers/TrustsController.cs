using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers
{
    [ApiController]
    [Route("trust")]
    public class TrustsController : ControllerBase
    {
        private readonly IGetTrustByUkprn _getTrustByUkprn;

        public TrustsController(IGetTrustByUkprn getTrustByUkprn)
        {
            _getTrustByUkprn = getTrustByUkprn;
        }
        
        [HttpGet]
        [Route("{ukprn}")]
        public ActionResult<TrustResponse> Get(string ukprn)
        {
            var trust = _getTrustByUkprn.Execute(ukprn);

            if (trust == null)
            {
                return NotFound();
            }

            return Ok(trust);
        }
    }
}
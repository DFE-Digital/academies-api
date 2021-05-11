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
        private readonly IGetTrustsByUkprn _getTrustsByUkprn;

        public TrustsController(IGetTrustsByUkprn getTrustsByUkprn)
        {
            _getTrustsByUkprn = getTrustsByUkprn;
        }
        
        [HttpGet]
        [Route("{ukprn}")]
        public IActionResult Get(string ukprn)
        {
            var trust = _getTrustsByUkprn.Execute(ukprn);

            if (trust == null)
            {
                return NotFound();
            }

            return Ok(trust);
        }
    }
}
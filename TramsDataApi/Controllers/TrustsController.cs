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
    [ApiVersion("1.0")]
    public class TrustsController : ControllerBase
    {
        private readonly IGetTrustByUkprn _getTrustByUkprn;
        private readonly ISearchTrusts _searchTrusts;

        public TrustsController(IGetTrustByUkprn getTrustByUkprn, ISearchTrusts searchTrusts)
        {
            _getTrustByUkprn = getTrustByUkprn;
            _searchTrusts = searchTrusts;
        }
        
        [HttpGet]
        [Route("trust/{ukprn}")]
        public ActionResult<TrustResponse> GetTrustByUkprn(string ukprn)
        {
            var trust = _getTrustByUkprn.Execute(ukprn);

            if (trust == null)
            {
                return NotFound();
            }

            return Ok(trust);
        }

        [HttpGet]
        [Route("trusts")]
        public ActionResult<List<TrustSummaryResponse>> SearchTrusts(string groupName, string ukprn, string companiesHouseNumber, int page = 1)
        {
            var trusts = _searchTrusts.Execute(groupName, ukprn, companiesHouseNumber, page);
            return Ok(trusts);
        }
    }
}
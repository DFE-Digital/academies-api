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
    [Route("[controller]")]
    public class TrustsController : ControllerBase
    {
        private readonly ITrustGateway _trustGateway;

        public TrustsController(ITrustGateway trustGateway)
        {
            _trustGateway = trustGateway;
        }
        
        [HttpGet]
        public TrustResponse Get(string ukprn)
        {
            return _trustGateway.GetByUkprn(ukprn);
        }
    }
}
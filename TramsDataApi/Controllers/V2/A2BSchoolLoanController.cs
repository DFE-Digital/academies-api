using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/apply-to-become/school-loans")]
    public class A2BSchoolLoanController : ControllerBase
    {
        private readonly ILogger<A2BSchoolLoanController> _logger;
        private readonly ICreateA2BSchoolLoan _createA2BSchoolLoan;

        public A2BSchoolLoanController(
            ILogger<A2BSchoolLoanController> logger,
            ICreateA2BSchoolLoan createA2BSchoolLoan)
        {
            _logger = logger;
            _createA2BSchoolLoan = createA2BSchoolLoan;
        }
        
        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BSchoolLoanResponse>> Create(A2BSchoolLoanCreateRequest request)
        {
            var createdSchoolLoan = _createA2BSchoolLoan.Execute(request);
            var response = new ApiSingleResponseV2<A2BSchoolLoanResponse>(createdSchoolLoan);
            
            return new ObjectResult(response) {StatusCode = StatusCodes.Status201Created};
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.ApplyToBecome;
using TramsDataApi.UseCases;
using System.Text.Json;

namespace TramsDataApi.Controllers.V2
{
    [ApiVersion("2.0")]
    [ApiController]
    [Route("v{version:apiVersion}/apply-to-become/school-loans")]
    public class A2BSchoolLoanController : ControllerBase
    {
        private readonly ILogger<A2BSchoolLoanController> _logger;
        private readonly ICreateA2BSchoolLoan _createA2BSchoolLoan;
        private readonly IGetA2BSchoolLoan _getA2BSchoolLoan;

        public A2BSchoolLoanController(
            ILogger<A2BSchoolLoanController> logger,
            ICreateA2BSchoolLoan createA2BSchoolLoan,
            IGetA2BSchoolLoan getA2BSchoolLoan)
        {
            _logger = logger;
            _createA2BSchoolLoan = createA2BSchoolLoan;
            _getA2BSchoolLoan = getA2BSchoolLoan;
        }
        
        [HttpPost]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BSchoolLoanResponse>> Create(A2BSchoolLoanCreateRequest request)
        {
            var createdSchoolLoan = _createA2BSchoolLoan.Execute(request);
            var response = new ApiSingleResponseV2<A2BSchoolLoanResponse>(createdSchoolLoan);
            
            return new ObjectResult(response) {StatusCode = StatusCodes.Status201Created};
        }
        
        [HttpGet]
        [Route("{loanId}")]
        [MapToApiVersion("2.0")]
        public ActionResult<ApiSingleResponseV2<A2BSchoolLoanResponse>> GetLoanByLoanId(string loanId)
        {
            _logger.LogInformation($"Attempting to get ApplyToBecome School Loan by LoanId {loanId}", loanId);
             
            var loan = _getA2BSchoolLoan.Execute(loanId);
            
            if (loan == null)
            {
                _logger.LogInformation($"No ApplyToBecome School loan found for loanId {loanId}", loanId);
                return NotFound($"Loan with Id {loanId} not found");
            }
            
            _logger.LogInformation($"Returning ApplyToBecome Loan by loanId {loanId}", loanId);
            _logger.LogDebug(JsonSerializer.Serialize(loan));
            var response = new ApiSingleResponseV2<A2BSchoolLoanResponse>(loan);
            
            return Ok(response);
        }
    }
}
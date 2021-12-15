using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class GetA2BSchoolLoan : IGetA2BSchoolLoan
    {
        private readonly IA2BSchoolLoanGateway _gateway;

        public GetA2BSchoolLoan(IA2BSchoolLoanGateway gateway)
        {
            _gateway = gateway;
        }

        public A2BSchoolLoanResponse Execute(string loanId)
        {
            var loan = _gateway.GetByLoanId(loanId);
            
            return loanId != null 
                ? A2BSchoolLoanResponseFactory.Create(loan) 
                : null;
        }
    }
}
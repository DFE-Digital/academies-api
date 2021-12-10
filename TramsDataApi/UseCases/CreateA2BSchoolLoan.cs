using TramsDataApi.Factories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.UseCases
{
    public class CreateA2BSchoolLoan : ICreateA2BSchoolLoan
    {
        private readonly IA2BSchoolLoanGateway _gateway;

        public CreateA2BSchoolLoan(IA2BSchoolLoanGateway gateway)
        {
            _gateway = gateway;
        }
        public A2BSchoolLoanResponse Execute(A2BSchoolLoanCreateRequest request)
        {
            var schoolLoanToCreate = A2BSchoolLoanFactory.Create(request);
            var createdSchoolLoan = _gateway.CreateA2BSchoolLoan(schoolLoanToCreate);
            return A2BSchoolLoanResponseFactory.Create(createdSchoolLoan);
        }
    }
}
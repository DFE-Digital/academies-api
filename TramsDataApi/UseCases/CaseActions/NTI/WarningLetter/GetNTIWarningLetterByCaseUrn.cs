using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.CaseActions.NTI.WarningLetter;

namespace TramsDataApi.UseCases.CaseActions.NTI.WarningLetter
{
    public class GetNTIWarningLetterByCaseUrn : IUseCase<int, List<NTIWarningLetterResponse>>
    {
        private readonly INTIWarningLetterGateway _gateway;

        public GetNTIWarningLetterByCaseUrn(INTIWarningLetterGateway gateway)
        {
            _gateway = gateway;
        }

        public List<NTIWarningLetterResponse> Execute(int caseUrn)
        {
            return ExecuteAsync(caseUrn).Result;
        }

        public async Task<List<NTIWarningLetterResponse>> ExecuteAsync(int caseUrn)
        {
            var warningLetters = await _gateway.GetNTIWarningLetterByCaseUrn(caseUrn);
            return warningLetters.Select(warningLetter => NTIWarningLetterFactory.CreateResponse(warningLetter)).ToList();
        }
    }
}
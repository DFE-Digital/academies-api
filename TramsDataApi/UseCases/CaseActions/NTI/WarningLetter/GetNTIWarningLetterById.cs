using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.CaseActions.NTI.WarningLetter;

namespace TramsDataApi.UseCases.CaseActions.NTI.WarningLetter
{
    public class GetNTIWarningLetterById : IUseCase<long, NTIWarningLetterResponse>
    {
        private readonly INTIWarningLetterGateway _gateway;

        public GetNTIWarningLetterById(INTIWarningLetterGateway gateway)
        {
            _gateway = gateway;
        }

        public NTIWarningLetterResponse Execute(long warningLetterId)
        {
            return ExecuteAsync(warningLetterId).Result;
        }

        public async Task<NTIWarningLetterResponse> ExecuteAsync(long warningLetterId)
        {
            var warningLetter = await _gateway.GetNTIWarningLetterById(warningLetterId);
            return NTIWarningLetterFactory.CreateResponse(warningLetter);
        }
    }
}

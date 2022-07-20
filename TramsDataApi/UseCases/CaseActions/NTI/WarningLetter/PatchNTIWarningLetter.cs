using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.NTI.WarningLetter;
using TramsDataApi.ResponseModels.CaseActions.NTI.WarningLetter;

namespace TramsDataApi.UseCases.CaseActions.NTI.WarningLetter
{
    public class PatchNTIWarningLetter : IUseCase<PatchNTIWarningLetterRequest, NTIWarningLetterResponse>
    {
        private readonly INTIWarningLetterGateway _gateway;

        public PatchNTIWarningLetter(INTIWarningLetterGateway gateway)
        {
            _gateway = gateway;
        }

        public NTIWarningLetterResponse Execute(PatchNTIWarningLetterRequest request)
        {
            return ExecuteAsync(request).Result;
        }

        public async Task<NTIWarningLetterResponse> ExecuteAsync(PatchNTIWarningLetterRequest request)
        {
            var patchedNTIWarningLetter = await _gateway.PatchNTIWarningLetter(NTIWarningLetterFactory.CreateDBModel(request));
            return NTIWarningLetterFactory.CreateResponse(patchedNTIWarningLetter);
        }
    }
}

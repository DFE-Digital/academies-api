using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.CaseActions.NTI.NoticeToImprove;
using TramsDataApi.ResponseModels.CaseActions.NTI.NoticeToImprove;

namespace TramsDataApi.UseCases.CaseActions.NTI.NoticeToImprove
{
    public class PatchNoticeToImprove : IUseCase<PatchNoticeToImproveRequest, NoticeToImproveResponse>
    {
        private readonly INoticeToImproveGateway _gateway;

        public PatchNoticeToImprove(INoticeToImproveGateway gateway)
        {
            _gateway = gateway;
        }

        public NoticeToImproveResponse Execute(PatchNoticeToImproveRequest request)
        {
            return ExecuteAsync(request).Result;
        }

        public async Task<NoticeToImproveResponse> ExecuteAsync(PatchNoticeToImproveRequest request)
        {
            var patchedNoticeToImprove = await _gateway.PatchNoticeToImprove(NoticeToImproveFactory.CreateDBModel(request));
            return NoticeToImproveFactory.CreateResponse(patchedNoticeToImprove);
        }
    }
}

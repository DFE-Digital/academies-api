using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.CaseActions.NTI.NoticeToImprove;

namespace TramsDataApi.UseCases.CaseActions.NTI.NoticeToImprove
{
    public class GetNoticeToImproveById : IUseCase<long, NoticeToImproveResponse>
    {
        private readonly INoticeToImproveGateway _gateway;

        public GetNoticeToImproveById(INoticeToImproveGateway gateway)
        {
            _gateway = gateway;
        }

        public NoticeToImproveResponse Execute(long noticeToImproveId)
        {
            return ExecuteAsync(noticeToImproveId).Result;
        }

        public async Task<NoticeToImproveResponse> ExecuteAsync(long noticeToImproveId)
        {
            var noticeToImprove = await _gateway.GetNoticeToImproveById(noticeToImproveId);
            return NoticeToImproveFactory.CreateResponse(noticeToImprove);
        }
    }
}

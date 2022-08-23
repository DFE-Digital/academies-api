using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.Factories.CaseActionFactories;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels.CaseActions.NTI.NoticeToImprove;

namespace TramsDataApi.UseCases.CaseActions.NTI.NoticeToImprove
{
    public class GetNoticeToImproveByCaseUrn : IUseCase<int, List<NoticeToImproveResponse>>
    {
        private readonly INoticeToImproveGateway _gateway;

        public GetNoticeToImproveByCaseUrn(INoticeToImproveGateway gateway)
        {
            _gateway = gateway;
        }

        public List<NoticeToImproveResponse> Execute(int caseUrn)
        {
            return ExecuteAsync(caseUrn).Result;
        }

        public async Task<List<NoticeToImproveResponse>> ExecuteAsync(int caseUrn)
        {
            var noticesToImprove = await _gateway.GetNoticeToImproveByCaseUrn(caseUrn);
            return noticesToImprove.Select(noticeToImprove => NoticeToImproveFactory.CreateResponse(noticeToImprove)).ToList();
        }
    }
}
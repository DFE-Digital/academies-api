using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;

namespace TramsDataApi.UseCases.CaseActions.NTI.NoticeToImprove
{
    public class GetAllStatuses : IUseCase<Object, List<NoticeToImproveStatus>>
    {
        private readonly INoticeToImproveGateway _gateway;

        public GetAllStatuses(INoticeToImproveGateway gateway)
        {
            _gateway = gateway;
        }

        public List<NoticeToImproveStatus> Execute(Object ignore)
        {
            return ExecuteAsync(ignore).Result;
        }

        public async Task<List<NoticeToImproveStatus>> ExecuteAsync(Object ignore)
        {
            return await _gateway.GetAllStatuses();
        }
    }
}

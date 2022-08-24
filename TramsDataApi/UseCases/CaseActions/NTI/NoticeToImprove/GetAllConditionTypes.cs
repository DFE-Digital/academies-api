using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;

namespace TramsDataApi.UseCases.CaseActions.NTI.NoticeToImprove
{
    public class GetAllConditionTypes : IUseCase<Object, List<NoticeToImproveConditionType>>
    {
        private readonly INoticeToImproveGateway _gateway;

        public GetAllConditionTypes(INoticeToImproveGateway gateway)
        {
            _gateway = gateway;
        }

        public List<NoticeToImproveConditionType> Execute(Object ignore)
        {
            return ExecuteAsync(ignore).Result;
        }

        public async Task<List<NoticeToImproveConditionType>> ExecuteAsync(Object ignore)
        {
            return await _gateway.GetAllConditionTypes();
        }
    }
}

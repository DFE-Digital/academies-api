using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;

namespace TramsDataApi.UseCases.CaseActions.NTI.WarningLetter
{
    public class GetAllConditionTypes : IUseCase<Object, List<NTIWarningLetterConditionType>>
    {
        private readonly INTIWarningLetterGateway _gateway;

        public GetAllConditionTypes(INTIWarningLetterGateway gateway)
        {
            _gateway = gateway;
        }

        public List<NTIWarningLetterConditionType> Execute(Object ignore)
        {
            return ExecuteAsync(ignore).Result;
        }

        public async Task<List<NTIWarningLetterConditionType>> ExecuteAsync(Object ignore)
        {
            return await _gateway.GetAllConditionTypes();
        }
    }
}

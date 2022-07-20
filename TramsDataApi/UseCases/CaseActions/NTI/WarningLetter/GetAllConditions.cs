using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;

namespace TramsDataApi.UseCases.CaseActions.NTI.WarningLetter
{
    public class GetAllConditions : IUseCase<Object, List<NTIWarningLetterCondition>>
    {
        private readonly INTIWarningLetterGateway _gateway;

        public GetAllConditions(INTIWarningLetterGateway gateway)
        {
            _gateway = gateway;
        }

        public List<NTIWarningLetterCondition> Execute(Object ignore)
        {
            return ExecuteAsync(ignore).Result;
        }

        public async Task<List<NTIWarningLetterCondition>> ExecuteAsync(Object ignore)
        {
            return await _gateway.GetAllConditions();
        }
    }
}

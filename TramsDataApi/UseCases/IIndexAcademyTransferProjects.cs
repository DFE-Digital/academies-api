using System.Collections.Generic;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.UseCases
{
    public interface IIndexAcademyTransferProjects
    {
        public IList<AcademyTransferProjectSummaryResponse> Execute(int page);
    }
}
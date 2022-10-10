using System.Collections.Generic;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
    public interface IIndexAcademyTransferProjects
    {
        public IList<AcademyTransferProjectSummaryResponse> Execute(int page);
    }
}
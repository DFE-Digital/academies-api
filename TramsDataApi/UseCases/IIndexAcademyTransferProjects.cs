using System;
using System.Collections.Generic;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
    public interface IIndexAcademyTransferProjects
    {
        public Tuple<IList<AcademyTransferProjectSummaryResponse>, int> Execute(int page);
    }
}
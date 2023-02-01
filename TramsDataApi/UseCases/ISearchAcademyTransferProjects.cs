﻿using System.Threading.Tasks;
using TramsDataApi.RequestModels;
using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
    public interface ISearchAcademyTransferProjects
    {
        Task<PagedResult<AcademyTransferProjectSummaryResponse>> Execute(int page, int count, int? urn, string title);
    }
}

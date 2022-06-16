using System.Collections.Generic;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface IGetAcademyConversionProjectsByStatuses
    {
        IEnumerable<AcademyConversionProjectResponse> Execute(int page, int count, IEnumerable<string> statuses);
    }
}
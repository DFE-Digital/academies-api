using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.UseCases
{
    public interface ISearchAcademyConversionProjects
    {
        Task<PagedResult<AcademyConversionProjectResponse>> Execute(int page, int count, IEnumerable<string> statuses, int? urn, string title, IEnumerable<string> deliveryOfficer);
    }
}
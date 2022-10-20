using System.Collections.Generic;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IAcademyConversionProjectGateway
    {
        Task<AcademyConversionProject> GetById(int id);
        Task<List<AcademyConversionProject>> GetProjects(int page, int count);
        Task<List<string>> GetAvailableProjectStatuses();
        Task<AcademyConversionProject> Update(AcademyConversionProject academyConversionProject);
        Task<PagedResult<AcademyConversionProject>> SearchProjects(int page, int count, IEnumerable<string> statuses, int? urn, string title, IEnumerable<string> deliveryOfficers);
    }
}
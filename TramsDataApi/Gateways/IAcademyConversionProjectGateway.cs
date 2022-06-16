using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IAcademyConversionProjectGateway
    {
        AcademyConversionProject GetById(int id);
        IEnumerable<AcademyConversionProject> GetProjects(int page, int count);
        AcademyConversionProject Update(AcademyConversionProject academyConversionProject);
        IEnumerable<AcademyConversionProject> GetByStatuses(int page, int count, IEnumerable<string> statuses);
    }
}
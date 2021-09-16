using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IAcademyConversionProjectGateway
    {
        AcademyConversionProject GetById(int id);
        IEnumerable<AcademyConversionJoinModel> GetProjects(int take);
        AcademyConversionProject Update(AcademyConversionProject academyConversionProject);
        IEnumerable<AcademyConversionJoinModel> GetByStatuses(int take, List<string> state);
    }
}
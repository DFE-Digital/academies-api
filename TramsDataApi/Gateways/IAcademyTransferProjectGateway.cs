using System.Collections.Generic;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IAcademyTransferProjectGateway
    {
        AcademyTransferProjects SaveAcademyTransferProject(AcademyTransferProjects project);
        AcademyTransferProjects GetAcademyTransferProjectByUrn(int urn);
        AcademyTransferProjects UpdateAcademyTransferProject(AcademyTransferProjects project);
        IList<AcademyTransferProjects> IndexAcademyTransferProjects(int page);
    }
}
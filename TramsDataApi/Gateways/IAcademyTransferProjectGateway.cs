using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IAcademyTransferProjectGateway
    {
        AcademyTransferProjects SaveAcademyTransferProject(AcademyTransferProjects project);
        AcademyTransferProjects GetAcademyTransferProjectByUrn(int urn);
        AcademyTransferProjects UpdateAcademyTransferProject(AcademyTransferProjects project);
    }
}
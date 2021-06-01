using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IAcademyTransferProjectGateway
    {
        public AcademyTransferProjects CreateAcademyTransferProject(AcademyTransferProjects project);
        AcademyTransferProjects GetAcademyTransferProjectByUrn(int urn);
    }
}
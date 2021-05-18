using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public interface IAcademyTransferProjectGateway
    {
        public AcademyTransferProjects CreateAcademyTransferProject(AcademyTransferProjects project);
    }
}
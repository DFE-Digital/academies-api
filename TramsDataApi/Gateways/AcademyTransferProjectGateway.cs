using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class AcademyTransferProjectGateway : IAcademyTransferProjectGateway
    {
        
        private readonly LegacyTramsDbContext _legacyTramsDbContext;
        private readonly TramsDbContext _tramsDbContext;

        public AcademyTransferProjectGateway(LegacyTramsDbContext legacyTramsDbContext, TramsDbContext tramsDbContext)
        {
            _legacyTramsDbContext = legacyTramsDbContext;
            _tramsDbContext = tramsDbContext;
        }
        
        public AcademyTransferProjects CreateAcademyTransferProject(AcademyTransferProjects project)
        {
            _tramsDbContext.AcademyTransferProjects.Add(project);
            _tramsDbContext.SaveChanges();

            return project;
        }
    }
}
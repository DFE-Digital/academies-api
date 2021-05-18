using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class AcademyTransferProjectGateway : IAcademyTransferProjectGateway
    {
        
        private readonly TramsDbContext _dbContext;

        public AcademyTransferProjectGateway(TramsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public AcademyTransferProjects CreateAcademyTransferProject(AcademyTransferProjects project)
        {
            _dbContext.AcademyTransferProjects.Add(project);
            _dbContext.SaveChanges();

            return project;
        }
    }
}
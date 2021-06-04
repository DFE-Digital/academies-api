using System.Linq;
using Microsoft.EntityFrameworkCore;
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
        
        public AcademyTransferProjects SaveAcademyTransferProject(AcademyTransferProjects project)
        {
            _tramsDbContext.AcademyTransferProjects.Update(project);
            _tramsDbContext.SaveChanges();

            return project;
        }

        public AcademyTransferProjects GetAcademyTransferProjectByUrn(int urn)
        {
            return _tramsDbContext.AcademyTransferProjects
                .Include(atp => atp.AcademyTransferProjectIntendedTransferBenefits)
                .Include(atp => atp.TransferringAcademies)
                .FirstOrDefault(atp => atp.Urn == urn);
        }
    }
}
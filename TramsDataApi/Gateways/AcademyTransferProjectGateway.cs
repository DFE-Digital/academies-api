using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public AcademyTransferProjects UpdateAcademyTransferProject(AcademyTransferProjects project)
        {
            
            _tramsDbContext.TransferringAcademies.RemoveRange(
                _tramsDbContext.TransferringAcademies.Where(
                    ta => ta.FkAcademyTransferProject == project
                    )
                );
            _tramsDbContext.AcademyTransferProjectIntendedTransferBenefits.RemoveRange(_tramsDbContext.AcademyTransferProjectIntendedTransferBenefits.Where(
                    ta => ta.FkAcademyTransferProject == project
                )
            );
            _tramsDbContext.AcademyTransferProjects.Update(project);
            
            _tramsDbContext.SaveChanges();

            return project;
        }

        public Tuple<IList<AcademyTransferProjects>, int> IndexAcademyTransferProjects(int page)
        {
           var academyTransferProjects = _tramsDbContext.AcademyTransferProjects
              .Include(atp => atp.AcademyTransferProjectIntendedTransferBenefits)
              .Include(atp => atp.TransferringAcademies);

           return
              Tuple.Create<IList<AcademyTransferProjects>, int>(
                 academyTransferProjects
                    .OrderByDescending(atp => atp.Id)
                    .Skip((page - 1) * 10).Take(10).ToList(),
                 academyTransferProjects.Count());
        }

        public AcademyTransferProjects GetAcademyTransferProjectByUrn(int urn)
        {
            return _tramsDbContext.AcademyTransferProjects
                .Include(atp => atp.AcademyTransferProjectIntendedTransferBenefits)
                .Include(atp => atp.TransferringAcademies)
                .FirstOrDefault(atp => atp.Urn == urn);
        }

        public IList<AcademyTransferProjects> GetAcademyTransferProjects()
        {
            return _tramsDbContext.AcademyTransferProjects
                .Include(atp => atp.AcademyTransferProjectIntendedTransferBenefits)
                .Include(atp => atp.TransferringAcademies).ToList();
        }
    }
}
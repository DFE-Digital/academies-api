using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class AcademyTransferProjectGateway : IAcademyTransferProjectGateway
    {
       private readonly TramsDbContext _tramsDbContext;

        public AcademyTransferProjectGateway(TramsDbContext tramsDbContext)
        {
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

        public IEnumerable<AcademyTransferProjects> GetAcademyTransferProjects()
        {
           return _tramsDbContext.AcademyTransferProjects
              .Include(atp => atp.AcademyTransferProjectIntendedTransferBenefits)
              .Include(atp => atp.TransferringAcademies);
        }
    }
}
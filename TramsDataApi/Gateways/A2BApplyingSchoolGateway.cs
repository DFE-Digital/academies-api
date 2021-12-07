using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class A2BApplyingSchoolGateway : IA2BApplyingSchoolGateway
    {
        private readonly TramsDbContext _tramsDbContext;
        
        public A2BApplyingSchoolGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }
        
        public A2BApplyingSchool GetByApplyingSchoolId(string applyingSchoolId)
        {
            return _tramsDbContext.A2BApplyingSchools
                .Include(k => k.SchoolDeclarationBodyAgreeOption)
                .Include(k => k.SchoolDeclarationTeacherChairOption)
                .Include(k => k.SchoolLoanExistsOption)
                .Include(k => k.SchoolLeaseExistsOption)
                .AsNoTracking()
                .FirstOrDefault(k => k.ApplyingSchoolId == applyingSchoolId);
        }

        public A2BApplyingSchool CreateA2BApplyingSchool(A2BApplyingSchool applyingSchool)
        {
            _tramsDbContext.A2BApplyingSchools.Add(applyingSchool);
            _tramsDbContext.SaveChanges();

            return GetByApplyingSchoolId(applyingSchool.ApplyingSchoolId);
        }
    }
}
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Gateways
{
    public class A2BContributorGateway : IA2BContributorGateway
    {
        private readonly TramsDbContext _tramsDbContext;

        public A2BContributorGateway(TramsDbContext tramsDbContext)
        {
            _tramsDbContext = tramsDbContext;
        }

        public A2BContributor GetByContributorId(string contributorId)
        {
            return _tramsDbContext.A2BContributors
                .AsNoTracking()
                .FirstOrDefault(k => k.ContributorUserId == contributorId);
        }

        public A2BContributor CreateA2BContributor(A2BContributor contributor)
        {
            _tramsDbContext.A2BContributors.Add(contributor);
            _tramsDbContext.SaveChanges();

            return contributor;
        }
    }
}
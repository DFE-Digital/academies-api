using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Extensions;

namespace TramsDataApi.Gateways
{
   public class TrustGateway : ITrustGateway
   {
      private readonly LegacyTramsDbContext _dbContext;

      public TrustGateway(LegacyTramsDbContext dbContext)
      {
         _dbContext = dbContext;
      }

      public Group GetGroupByUkPrn(string ukPrn)
      {
         return _dbContext.Group.FirstOrDefault(g => g.Ukprn == ukPrn);
      }

      public Trust GetIfdTrustByGroupId(string groupId)
      {
         return _dbContext.Trust.FirstOrDefault(t => t.TrustRef == groupId);
      }

      public Trust GetIfdTrustByRID(string RID)
      {
         return _dbContext.Trust.FirstOrDefault(x => x.Rid.Equals(RID));
      }

      public IQueryable<Trust> GetIfdTrustsByTrustRef(string[] trustRefs)
      {
         Expression<Func<Trust, bool>> predicate = PredicateBuilder.False<Trust>();
         foreach (var trustRef in trustRefs) predicate = predicate.Or(t => t.TrustRef == trustRef);

         return _dbContext.Trust.Where(predicate);
      }

      public (IList<Group>, int) SearchGroups(int page, int count, string groupName, string ukPrn,
         string companiesHouseNumber)
      {
         if (groupName == null && ukPrn == null && companiesHouseNumber == null)
         {
            List<Group> allGroups = _dbContext.Group.OrderBy(group => group.GroupUid).Skip((page - 1) * count)
               .Take(count).ToList();
            return (allGroups, allGroups.Count);
         }

         IOrderedQueryable<Group> filteredGroups = _dbContext.Group
            .Where(g => (g.GroupName.Contains(groupName) ||
                         g.Ukprn.Contains(ukPrn) ||
                         g.CompaniesHouseNumber.Contains(companiesHouseNumber))
                        && (
                           g.GroupType == "Single-academy trust" ||
                           g.GroupType == "Multi-academy trust"
                        ))
            .OrderBy(group => group.GroupUid);

         return (
            filteredGroups.Skip((page - 1) * count).Take(count).ToList(),
            filteredGroups.Count()
         );
      }

      public IEnumerable<Group> GetMultipleGroupsByUkprn(IEnumerable<string> ukprns)
      {
         IEnumerable<string> distinctUkprns = ukprns.Distinct();
         return _dbContext.Group.AsNoTracking().Where(x => distinctUkprns.Contains(x.Ukprn));
      }

      public IEnumerable<Trust> GetMultipleTrustsByGroupId(IEnumerable<string> groupIds)
      {
         IEnumerable<string> distinctGroupIds = groupIds.Distinct();
         return _dbContext.Trust.AsNoTracking().Where(x => distinctGroupIds.Contains(x.TrustRef));
      }
   }
}

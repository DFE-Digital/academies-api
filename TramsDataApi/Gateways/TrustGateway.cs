using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Extensions;
using TramsDataApi.ResponseModels.AcademyTransferProject;
using TramsDataApi.ResponseModels;

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
            var predicate = PredicateBuilder.False<Trust>();
            foreach (var trustRef in trustRefs)
            {
                predicate = predicate.Or(t => t.TrustRef == trustRef);
            }

            return _dbContext.Trust.Where(predicate);
        }

        public (IList<Group>, int) SearchGroups(int page, int count, string groupName, string ukPrn, string companiesHouseNumber)
        {
            if (groupName == null && ukPrn == null && companiesHouseNumber == null)
            {
                var allGroups = _dbContext.Group.OrderBy(group => group.GroupUid).Skip((page - 1) * count).Take(count).ToList();
                return (allGroups, allGroups.Count);
            }

            var filteredGroups = _dbContext.Group
                .Where(g => (
                    (g.GroupName.Contains(groupName) ||
                     g.Ukprn.Contains(ukPrn) ||
                     g.CompaniesHouseNumber.Contains(companiesHouseNumber))
                    && (
                        g.GroupType == "Single-academy trust" ||
                        g.GroupType == "Multi-academy trust"
                    )
                ))
                .OrderBy(group => group.GroupUid);

            return (
                filteredGroups.Skip((page - 1) * count).Take(count).ToList(), 
                filteredGroups.Count()
                );
        }

        public List<AcademyTransferProjectSummaryResponse> CreateAcademyTransferProjectSummaryResponseForTrust(IList<AcademyTransferProjects> academyTransferProjects)
        {
            var projects = academyTransferProjects.ToList().Select(atp =>
            {
                atp.TransferringAcademies.Add(new TransferringAcademies());
                var outgoingGroup = GetGroupByUkPrn(atp.OutgoingTrustUkprn);
                return new AcademyTransferProjectSummaryResponse()
                {
                    ProjectUrn = atp.Urn.ToString(),
                    ProjectReference = atp.ProjectReference,
                    OutgoingTrustUkprn = atp.OutgoingTrustUkprn,
                    OutgoingTrustName = outgoingGroup.GroupName,
                    OutgoingTrustLeadRscRegion =
                        GetIfdTrustByGroupId(outgoingGroup.GroupId).LeadRscRegion,
                    TransferringAcademies = atp.TransferringAcademies.Select(ta =>
                    {
                        var group = GetGroupByUkPrn(ta.IncomingTrustUkprn);
                        return new TransferringAcademiesResponse
                        {
                            OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                            IncomingTrustUkprn = ta.IncomingTrustUkprn,
                            IncomingTrustName = group.GroupName,
                            IncomingTrustLeadRscRegion = GetIfdTrustByGroupId(group.GroupId).LeadRscRegion,
                            PupilNumbersAdditionalInformation = ta.PupilNumbersAdditionalInformation,
                            LatestOfstedReportAdditionalInformation = ta.LatestOfstedReportAdditionalInformation,
                            KeyStage2PerformanceAdditionalInformation = ta.KeyStage2PerformanceAdditionalInformation,
                            KeyStage4PerformanceAdditionalInformation = ta.KeyStage4PerformanceAdditionalInformation,
                            KeyStage5PerformanceAdditionalInformation = ta.KeyStage5PerformanceAdditionalInformation
                        };
                    }).ToList()
                };
            }).ToList();
            return projects;
        }
    }
}

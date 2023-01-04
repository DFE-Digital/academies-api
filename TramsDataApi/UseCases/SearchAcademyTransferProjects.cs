using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.ResponseModels;
using TramsDataApi.ResponseModels.AcademyTransferProject;

namespace TramsDataApi.UseCases
{
   public class SearchAcademyTransferProjects : ISearchAcademyTransferProjects
   {
      private readonly IAcademyTransferProjectGateway _academyTransferProjectGateway;
      private readonly ITrustGateway _trustGateway;

      public SearchAcademyTransferProjects(
         IAcademyTransferProjectGateway academyTransferProjectGateway,
         ITrustGateway trustGateway)
      {
         _academyTransferProjectGateway = academyTransferProjectGateway;
         _trustGateway = trustGateway;
      }

      public Task<PagedResult<AcademyTransferProjectSummaryResponse>> Execute(int page, int count, int? urn,
         string title)
      {
         IEnumerable<AcademyTransferProjects> academyTransferProjects = FilterByUrn(
            _academyTransferProjectGateway.GetAcademyTransferProjects(), urn).ToList();

         IEnumerable<AcademyTransferProjectSummaryResponse> projects =
            FilterByIncomingTrust(title, AcademyTransferProjectSummaryResponse(academyTransferProjects));

         var recordTotal = projects.Count();
         projects = projects
            // remove any projects without an incoming or outgoing trust.
            .Where(p =>
                !string.IsNullOrEmpty(p.OutgoingTrustUkprn) || !string.IsNullOrEmpty(p.OutgoingTrustName) ||
                !p.TransferringAcademies.Any(ta => string.IsNullOrEmpty(ta.IncomingTrustUkprn) || string.IsNullOrEmpty(ta.IncomingTrustName)))
            .OrderByDescending(atp => atp.ProjectUrn)
            .Skip((page - 1) * count).Take(count).ToList();

         return Task.FromResult(new PagedResult<AcademyTransferProjectSummaryResponse>(projects, recordTotal));
      }

      private static IEnumerable<AcademyTransferProjects> FilterByUrn(IEnumerable<AcademyTransferProjects> queryable,
         int? urn)
      {
         if (urn.HasValue) queryable = queryable.Where(p => p.Urn == urn);

         return queryable;
      }

      private static IEnumerable<AcademyTransferProjectSummaryResponse> FilterByIncomingTrust(string title,
         IEnumerable<AcademyTransferProjectSummaryResponse> queryable)
      {
         if (!string.IsNullOrWhiteSpace(title))
            queryable = queryable
               .Where(p => p.TransferringAcademies.Any(r => r.IncomingTrustName!.ToLower().Contains(title!.ToLower())))
               .ToList();
         return queryable;
      }

      public IEnumerable<AcademyTransferProjectSummaryResponse> AcademyTransferProjectSummaryResponse(
         IEnumerable<AcademyTransferProjects> atp)
      {
         IEnumerable<Group> outgoingGroups =
            _trustGateway.GetMultipleGroupsByUkprn(atp.Select(x => x.OutgoingTrustUkprn)).ToList();

         IEnumerable<Trust> outgoingTrusts =
            _trustGateway.GetMultipleTrustsByGroupId(outgoingGroups.Select(x => x.GroupId)).ToList();

         IEnumerable<Group> incomingGroups =
            _trustGateway.GetMultipleGroupsByUkprn(atp.SelectMany(p =>
               p.TransferringAcademies.Select(a => a.IncomingTrustUkprn))).ToList();

         IEnumerable<Trust> incomingTrusts =
            _trustGateway.GetMultipleTrustsByGroupId(incomingGroups.Select(g => g.GroupId)).ToList();

         return atp.Select(x =>
         {
            Group outgoingGroup = outgoingGroups.FirstOrDefault(g => g.Ukprn == x.OutgoingTrustUkprn);
            return new AcademyTransferProjectSummaryResponse
            {
               ProjectUrn = x.Urn.ToString(),
               ProjectReference = x.ProjectReference,
               OutgoingTrustUkprn = x.OutgoingTrustUkprn,
               OutgoingTrustName = outgoingGroup?.GroupName,
               OutgoingTrustLeadRscRegion =
                  outgoingTrusts.FirstOrDefault(t => t.TrustRef == outgoingGroup?.GroupId)?.LeadRscRegion,
               AssignedUser = string.IsNullOrWhiteSpace(x.AssignedUserEmailAddress)
               ? null
               : new AssignedUserResponse
               {
                   EmailAddress = x.AssignedUserEmailAddress,
                   FullName = x.AssignedUserFullName,
                   Id = x.AssignedUserId
               },
               TransferringAcademies = x.TransferringAcademies.Select(ta =>
               {
                  Group group = incomingGroups.FirstOrDefault(g => g.Ukprn == ta.IncomingTrustUkprn);
                  return new TransferringAcademiesResponse
                  {
                     OutgoingAcademyUkprn = ta.OutgoingAcademyUkprn,
                     IncomingTrustUkprn = ta.IncomingTrustUkprn,
                     IncomingTrustName = group?.GroupName,
                     IncomingTrustLeadRscRegion = incomingTrusts.FirstOrDefault(t => t.TrustRef == group?.GroupId)?.LeadRscRegion,
                     PupilNumbersAdditionalInformation = ta.PupilNumbersAdditionalInformation,
                     LatestOfstedReportAdditionalInformation = ta.LatestOfstedReportAdditionalInformation,
                     KeyStage2PerformanceAdditionalInformation = ta.KeyStage2PerformanceAdditionalInformation,
                     KeyStage4PerformanceAdditionalInformation = ta.KeyStage4PerformanceAdditionalInformation,
                     KeyStage5PerformanceAdditionalInformation = ta.KeyStage5PerformanceAdditionalInformation
                  };
               }).ToList()
            };
         });
      }
   }
}

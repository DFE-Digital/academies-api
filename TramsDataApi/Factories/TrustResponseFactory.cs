using System.Collections.Generic;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public static class TrustResponseFactory
    {
        public static TrustResponse Create(Group group, Trust ifdTrustData)
        {
            IFDDataResponse ifdDataResponse;
            if (ifdTrustData == null)
            {
                ifdDataResponse = null;
            }
            else
            {
                ifdDataResponse = new IFDDataResponse
                {
                    TrustOpenDate = ifdTrustData.TrustsTrustOpenDate.ToString(),
                    LeadRSCRegion = ifdTrustData.LeadRscRegion,
                    TrustContactPhoneNumber = ifdTrustData.TrustContactDetailsTrustContactPhoneNumber,
                    PerformanceAndRiskDateOfMeeting = ifdTrustData.TrustPerformanceAndRiskDateOfMeeting.ToString(),
                    PrioritisedAreaOfReview = ifdTrustData.TrustPerformanceAndRiskPrioritisedForAReview,
                    CurrentSingleListGrouping = ifdTrustData.TrustPerformanceAndRiskSingleListGrouping,
                    DateOfGroupingDecision = ifdTrustData.TrustPerformanceAndRiskDateOfGroupingDecision.ToString(),
                    DateEnteredOntoSingleList = ifdTrustData.TrustPerformanceAndRiskDateEnteredOntoSingleList.ToString(),
                    TrustReviewWriteup = ifdTrustData.TrustPerformanceAndRiskTrustReviewWriteUp,
                    DateOfTrustReviewMeeting = ifdTrustData.TrustPerformanceAndRiskDateOfMeeting.ToString(),
                    FollowupLetterSent = ifdTrustData.TrustPerformanceAndRiskFollowUpLetterSent,
                    DateActionPlannedFor = ifdTrustData.TrustPerformanceAndRiskDateActionPlannedFor.ToString(),
                    WIPSummaryGoesToMinister = ifdTrustData.TrustPerformanceAndRiskWipSummaryGoesToMinister,
                    ExternalGovernanceReviewDate =
                        ifdTrustData.TrustPerformanceAndRiskExternalGovernanceReviewDate.ToString(),
                    EfficiencyICFPreviewCompleted = ifdTrustData.TrustPerformanceAndRiskEfficiencyIcfpReviewCompleted,
                    EfficiencyICFPreviewOther = ifdTrustData.TrustPerformanceAndRiskEfficiencyIcfpReviewOther,
                    LinkToWorkplaceForEfficiencyICFReview =
                        ifdTrustData.TrustPerformanceAndRiskLinkToWorkplaceForEfficiencyIcfpReview,
                    NumberInTrust = ifdTrustData.NumberInTrust.ToString()
                }; 
            }

           
            
            var giasDataResponse = new GIASDataResponse
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                CompaniesHouseNumber = group.CompaniesHouseNumber,
                GroupContactAddress = new AddressResponse
                {
                    Street = group.GroupContactStreet,
                    AdditionalLine = group.GroupContactAddress3,
                    Locality = group.GroupContactLocality,
                    Town = group.GroupContactTown,
                    County = group.GroupContactCounty,
                    Postcode = group.GroupContactPostcode
                },
                Ukprn = group.Ukprn
            };
            var academyResponses = new List<AcademyResponse>();
            return new TrustResponse
                {IfdData = ifdDataResponse, GiasData = giasDataResponse, Academies = academyResponses};
        }
    }
}
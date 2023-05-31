using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public static class TrustResponseFactory
    {
        public static TrustResponse Create(Group group, Trust ifdTrustData, List<EstablishmentResponse> establishments)
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
                    TrustOpenDate = ifdTrustData.TrustsTrustOpenDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    LeadRSCRegion = ifdTrustData.LeadRscRegion,
                    TrustContactPhoneNumber = ifdTrustData.TrustContactDetailsTrustContactPhoneNumber,
                    PerformanceAndRiskDateOfMeeting = ifdTrustData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PrioritisedAreaOfReview = ifdTrustData.TrustPerformanceAndRiskPrioritisedForAReview,
                    CurrentSingleListGrouping = ifdTrustData.TrustPerformanceAndRiskSingleListGrouping,
                    DateOfGroupingDecision = ifdTrustData.TrustPerformanceAndRiskDateOfGroupingDecision?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DateEnteredOntoSingleList = ifdTrustData.TrustPerformanceAndRiskDateEnteredOntoSingleList?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    TrustReviewWriteup = ifdTrustData.TrustPerformanceAndRiskTrustReviewWriteUp,
                    DateOfTrustReviewMeeting = ifdTrustData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    FollowupLetterSent = ifdTrustData.TrustPerformanceAndRiskFollowUpLetterSent,
                    DateActionPlannedFor = ifdTrustData.TrustPerformanceAndRiskDateActionPlannedFor?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    WIPSummaryGoesToMinister = ifdTrustData.TrustPerformanceAndRiskWipSummaryGoesToMinister,
                    ExternalGovernanceReviewDate =
                        ifdTrustData.TrustPerformanceAndRiskExternalGovernanceReviewDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EfficiencyICFPreviewCompleted = ifdTrustData.TrustPerformanceAndRiskEfficiencyIcfpReviewCompleted,
                    EfficiencyICFPreviewOther = ifdTrustData.TrustPerformanceAndRiskEfficiencyIcfpReviewOther,
                    LinkToWorkplaceForEfficiencyICFReview =
                        ifdTrustData.TrustPerformanceAndRiskLinkToWorkplaceForEfficiencyIcfpReview,
                    NumberInTrust = ifdTrustData.NumberInTrust.ToString(),
                    TrustType = ifdTrustData.TrustsTrustType,
                    TrustAddress = new AddressResponse
                    {
                        Street = ifdTrustData.TrustContactDetailsTrustAddressLine1,
                        AdditionalLine = ifdTrustData.TrustContactDetailsTrustAddressLine2,
                        Locality = ifdTrustData.TrustContactDetailsTrustAddressLine3,
                        Town = ifdTrustData.TrustContactDetailsTrustTown,
                        County = ifdTrustData.TrustContactDetailsTrustCounty,
                        Postcode = ifdTrustData.TrustContactDetailsTrustPostcode
                    }
                }; 
            }
            
            var giasDataResponse = new GIASDataResponse
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                GroupType = group.GroupType,
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
            
            return new TrustResponse
            {
                IfdData = ifdDataResponse, 
                GiasData = giasDataResponse, 
                Establishments = establishments
            };
        }

        public static MasterTrustResponse CreateFromMaster(Group group, TrustMasterData mstrTrustData, List<EstablishmentResponse> establishments)
        {
            MasterTrustDataResponse masterDataResponse;
            if (mstrTrustData == null)
            {
                masterDataResponse = null;
            }
            else
            {
                masterDataResponse = new MasterTrustDataResponse
                {
       
                    TrustContactPhoneNumber = mstrTrustData.MainPhone,
                    PerformanceAndRiskDateOfMeeting = mstrTrustData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    PrioritisedAreaOfReview = mstrTrustData.PrioritisedForReview,
                    CurrentSingleListGrouping = mstrTrustData.CurrentSingleListGrouping,
                    DateOfGroupingDecision = mstrTrustData.DateOfGroupingDecision?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DateEnteredOntoSingleList = mstrTrustData.DateEnteredOntoSingleList?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    TrustReviewWriteup = mstrTrustData.TrustReviewWriteUp,
                    DateOfTrustReviewMeeting = mstrTrustData.TrustPerformanceAndRiskDateOfMeeting?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DateActionPlannedFor = mstrTrustData.DateActionPlannedFor?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    WIPSummaryGoesToMinister = mstrTrustData.WIPSummaryGoesToMinister,
                    ExternalGovernanceReviewDate =
                        mstrTrustData.ExternalGovernanceReviewDate?.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                    EfficiencyICFPreviewCompleted = mstrTrustData.EfficiencyICFPReviewCompleted,
                    EfficiencyICFPreviewOther = mstrTrustData.EfficiencyICFPReviewOther,
                    LinkToWorkplaceForEfficiencyICFReview =
                        mstrTrustData.LinkToWorkplaceForEfficiencyICFPReview,
                    FollowupLetterSent = mstrTrustData.FollowUpLetterSent,
                    NumberInTrust = mstrTrustData.NumberInTrust.ToString(),
                    TrustType = mstrTrustData.TrustsTrustType.ToString(),   
                    TrustAddress = new AddressResponse
                    {
                        Street = mstrTrustData.AddressLine1,
                        AdditionalLine = mstrTrustData.AddressLine2,
                        Locality = mstrTrustData.AddressLine3,
                        Town = mstrTrustData.Town,
                        County = mstrTrustData.County,
                        Postcode = mstrTrustData.Postcode
                    }
                };
            }

            var giasDataResponse = new GIASDataResponse
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName,
                GroupType = group.GroupType,
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

            return new MasterTrustResponse
            {
                MasterTrustData = masterDataResponse,
                GiasData = giasDataResponse,
                Establishments = establishments
            };
        }


    }
}
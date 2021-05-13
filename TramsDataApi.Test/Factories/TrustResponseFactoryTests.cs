using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using FizzWare.NBuilder;
using FizzWare.NBuilder.PropertyNaming;
using FluentAssertions;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class TrustResponseFactoryTests
    {
        public TrustResponseFactoryTests()
        {
            BuilderSetup.SetDefaultPropertyName(new RandomValuePropertyNamer(new BuilderSettings()));
        }

        [Fact]
        public void TrustResponseFactory_CreatesTrustResponse_FromAGroup()
        {
            var group = Builder<Group>.CreateNew().Build();
            var ifdTrustData =  Builder<Trust>.CreateNew().Build();

            var ifdDataResponse = new IFDDataResponse
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
                NumberInTrust = ifdTrustData.NumberInTrust.ToString()
            };
            
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
            var establishmentResponses = new List<EstablishmentResponse>();
            var expected = new TrustResponse
                {IfdData = ifdDataResponse, GiasData = giasDataResponse, Establishments = establishmentResponses};

            var result = TrustResponseFactory.Create(group, ifdTrustData, new List<EstablishmentResponse>());
            result.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
         public void TrustResponseFactory_CreatesTrustResponse_FromAGroup_WhenIfdTrustDataIsNull()
         {
            var group = Builder<Group>.CreateNew().Build();
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
            var establishmentResponses = new List<EstablishmentResponse>();
            var expected = new TrustResponse
                {IfdData = null, GiasData = giasDataResponse, Establishments = establishmentResponses};

            var result = TrustResponseFactory.Create(group, null, new List<EstablishmentResponse>());
            result.Should().BeEquivalentTo(expected);
        }
    }
}
    
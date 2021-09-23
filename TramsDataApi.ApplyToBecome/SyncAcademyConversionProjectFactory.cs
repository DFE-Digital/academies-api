namespace TramsDataApi.ApplyToBecome
{
    public static class SyncAcademyConversionProjectFactory
    {
        private const int DefaultConversionSupportGrantAmount = 25000;

        public static SyncAcademyConversionProject Create(SyncIfdPipeline ifdPipeline)
        {
            int.TryParse(ifdPipeline.GeneralDetailsUrn, out var urn);

            return new SyncAcademyConversionProject
            {
                IfdPipelineId = (int)ifdPipeline.Sk,
                Urn = urn > 0 ? (int?)urn : null,
                SchoolName = ifdPipeline.GeneralDetailsProjectName,
                LocalAuthority = ifdPipeline.GeneralDetailsLocalAuthority,
                //ApplicationReferenceNumber
                ProjectStatus = "Active",
                ApplicationReceivedDate = ifdPipeline.ApprovalProcessApplicationDate,
                //AssignedDate
                HeadTeacherBoardDate = ifdPipeline.DeliveryProcessDateForDiscussionByRscHtb,
                //OpeningDate
                //BaselineDate

                //school/trust info
                //RecommendationForProject
                Author = ifdPipeline.GeneralDetailsProjectLead,
                //Version
                ClearedBy = ifdPipeline.GeneralDetailsTeamLeader,
                //AcademyOrderRequired
                //PreviousHeadTeacherBoardDate
                //PreviousHeadTeacherBoardLink
                TrustReferenceNumber = ifdPipeline.TrustSponsorManagementTrust,
                //NameOfTrust
                //SponsorReferenceNumber
                //SponsorName
                //AcademyTypeAndRoute
                ProposedAcademyOpeningDate = ifdPipeline.GeneralDetailsExpectedOpeningDate,
                ConversionSupportGrantAmount = DefaultConversionSupportGrantAmount,

                //general info
                PublishedAdmissionNumber = ifdPipeline.DeliveryProcessPan,
                PartOfPfiScheme = ifdPipeline.DeliveryProcessPfi,
                ViabilityIssues = ifdPipeline.ProjectTemplateInformationViabilityIssue,
                FinancialDeficit = ifdPipeline.ProjectTemplateInformationDeficit,

                // rationale
                RationaleForProject = ifdPipeline.ProjectTemplateInformationRationaleForProject,
                RationaleForTrust = ifdPipeline.ProjectTemplateInformationRationaleForSponsor,

                // risk and issues
                RisksAndIssues = ifdPipeline.ProjectTemplateInformationRisksAndIssues,
                //EqualitiesImpactAssessmentConsidered

                // school budget info
                RevenueCarryForwardAtEndMarchCurrentYear = ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward.ToDecimal(),
                ProjectedRevenueBalanceAtEndMarchNextYear = ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward.ToDecimal(),
                //CapitalCarryForwardAtEndMarchCurrentYear
                //CapitalCarryForwardAtEndMarchNextYear

                // pupil schools forecast
                YearOneProjectedCapacity = ifdPipeline.ProjectTemplateInformationAy1CapacityForecast.ToInt(),
                YearOneProjectedPupilNumbers = ifdPipeline.ProjectTemplateInformationAy1TotalPupilNumberForecast.ToInt(),
                YearTwoProjectedCapacity = ifdPipeline.ProjectTemplateInformationAy2CapacityForecast.ToInt(),
                YearTwoProjectedPupilNumbers = ifdPipeline.ProjectTemplateInformationAy2TotalPupilNumberForecast.ToInt(),
                YearThreeProjectedCapacity = ifdPipeline.ProjectTemplateInformationAy3CapacityForecast.ToInt(),
                YearThreeProjectedPupilNumbers = ifdPipeline.ProjectTemplateInformationAy3TotalPupilNumberForecast.ToInt()
            };
        }

        private static decimal? ToDecimal(this string decimalString)
        {
            if (string.IsNullOrEmpty(decimalString)) return null;
            var parseSuccess = decimal.TryParse(decimalString, out var parsedDecimal);
            return parseSuccess ? parsedDecimal : (decimal?)null;
        }

        private static int? ToInt(this string intString)
        {
            if (string.IsNullOrEmpty(intString)) return null;
            var parseSuccess = int.TryParse(intString, out var parsedInt);
            return parseSuccess ? parsedInt : (int?)null;
        }
    }
}

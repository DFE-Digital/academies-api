namespace TramsDataApi.ApplyToBecome
{
    public static class SyncAcademyConversionProjectFactory
    {
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
                ApplicationReceivedDate = ifdPipeline.InterestDateOfInterest,
                AssignedDate = ifdPipeline.ApprovalProcessApplicationDate,
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
                RevenueCarryForwardAtEndMarchCurrentYear = ParseDecimal(ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward),
                ProjectedRevenueBalanceAtEndMarchNextYear = ParseDecimal(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward),
                //CapitalCarryForwardAtEndMarchCurrentYear
                //CapitalCarryForwardAtEndMarchNextYear

                // pupil schools forecast
                YearOneProjectedCapacity = ParseInt(ifdPipeline.ProjectTemplateInformationAy1CapacityForecast),
                YearOneProjectedPupilNumbers = ParseInt(ifdPipeline.ProjectTemplateInformationAy1TotalPupilNumberForecast),
                YearTwoProjectedCapacity = ParseInt(ifdPipeline.ProjectTemplateInformationAy2CapacityForecast),
                YearTwoProjectedPupilNumbers = ParseInt(ifdPipeline.ProjectTemplateInformationAy2TotalPupilNumberForecast),
                YearThreeProjectedCapacity = ParseInt(ifdPipeline.ProjectTemplateInformationAy3CapacityForecast),
                YearThreeProjectedPupilNumbers = ParseInt(ifdPipeline.ProjectTemplateInformationAy3TotalPupilNumberForecast)
            };
        }

        private static decimal? ParseDecimal(string decimalString)
        {
            if (string.IsNullOrEmpty(decimalString)) return null;
            var parseSuccess = decimal.TryParse(decimalString, out var parsedDecimal);
            return parseSuccess ? parsedDecimal : (decimal?)null;
        }

        private static int? ParseInt(string intString)
        {
            if (string.IsNullOrEmpty(intString)) return null;
            var parseSuccess = int.TryParse(intString, out var parsedInt);
            return parseSuccess ? parsedInt : (int?)null;
        }
    }
}

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
                RevenueCarryForwardAtEndMarchCurrentYear = !string.IsNullOrEmpty(ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward) ?
                    decimal.Parse(ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward) : (decimal?)null,
                ProjectedRevenueBalanceAtEndMarchNextYear = !string.IsNullOrEmpty(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward) ?
                    decimal.Parse(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward) : (decimal?)null
                //CapitalCarryForwardAtEndMarchCurrentYear
                //CapitalCarryForwardAtEndMarchNextYear

                // pupil schools forecast
                //YearOneProjectedCapacity
                //YearOneProjectedPupilNumbers
                //YearTwoProjectedCapacity
                //YearTwoProjectedPupilNumbers
                //YearThreeProjectedCapacity
                //YearThreeProjectedPupilNumbers
            };
        }
    }
}

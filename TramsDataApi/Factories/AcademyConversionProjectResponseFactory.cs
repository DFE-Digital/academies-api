using System.Linq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
    public class AcademyConversionProjectResponseFactory
    {
	    public static AcademyConversionProjectResponse Create(IfdPipeline ifdPipeline, AcademyConversionProject academyConversionProject = null)
        {
			var response = new AcademyConversionProjectResponse
			{
				Id = (int)ifdPipeline.Sk,
				Urn = int.Parse(ifdPipeline.GeneralDetailsUrn),
				SchoolName = ifdPipeline.GeneralDetailsProjectName,
				LocalAuthority = ifdPipeline.GeneralDetailsLocalAuthority,
				ApplicationReceivedDate = ifdPipeline.InterestDateOfInterest,
				AssignedDate = ifdPipeline.ApprovalProcessApplicationDate,
				ProjectStatus = "Pre HTB",
				PublishedAdmissionNumber = ifdPipeline.DeliveryProcessPan,
				PartOfPfiScheme = ifdPipeline.DeliveryProcessPfi,
				ViabilityIssues = ifdPipeline.ProjectTemplateInformationViabilityIssue,
				FinancialDeficit = ifdPipeline.ProjectTemplateInformationDeficit,
				RationaleForProject = ifdPipeline.ProjectTemplateInformationRationaleForProject,
				RationaleForTrust = ifdPipeline.ProjectTemplateInformationRationaleForSponsor,
				RisksAndIssues = ifdPipeline.ProjectTemplateInformationRisksAndIssues,
				RevenueCarryForwardAtEndMarchCurrentYear = !string.IsNullOrEmpty(ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward) ?
				    decimal.Parse(ifdPipeline.ProjectTemplateInformationFyRevenueBalanceCarriedForward) : (decimal?)null,
				ProjectedRevenueBalanceAtEndMarchNextYear = !string.IsNullOrEmpty(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward) ?
					decimal.Parse(ifdPipeline.ProjectTemplateInformationFy1RevenueBalanceCarriedForward) : (decimal?)null
			};

			if (academyConversionProject != null)
            {
				response.RationaleSectionComplete = academyConversionProject.RationaleSectionComplete;
				response.LocalAuthorityInformationTemplateSentDate = academyConversionProject.LocalAuthorityInformationTemplateSentDate;
				response.LocalAuthorityInformationTemplateReturnedDate = academyConversionProject.LocalAuthorityInformationTemplateReturnedDate;
				response.LocalAuthorityInformationTemplateComments = academyConversionProject.LocalAuthorityInformationTemplateComments;
				response.LocalAuthorityInformationTemplateLink = academyConversionProject.LocalAuthorityInformationTemplateLink;
				response.LocalAuthorityInformationTemplateSectionComplete = academyConversionProject.LocalAuthorityInformationTemplateSectionComplete;
				response.DistanceFromSchoolToTrustHeadquarters = academyConversionProject.DistanceFromSchoolToTrustHeadquarters;
				response.DistanceFromSchoolToTrustHeadquartersAdditionalInformation = academyConversionProject.DistanceFromSchoolToTrustHeadquartersAdditionalInformation;
				response.GeneralInformationSectionComplete = academyConversionProject.GeneralInformationSectionComplete;
				response.RisksAndIssuesSectionComplete = academyConversionProject.RisksAndIssuesSectionComplete;
				response.SchoolPerformanceAdditionalInformation = academyConversionProject.SchoolPerformanceAdditionalInformation;
				response.CapitalCarryForwardAtEndMarchCurrentYear = academyConversionProject.CapitalCarryForwardAtEndMarchCurrentYear;
				response.CapitalCarryForwardAtEndMarchNextYear = academyConversionProject.CapitalCarryForwardAtEndMarchNextYear;
				response.SchoolBudgetInformationAdditionalInformation = academyConversionProject.SchoolBudgetInformationAdditionalInformation;
				response.SchoolBudgetInformationSectionComplete = academyConversionProject.SchoolBudgetInformationSectionComplete;
				response.ProjectNotes = academyConversionProject.ProjectNotes?.Select(p => new ProjectNoteResponse
				{
					Subject = p.Subject,
					Note = p.Note,
					Author = p.Author,
					Date = p.Date
				}).ToList();
            }

			return response;
		}
    }
}

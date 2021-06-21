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
				RationaleForProject = ifdPipeline.ProjectTemplateInformationRationaleForProject,
				RationaleForTrust = ifdPipeline.ProjectTemplateInformationRationaleForSponsor,
				RisksAndIssues = ifdPipeline.ProjectTemplateInformationRisksAndIssues,
			};

			if (academyConversionProject != null)
            {
				response.RationaleSectionComplete = academyConversionProject.RationaleSectionComplete;
				response.LocalAuthorityInformationTemplateSentDate = academyConversionProject.LocalAuthorityInformationTemplateSentDate;
				response.LocalAuthorityInformationTemplateReturnedDate = academyConversionProject.LocalAuthorityInformationTemplateReturnedDate;
				response.LocalAuthorityInformationTemplateComments = academyConversionProject.LocalAuthorityInformationTemplateComments;
				response.LocalAuthorityInformationTemplateLink = academyConversionProject.LocalAuthorityInformationTemplateLink;
				response.LocalAuthorityInformationTemplateSectionComplete = academyConversionProject.LocalAuthorityInformationTemplateSectionComplete;
				response.RisksAndIssuesSectionComplete = academyConversionProject.RisksAndIssuesSectionComplete;
				response.SchoolPerformanceAdditionalInformation = academyConversionProject.SchoolPerformanceAdditionalInformation;
			}

			return response;
		}
    }
}

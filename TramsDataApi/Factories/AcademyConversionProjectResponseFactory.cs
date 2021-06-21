using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
    public class AcademyConversionProjectResponseFactory
    {
	    public static AcademyConversionProjectResponse Create(IfdPipeline ifdPipeline, AcademyConversionProject academyConversionProject = null)
        {
			return new AcademyConversionProjectResponse
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
				RationaleSectionComplete = academyConversionProject?.RationaleSectionComplete,
				LocalAuthorityInformationTemplateSentDate = academyConversionProject?.LocalAuthorityInformationTemplateSentDate,
				LocalAuthorityInformationTemplateReturnedDate = academyConversionProject?.LocalAuthorityInformationTemplateReturnedDate,
				LocalAuthorityInformationTemplateComments = academyConversionProject?.LocalAuthorityInformationTemplateComments,
				LocalAuthorityInformationTemplateLink = academyConversionProject?.LocalAuthorityInformationTemplateLink,
				LocalAuthorityInformationTemplateSectionComplete = academyConversionProject?.LocalAuthorityInformationTemplateSectionComplete
			};
		}
    }
}

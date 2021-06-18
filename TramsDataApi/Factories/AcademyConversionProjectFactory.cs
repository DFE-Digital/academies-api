using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
    public class AcademyConversionProjectFactory
    {
        public static IfdPipeline Update(IfdPipeline project, UpdateAcademyConversionProjectRequest updateRequest)
        {
            if (updateRequest == null)
            {
                return project;
            }

            project.ProjectTemplateInformationRationaleForProject = updateRequest.RationaleForProject ?? project.ProjectTemplateInformationRationaleForProject;
            project.ProjectTemplateInformationRationaleForSponsor = updateRequest.RationaleForTrust ?? project.ProjectTemplateInformationRationaleForSponsor;
            project.ProjectTemplateInformationRisksAndIssues = updateRequest.RisksAndIssues ?? project.ProjectTemplateInformationRisksAndIssues;

            return project;
        }

        public static AcademyConversionProject Update(AcademyConversionProject project, UpdateAcademyConversionProjectRequest updateRequest)
        {
            if (updateRequest == null)
            {
                return project;
            }

            project.RationaleSectionComplete = updateRequest.RationaleSectionComplete ?? project.RationaleSectionComplete;
            project.RisksAndIssuesSectionComplete = updateRequest.RisksAndIssuesSectionComplete ?? project.RisksAndIssuesSectionComplete;

            return project;
        }
    }
}

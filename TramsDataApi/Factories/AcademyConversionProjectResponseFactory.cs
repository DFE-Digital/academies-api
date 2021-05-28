using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;

namespace TramsDataApi.Factories
{
    public class AcademyConversionProjectResponseFactory
    {
        public static AcademyConversionProjectResponse Create(IfdPipeline ifdPipeline)
        {
			return new AcademyConversionProjectResponse
			{
				Id = (int)ifdPipeline.Sk,
				School = new SchoolResponse
				{
					Id = ifdPipeline.GeneralDetailsUrn,
					Name = ifdPipeline.GeneralDetailsProjectName,
					URN = ifdPipeline.GeneralDetailsUrn,
					LocalAuthority = ifdPipeline.GeneralDetailsLocalAuthority
				},
				Trust = new TrustResponse
				{
					Id = ifdPipeline.TrustSponsorManagementCoSponsor1,
					Name = ifdPipeline.TrustSponsorManagementCoSponsor1SponsorName
				},
				ApplicationReceivedDate = ifdPipeline.InterestDateOfInterest,
				AssignedDate = ifdPipeline.ApprovalProcessApplicationDate,
				Phase = ProjectPhase.PreHTB,
				ProjectDocuments = new DocumentDetailsResponse[0]
			};
		}
    }
}

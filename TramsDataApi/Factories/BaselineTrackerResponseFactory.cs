using System;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class BaselineTrackerResponseFactory
    {
		public static BaselineTrackerResponse Create(IfdPipeline ifd = null)
		{
			var response = new BaselineTrackerResponse();

			// KIM
			if (ifd != null)
			{
				response.Urn = Convert.ToInt32(ifd.GeneralDetailsUrn);
				response.RouteOfProject = ifd.GeneralDetailsRouteOfProject;

				response.PupilNumberMethodology = ifd.ProposedAcademyDetailsPost16;
				response.AcademyFundingTypeCategory = ifd.ProposedAcademyDetailsGagFundingPupilNumbersType;

				response.AcademyOrderApprovedDate = ifd.ApprovalProcessFundingAgreementApprovedDate;
				response.CurrentConverionDate = ifd.GeneralDetailsExpectedOpeningDate;

				response.Upin = ifd.EfaFundingUpin;
				response.NewAcademyUrn = ifd.ProposedAcademyDetailsNewAcademyUrn;
				response.NewAcademyName = ifd.ProposedAcademyDetailsNewAcademyName;
				response.ProjectStatus = ifd.GeneralDetailsProjectStatus;
				response.ProjectName = ifd.GeneralDetailsProjectName;

				response.SchoolContactName = ifd.DeliveryProcessMainContactForConversionName;
				response.SchoolAddress1 = ifd.ProposedAcademyDetailsAcademyMainContactAddressLine1;
				response.SchoolAddress2 = ifd.ProposedAcademyDetailsAcademyMainContactAddressLine2;
				response.SchoolAddress3 = ifd.ProposedAcademyDetailsAcademyMainContactAddressLine3;
				response.SchoolAddress4 = ifd.ProposedAcademyDetailsAcademyMainContactTown;
				response.SchoolPostcode = ifd.ProposedAcademyDetailsAcademyMainContactPostcode;
				response.SchoolEmail = ifd.ProposedAcademyDetailsAcademyMainContactEmail;

				response.RSC = ifd.GeneralDetailsRscRegion;
				response.Territory = ifd.EfaFundingEfaTerritory;
				response.SchoolPhase = ifd.ProposedAcademyDetailsAcademyPhaseProposed;
				response.SchoolType = ifd.ProposedAcademyDetailsGagFundingPupilNumbersType;

				response.AcademyProposedCapacityPrimary = ifd.ProposedAcademyDetailsAcademyProposedCapacityPrimaryRYr6;
				response.AcademyProposedCapacitySecondary = ifd.ProposedAcademyDetailsAcademyProposedCapacitySecondaryYr7Yr11;
				response.AcademyProposedCapacityPost = ifd.ProposedAcademyDetailsAcademyProposedCapacityPost16;

				response.DfeProjectLead = ifd.GeneralDetailsProjectLead;
				response.DfeGrade6 = ifd.GeneralDetailsGrade6;
				response.DfeTeamLeder = ifd.GeneralDetailsTeamLeader;
				response.ProjectLeadEmail = string.Empty; // No mapping found
				response.RPA = ifd.DeliveryProcessBaselineDate;
			}

			return response;
		}
	}
}

﻿using Dfe.Academies.Domain.Establishment;
using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;
using Establishment = TramsDataApi.DatabaseModels.Establishment;
using IfdPipeline = TramsDataApi.DatabaseModels.IfdPipeline;

namespace TramsDataApi.Factories
{
    public class BaselineTrackerResponseFactory
    {
		public static BaselineTrackerResponse Create(IfdPipeline ifd = null, Trust trust = null, Establishment establishment = null, Group group = null, MisEstablishment misEstablishment = null)
		{
			var response = new BaselineTrackerResponse();

			// KIM
			if (ifd != null)
			{
				response.Urn = ifd.GeneralDetailsUrn;
				response.RouteOfProject = ifd.GeneralDetailsRouteOfProject;
				response.NewLAEstab = ifd.GeneralDetailsAcademyLaestab;
				response.NewAcademyUKPRN = ifd.GeneralDetailsAcademyUkprn;

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
				response.Region = ifd.GeneralDetailsRscRegion;
			}

			if (trust != null)
            {
				response.NameOfTrust = trust.TrustsTrustName;
				response.SponsorReferenceNumber = trust.LeadSponsor;
				response.SponsorName = trust.TrustsLeadSponsorName;
				response.LeadSponsorId = trust.TrustsLeadSponsorId;
				response.SponsorEmail = trust.TrustContactDetailsTrustContactEmail;
				response.GroupId = group?.GroupId;
				response.GroupType = group?.GroupType;
				response.TrustCompaniesHouseRef = group?.CompaniesHouseNumber;
				response.TrustUKPRN = group.Ukprn;
			}

			// GIAS
			if (establishment != null)
            {
				response.UkPrn = establishment.Ukprn;
				response.TrustUID = establishment.TrustsCode;
				response.LA = establishment.LaCode;
				response.Laestab = misEstablishment?.Laestab ?? 0;
			}

			return response;
		}
	}
}

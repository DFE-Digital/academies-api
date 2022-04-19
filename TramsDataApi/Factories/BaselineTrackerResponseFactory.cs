using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public class BaselineTrackerResponseFactory
    {
		public static BaselineTrackerResponse Create(AcademyConversionProject academyConversionProject, Trust trust = null, IfdPipeline ifd = null)
		{
			var response = new BaselineTrackerResponse
			{
				Id = academyConversionProject.Id,
				ApplicationReferenceNumber = academyConversionProject.ApplicationReferenceNumber,
				Urn = academyConversionProject.Urn ?? 0,

				

				SchoolContactName = academyConversionProject.SchoolName,
				TrustReferenceNumber = academyConversionProject.TrustReferenceNumber,
				ProjectStatus = academyConversionProject.ProjectStatus,

			};

			if (trust != null)
			{
				response.NameOfTrust = trust.TrustsTrustName;
				response.SponsorReferenceNumber = trust.LeadSponsor;
				response.SponsorName = trust.TrustsLeadSponsorName;
			}

			if (ifd != null)
			{
				response.Upin = ifd.EfaFundingUpin;
				response.NewAcademyUrn = ifd.ProposedAcademyDetailsNewAcademyUrn;
				response.NewAcademyName = ifd.ProposedAcademyDetailsNewAcademyName;
				response.ProjectStatus = ifd.GeneralDetailsProjectStatus;

				response.SchoolContactName = ifd.DeliveryProcessMainContactForConversionName;
			}

			return response;
		}
	}
}

using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels;

namespace TramsDataApi.Factories
{
    public static class FssProjectResponseFactory
    {
        public static FssProjectResponse Create(FssProject fssProject)
        {
            if (fssProject == null)
            {
                return null;
            }

            return new FssProjectResponse
            {               
                ActualOpeningDate = fssProject.ActualOpeningDate,
                AgeRange = fssProject.AgeRange,
                ApplicationWave = fssProject.ApplicationWave,
                CurrentFreeSchoolName = fssProject.CurrentFreeSchoolName,
                DateOfEntryIntoPreOpening = fssProject.DateOfEntryIntoPreOpening,
                DateSchoolClosed = fssProject.DateSchoolClosed,
                FaithStatus = fssProject.FaithStatus,
                FaithType = fssProject.FaithType,
                FreeSchoolPenPortrait = fssProject.FreeSchoolPenPortrait,
                FSGLeadContact = fssProject.FSGLeadContact,
                Gender = fssProject.Gender,
                LocalAuthority = fssProject.LocalAuthority,
                NumberOfFormsOfEntry = fssProject.NumberOfFormsOfEntry,
                Nursery = fssProject.Nursery,
                Postcode = fssProject.Postcode,
                ProjectId = fssProject.ProjectId,
                ProjectStatus = fssProject.ProjectStatus,
                ProvisionalOpeningDateAgreedWithTrust = fssProject.ProvisionalOpeningDateAgreedWithTrust,
                ResidentialOrBoardingProvision = fssProject.ResidentialOrBoardingProvision,
                ResidentialBoardingProvisionDetails = fssProject.ResidentialBoardingProvisionDetails,
                OtherFaithType = fssProject.OtherFaithType,
                LaesTab = fssProject.LaesTab,
                RSCRegion = fssProject.RSCRegion,
                SchoolAddress = fssProject.SchoolAddress,
                SchoolPhase = fssProject.SchoolPhase,
                SchoolType = fssProject.SchoolType,
                SixthForm = fssProject.SixthForm,
                SixthFormType = fssProject.SixthFormType,
                Specialism = fssProject.Specialism,
                TrustId = fssProject.TrustId,
                TrustName = fssProject.TrustName,
                URN = fssProject.URN,
                FAForecastDate = fssProject.FAForecastDate,
                FAActualCompletionDate = fssProject.FAActualCompletionDate,
                KickOfMeetingHeldDate = fssProject.KickOfMeetingHeldDate,
                RealisticYearofOpening = fssProject.RealisticYearofOpening,
                MemberOfParliament = fssProject.MemberOfParliament,
                NumberOfPupil = fssProject.NumberOfPupil
            };
        }
    }
}

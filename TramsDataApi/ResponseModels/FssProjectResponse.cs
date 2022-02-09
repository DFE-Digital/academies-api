using System;

namespace TramsDataApi.ResponseModels
{
    public class FssProjectResponse
    {        
        public DateTime? ActualOpeningDate { get; set; }
        public string AgeRange { get; set; }
        public string ApplicationWave { get; set; }
        public string CurrentFreeSchoolName { get; set; }
        public DateTime?  DateOfEntryIntoPreOpening { get; set; }
        public DateTime? DateSchoolClosed { get; set; }
        public string FaithStatus { get; set; }
        public string FaithType { get; set; }
        public string FreeSchoolPenPortrait { get; set; }
        public string FSGLeadContact { get; set; }
        public string Gender { get; set; }
        public string LocalAuthority { get; set; }
        public string NumberOfFormsOfEntry { get; set; }
        public string Nursery { get; set; }
        public string Postcode { get; set; }
        public string ProjectId { get; set; }
        public string ProjectStatus { get; set; }
        public DateTime? ProvisionalOpeningDateAgreedWithTrust { get; set; }
        public string ResidentialOrBoardingProvision { get; set; }
        public string RSCRegion { get; set; }
        public string SchoolAddress { get; set; }
        // (primary, secondary) 
        public string SchoolPhase { get; set; }
       // School type(mainstream, AP etc)
        public string SchoolType { get; set; }
        public string SixthForm { get; set; }
        public string SixthFormType { get; set; }
        public string Specialism { get; set; }
        public string TrustId { get; set; }
        public string TrustName { get; set; }
        public string URN { get; set; }
        public DateTime? FAForecastDate { get; set; }
        //(actual date)
        public DateTime? FAActualCompletionDate { get; set; }
        public DateTime? KickOfMeetingHeldDate { get; set; }
    }
}

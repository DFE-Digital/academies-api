using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfe.Academies.Domain.Establishment
{
    public class Establishment
    {
        public long? SK { get; set; }
        public string? PK_GIAS_URN { get; set; }
        public long? PK_CDM_ID { get; set; }
        public int? URN { get; set; }
        public long? LocalAuthorityId { get; set; }
        public long? EstablishmentTypeId { get; set; }
        public long? EstablishmentGroupTypeId { get; set; }
        public long? EstablishmentStatusId { get; set; }
        public long? RegionId { get; set; }
        public int? EstablishmentNumber { get; set; }
        public string? EstablishmentName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string? MainPhone { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? AddressLine3 { get; set; }
        public string? Town { get; set; }
        public string? County { get; set; }
        public string? Postcode { get; set; }
        public string? Email { get; set; }
        public string? Website { get; set; }
        public string? StatutoryLowAge { get; set; }
        public string? StatutoryHighAge { get; set; }
        public string? SchoolCapacity { get; set; }
        public string? NumberOfPupils { get; set; }
        public string? OfstedLastInspection { get; set; }
        public string? OfstedRating { get; set; }
        public string? OpenDate { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }
        public int? TheIncomeDeprivationAffectingChildrenIndexIDACIQuintile { get; set; }
        public int? NumberOfShortInspectionsSinceLastFullInspection { get; set; }
        public DateTime? DateOfLatestShortInspection { get; set; }
        public DateTime? ShortInspectionPublicationDate { get; set; }
        public string? DidTheLatestShortInspectionConvertToAFullInspection { get; set; }
        public string? ShortInspectionOverallOutcome { get; set; }
        public int? NumberOfOtherSection8InspectionsSinceLastFullInspection { get; set; }
        public string? InspectionType { get; set; }
        public DateTime? InspectionStartDate { get; set; }
        public DateTime? InspectionEndDate { get; set; }
        public DateTime? PublicationDate { get; set; }
        public int? OverallEffectiveness { get; set; }
        public string? CategoryOfConcern { get; set; }
        public int? EarlyYearsProvisionWhereApplicable { get; set; }
        public int? EffectivenessOfLeadershipAndManagement { get; set; }
        public string? IsSafeguardingEffective { get; set; }
        public DateTime? PreviousInspectionStartDate { get; set; }
        public DateTime? PreviousInspectionEndDate { get; set; }
        public DateTime? PreviousPublicationDate { get; set; }
        public int? PreviousFullInspectionOverallEffectiveness { get; set; }
        public string? PreviousCategoryOfConcern { get; set; }
        public int? PreviousEarlyYearsProvisionWhereApplicable { get; set; }
        public string? PreviousIsSafeguardingEffective { get; set; }
        public string? HeadTitle { get; set; }
        public string? HeadFirstName { get; set; }
        public string? HeadLastName { get; set; }
        public string? HeadPreferredJobTitle { get; set; }
        public string? PhaseOfEducation { get; set; }
        public string? PercentageFSM { get; set; }
        public string? UKPRN { get; set; }
        public string? ReligiousCharacter { get; set; }
        public string? ReligiousEthos { get; set; }
        public string? Diocese { get; set; }
        public string? ReasonEstablishmentClosed { get; set; }
        public DateTime? CloseDate { get; set; }
        public string? ProjectLead { get; set; }
        public string? ParliamentaryConstituency { get; set; }
        public int? QualityOfEducation { get; set; }
        public int? BehaviourAndAttitudes { get; set; }
        public int? PersonalDevelopment { get; set; }
        public int? SixthFormProvisionWhereApplicable { get; set; }
        public int? URNAtCurrentFullInspection { get; set; }
        public int? URNAtPreviousFullInspection { get; set; }
        public int? URNAtSection8Inspection { get; set; }
        public string? AdministrativeDistrict { get; set; }
        public string? RouteOfProject { get; set; }
        public string? GORregion { get; set; }
        public string? SFSOTerritory { get; set; }

        public DateTime? GiasLastChangedDate { get; set; }
        public int? NumberOfBoys { get; set; }
        public int? NumberOfGirls { get; set; }
        public string? DioceseCode { get; set; }
        public string? GORregionCode { get; set; }
        public string? ReligiousCharacterCode { get; set; }
        public string? ParliamentaryConstituencyCode { get; set; }
        public int? PhaseOfEducationCode { get; set; }
        public int? SenUnitCapacity { get; set; }
        public int? SenUnitOnRoll { get; set; }

        public LocalAuthority? LocalAuthority { get; set; }
        public EstablishmentType? EstablishmentType{ get; set; }

        public IfdPipeline? IfdPipeline { get; set; }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "gias");

            migrationBuilder.EnsureSchema(
                name: "ifd");

            migrationBuilder.CreateTable(
                name: "Establishment",
                schema: "gias",
                columns: table => new
                {
                    URN = table.Column<int>(nullable: false),
                    LAcode = table.Column<string>(name: "LA (code)", unicode: false, nullable: true),
                    LAname = table.Column<string>(name: "LA (name)", unicode: false, nullable: true),
                    EstablishmentNumber = table.Column<string>(unicode: false, nullable: true),
                    EstablishmentName = table.Column<string>(unicode: false, nullable: true),
                    TypeOfEstablishmentcode = table.Column<string>(name: "TypeOfEstablishment (code)", unicode: false, nullable: true),
                    TypeOfEstablishmentname = table.Column<string>(name: "TypeOfEstablishment (name)", unicode: false, nullable: true),
                    EstablishmentTypeGroupcode = table.Column<string>(name: "EstablishmentTypeGroup (code)", unicode: false, nullable: true),
                    EstablishmentTypeGroupname = table.Column<string>(name: "EstablishmentTypeGroup (name)", unicode: false, nullable: true),
                    EstablishmentStatuscode = table.Column<string>(name: "EstablishmentStatus (code)", unicode: false, nullable: true),
                    EstablishmentStatusname = table.Column<string>(name: "EstablishmentStatus (name)", unicode: false, nullable: true),
                    ReasonEstablishmentOpenedcode = table.Column<string>(name: "ReasonEstablishmentOpened (code)", unicode: false, nullable: true),
                    ReasonEstablishmentOpenedname = table.Column<string>(name: "ReasonEstablishmentOpened (name)", unicode: false, nullable: true),
                    OpenDate = table.Column<string>(unicode: false, nullable: true),
                    ReasonEstablishmentClosedcode = table.Column<string>(name: "ReasonEstablishmentClosed (code)", unicode: false, nullable: true),
                    ReasonEstablishmentClosedname = table.Column<string>(name: "ReasonEstablishmentClosed (name)", unicode: false, nullable: true),
                    CloseDate = table.Column<string>(unicode: false, nullable: true),
                    PhaseOfEducationcode = table.Column<string>(name: "PhaseOfEducation (code)", unicode: false, nullable: true),
                    PhaseOfEducationname = table.Column<string>(name: "PhaseOfEducation (name)", unicode: false, nullable: true),
                    StatutoryLowAge = table.Column<string>(unicode: false, nullable: true),
                    StatutoryHighAge = table.Column<string>(unicode: false, nullable: true),
                    Boarderscode = table.Column<string>(name: "Boarders (code)", unicode: false, nullable: true),
                    Boardersname = table.Column<string>(name: "Boarders (name)", unicode: false, nullable: true),
                    NurseryProvisionname = table.Column<string>(name: "NurseryProvision (name)", unicode: false, nullable: true),
                    OfficialSixthFormcode = table.Column<string>(name: "OfficialSixthForm (code)", unicode: false, nullable: true),
                    OfficialSixthFormname = table.Column<string>(name: "OfficialSixthForm (name)", unicode: false, nullable: true),
                    Gendercode = table.Column<string>(name: "Gender (code)", unicode: false, nullable: true),
                    Gendername = table.Column<string>(name: "Gender (name)", unicode: false, nullable: true),
                    ReligiousCharactercode = table.Column<string>(name: "ReligiousCharacter (code)", unicode: false, nullable: true),
                    ReligiousCharactername = table.Column<string>(name: "ReligiousCharacter (name)", unicode: false, nullable: true),
                    ReligiousEthosname = table.Column<string>(name: "ReligiousEthos (name)", unicode: false, nullable: true),
                    Diocesecode = table.Column<string>(name: "Diocese (code)", unicode: false, nullable: true),
                    Diocesename = table.Column<string>(name: "Diocese (name)", unicode: false, nullable: true),
                    AdmissionsPolicycode = table.Column<string>(name: "AdmissionsPolicy (code)", unicode: false, nullable: true),
                    AdmissionsPolicyname = table.Column<string>(name: "AdmissionsPolicy (name)", unicode: false, nullable: true),
                    SchoolCapacity = table.Column<string>(unicode: false, nullable: true),
                    SpecialClassescode = table.Column<string>(name: "SpecialClasses (code)", unicode: false, nullable: true),
                    SpecialClassesname = table.Column<string>(name: "SpecialClasses (name)", unicode: false, nullable: true),
                    CensusDate = table.Column<string>(unicode: false, nullable: true),
                    NumberOfPupils = table.Column<string>(unicode: false, nullable: true),
                    NumberOfBoys = table.Column<string>(unicode: false, nullable: true),
                    NumberOfGirls = table.Column<string>(unicode: false, nullable: true),
                    PercentageFSM = table.Column<string>(unicode: false, nullable: true),
                    TrustSchoolFlagcode = table.Column<string>(name: "TrustSchoolFlag (code)", unicode: false, nullable: true),
                    TrustSchoolFlagname = table.Column<string>(name: "TrustSchoolFlag (name)", unicode: false, nullable: true),
                    Trustscode = table.Column<string>(name: "Trusts (code)", unicode: false, nullable: true),
                    Trustsname = table.Column<string>(name: "Trusts (name)", unicode: false, nullable: true),
                    SchoolSponsorFlagname = table.Column<string>(name: "SchoolSponsorFlag (name)", unicode: false, nullable: true),
                    SchoolSponsorsname = table.Column<string>(name: "SchoolSponsors (name)", unicode: false, nullable: true),
                    FederationFlagname = table.Column<string>(name: "FederationFlag (name)", unicode: false, nullable: true),
                    Federationscode = table.Column<string>(name: "Federations (code)", unicode: false, nullable: true),
                    Federationsname = table.Column<string>(name: "Federations (name)", unicode: false, nullable: true),
                    UKPRN = table.Column<string>(unicode: false, nullable: true),
                    FEHEIdentifier = table.Column<string>(unicode: false, nullable: true),
                    FurtherEducationTypename = table.Column<string>(name: "FurtherEducationType (name)", unicode: false, nullable: true),
                    OfstedLastInsp = table.Column<string>(unicode: false, nullable: true),
                    OfstedSpecialMeasurescode = table.Column<string>(name: "OfstedSpecialMeasures (code)", unicode: false, nullable: true),
                    OfstedSpecialMeasuresname = table.Column<string>(name: "OfstedSpecialMeasures (name)", unicode: false, nullable: true),
                    LastChangedDate = table.Column<string>(unicode: false, nullable: true),
                    Street = table.Column<string>(unicode: false, nullable: true),
                    Locality = table.Column<string>(unicode: false, nullable: true),
                    Address3 = table.Column<string>(unicode: false, nullable: true),
                    Town = table.Column<string>(unicode: false, nullable: true),
                    Countyname = table.Column<string>(name: "County (name)", unicode: false, nullable: true),
                    Postcode = table.Column<string>(unicode: false, nullable: true),
                    SchoolWebsite = table.Column<string>(unicode: false, nullable: true),
                    TelephoneNum = table.Column<string>(unicode: false, nullable: true),
                    HeadTitlename = table.Column<string>(name: "HeadTitle (name)", unicode: false, nullable: true),
                    HeadFirstName = table.Column<string>(unicode: false, nullable: true),
                    HeadLastName = table.Column<string>(unicode: false, nullable: true),
                    HeadPreferredJobTitle = table.Column<string>(unicode: false, nullable: true),
                    InspectorateNamename = table.Column<string>(name: "InspectorateName (name)", unicode: false, nullable: true),
                    InspectorateReport = table.Column<string>(unicode: false, nullable: true),
                    DateOfLastInspectionVisit = table.Column<string>(unicode: false, nullable: true),
                    NextInspectionVisit = table.Column<string>(unicode: false, nullable: true),
                    TeenMothname = table.Column<string>(name: "TeenMoth (name)", unicode: false, nullable: true),
                    TeenMothPlaces = table.Column<string>(unicode: false, nullable: true),
                    CCFname = table.Column<string>(name: "CCF (name)", unicode: false, nullable: true),
                    SENPRUname = table.Column<string>(name: "SENPRU (name)", unicode: false, nullable: true),
                    EBDname = table.Column<string>(name: "EBD (name)", unicode: false, nullable: true),
                    PlacesPRU = table.Column<string>(unicode: false, nullable: true),
                    FTProvname = table.Column<string>(name: "FTProv (name)", unicode: false, nullable: true),
                    EdByOthername = table.Column<string>(name: "EdByOther (name)", unicode: false, nullable: true),
                    Section41Approvedname = table.Column<string>(name: "Section41Approved (name)", unicode: false, nullable: true),
                    SEN1name = table.Column<string>(name: "SEN1 (name)", unicode: false, nullable: true),
                    SEN2name = table.Column<string>(name: "SEN2 (name)", unicode: false, nullable: true),
                    SEN3name = table.Column<string>(name: "SEN3 (name)", unicode: false, nullable: true),
                    SEN4name = table.Column<string>(name: "SEN4 (name)", unicode: false, nullable: true),
                    SEN5name = table.Column<string>(name: "SEN5 (name)", unicode: false, nullable: true),
                    SEN6name = table.Column<string>(name: "SEN6 (name)", unicode: false, nullable: true),
                    SEN7name = table.Column<string>(name: "SEN7 (name)", unicode: false, nullable: true),
                    SEN8name = table.Column<string>(name: "SEN8 (name)", unicode: false, nullable: true),
                    SEN9name = table.Column<string>(name: "SEN9 (name)", unicode: false, nullable: true),
                    SEN10name = table.Column<string>(name: "SEN10 (name)", unicode: false, nullable: true),
                    SEN11name = table.Column<string>(name: "SEN11 (name)", unicode: false, nullable: true),
                    SEN12name = table.Column<string>(name: "SEN12 (name)", unicode: false, nullable: true),
                    SEN13name = table.Column<string>(name: "SEN13 (name)", unicode: false, nullable: true),
                    TypeOfResourcedProvisionname = table.Column<string>(name: "TypeOfResourcedProvision (name)", unicode: false, nullable: true),
                    ResourcedProvisionOnRoll = table.Column<string>(unicode: false, nullable: true),
                    ResourcedProvisionCapacity = table.Column<string>(unicode: false, nullable: true),
                    SenUnitOnRoll = table.Column<string>(unicode: false, nullable: true),
                    SenUnitCapacity = table.Column<string>(unicode: false, nullable: true),
                    GORcode = table.Column<string>(name: "GOR (code)", unicode: false, nullable: true),
                    GORname = table.Column<string>(name: "GOR (name)", unicode: false, nullable: true),
                    DistrictAdministrativecode = table.Column<string>(name: "DistrictAdministrative (code)", unicode: false, nullable: true),
                    DistrictAdministrativename = table.Column<string>(name: "DistrictAdministrative (name)", unicode: false, nullable: true),
                    AdministrativeWardcode = table.Column<string>(name: "AdministrativeWard (code)", unicode: false, nullable: true),
                    AdministrativeWardname = table.Column<string>(name: "AdministrativeWard (name)", unicode: false, nullable: true),
                    ParliamentaryConstituencycode = table.Column<string>(name: "ParliamentaryConstituency (code)", unicode: false, nullable: true),
                    ParliamentaryConstituencyname = table.Column<string>(name: "ParliamentaryConstituency (name)", unicode: false, nullable: true),
                    UrbanRuralcode = table.Column<string>(name: "UrbanRural (code)", unicode: false, nullable: true),
                    UrbanRuralname = table.Column<string>(name: "UrbanRural (name)", unicode: false, nullable: true),
                    GSSLACodename = table.Column<string>(name: "GSSLACode (name)", unicode: false, nullable: true),
                    Easting = table.Column<string>(unicode: false, nullable: true),
                    Northing = table.Column<string>(unicode: false, nullable: true),
                    CensusAreaStatisticWardname = table.Column<string>(name: "CensusAreaStatisticWard (name)", unicode: false, nullable: true),
                    MSOAname = table.Column<string>(name: "MSOA (name)", unicode: false, nullable: true),
                    LSOAname = table.Column<string>(name: "LSOA (name)", unicode: false, nullable: true),
                    SENStat = table.Column<string>(unicode: false, nullable: true),
                    SENNoStat = table.Column<string>(unicode: false, nullable: true),
                    BoardingEstablishmentname = table.Column<string>(name: "BoardingEstablishment (name)", unicode: false, nullable: true),
                    PropsName = table.Column<string>(unicode: false, nullable: true),
                    PreviousLAcode = table.Column<string>(name: "PreviousLA (code)", unicode: false, nullable: true),
                    PreviousLAname = table.Column<string>(name: "PreviousLA (name)", unicode: false, nullable: true),
                    PreviousEstablishmentNumber = table.Column<string>(unicode: false, nullable: true),
                    OfstedRatingname = table.Column<string>(name: "OfstedRating (name)", unicode: false, nullable: true),
                    RSCRegionname = table.Column<string>(name: "RSCRegion (name)", unicode: false, nullable: true),
                    Countryname = table.Column<string>(name: "Country (name)", unicode: false, nullable: true),
                    UPRN = table.Column<string>(unicode: false, nullable: true),
                    SiteName = table.Column<string>(unicode: false, nullable: true),
                    MSOAcode = table.Column<string>(name: "MSOA (code)", unicode: false, nullable: true),
                    LSOAcode = table.Column<string>(name: "LSOA (code)", unicode: false, nullable: true),
                    BSOInspectorateNamename = table.Column<string>(name: "BSOInspectorateName (name)", unicode: false, nullable: true),
                    CHNumber = table.Column<string>(unicode: false, nullable: true),
                    EstablishmentAccreditedcode = table.Column<string>(name: "EstablishmentAccredited (code)", unicode: false, nullable: true),
                    EstablishmentAccreditedname = table.Column<string>(name: "EstablishmentAccredited (name)", unicode: false, nullable: true),
                    QABNamecode = table.Column<string>(name: "QABName (code)", unicode: false, nullable: true),
                    QABNamename = table.Column<string>(name: "QABName (name)", unicode: false, nullable: true),
                    QABReport = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Establishment", x => x.URN);
                });

            migrationBuilder.CreateTable(
                name: "EstablishmentLink",
                schema: "gias",
                columns: table => new
                {
                    URN = table.Column<string>(unicode: false, nullable: true),
                    LinkURN = table.Column<string>(unicode: false, nullable: true),
                    LinkName = table.Column<string>(unicode: false, nullable: true),
                    LinkType = table.Column<string>(unicode: false, nullable: true),
                    LinkEstablishedDate = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Governance",
                schema: "gias",
                columns: table => new
                {
                    GID = table.Column<string>(unicode: false, nullable: true),
                    URN = table.Column<string>(unicode: false, nullable: true),
                    UID = table.Column<string>(unicode: false, nullable: true),
                    CompaniesHouseNumber = table.Column<string>(name: "Companies House Number", unicode: false, nullable: true),
                    Role = table.Column<string>(unicode: false, nullable: true),
                    Title = table.Column<string>(unicode: false, nullable: true),
                    Forename1 = table.Column<string>(name: "Forename 1", unicode: false, nullable: true),
                    Forename2 = table.Column<string>(name: "Forename 2", unicode: false, nullable: true),
                    Surname = table.Column<string>(unicode: false, nullable: true),
                    Dateofappointment = table.Column<string>(name: "Date of appointment", unicode: false, nullable: true),
                    Datetermofofficeendsended = table.Column<string>(name: "Date term of office ends/ended", unicode: false, nullable: true),
                    Appointingbody = table.Column<string>(name: "Appointing body", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Group",
                schema: "gias",
                columns: table => new
                {
                    GroupUID = table.Column<string>(name: "Group UID", unicode: false, nullable: false),
                    GroupID = table.Column<string>(name: "Group ID", unicode: false, nullable: true),
                    GroupName = table.Column<string>(name: "Group Name", unicode: false, nullable: true),
                    CompaniesHouseNumber = table.Column<string>(name: "Companies House Number", unicode: false, nullable: true),
                    GroupTypecode = table.Column<string>(name: "Group Type (code)", unicode: false, nullable: true),
                    GroupType = table.Column<string>(name: "Group Type", unicode: false, nullable: true),
                    ClosedDate = table.Column<string>(name: "Closed Date", unicode: false, nullable: true),
                    GroupStatuscode = table.Column<string>(name: "Group Status (code)", unicode: false, nullable: true),
                    GroupStatus = table.Column<string>(name: "Group Status", unicode: false, nullable: true),
                    GroupContactStreet = table.Column<string>(name: "Group Contact Street", unicode: false, nullable: true),
                    GroupContactLocality = table.Column<string>(name: "Group Contact Locality", unicode: false, nullable: true),
                    GroupContactAddress3 = table.Column<string>(name: "Group Contact Address 3", unicode: false, nullable: true),
                    GroupContactTown = table.Column<string>(name: "Group Contact Town", unicode: false, nullable: true),
                    GroupContactCounty = table.Column<string>(name: "Group Contact County", unicode: false, nullable: true),
                    GroupContactPostcode = table.Column<string>(name: "Group Contact Postcode", unicode: false, nullable: true),
                    HeadofGroupTitle = table.Column<string>(name: "Head of Group Title", unicode: false, nullable: true),
                    HeadofGroupFirstName = table.Column<string>(name: "Head of Group First Name", unicode: false, nullable: true),
                    HeadofGroupLastName = table.Column<string>(name: "Head of Group Last Name", unicode: false, nullable: true),
                    UKPRN = table.Column<string>(nullable: true),
                    Incorporatedonopendate = table.Column<string>(name: "Incorporated on (open date)", unicode: false, nullable: true),
                    Opendate = table.Column<string>(name: "Open date", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.GroupUID);
                });

            migrationBuilder.CreateTable(
                name: "GroupLink",
                schema: "gias",
                columns: table => new
                {
                    URN = table.Column<string>(unicode: false, nullable: true),
                    GroupUID = table.Column<string>(name: "Group UID", unicode: false, nullable: true),
                    GroupID = table.Column<string>(name: "Group ID", unicode: false, nullable: true),
                    GroupName = table.Column<string>(name: "Group Name", unicode: false, nullable: true),
                    CompaniesHouseNumber = table.Column<string>(name: "Companies House Number", unicode: false, nullable: true),
                    GroupTypecode = table.Column<string>(name: "Group Type (code)", unicode: false, nullable: true),
                    GroupType = table.Column<string>(name: "Group Type", unicode: false, nullable: true),
                    ClosedDate = table.Column<string>(name: "Closed Date", unicode: false, nullable: true),
                    GroupStatuscode = table.Column<string>(name: "Group Status (code)", unicode: false, nullable: true),
                    GroupStatus = table.Column<string>(name: "Group Status", unicode: false, nullable: true),
                    Joineddate = table.Column<string>(name: "Joined date", unicode: false, nullable: true),
                    EstablishmentName = table.Column<string>(unicode: false, nullable: true),
                    TypeOfEstablishmentcode = table.Column<string>(name: "TypeOfEstablishment (code)", unicode: false, nullable: true),
                    TypeOfEstablishmentname = table.Column<string>(name: "TypeOfEstablishment (name)", unicode: false, nullable: true),
                    PhaseOfEducationcode = table.Column<string>(name: "PhaseOfEducation (code)", unicode: false, nullable: true),
                    PhaseOfEducationname = table.Column<string>(name: "PhaseOfEducation (name)", unicode: false, nullable: true),
                    LAcode = table.Column<string>(name: "LA (code)", unicode: false, nullable: true),
                    LAname = table.Column<string>(name: "LA (name)", unicode: false, nullable: true),
                    Incorporatedonopendate = table.Column<string>(name: "Incorporated on (open date)", unicode: false, nullable: true),
                    Opendate = table.Column<string>(name: "Open date", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Sponsor",
                schema: "ifd",
                columns: table => new
                {
                    p_rid = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    RID = table.Column<string>(unicode: false, maxLength: 11, nullable: true),
                    SponsorID = table.Column<string>(unicode: false, maxLength: 7, nullable: true),
                    SponsorsSponsorid = table.Column<string>(name: "Sponsors.Sponsor id", unicode: false, maxLength: 5, nullable: true),
                    SponsorsSponsorname = table.Column<string>(name: "Sponsors.Sponsor name", unicode: false, maxLength: 100, nullable: true),
                    SponsorsPreviousoralternativename = table.Column<string>(name: "Sponsors.Previous or alternative name", unicode: false, maxLength: 100, nullable: true),
                    SponsorsCosponsororeducationalpartner = table.Column<string>(name: "Sponsors.Co-sponsor or educational partner", unicode: false, maxLength: 100, nullable: true),
                    SponsorsSponsorstatus = table.Column<string>(name: "Sponsors.Sponsor status", unicode: false, maxLength: 100, nullable: true),
                    SponsorsSponsorcoordinator = table.Column<string>(name: "Sponsors.Sponsor coordinator", unicode: false, maxLength: 100, nullable: true),
                    SponsorsLeadcontactforsponsor = table.Column<string>(name: "Sponsors.Lead contact for sponsor", unicode: false, maxLength: 100, nullable: true),
                    SponsorsLeadRSCRegion = table.Column<string>(name: "Sponsors.Lead RSC Region", unicode: false, maxLength: 100, nullable: true),
                    LeadRSCRegion = table.Column<string>(name: "Lead RSC Region", unicode: false, maxLength: 100, nullable: true),
                    SponsorsKS2MATQualityAssessment = table.Column<string>(name: "Sponsors.KS2 MAT Quality Assessment", unicode: false, maxLength: 100, nullable: true),
                    SponsorsKS4MATQualityAssessment = table.Column<string>(name: "Sponsors.KS4 MAT Quality Assessment", unicode: false, maxLength: 100, nullable: true),
                    SponsorsOtherMATQualityAssessment = table.Column<string>(name: "Sponsors.Other MAT Quality Assessment", unicode: false, maxLength: 100, nullable: true),
                    SponsorsOtherMATQualityAssessmentType = table.Column<string>(name: "Sponsors.Other MAT Quality Assessment Type", unicode: false, maxLength: 100, nullable: true),
                    SponsorsOverallcapacityfortheacademicyear = table.Column<string>(name: "Sponsors.Overall capacity for the academic year", unicode: false, maxLength: 100, nullable: true),
                    SponsorsSponsorrestriction = table.Column<string>(name: "Sponsors.Sponsor restriction", unicode: false, maxLength: 100, nullable: true),
                    SponsorsSponsorpausedexiteddate = table.Column<DateTime>(name: "Sponsors.Sponsor paused/exited date", type: "date", nullable: true),
                    SponsorsPausereviewdate = table.Column<DateTime>(name: "Sponsors.Pause review date", type: "date", nullable: true),
                    SponsorsLinktoWorkplaces = table.Column<string>(name: "Sponsors.Link to Workplaces", unicode: false, nullable: true),
                    SponsorsLoadopenacademieswiththissponsor = table.Column<bool>(name: "Sponsors.Load open academies with this sponsor", nullable: true),
                    SponsorsLoadpipelineacademiesprovisionallywiththissponsor = table.Column<bool>(name: "Sponsors.Load pipeline academies provisionally with this sponsor", nullable: true),
                    SponsorsLoadprepipelineacademiesprovisionallywiththissponsor = table.Column<bool>(name: "Sponsors.Load pre–pipeline academies provisionally with this sponsor", nullable: true),
                    SponsorsLoadopenacademiesprovisionallywiththissponsorthroughresponsoring = table.Column<bool>(name: "Sponsors.Load open academies provisionally with this sponsor through re–sponsoring", nullable: true),
                    SponsorContactDetailsContactname = table.Column<string>(name: "Sponsor Contact Details.Contact name", unicode: false, maxLength: 100, nullable: true),
                    SponsorContactDetailsContactposition = table.Column<string>(name: "Sponsor Contact Details.Contact position", unicode: false, maxLength: 100, nullable: true),
                    SponsorContactDetailsContactphone = table.Column<string>(name: "Sponsor Contact Details.Contact phone", unicode: false, maxLength: 100, nullable: true),
                    SponsorContactDetailsContactEmail = table.Column<string>(name: "Sponsor Contact Details.Contact Email", unicode: false, nullable: true),
                    SponsorContactDetailsContactaddressline1 = table.Column<string>(name: "Sponsor Contact Details.Contact address line 1", unicode: false, maxLength: 100, nullable: true),
                    SponsorContactDetailsContactaddressline2 = table.Column<string>(name: "Sponsor Contact Details.Contact address line 2", unicode: false, maxLength: 100, nullable: true),
                    SponsorContactDetailsContactaddressline3 = table.Column<string>(name: "Sponsor Contact Details.Contact address line 3", unicode: false, maxLength: 100, nullable: true),
                    SponsorContactDetailsContacttown = table.Column<string>(name: "Sponsor Contact Details.Contact town", unicode: false, maxLength: 100, nullable: true),
                    SponsorContactDetailsContactcounty = table.Column<string>(name: "Sponsor Contact Details.Contact county", unicode: false, maxLength: 100, nullable: true),
                    SponsorContactDetailsContactpostcode = table.Column<string>(name: "Sponsor Contact Details.Contact postcode", unicode: false, maxLength: 100, nullable: true),
                    SponsorContactDetailsContactLA = table.Column<string>(name: "Sponsor Contact Details.Contact LA", unicode: false, maxLength: 100, nullable: true),
                    SponsorCharacteristicsSponsortype = table.Column<string>(name: "Sponsor Characteristics.Sponsor type", unicode: false, maxLength: 100, nullable: true),
                    SponsorCharacteristicsSecondordersponsortype = table.Column<string>(name: "Sponsor Characteristics.Second order sponsor type", unicode: false, maxLength: 100, nullable: true),
                    SponsorCharacteristicsSponsorEducationalinstitutioncharacteristic = table.Column<string>(name: "Sponsor Characteristics.Sponsor Educational institution characteristic", unicode: false, maxLength: 100, nullable: true),
                    SponsorCharacteristicsSponsorexpertisePrimary = table.Column<string>(name: "Sponsor Characteristics.Sponsor expertise – Primary", unicode: false, maxLength: 100, nullable: true),
                    SponsorCharacteristicsSponsorexpertisePRU = table.Column<string>(name: "Sponsor Characteristics.Sponsor expertise - PRU", unicode: false, maxLength: 100, nullable: true),
                    SponsorCharacteristicsSponsorexpertiseSecondary = table.Column<string>(name: "Sponsor Characteristics.Sponsor expertise - Secondary", unicode: false, maxLength: 100, nullable: true),
                    SponsorCharacteristicsSponsorexpertiseSpecial = table.Column<string>(name: "Sponsor Characteristics.Sponsor expertise - Special", unicode: false, maxLength: 100, nullable: true),
                    ApprovalSponsorstatus = table.Column<string>(name: "Approval.Sponsor status", unicode: false, maxLength: 100, nullable: true),
                    ApprovalWithdrawndate = table.Column<DateTime>(name: "Approval.Withdrawn date", type: "date", nullable: true),
                    ApprovalWithdrawalledby = table.Column<string>(name: "Approval.Withdrawal led by", unicode: false, maxLength: 100, nullable: true),
                    ApprovalLastcontactdate = table.Column<DateTime>(name: "Approval.Last contact date", type: "date", nullable: true),
                    ApprovalExpressionofinterestdate = table.Column<DateTime>(name: "Approval.Expression of interest date", type: "date", nullable: true),
                    ApprovalApplicationdate = table.Column<DateTime>(name: "Approval.Application date", type: "date", nullable: true),
                    ApprovalApplicationapproveddate = table.Column<DateTime>(name: "Approval.Application approved date", type: "date", nullable: true),
                    ApprovalEFAduediligencecheckdatesent = table.Column<DateTime>(name: "Approval.EFA due diligence check date sent", type: "date", nullable: true),
                    ApprovalEFAduediligencecheckdatecompleted = table.Column<DateTime>(name: "Approval.EFA due diligence check date completed", type: "date", nullable: true),
                    ApprovalEFAduediligencecheckstatus = table.Column<string>(name: "Approval.EFA due diligence check status", unicode: false, maxLength: 100, nullable: true),
                    ApprovalEFAcomments = table.Column<string>(name: "Approval.EFA comments", unicode: false, nullable: true),
                    ApprovalDuediligencecheck = table.Column<string>(name: "Approval.Due diligence check", unicode: false, maxLength: 100, nullable: true),
                    ApprovalDuediligencecomments = table.Column<string>(name: "Approval.Due diligence comments", unicode: false, nullable: true),
                    ApprovalSponsorrecruitmenteventattendedifapplicable = table.Column<string>(name: "Approval.Sponsor recruitment event attended (if applicable)", unicode: false, maxLength: 100, nullable: true),
                    ManagementCapacityandAssessmentreviewdate = table.Column<DateTime>(name: "Management.Capacity and Assessment review date", type: "date", nullable: true),
                    ManagementCapacityandgradeassessmentcomments = table.Column<string>(name: "Management.Capacity and grade assessment comments", unicode: false, nullable: true),
                    ManagementSponsorcoordinatorcomments = table.Column<string>(name: "Management.Sponsor coordinator comments", unicode: false, nullable: true),
                    ManagementEngagementtypeEastofEnglandandNorthEastLondon = table.Column<string>(name: "Management.Engagement type East of England and North East London", unicode: false, maxLength: 100, nullable: true),
                    ManagementCapacityEastofEnglandandNorthEastLondon = table.Column<string>(name: "Management.Capacity East of England and North East London", unicode: false, maxLength: 100, nullable: true),
                    ManagementEngagementtypeSouthEastandSouthLondon = table.Column<string>(name: "Management.Engagement type South East and South London", unicode: false, maxLength: 100, nullable: true),
                    ManagementCapacitySouthEastandSouthLondon = table.Column<string>(name: "Management.Capacity South East and South London ", unicode: false, maxLength: 100, nullable: true),
                    ManagementEngagementtypeNorthWestLondonandSouthCentral = table.Column<string>(name: "Management.Engagement type North West London and South Central", unicode: false, maxLength: 100, nullable: true),
                    ManagementCapacityNorthWestLondonandSouthCentral = table.Column<string>(name: "Management.Capacity North West London and South Central", unicode: false, maxLength: 100, nullable: true),
                    ManagementEngagementtypeSouthWest = table.Column<string>(name: "Management.Engagement type South West", unicode: false, maxLength: 100, nullable: true),
                    ManagementCapacitySouthWest = table.Column<string>(name: "Management.Capacity South West", unicode: false, maxLength: 100, nullable: true),
                    ManagementEngagementtypeNorth = table.Column<string>(name: "Management.Engagement type North", unicode: false, maxLength: 100, nullable: true),
                    ManagementCapacityNorth = table.Column<string>(name: "Management.Capacity North", unicode: false, maxLength: 100, nullable: true),
                    ManagementEngagementtypeEastMidlandsandHumber = table.Column<string>(name: "Management.Engagement type East Midlands and Humber", unicode: false, maxLength: 100, nullable: true),
                    ManagementCapacityEastMidlandsandHumber = table.Column<string>(name: "Management.Capacity East Midlands and Humber", unicode: false, maxLength: 100, nullable: true),
                    ManagementEngagementtypeWestMidlands = table.Column<string>(name: "Management.Engagement type West Midlands", unicode: false, maxLength: 100, nullable: true),
                    ManagementCapacityWestMidlands = table.Column<string>(name: "Management.Capacity West Midlands", unicode: false, maxLength: 100, nullable: true),
                    ManagementEngagementtypeLancashireandWestYorkshire = table.Column<string>(name: "Management.Engagement type Lancashire and West Yorkshire", unicode: false, maxLength: 100, nullable: true),
                    ManagementCapacityLancashireandWestYorkshire = table.Column<string>(name: "Management.Capacity Lancashire and West Yorkshire", unicode: false, maxLength: 100, nullable: true),
                    ManagementSponsormeetingswithMinistersdate = table.Column<string>(name: "Management.Sponsor meetings with Ministers date", unicode: false, maxLength: 100, nullable: true),
                    ManagementSponsormeetingswithRSCdate = table.Column<string>(name: "Management.Sponsor meetings with RSC date", unicode: false, maxLength: 100, nullable: true),
                    ManagementPriorityarea = table.Column<string>(name: "Management.Priority area", unicode: false, maxLength: 100, nullable: true),
                    ManagementLocalAuthoritys = table.Column<string>(name: "Management.Local Authority(s)", unicode: false, maxLength: 1000, nullable: true),
                    Local_Authorities_Active = table.Column<string>(unicode: false, nullable: true),
                    Local_Authorities_Prospective = table.Column<string>(unicode: false, nullable: true),
                    SponsortemplateinformationSponsoroverview = table.Column<string>(name: "Sponsor template information.Sponsor overview", unicode: false, nullable: true),
                    SponsortemplateinformationKeypeople = table.Column<string>(name: "Sponsor template information.Key people", unicode: false, nullable: true),
                    SponsortemplateinformationFinance = table.Column<string>(name: "Sponsor template information.Finance", unicode: false, nullable: true),
                    SponsortemplateinformationFutureplans = table.Column<string>(name: "Sponsor template information.Future plans", unicode: false, nullable: true),
                    SponsortemplateinformationIssues = table.Column<string>(name: "Sponsor template information.Issues", unicode: false, nullable: true),
                    SponsortemplateinformationGovernanceandTrustBoardstructuresandaccountabilityframework = table.Column<string>(name: "Sponsor template information.Governance and Trust Board - structures and accountability framework", unicode: false, nullable: true),
                    SponsortemplateinformationSchoolImprovementStrategy = table.Column<string>(name: "Sponsor template information.School Improvement Strategy", unicode: false, nullable: true),
                    SponsortemplateinformationCompanynumber = table.Column<string>(name: "Sponsor template information.Company number", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Establishment",
                schema: "gias");

            migrationBuilder.DropTable(
                name: "EstablishmentLink",
                schema: "gias");

            migrationBuilder.DropTable(
                name: "Governance",
                schema: "gias");

            migrationBuilder.DropTable(
                name: "Group",
                schema: "gias");

            migrationBuilder.DropTable(
                name: "GroupLink",
                schema: "gias");

            migrationBuilder.DropTable(
                name: "Sponsor",
                schema: "ifd");
        }
    }
}

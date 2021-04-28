using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class TramsDbContext : DbContext
    {
        public TramsDbContext()
        {
        }

        public TramsDbContext(DbContextOptions<TramsDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Establishment> Establishment { get; set; }
        public virtual DbSet<EstablishmentLink> EstablishmentLink { get; set; }
        public virtual DbSet<Governance> Governance { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupLink> GroupLink { get; set; }
        public virtual DbSet<Sponsor> Sponsor { get; set; }
        public virtual DbSet<Trust> Trust { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=local_trams_test_db;persist security info=True;User id=sa; Password=StrongPassword905");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Establishment>(entity =>
            {
                entity.HasKey(e => e.Urn);

                entity.ToTable("Establishment", "gias");

                entity.Property(e => e.Urn)
                    .HasColumnName("URN")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address3).IsUnicode(false);

                entity.Property(e => e.AdministrativeWardCode)
                    .HasColumnName("AdministrativeWard (code)")
                    .IsUnicode(false);

                entity.Property(e => e.AdministrativeWardName)
                    .HasColumnName("AdministrativeWard (name)")
                    .IsUnicode(false);

                entity.Property(e => e.AdmissionsPolicyCode)
                    .HasColumnName("AdmissionsPolicy (code)")
                    .IsUnicode(false);

                entity.Property(e => e.AdmissionsPolicyName)
                    .HasColumnName("AdmissionsPolicy (name)")
                    .IsUnicode(false);

                entity.Property(e => e.BoardersCode)
                    .HasColumnName("Boarders (code)")
                    .IsUnicode(false);

                entity.Property(e => e.BoardersName)
                    .HasColumnName("Boarders (name)")
                    .IsUnicode(false);

                entity.Property(e => e.BoardingEstablishmentName)
                    .HasColumnName("BoardingEstablishment (name)")
                    .IsUnicode(false);

                entity.Property(e => e.BsoinspectorateNameName)
                    .HasColumnName("BSOInspectorateName (name)")
                    .IsUnicode(false);

                entity.Property(e => e.CcfName)
                    .HasColumnName("CCF (name)")
                    .IsUnicode(false);

                entity.Property(e => e.CensusAreaStatisticWardName)
                    .HasColumnName("CensusAreaStatisticWard (name)")
                    .IsUnicode(false);

                entity.Property(e => e.CensusDate).IsUnicode(false);

                entity.Property(e => e.Chnumber)
                    .HasColumnName("CHNumber")
                    .IsUnicode(false);

                entity.Property(e => e.CloseDate).IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasColumnName("Country (name)")
                    .IsUnicode(false);

                entity.Property(e => e.CountyName)
                    .HasColumnName("County (name)")
                    .IsUnicode(false);

                entity.Property(e => e.DateOfLastInspectionVisit).IsUnicode(false);

                entity.Property(e => e.DioceseCode)
                    .HasColumnName("Diocese (code)")
                    .IsUnicode(false);

                entity.Property(e => e.DioceseName)
                    .HasColumnName("Diocese (name)")
                    .IsUnicode(false);

                entity.Property(e => e.DistrictAdministrativeCode)
                    .HasColumnName("DistrictAdministrative (code)")
                    .IsUnicode(false);

                entity.Property(e => e.DistrictAdministrativeName)
                    .HasColumnName("DistrictAdministrative (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Easting).IsUnicode(false);

                entity.Property(e => e.EbdName)
                    .HasColumnName("EBD (name)")
                    .IsUnicode(false);

                entity.Property(e => e.EdByOtherName)
                    .HasColumnName("EdByOther (name)")
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentAccreditedCode)
                    .HasColumnName("EstablishmentAccredited (code)")
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentAccreditedName)
                    .HasColumnName("EstablishmentAccredited (name)")
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentName).IsUnicode(false);

                entity.Property(e => e.EstablishmentNumber).IsUnicode(false);

                entity.Property(e => e.EstablishmentStatusCode)
                    .HasColumnName("EstablishmentStatus (code)")
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentStatusName)
                    .HasColumnName("EstablishmentStatus (name)")
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentTypeGroupCode)
                    .HasColumnName("EstablishmentTypeGroup (code)")
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentTypeGroupName)
                    .HasColumnName("EstablishmentTypeGroup (name)")
                    .IsUnicode(false);

                entity.Property(e => e.FederationFlagName)
                    .HasColumnName("FederationFlag (name)")
                    .IsUnicode(false);

                entity.Property(e => e.FederationsCode)
                    .HasColumnName("Federations (code)")
                    .IsUnicode(false);

                entity.Property(e => e.FederationsName)
                    .HasColumnName("Federations (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Feheidentifier)
                    .HasColumnName("FEHEIdentifier")
                    .IsUnicode(false);

                entity.Property(e => e.FtprovName)
                    .HasColumnName("FTProv (name)")
                    .IsUnicode(false);

                entity.Property(e => e.FurtherEducationTypeName)
                    .HasColumnName("FurtherEducationType (name)")
                    .IsUnicode(false);

                entity.Property(e => e.GenderCode)
                    .HasColumnName("Gender (code)")
                    .IsUnicode(false);

                entity.Property(e => e.GenderName)
                    .HasColumnName("Gender (name)")
                    .IsUnicode(false);

                entity.Property(e => e.GorCode)
                    .HasColumnName("GOR (code)")
                    .IsUnicode(false);

                entity.Property(e => e.GorName)
                    .HasColumnName("GOR (name)")
                    .IsUnicode(false);

                entity.Property(e => e.GsslacodeName)
                    .HasColumnName("GSSLACode (name)")
                    .IsUnicode(false);

                entity.Property(e => e.HeadFirstName).IsUnicode(false);

                entity.Property(e => e.HeadLastName).IsUnicode(false);

                entity.Property(e => e.HeadPreferredJobTitle).IsUnicode(false);

                entity.Property(e => e.HeadTitleName)
                    .HasColumnName("HeadTitle (name)")
                    .IsUnicode(false);

                entity.Property(e => e.InspectorateNameName)
                    .HasColumnName("InspectorateName (name)")
                    .IsUnicode(false);

                entity.Property(e => e.InspectorateReport).IsUnicode(false);

                entity.Property(e => e.LaCode)
                    .HasColumnName("LA (code)")
                    .IsUnicode(false);

                entity.Property(e => e.LaName)
                    .HasColumnName("LA (name)")
                    .IsUnicode(false);

                entity.Property(e => e.LastChangedDate).IsUnicode(false);

                entity.Property(e => e.Locality).IsUnicode(false);

                entity.Property(e => e.LsoaCode)
                    .HasColumnName("LSOA (code)")
                    .IsUnicode(false);

                entity.Property(e => e.LsoaName)
                    .HasColumnName("LSOA (name)")
                    .IsUnicode(false);

                entity.Property(e => e.MsoaCode)
                    .HasColumnName("MSOA (code)")
                    .IsUnicode(false);

                entity.Property(e => e.MsoaName)
                    .HasColumnName("MSOA (name)")
                    .IsUnicode(false);

                entity.Property(e => e.NextInspectionVisit).IsUnicode(false);

                entity.Property(e => e.Northing).IsUnicode(false);

                entity.Property(e => e.NumberOfBoys).IsUnicode(false);

                entity.Property(e => e.NumberOfGirls).IsUnicode(false);

                entity.Property(e => e.NumberOfPupils).IsUnicode(false);

                entity.Property(e => e.NurseryProvisionName)
                    .HasColumnName("NurseryProvision (name)")
                    .IsUnicode(false);

                entity.Property(e => e.OfficialSixthFormCode)
                    .HasColumnName("OfficialSixthForm (code)")
                    .IsUnicode(false);

                entity.Property(e => e.OfficialSixthFormName)
                    .HasColumnName("OfficialSixthForm (name)")
                    .IsUnicode(false);

                entity.Property(e => e.OfstedLastInsp).IsUnicode(false);

                entity.Property(e => e.OfstedRatingName)
                    .HasColumnName("OfstedRating (name)")
                    .IsUnicode(false);

                entity.Property(e => e.OfstedSpecialMeasuresCode)
                    .HasColumnName("OfstedSpecialMeasures (code)")
                    .IsUnicode(false);

                entity.Property(e => e.OfstedSpecialMeasuresName)
                    .HasColumnName("OfstedSpecialMeasures (name)")
                    .IsUnicode(false);

                entity.Property(e => e.OpenDate).IsUnicode(false);

                entity.Property(e => e.ParliamentaryConstituencyCode)
                    .HasColumnName("ParliamentaryConstituency (code)")
                    .IsUnicode(false);

                entity.Property(e => e.ParliamentaryConstituencyName)
                    .HasColumnName("ParliamentaryConstituency (name)")
                    .IsUnicode(false);

                entity.Property(e => e.PercentageFsm)
                    .HasColumnName("PercentageFSM")
                    .IsUnicode(false);

                entity.Property(e => e.PhaseOfEducationCode)
                    .HasColumnName("PhaseOfEducation (code)")
                    .IsUnicode(false);

                entity.Property(e => e.PhaseOfEducationName)
                    .HasColumnName("PhaseOfEducation (name)")
                    .IsUnicode(false);

                entity.Property(e => e.PlacesPru)
                    .HasColumnName("PlacesPRU")
                    .IsUnicode(false);

                entity.Property(e => e.Postcode).IsUnicode(false);

                entity.Property(e => e.PreviousEstablishmentNumber).IsUnicode(false);

                entity.Property(e => e.PreviousLaCode)
                    .HasColumnName("PreviousLA (code)")
                    .IsUnicode(false);

                entity.Property(e => e.PreviousLaName)
                    .HasColumnName("PreviousLA (name)")
                    .IsUnicode(false);

                entity.Property(e => e.PropsName).IsUnicode(false);

                entity.Property(e => e.QabnameCode)
                    .HasColumnName("QABName (code)")
                    .IsUnicode(false);

                entity.Property(e => e.QabnameName)
                    .HasColumnName("QABName (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Qabreport)
                    .HasColumnName("QABReport")
                    .IsUnicode(false);

                entity.Property(e => e.ReasonEstablishmentClosedCode)
                    .HasColumnName("ReasonEstablishmentClosed (code)")
                    .IsUnicode(false);

                entity.Property(e => e.ReasonEstablishmentClosedName)
                    .HasColumnName("ReasonEstablishmentClosed (name)")
                    .IsUnicode(false);

                entity.Property(e => e.ReasonEstablishmentOpenedCode)
                    .HasColumnName("ReasonEstablishmentOpened (code)")
                    .IsUnicode(false);

                entity.Property(e => e.ReasonEstablishmentOpenedName)
                    .HasColumnName("ReasonEstablishmentOpened (name)")
                    .IsUnicode(false);

                entity.Property(e => e.ReligiousCharacterCode)
                    .HasColumnName("ReligiousCharacter (code)")
                    .IsUnicode(false);

                entity.Property(e => e.ReligiousCharacterName)
                    .HasColumnName("ReligiousCharacter (name)")
                    .IsUnicode(false);

                entity.Property(e => e.ReligiousEthosName)
                    .HasColumnName("ReligiousEthos (name)")
                    .IsUnicode(false);

                entity.Property(e => e.ResourcedProvisionCapacity).IsUnicode(false);

                entity.Property(e => e.ResourcedProvisionOnRoll).IsUnicode(false);

                entity.Property(e => e.RscregionName)
                    .HasColumnName("RSCRegion (name)")
                    .IsUnicode(false);

                entity.Property(e => e.SchoolCapacity).IsUnicode(false);

                entity.Property(e => e.SchoolSponsorFlagName)
                    .HasColumnName("SchoolSponsorFlag (name)")
                    .IsUnicode(false);

                entity.Property(e => e.SchoolSponsorsName)
                    .HasColumnName("SchoolSponsors (name)")
                    .IsUnicode(false);

                entity.Property(e => e.SchoolWebsite).IsUnicode(false);

                entity.Property(e => e.Section41ApprovedName)
                    .HasColumnName("Section41Approved (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen10Name)
                    .HasColumnName("SEN10 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen11Name)
                    .HasColumnName("SEN11 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen12Name)
                    .HasColumnName("SEN12 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen13Name)
                    .HasColumnName("SEN13 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen1Name)
                    .HasColumnName("SEN1 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen2Name)
                    .HasColumnName("SEN2 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen3Name)
                    .HasColumnName("SEN3 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen4Name)
                    .HasColumnName("SEN4 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen5Name)
                    .HasColumnName("SEN5 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen6Name)
                    .HasColumnName("SEN6 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen7Name)
                    .HasColumnName("SEN7 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen8Name)
                    .HasColumnName("SEN8 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Sen9Name)
                    .HasColumnName("SEN9 (name)")
                    .IsUnicode(false);

                entity.Property(e => e.SenUnitCapacity).IsUnicode(false);

                entity.Property(e => e.SenUnitOnRoll).IsUnicode(false);

                entity.Property(e => e.SennoStat)
                    .HasColumnName("SENNoStat")
                    .IsUnicode(false);

                entity.Property(e => e.SenpruName)
                    .HasColumnName("SENPRU (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Senstat)
                    .HasColumnName("SENStat")
                    .IsUnicode(false);

                entity.Property(e => e.SiteName).IsUnicode(false);

                entity.Property(e => e.SpecialClassesCode)
                    .HasColumnName("SpecialClasses (code)")
                    .IsUnicode(false);

                entity.Property(e => e.SpecialClassesName)
                    .HasColumnName("SpecialClasses (name)")
                    .IsUnicode(false);

                entity.Property(e => e.StatutoryHighAge).IsUnicode(false);

                entity.Property(e => e.StatutoryLowAge).IsUnicode(false);

                entity.Property(e => e.Street).IsUnicode(false);

                entity.Property(e => e.TeenMothName)
                    .HasColumnName("TeenMoth (name)")
                    .IsUnicode(false);

                entity.Property(e => e.TeenMothPlaces).IsUnicode(false);

                entity.Property(e => e.TelephoneNum).IsUnicode(false);

                entity.Property(e => e.Town).IsUnicode(false);

                entity.Property(e => e.TrustSchoolFlagCode)
                    .HasColumnName("TrustSchoolFlag (code)")
                    .IsUnicode(false);

                entity.Property(e => e.TrustSchoolFlagName)
                    .HasColumnName("TrustSchoolFlag (name)")
                    .IsUnicode(false);

                entity.Property(e => e.TrustsCode)
                    .HasColumnName("Trusts (code)")
                    .IsUnicode(false);

                entity.Property(e => e.TrustsName)
                    .HasColumnName("Trusts (name)")
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfEstablishmentCode)
                    .HasColumnName("TypeOfEstablishment (code)")
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfEstablishmentName)
                    .HasColumnName("TypeOfEstablishment (name)")
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfResourcedProvisionName)
                    .HasColumnName("TypeOfResourcedProvision (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Ukprn)
                    .HasColumnName("UKPRN")
                    .IsUnicode(false);

                entity.Property(e => e.Uprn)
                    .HasColumnName("UPRN")
                    .IsUnicode(false);

                entity.Property(e => e.UrbanRuralCode)
                    .HasColumnName("UrbanRural (code)")
                    .IsUnicode(false);

                entity.Property(e => e.UrbanRuralName)
                    .HasColumnName("UrbanRural (name)")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EstablishmentLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EstablishmentLink", "gias");

                entity.Property(e => e.LinkEstablishedDate).IsUnicode(false);

                entity.Property(e => e.LinkName).IsUnicode(false);

                entity.Property(e => e.LinkType).IsUnicode(false);

                entity.Property(e => e.LinkUrn)
                    .HasColumnName("LinkURN")
                    .IsUnicode(false);

                entity.Property(e => e.Urn)
                    .HasColumnName("URN")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Governance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Governance", "gias");

                entity.Property(e => e.AppointingBody)
                    .HasColumnName("Appointing body")
                    .IsUnicode(false);

                entity.Property(e => e.CompaniesHouseNumber)
                    .HasColumnName("Companies House Number")
                    .IsUnicode(false);

                entity.Property(e => e.DateOfAppointment)
                    .HasColumnName("Date of appointment")
                    .IsUnicode(false);

                entity.Property(e => e.DateTermOfOfficeEndsEnded)
                    .HasColumnName("Date term of office ends/ended")
                    .IsUnicode(false);

                entity.Property(e => e.Forename1)
                    .HasColumnName("Forename 1")
                    .IsUnicode(false);

                entity.Property(e => e.Forename2)
                    .HasColumnName("Forename 2")
                    .IsUnicode(false);

                entity.Property(e => e.Gid)
                    .HasColumnName("GID")
                    .IsUnicode(false);

                entity.Property(e => e.Role).IsUnicode(false);

                entity.Property(e => e.Surname).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .IsUnicode(false);

                entity.Property(e => e.Urn)
                    .HasColumnName("URN")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupUid);

                entity.ToTable("Group", "gias");

                entity.Property(e => e.ClosedDate)
                    .HasColumnName("Closed Date")
                    .IsUnicode(false);

                entity.Property(e => e.CompaniesHouseNumber)
                    .HasColumnName("Companies House Number")
                    .IsUnicode(false);

                entity.Property(e => e.GroupContactAddress3)
                    .HasColumnName("Group Contact Address 3")
                    .IsUnicode(false);

                entity.Property(e => e.GroupContactCounty)
                    .HasColumnName("Group Contact County")
                    .IsUnicode(false);

                entity.Property(e => e.GroupContactLocality)
                    .HasColumnName("Group Contact Locality")
                    .IsUnicode(false);

                entity.Property(e => e.GroupContactPostcode)
                    .HasColumnName("Group Contact Postcode")
                    .IsUnicode(false);

                entity.Property(e => e.GroupContactStreet)
                    .HasColumnName("Group Contact Street")
                    .IsUnicode(false);

                entity.Property(e => e.GroupContactTown)
                    .HasColumnName("Group Contact Town")
                    .IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnName("Group ID")
                    .IsUnicode(false);

                entity.Property(e => e.GroupName)
                    .HasColumnName("Group Name")
                    .IsUnicode(false);

                entity.Property(e => e.GroupStatus)
                    .HasColumnName("Group Status")
                    .IsUnicode(false);

                entity.Property(e => e.GroupStatusCode)
                    .HasColumnName("Group Status (code)")
                    .IsUnicode(false);

                entity.Property(e => e.GroupType)
                    .HasColumnName("Group Type")
                    .IsUnicode(false);

                entity.Property(e => e.GroupTypeCode)
                    .HasColumnName("Group Type (code)")
                    .IsUnicode(false);

                entity.Property(e => e.GroupUid)
                    .HasColumnName("Group UID")
                    .IsUnicode(false);

                entity.Property(e => e.HeadOfGroupFirstName)
                    .HasColumnName("Head of Group First Name")
                    .IsUnicode(false);

                entity.Property(e => e.HeadOfGroupLastName)
                    .HasColumnName("Head of Group Last Name")
                    .IsUnicode(false);

                entity.Property(e => e.HeadOfGroupTitle)
                    .HasColumnName("Head of Group Title")
                    .IsUnicode(false);

                entity.Property(e => e.IncorporatedOnOpenDate)
                    .HasColumnName("Incorporated on (open date)")
                    .IsUnicode(false);

                entity.Property(e => e.OpenDate)
                    .HasColumnName("Open date")
                    .IsUnicode(false);

                entity.Property(e => e.Ukprn).HasColumnName("UKPRN");
            });

            modelBuilder.Entity<GroupLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GroupLink", "gias");

                entity.Property(e => e.ClosedDate)
                    .HasColumnName("Closed Date")
                    .IsUnicode(false);

                entity.Property(e => e.CompaniesHouseNumber)
                    .HasColumnName("Companies House Number")
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentName).IsUnicode(false);

                entity.Property(e => e.GroupId)
                    .HasColumnName("Group ID")
                    .IsUnicode(false);

                entity.Property(e => e.GroupName)
                    .HasColumnName("Group Name")
                    .IsUnicode(false);

                entity.Property(e => e.GroupStatus)
                    .HasColumnName("Group Status")
                    .IsUnicode(false);

                entity.Property(e => e.GroupStatusCode)
                    .HasColumnName("Group Status (code)")
                    .IsUnicode(false);

                entity.Property(e => e.GroupType)
                    .HasColumnName("Group Type")
                    .IsUnicode(false);

                entity.Property(e => e.GroupTypeCode)
                    .HasColumnName("Group Type (code)")
                    .IsUnicode(false);

                entity.Property(e => e.GroupUid)
                    .HasColumnName("Group UID")
                    .IsUnicode(false);

                entity.Property(e => e.IncorporatedOnOpenDate)
                    .HasColumnName("Incorporated on (open date)")
                    .IsUnicode(false);

                entity.Property(e => e.JoinedDate)
                    .HasColumnName("Joined date")
                    .IsUnicode(false);

                entity.Property(e => e.LaCode)
                    .HasColumnName("LA (code)")
                    .IsUnicode(false);

                entity.Property(e => e.LaName)
                    .HasColumnName("LA (name)")
                    .IsUnicode(false);

                entity.Property(e => e.OpenDate)
                    .HasColumnName("Open date")
                    .IsUnicode(false);

                entity.Property(e => e.PhaseOfEducationCode)
                    .HasColumnName("PhaseOfEducation (code)")
                    .IsUnicode(false);

                entity.Property(e => e.PhaseOfEducationName)
                    .HasColumnName("PhaseOfEducation (name)")
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfEstablishmentCode)
                    .HasColumnName("TypeOfEstablishment (code)")
                    .IsUnicode(false);

                entity.Property(e => e.TypeOfEstablishmentName)
                    .HasColumnName("TypeOfEstablishment (name)")
                    .IsUnicode(false);

                entity.Property(e => e.Urn)
                    .HasColumnName("URN")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sponsor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sponsor", "ifd");

                entity.Property(e => e.ApprovalApplicationApprovedDate)
                    .HasColumnName("Approval.Application approved date")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalApplicationDate)
                    .HasColumnName("Approval.Application date")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalDueDiligenceCheck)
                    .HasColumnName("Approval.Due diligence check")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalDueDiligenceComments)
                    .HasColumnName("Approval.Due diligence comments")
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalEfaComments)
                    .HasColumnName("Approval.EFA comments")
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalEfaDueDiligenceCheckDateCompleted)
                    .HasColumnName("Approval.EFA due diligence check date completed")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalEfaDueDiligenceCheckDateSent)
                    .HasColumnName("Approval.EFA due diligence check date sent")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalEfaDueDiligenceCheckStatus)
                    .HasColumnName("Approval.EFA due diligence check status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalExpressionOfInterestDate)
                    .HasColumnName("Approval.Expression of interest date")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalLastContactDate)
                    .HasColumnName("Approval.Last contact date")
                    .HasColumnType("date");

                entity.Property(e => e.ApprovalSponsorRecruitmentEventAttendedIfApplicable)
                    .HasColumnName("Approval.Sponsor recruitment event attended (if applicable)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalSponsorStatus)
                    .HasColumnName("Approval.Sponsor status")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalWithdrawalLedBy)
                    .HasColumnName("Approval.Withdrawal led by")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalWithdrawnDate)
                    .HasColumnName("Approval.Withdrawn date")
                    .HasColumnType("date");

                entity.Property(e => e.LeadRscRegion)
                    .HasColumnName("Lead RSC Region")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LocalAuthoritiesActive)
                    .HasColumnName("Local_Authorities_Active")
                    .IsUnicode(false);

                entity.Property(e => e.LocalAuthoritiesProspective)
                    .HasColumnName("Local_Authorities_Prospective")
                    .IsUnicode(false);

                entity.Property(e => e.ManagementCapacityAndAssessmentReviewDate)
                    .HasColumnName("Management.Capacity and Assessment review date")
                    .HasColumnType("date");

                entity.Property(e => e.ManagementCapacityAndGradeAssessmentComments)
                    .HasColumnName("Management.Capacity and grade assessment comments")
                    .IsUnicode(false);

                entity.Property(e => e.ManagementCapacityEastMidlandsAndHumber)
                    .HasColumnName("Management.Capacity East Midlands and Humber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementCapacityEastOfEnglandAndNorthEastLondon)
                    .HasColumnName("Management.Capacity East of England and North East London")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementCapacityLancashireAndWestYorkshire)
                    .HasColumnName("Management.Capacity Lancashire and West Yorkshire")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementCapacityNorth)
                    .HasColumnName("Management.Capacity North")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementCapacityNorthWestLondonAndSouthCentral)
                    .HasColumnName("Management.Capacity North West London and South Central")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementCapacitySouthEastAndSouthLondon)
                    .HasColumnName("Management.Capacity South East and South London ")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementCapacitySouthWest)
                    .HasColumnName("Management.Capacity South West")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementCapacityWestMidlands)
                    .HasColumnName("Management.Capacity West Midlands")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementEngagementTypeEastMidlandsAndHumber)
                    .HasColumnName("Management.Engagement type East Midlands and Humber")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementEngagementTypeEastOfEnglandAndNorthEastLondon)
                    .HasColumnName("Management.Engagement type East of England and North East London")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementEngagementTypeLancashireAndWestYorkshire)
                    .HasColumnName("Management.Engagement type Lancashire and West Yorkshire")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementEngagementTypeNorth)
                    .HasColumnName("Management.Engagement type North")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementEngagementTypeNorthWestLondonAndSouthCentral)
                    .HasColumnName("Management.Engagement type North West London and South Central")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementEngagementTypeSouthEastAndSouthLondon)
                    .HasColumnName("Management.Engagement type South East and South London")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementEngagementTypeSouthWest)
                    .HasColumnName("Management.Engagement type South West")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementEngagementTypeWestMidlands)
                    .HasColumnName("Management.Engagement type West Midlands")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementLocalAuthorityS)
                    .HasColumnName("Management.Local Authority(s)")
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementPriorityArea)
                    .HasColumnName("Management.Priority area")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementSponsorCoordinatorComments)
                    .HasColumnName("Management.Sponsor coordinator comments")
                    .IsUnicode(false);

                entity.Property(e => e.ManagementSponsorMeetingsWithMinistersDate)
                    .HasColumnName("Management.Sponsor meetings with Ministers date")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ManagementSponsorMeetingsWithRscDate)
                    .HasColumnName("Management.Sponsor meetings with RSC date")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PRid)
                    .HasColumnName("p_rid")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Rid)
                    .HasColumnName("RID")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorCharacteristicsSecondOrderSponsorType)
                    .HasColumnName("Sponsor Characteristics.Second order sponsor type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorCharacteristicsSponsorEducationalInstitutionCharacteristic)
                    .HasColumnName("Sponsor Characteristics.Sponsor Educational institution characteristic")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorCharacteristicsSponsorExpertisePrimary)
                    .HasColumnName("Sponsor Characteristics.Sponsor expertise – Primary")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorCharacteristicsSponsorExpertisePru)
                    .HasColumnName("Sponsor Characteristics.Sponsor expertise - PRU")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorCharacteristicsSponsorExpertiseSecondary)
                    .HasColumnName("Sponsor Characteristics.Sponsor expertise - Secondary")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorCharacteristicsSponsorExpertiseSpecial)
                    .HasColumnName("Sponsor Characteristics.Sponsor expertise - Special")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorCharacteristicsSponsorType)
                    .HasColumnName("Sponsor Characteristics.Sponsor type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactAddressLine1)
                    .HasColumnName("Sponsor Contact Details.Contact address line 1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactAddressLine2)
                    .HasColumnName("Sponsor Contact Details.Contact address line 2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactAddressLine3)
                    .HasColumnName("Sponsor Contact Details.Contact address line 3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactCounty)
                    .HasColumnName("Sponsor Contact Details.Contact county")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactEmail)
                    .HasColumnName("Sponsor Contact Details.Contact Email")
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactLa)
                    .HasColumnName("Sponsor Contact Details.Contact LA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactName)
                    .HasColumnName("Sponsor Contact Details.Contact name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactPhone)
                    .HasColumnName("Sponsor Contact Details.Contact phone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactPosition)
                    .HasColumnName("Sponsor Contact Details.Contact position")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactPostcode)
                    .HasColumnName("Sponsor Contact Details.Contact postcode")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorContactDetailsContactTown)
                    .HasColumnName("Sponsor Contact Details.Contact town")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorId)
                    .HasColumnName("SponsorID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorTemplateInformationCompanyNumber)
                    .HasColumnName("Sponsor template information.Company number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorTemplateInformationFinance)
                    .HasColumnName("Sponsor template information.Finance")
                    .IsUnicode(false);

                entity.Property(e => e.SponsorTemplateInformationFuturePlans)
                    .HasColumnName("Sponsor template information.Future plans")
                    .IsUnicode(false);

                entity.Property(e => e.SponsorTemplateInformationGovernanceAndTrustBoardStructuresAndAccountabilityFramework)
                    .HasColumnName("Sponsor template information.Governance and Trust Board - structures and accountability framework")
                    .IsUnicode(false);

                entity.Property(e => e.SponsorTemplateInformationIssues)
                    .HasColumnName("Sponsor template information.Issues")
                    .IsUnicode(false);

                entity.Property(e => e.SponsorTemplateInformationKeyPeople)
                    .HasColumnName("Sponsor template information.Key people")
                    .IsUnicode(false);

                entity.Property(e => e.SponsorTemplateInformationSchoolImprovementStrategy)
                    .HasColumnName("Sponsor template information.School Improvement Strategy")
                    .IsUnicode(false);

                entity.Property(e => e.SponsorTemplateInformationSponsorOverview)
                    .HasColumnName("Sponsor template information.Sponsor overview")
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsCoSponsorOrEducationalPartner)
                    .HasColumnName("Sponsors.Co-sponsor or educational partner")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsKs2MatQualityAssessment)
                    .HasColumnName("Sponsors.KS2 MAT Quality Assessment")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsKs4MatQualityAssessment)
                    .HasColumnName("Sponsors.KS4 MAT Quality Assessment")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsLeadContactForSponsor)
                    .HasColumnName("Sponsors.Lead contact for sponsor")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsLeadRscRegion)
                    .HasColumnName("Sponsors.Lead RSC Region")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsLinkToWorkplaces)
                    .HasColumnName("Sponsors.Link to Workplaces")
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsLoadOpenAcademiesProvisionallyWithThisSponsorThroughReSponsoring).HasColumnName("Sponsors.Load open academies provisionally with this sponsor through re–sponsoring");

                entity.Property(e => e.SponsorsLoadOpenAcademiesWithThisSponsor).HasColumnName("Sponsors.Load open academies with this sponsor");

                entity.Property(e => e.SponsorsLoadPipelineAcademiesProvisionallyWithThisSponsor).HasColumnName("Sponsors.Load pipeline academies provisionally with this sponsor");

                entity.Property(e => e.SponsorsLoadPrePipelineAcademiesProvisionallyWithThisSponsor).HasColumnName("Sponsors.Load pre–pipeline academies provisionally with this sponsor");

                entity.Property(e => e.SponsorsOtherMatQualityAssessment)
                    .HasColumnName("Sponsors.Other MAT Quality Assessment")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsOtherMatQualityAssessmentType)
                    .HasColumnName("Sponsors.Other MAT Quality Assessment Type")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsOverallCapacityForTheAcademicYear)
                    .HasColumnName("Sponsors.Overall capacity for the academic year")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsPauseReviewDate)
                    .HasColumnName("Sponsors.Pause review date")
                    .HasColumnType("date");

                entity.Property(e => e.SponsorsPreviousOrAlternativeName)
                    .HasColumnName("Sponsors.Previous or alternative name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsSponsorCoordinator)
                    .HasColumnName("Sponsors.Sponsor coordinator")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsSponsorId)
                    .HasColumnName("Sponsors.Sponsor id")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsSponsorName)
                    .HasColumnName("Sponsors.Sponsor name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsSponsorPausedExitedDate)
                    .HasColumnName("Sponsors.Sponsor paused/exited date")
                    .HasColumnType("date");

                entity.Property(e => e.SponsorsSponsorRestriction)
                    .HasColumnName("Sponsors.Sponsor restriction")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SponsorsSponsorStatus)
                    .HasColumnName("Sponsors.Sponsor status")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });
            
            modelBuilder.Entity<Trust>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("Trust", "ifd");

                entity.Property(e => e.AcademiesInTrustOpen)
                    .HasColumnName("Academies_in_trust_Open")
                    .IsUnicode(false);

                entity.Property(e => e.AcademiesInTrustRebrokered)
                    .HasColumnName("Academies_in_trust_Rebrokered")
                    .IsUnicode(false);

                entity.Property(e => e.ChainId)
                    .HasColumnName("ChainID")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.LeadRscRegion)
                    .HasColumnName("Lead RSC Region")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LeadSponsor)
                    .HasColumnName("Lead Sponsor")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.MatTemplateAccountabilityFramework)
                    .HasColumnName("MAT Template.Accountability Framework")
                    .IsUnicode(false);

                entity.Property(e => e.MatTemplateFinancialAndResourceManagement)
                    .HasColumnName("MAT Template.Financial and Resource Management")
                    .IsUnicode(false);

                entity.Property(e => e.MatTemplateFuturePlans)
                    .HasColumnName("MAT Template.Future Plans")
                    .IsUnicode(false);

                entity.Property(e => e.MatTemplateGovernanceAndTrustBoard)
                    .HasColumnName("MAT Template.Governance and Trust Board")
                    .IsUnicode(false);

                entity.Property(e => e.MatTemplateIssues)
                    .HasColumnName("MAT Template.Issues")
                    .IsUnicode(false);

                entity.Property(e => e.MatTemplateMatOverview)
                    .HasColumnName("MAT Template.MAT Overview")
                    .IsUnicode(false);

                entity.Property(e => e.MatTemplateSchoolImprovementStrategy)
                    .HasColumnName("MAT Template.School Improvement Strategy")
                    .IsUnicode(false);

                entity.Property(e => e.NumberInChain).HasColumnName("Number_in_chain");

                entity.Property(e => e.NumberInTrust).HasColumnName("Number_in_trust");

                entity.Property(e => e.NumberInTrustOpen).HasColumnName("Number_in_trust_Open");

                entity.Property(e => e.NumberInTrustPipeline).HasColumnName("Number_in_trust_Pipeline");

                entity.Property(e => e.NumberInTrustPrePipeline).HasColumnName("Number_in_trust_Pre-Pipeline");

                entity.Property(e => e.NumberInTrustRebrokered).HasColumnName("Number_in_trust_Rebrokered");

                entity.Property(e => e.PRid)
                    .HasColumnName("p_rid")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Rid)
                    .HasColumnName("RID")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.SchoolsInTrustPipeline)
                    .HasColumnName("Schools_in_trust_Pipeline")
                    .IsUnicode(false);

                entity.Property(e => e.SchoolsInTrustPrePipeline)
                    .HasColumnName("Schools_in_trust_Pre-Pipeline")
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustAddressLine1)
                    .HasColumnName("Trust Contact Details.Trust address line 1")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustAddressLine2)
                    .HasColumnName("Trust Contact Details.Trust address line 2")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustAddressLine3)
                    .HasColumnName("Trust Contact Details.Trust address line 3")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustContactEmail)
                    .HasColumnName("Trust Contact Details.Trust contact email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustContactLa)
                    .HasColumnName("Trust Contact Details.Trust contact LA")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustContactName)
                    .HasColumnName("Trust Contact Details.Trust contact name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustContactPhoneNumber)
                    .HasColumnName("Trust Contact Details.Trust contact phone number")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustContactPosition)
                    .HasColumnName("Trust Contact Details.Trust contact position")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustCounty)
                    .HasColumnName("Trust Contact Details.Trust county")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustPostcode)
                    .HasColumnName("Trust Contact Details.Trust postcode")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustContactDetailsTrustTown)
                    .HasColumnName("Trust Contact Details.Trust town")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustPerformanceAndRiskDateActionPlannedFor)
                    .HasColumnName("Trust Performance and Risk.Date Action Planned For")
                    .HasColumnType("date");

                entity.Property(e => e.TrustPerformanceAndRiskDateEnteredOntoSingleList)
                    .HasColumnName("Trust Performance and Risk.Date Entered Onto Single List")
                    .HasColumnType("date");

                entity.Property(e => e.TrustPerformanceAndRiskDateOfGroupingDecision)
                    .HasColumnName("Trust Performance and Risk.Date of Grouping Decision")
                    .HasColumnType("date");

                entity.Property(e => e.TrustPerformanceAndRiskDateOfMeeting)
                    .HasColumnName("Trust Performance and Risk.Date of Meeting")
                    .HasColumnType("date");

                entity.Property(e => e.TrustPerformanceAndRiskEfficiencyIcfpReviewCompleted)
                    .HasColumnName("Trust Performance and Risk.Efficiency (& ICFP) Review Completed")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustPerformanceAndRiskEfficiencyIcfpReviewOther)
                    .HasColumnName("Trust Performance and Risk.Efficiency (& ICFP) Review Other")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustPerformanceAndRiskExternalGovernanceReviewDate)
                    .HasColumnName("Trust Performance and Risk.External Governance Review Date")
                    .HasColumnType("date");

                entity.Property(e => e.TrustPerformanceAndRiskFollowUpLetterSent)
                    .HasColumnName("Trust Performance and Risk.Follow-up letter sent")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustPerformanceAndRiskLinkToWorkplaceForEfficiencyIcfpReview)
                    .HasColumnName("Trust Performance and Risk.Link to Workplace for Efficiency (& ICFP) Review")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustPerformanceAndRiskPrioritisedForAReview)
                    .HasColumnName("Trust Performance and Risk.Prioritised for a review")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustPerformanceAndRiskSingleListGrouping)
                    .HasColumnName("Trust Performance and Risk.Single List Grouping")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustPerformanceAndRiskTrustBanding)
                    .HasColumnName("Trust Performance and Risk.Trust Banding")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustPerformanceAndRiskTrustReviewWriteUp)
                    .HasColumnName("Trust Performance and Risk.Trust Review write-up")
                    .IsUnicode(false);

                entity.Property(e => e.TrustPerformanceAndRiskWipSummaryGoesToMinister)
                    .HasColumnName("Trust Performance and Risk.WIP Summary - Goes to Minister")
                    .IsUnicode(false);

                entity.Property(e => e.TrustRef)
                    .HasColumnName("Trust Ref")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsChainId)
                    .HasColumnName("Trusts.Chain id")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsCompaniesHouseNumber)
                    .HasColumnName("Trusts.Companies House number")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsLeadRscRegion)
                    .HasColumnName("Trusts.Lead RSC Region")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsLeadSponsorId)
                    .HasColumnName("Trusts.Lead sponsor id")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsLeadSponsorName)
                    .HasColumnName("Trusts.Lead sponsor name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsLinkToWorkplace)
                    .HasColumnName("Trusts.Link to workplace")
                    .IsUnicode(false);

                entity.Property(e => e.TrustsLoadOpenAcademiesInThisTrust).HasColumnName("Trusts.Load Open academies in this trust");

                entity.Property(e => e.TrustsLoadOpenAcademiesProvisionallyWithThisTrustReBrokerage).HasColumnName("Trusts.Load open academies provisionally with this trust (Re-brokerage)");

                entity.Property(e => e.TrustsLoadPipelineProjectsInThisTrust).HasColumnName("Trusts.Load pipeline projects in this trust");

                entity.Property(e => e.TrustsTrustName)
                    .HasColumnName("Trusts.Trust name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsTrustOpenDate)
                    .HasColumnName("Trusts.Trust open date")
                    .HasColumnType("date");

                entity.Property(e => e.TrustsTrustRef)
                    .HasColumnName("Trusts.Trust ref")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsTrustSecureAccessContactEmail)
                    .HasColumnName("Trusts.Trust Secure Access Contact email")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsTrustSecureAccessContactName)
                    .HasColumnName("Trusts.Trust Secure Access Contact name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrustsTrustType)
                    .HasColumnName("Trusts.Trust type")
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

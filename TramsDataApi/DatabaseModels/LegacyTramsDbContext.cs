﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TramsDataApi.DatabaseModels
{
    public partial class LegacyTramsDbContext : DbContext
    {
        public LegacyTramsDbContext()
        {
        }

        public LegacyTramsDbContext(DbContextOptions<LegacyTramsDbContext> options)
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
        public virtual DbSet<SmartData> SmartData { get; set; }
        public virtual DbSet<SipPhonics> SipPhonics { get; set; }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<GlobalOptionSetMetadata> GlobalOptionSetMetadata { get; set; }
        public virtual DbSet<IfdPipeline> IfdPipeline { get; set; }
        public virtual DbSet<TrustMasterData> TrustMasterData { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Data Source=127.0.0.1;Initial Catalog=local_trams_test_db;persist security info=True;User id=sa; Password=StrongPassword905");
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
                entity.HasKey(e => e.Urn);

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

                entity.Property(e =>
                        e.SponsorTemplateInformationGovernanceAndTrustBoardStructuresAndAccountabilityFramework)
                    .HasColumnName(
                        "Sponsor template information.Governance and Trust Board - structures and accountability framework")
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

                entity.Property(e => e.SponsorsLoadOpenAcademiesProvisionallyWithThisSponsorThroughReSponsoring)
                    .HasColumnName(
                        "Sponsors.Load open academies provisionally with this sponsor through re–sponsoring");

                entity.Property(e => e.SponsorsLoadOpenAcademiesWithThisSponsor)
                    .HasColumnName("Sponsors.Load open academies with this sponsor");

                entity.Property(e => e.SponsorsLoadPipelineAcademiesProvisionallyWithThisSponsor)
                    .HasColumnName("Sponsors.Load pipeline academies provisionally with this sponsor");

                entity.Property(e => e.SponsorsLoadPrePipelineAcademiesProvisionallyWithThisSponsor)
                    .HasColumnName("Sponsors.Load pre–pipeline academies provisionally with this sponsor");

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
                    if (Database.IsSqlite())
                        entity.ToTable("LegacyTrust");
                    else
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

                    entity.Property(e => e.TrustsLoadOpenAcademiesInThisTrust)
                        .HasColumnName("Trusts.Load Open academies in this trust");

                    entity.Property(e => e.TrustsLoadOpenAcademiesProvisionallyWithThisTrustReBrokerage)
                        .HasColumnName("Trusts.Load open academies provisionally with this trust (Re-brokerage)");

                    entity.Property(e => e.TrustsLoadPipelineProjectsInThisTrust)
                        .HasColumnName("Trusts.Load pipeline projects in this trust");

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

            modelBuilder.Entity<SmartData>(entity =>
            {
                entity.HasKey(e => e.Urn);

                entity.ToTable("SmartData", "smart");

                entity.Property(e => e.AbsSource).HasColumnName("ABS_Source");

                entity.Property(e => e.AbsencesOverall)
                    .HasColumnName("Absences_Overall")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.AbsencesPa)
                    .HasColumnName("Absences_PA")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.AbsencesUnauthorised)
                    .HasColumnName("Absences_Unauthorised")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.DateOfLastFullOrShortInspection).HasColumnType("date");

                entity.Property(e => e.EstablishmentName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstablishmentType).HasMaxLength(50);

                entity.Property(e => e.FlagAbsencesOverallPa).HasColumnName("Flag_Absences_OverallPA");

                entity.Property(e => e.FlagAbsencesUnauthorised).HasColumnName("Flag_Absences_Unauthorised");

                entity.Property(e => e.FlagHtchangesLastYear).HasColumnName("Flag_HTChangesLastYear");

                entity.Property(e => e.FlagHtchangesTotal).HasColumnName("Flag_HTChangesTotal");

                entity.Property(e => e.FlagKs2CoastingFlag).HasColumnName("Flag_KS2_CoastingFlag");

                entity.Property(e => e.FlagKs2CombinedDisadvantagedProgress)
                    .HasColumnName("Flag_KS2_CombinedDisadvantagedProgress");

                entity.Property(e => e.FlagKs2CombinedProgress).HasColumnName("Flag_KS2_CombinedProgress");

                entity.Property(e => e.FlagKs2ExpStandardsRwm).HasColumnName("Flag_KS2_ExpStandardsRWM");

                entity.Property(e => e.FlagKs4Attainment8).HasColumnName("Flag_KS4_Attainment8");

                entity.Property(e => e.FlagKs4AvgAchieveBasics3Years).HasColumnName("Flag_KS4_AvgAchieveBasics3Years");

                entity.Property(e => e.FlagKs4CoastingFlag).HasColumnName("Flag_KS4_CoastingFlag");

                entity.Property(e => e.FlagKs4DisadvProgress8Score).HasColumnName("Flag_KS4_DisadvProgress8Score");

                entity.Property(e => e.FlagKs4Progress8Score).HasColumnName("Flag_KS4_Progress8Score");

                entity.Property(e => e.FlagOfstedEverInadequate).HasColumnName("Flag_OfstedEverInadequate");

                entity.Property(e => e.FlagOfstedLastTwoRi).HasColumnName("Flag_OfstedLastTwoRI");

                entity.Property(e => e.HtchangesLastyear).HasColumnName("HTChangesLastyear");

                entity.Property(e => e.HtchangesTotal).HasColumnName("HTChangesTotal");

                entity.Property(e => e.IsNa).HasColumnName("IsNA");

                entity.Property(e => e.IsSpecial).HasColumnName("Is_Special");

                entity.Property(e => e.Ks2CoastingFlag).HasColumnName("KS2_CoastingFlag");

                entity.Property(e => e.Ks2DisadvMaths)
                    .HasColumnName("KS2_Disadv_Maths")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks2DisadvReading)
                    .HasColumnName("KS2_Disadv_Reading")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks2DisadvWriting)
                    .HasColumnName("KS2_Disadv_Writing")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks2ExpStandardsRwm)
                    .HasColumnName("KS2_ExpStandardsRWM")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks2Maths)
                    .HasColumnName("KS2_Maths")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks2Reading)
                    .HasColumnName("KS2_Reading")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks2Source).HasColumnName("KS2_Source");

                entity.Property(e => e.Ks2Writing)
                    .HasColumnName("KS2_Writing")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks4Attainment8Score)
                    .HasColumnName("KS4_Attainment8Score")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks4AvgAchieveBasics3Years)
                    .HasColumnName("KS4_AvgAchieveBasics3Years")
                    .HasColumnType("decimal(38, 6)");

                entity.Property(e => e.Ks4CoastingFlag).HasColumnName("KS4_CoastingFlag");

                entity.Property(e => e.Ks4DisadvProgress8Score)
                    .HasColumnName("KS4_DisadvProgress8Score")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks4Progress8Score)
                    .HasColumnName("KS4_Progress8Score")
                    .HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Ks4Source).HasColumnName("KS4_Source");

                entity.Property(e => e.LaCode)
                    .HasColumnName("LA_Code")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lat).HasColumnType("decimal(9, 7)");

                entity.Property(e => e.LocalAuthority)
                    .HasColumnName("Local_Authority")
                    .HasMaxLength(40);

                entity.Property(e => e.Lon).HasColumnType("decimal(19, 17)");

                entity.Property(e => e.MostRecentPublicationDate).HasColumnType("date");

                entity.Property(e => e.OfstedSource).HasColumnName("OFSTED_Source");

                entity.Property(e => e.Phase).HasMaxLength(30);

                entity.Property(e => e.PostCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PredecessorName).HasMaxLength(100);

                entity.Property(e => e.PredecessorUrn)
                    .HasColumnName("PredecessorURN")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.PredictedChanceOfChangeOccuring)
                    .HasColumnName("Predicted chance of change occuring");

                entity.Property(e => e.PredictedChangeInProgress8Score)
                    .IsRequired()
                    .HasColumnName("Predicted change in progress 8 score")
                    .HasMaxLength(23)
                    .IsUnicode(false);

                entity.Property(e => e.ProbabilityOfDeclining).HasColumnName("Probability of declining");

                entity.Property(e => e.ProbabilityOfImproving).HasColumnName("Probability of improving");

                entity.Property(e => e.ProbabilityOfStayingTheSame).HasColumnName("Probability of staying the same");

                entity.Property(e => e.PsdFlag)
                    .HasColumnName("PSD_Flag")
                    .HasMaxLength(1)
                    .IsFixedLength();

                entity.Property(e => e.PsdSource).HasColumnName("PSD_Source");

                entity.Property(e => e.RatDefinition)
                    .HasColumnName("RAT_Definition")
                    .HasMaxLength(25);

                entity.Property(e => e.RatGrade)
                    .HasColumnName("RAT_Grade")
                    .HasMaxLength(2)
                    .IsFixedLength();

                entity.Property(e => e.RebrokerageDate).HasColumnType("date");

                entity.Property(e => e.RscRegion)
                    .HasColumnName("RSC_Region")
                    .HasMaxLength(40);

                entity.Property(e => e.RscShort)
                    .HasColumnName("RSC_Short")
                    .HasMaxLength(8);

                entity.Property(e => e.ShortInspectionPubDate).HasColumnType("date");

                entity.Property(e => e.SponsorId)
                    .HasMaxLength(7)
                    .IsFixedLength();

                entity.Property(e => e.SponsorName).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(30);

                entity.Property(e => e.TotalNumberOfRisks).HasColumnName("totalNumberOfRisks");

                entity.Property(e => e.TotalRiskScore)
                    .HasColumnName("totalRiskScore")
                    .HasColumnType("numeric(24, 1)");

                entity.Property(e => e.TrustId)
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.TrustName).HasMaxLength(100);

                entity.Property(e => e.TrustType).HasMaxLength(12);

                entity.Property(e => e.TypeGroup).HasMaxLength(30);

                entity.Property(e => e.Urn)
                    .HasColumnName("URN")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SipPhonics>(entity =>
            {
                entity.ToTable("sip_phonics", "cdm");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createdbyname)
                    .HasColumnName("createdbyname")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdbyyominame)
                    .HasColumnName("createdbyyominame")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdon)
                    .HasColumnName("createdon")
                    .HasColumnType("datetime");

                entity.Property(e => e.Createdonbehalfby).HasColumnName("createdonbehalfby");

                entity.Property(e => e.Createdonbehalfbyname)
                    .HasColumnName("createdonbehalfbyname")
                    .HasMaxLength(100);

                entity.Property(e => e.Createdonbehalfbyyominame)
                    .HasColumnName("createdonbehalfbyyominame")
                    .HasMaxLength(100);

                entity.Property(e => e.Importsequencenumber).HasColumnName("importsequencenumber");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedbyname)
                    .HasColumnName("modifiedbyname")
                    .HasMaxLength(100);

                entity.Property(e => e.Modifiedbyyominame)
                    .HasColumnName("modifiedbyyominame")
                    .HasMaxLength(100);

                entity.Property(e => e.Modifiedon)
                    .HasColumnName("modifiedon")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifiedonbehalfby).HasColumnName("modifiedonbehalfby");

                entity.Property(e => e.Modifiedonbehalfbyname)
                    .HasColumnName("modifiedonbehalfbyname")
                    .HasMaxLength(100);

                entity.Property(e => e.Modifiedonbehalfbyyominame)
                    .HasColumnName("modifiedonbehalfbyyominame")
                    .HasMaxLength(100);

                entity.Property(e => e.Overriddencreatedon)
                    .HasColumnName("overriddencreatedon")
                    .HasColumnType("datetime");

                entity.Property(e => e.Ownerid).HasColumnName("ownerid");

                entity.Property(e => e.Owneridname)
                    .HasColumnName("owneridname")
                    .HasMaxLength(100);

                entity.Property(e => e.Owneridtype)
                    .HasColumnName("owneridtype")
                    .HasMaxLength(4000);

                entity.Property(e => e.Owneridyominame)
                    .HasColumnName("owneridyominame")
                    .HasMaxLength(100);

                entity.Property(e => e.Owningbusinessunit).HasColumnName("owningbusinessunit");                

                entity.Property(e => e.Owningteam).HasColumnName("owningteam");                

                entity.Property(e => e.Owninguser).HasColumnName("owninguser");                

                entity.Property(e => e.SipEstablishment).HasColumnName("sip_establishment");                

                entity.Property(e => e.SipEstablishmentname)
                    .HasColumnName("sip_establishmentname")
                    .HasMaxLength(160);

                entity.Property(e => e.SipEstablishmentyominame)
                    .HasColumnName("sip_establishmentyominame")
                    .HasMaxLength(160);

                entity.Property(e => e.SipKs1mathspercentagepupils).HasColumnName("sip_ks1mathspercentagepupils");

                entity.Property(e => e.SipKs1mathspercentageresults).HasColumnName("sip_ks1mathspercentageresults");

                entity.Property(e => e.SipKs1readingpercentagepupils).HasColumnName("sip_ks1readingpercentagepupils");

                entity.Property(e => e.SipKs1readingpercentageresults).HasColumnName("sip_ks1readingpercentageresults");

                entity.Property(e => e.SipKs1sciencepercentagepupils).HasColumnName("sip_ks1sciencepercentagepupils");

                entity.Property(e => e.SipKs1sciencepercentageresults).HasColumnName("sip_ks1sciencepercentageresults");

                entity.Property(e => e.SipKs1writingpercentagepupils).HasColumnName("sip_ks1writingpercentagepupils");

                entity.Property(e => e.SipKs1writingpercentageresults).HasColumnName("sip_ks1writingpercentageresults");

                entity.Property(e => e.SipName)
                    .HasColumnName("sip_name")
                    .HasMaxLength(100);

                entity.Property(e => e.SipPhonicsid).HasColumnName("sip_phonicsid");

                entity.Property(e => e.SipPhonicsyear1pupils).HasColumnName("sip_phonicsyear1pupils");

                entity.Property(e => e.SipPhonicsyear1results).HasColumnName("sip_phonicsyear1results");

                entity.Property(e => e.SipPhonicsyear2pupils).HasColumnName("sip_phonicsyear2pupils");

                entity.Property(e => e.SipPhonicsyear2results).HasColumnName("sip_phonicsyear2results");

                entity.Property(e => e.SipPreviousurn)
                    .HasColumnName("sip_previousurn")
                    .HasMaxLength(100);

                entity.Property(e => e.SipUrn)
                    .HasColumnName("sip_urn")
                    .HasMaxLength(100);

                entity.Property(e => e.SipYear)
                    .HasColumnName("sip_year")
                    .HasMaxLength(100);

                entity.Property(e => e.Statecode).HasColumnName("statecode");

                entity.Property(e => e.Statuscode).HasColumnName("statuscode");

                entity.Property(e => e.Timezoneruleversionnumber).HasColumnName("timezoneruleversionnumber");

                entity.Property(e => e.Utcconversiontimezonecode).HasColumnName("utcconversiontimezonecode");

                entity.Property(e => e.Versionnumber).HasColumnName("versionnumber");
            });
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("account", "cdm");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.SipUrn)
                    .HasColumnName("sip_urn")
                    .HasMaxLength(100);

                entity.Property(e => e.SipLocalAuthorityNumber)
                    .HasColumnName("sip_localauthoritynumber");
            });
            
            modelBuilder.Entity<GlobalOptionSetMetadata>(entity =>
            {
                entity.HasKey(e => new { e.OptionSetName, e.Option, e.IsUserLocalizedLabel, e.LocalizedLabelLanguageCode })
                    .HasName("PK__GlobalOp__C1071A5B45CD0479");

                entity.ToTable("GlobalOptionSetMetadata", "cdm");

                entity.Property(e => e.OptionSetName).HasMaxLength(64);

                entity.Property(e => e.LocalizedLabel).HasMaxLength(350);
            });

            if(Database.IsSqlite())
                modelBuilder.Ignore<IfdPipeline>();
            else
                modelBuilder.Entity<IfdPipeline>(entity =>
                {
                    entity.HasKey(e => e.Sk)
                        .HasName("Sk");

                    entity.ToTable("IfdPipeline", "mstr");

                    entity.Property(e => e.ApprovalProcessAoDecisionMethod)
                        .HasColumnName("Approval Process.AO Decision Method")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ApprovalProcessAoIssuedDate)
                        .HasColumnName("Approval Process.AO Issued Date")
                        .HasColumnType("date");

                    entity.Property(e => e.ApprovalProcessApplicationDate)
                        .HasColumnName("Approval Process.Application Date")
                        .HasColumnType("date");

                    entity.Property(e => e.ApprovalProcessAppliedOrBrokered)
                        .HasColumnName("Approval Process.Applied or Brokered")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ApprovalProcessDateRscFundingAgreementApprovedInPrinciple)
                        .HasColumnName("Approval Process.Date RSC funding agreement approved in principle")
                        .HasColumnType("date");

                    entity.Property(e => e.ApprovalProcessDateRscHtbApprovalGranted)
                        .HasColumnName("Approval Process.Date RSC/HTB approval granted")
                        .HasColumnType("date");

                    entity.Property(e => e.ApprovalProcessDateSubmittedForAoDecision)
                        .HasColumnName("Approval Process.Date Submitted for AO decision")
                        .HasColumnType("date");

                    entity.Property(e => e.ApprovalProcessFundingAgreementApprovedDate)
                        .HasColumnName("Approval Process.Funding Agreement Approved Date")
                        .HasColumnType("date");

                    entity.Property(e => e.ApprovalProcessReStartApplicationDate)
                        .HasColumnName("Approval Process.Re-start application date")
                        .HasColumnType("date");

                    entity.Property(e => e.ApprovalProcessRevokedDAoDate)
                        .HasColumnName("Approval Process.Revoked dAO date")
                        .HasColumnType("date");

                    entity.Property(e => e.CaseDataAcademyContactNumber)
                        .HasColumnName("Case Data.Academy contact number")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataAcademyHeadPrincipal)
                        .HasColumnName("Case Data.Academy head/principal")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataChangeOfLeadership)
                        .HasColumnName("Case Data.Change of leadership")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataClosing)
                        .HasColumnName("Case Data.Closing")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataClosureStatus)
                        .HasColumnName("Case Data.Closure status")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataCommentsNextSteps)
                        .HasColumnName("Case Data.Comments/next steps")
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataConcernType)
                        .HasColumnName("Case Data.Concern Type")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataCurrentConfidenceTerm)
                        .HasColumnName("Case Data.Current Confidence Term")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataCurrentKs2ConfidenceMeasure)
                        .HasColumnName("Case Data.Current KS2 Confidence Measure")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataCurrentKs2Rag)
                        .HasColumnName("Case Data.Current KS2 RAG")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataCurrentKs4ConfidenceMeasure)
                        .HasColumnName("Case Data.Current KS4 Confidence Measure")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataCurrentKs4Rag)
                        .HasColumnName("Case Data.Current KS4 RAG")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataCurrentKs5Rag)
                        .HasColumnName("Case Data.Current KS5 RAG")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataDateClosureCommenced)
                        .HasColumnName("Case Data.Date closure commenced")
                        .HasColumnType("date");

                    entity.Property(e => e.CaseDataDateOfInitialContact)
                        .HasColumnName("Case Data.Date of initial contact")
                        .HasColumnType("date");

                    entity.Property(e => e.CaseDataEducationAdviserTimingOfNextVisit)
                        .HasColumnName("Case Data.Education adviser timing of next visit")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataEfaRagRating)
                        .HasColumnName("Case Data.EFA RAG rating")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataExpectedClosureDate)
                        .HasColumnName("Case Data.Expected Closure date")
                        .HasColumnType("date");

                    entity.Property(e => e.CaseDataFntlIssued)
                        .HasColumnName("Case Data.FNtl issued")
                        .HasColumnType("date");

                    entity.Property(e => e.CaseDataFntlRemoved)
                        .HasColumnName("Case Data.FNtl removed")
                        .HasColumnType("date");

                    entity.Property(e => e.CaseDataIncreasedCapacityInTrustGb)
                        .HasColumnName("Case Data.Increased capacity in Trust/GB")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataKs2BelowTheFloor)
                        .HasColumnName("Case Data.KS2 below the floor?")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataKs2CoastingAcademy)
                        .HasColumnName("Case Data.KS2 Coasting Academy?")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataKs4BelowTheFloor)
                        .HasColumnName("Case Data.KS4 below the floor?")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataKs4CoastingAcademy)
                        .HasColumnName("Case Data.KS4 Coasting Academy?")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataKs5BelowTheFloorAcademicCase)
                        .HasColumnName("Case Data.KS5 below the floor? - Academic Case")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataKs5BelowTheFloorAppliedGeneralCase)
                        .HasColumnName("Case Data.KS5 below the floor? - Applied General Case")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataLinkToWorkplaces)
                        .HasColumnName("Case Data.Link to Workplaces")
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataOtherActionTaken)
                        .HasColumnName("Case Data.Other action taken")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataPlannedAction)
                        .HasColumnName("Case Data.Planned Action")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataProjectProgress)
                        .HasColumnName("Case Data.Project progress")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataReBrokeredDateCaseData)
                        .HasColumnName("Case Data.Re-brokered date Case Data")
                        .HasColumnType("date");

                    entity.Property(e => e.CaseDataStatus)
                        .HasColumnName("Case Data.Status")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.CaseDataTrustNotice)
                        .HasColumnName("Case Data.Trust notice?")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessAcknowledgementAndFollowUpSentToSchool)
                        .HasColumnName("Delivery Process.Acknowledgement and follow-up sent to school")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessActualDateOfGbResolution)
                        .HasColumnName("Delivery Process.Actual Date of GB Resolution")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessApplicationFormReference)
                        .HasColumnName("Delivery Process.Application form reference")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessArticlesOfAssociationRelatedComments)
                        .HasColumnName("Delivery Process.Articles of Association related comments")
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessArticlesOfAssociations)
                        .HasColumnName("Delivery Process.Articles of Associations")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessArticlesOfAssociationsReceivedCleared)
                        .HasColumnName("Delivery Process.Articles of Associations received/cleared")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessBaselineDate)
                        .HasColumnName("Delivery Process.Baseline Date")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessCommentsForOfstedPreOpeningInspection)
                        .HasColumnName("Delivery Process.Comments for Ofsted Pre–opening Inspection")
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessCommercialTransferAgreement)
                        .HasColumnName("Delivery Process.Commercial Transfer Agreement")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessCommercialTransferAgreementReceivedCleared)
                        .HasColumnName("Delivery Process.Commercial Transfer Agreement received/cleared")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessCommercialTransferAgreementRelatedComments)
                        .HasColumnName("Delivery Process.Commercial Transfer Agreement related comments")
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessConsideringSoSIebStage)
                        .HasColumnName("Delivery Process.Considering SoS IEB stage")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessDateChurchFoundationConsultationReceived)
                        .HasColumnName("Delivery Process.Date Church/Foundation Consultation received")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateDAoDueDiligenceAnnexReceived)
                        .HasColumnName("Delivery Process.Date dAO Due Diligence Annex received")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateDirectionToFacilitateConversionIssuedGbOrLa)
                        .HasColumnName("Delivery Process.Date Direction to Facilitate Conversion Issued (GB or LA)")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateForDiscussionByRscHtb)
                        .HasColumnName("Delivery Process.Date for discussion by RSC/HTB")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateForDiscussionByRscHtbForAgreeingPreOpeningGrant)
                        .HasColumnName("Delivery Process.Date for Discussion by RSC/ HTB  for agreeing pre-opening grant")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateLaIebApplicationApproved)
                        .HasColumnName("Delivery Process.Date LA IEB application approved")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateLaIebApplicationReceived)
                        .HasColumnName("Delivery Process.Date LA IEB application received")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateOfInitialMeeting)
                        .HasColumnName("Delivery Process.Date of Initial Meeting")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateParentInformedBySponsor)
                        .HasColumnName("Delivery Process.Date Parent informed by Sponsor")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateSettlementAgreementApproved)
                        .HasColumnName("Delivery Process.Date settlement agreement approved")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateSoSIebIssued)
                        .HasColumnName("Delivery Process.Date SoS IEB issued")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDateSponsorMatchAgreed)
                        .HasColumnName("Delivery Process.Date Sponsor Match agreed")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessDfEEfaContribution)
                        .HasColumnName("Delivery Process.DfE/EFA contribution")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessDidSettlementExceedContractualTerms)
                        .HasColumnName("Delivery Process.Did settlement exceed contractual terms?")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessDirectionToFacilitateConversion)
                        .HasColumnName("Delivery Process.Direction to Facilitate Conversion")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessEqualityImpactAssessmentsComplete)
                        .HasColumnName("Delivery Process.Equality Impact Assessments Complete")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessExpectedDateForGb)
                        .HasColumnName("Delivery Process.Expected Date for GB")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessFundingAgreement)
                        .HasColumnName("Delivery Process.Funding Agreement")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessFundingAgreementConditionsMet)
                        .HasColumnName("Delivery Process.Funding Agreement Conditions met")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessFundingAgreementReceivedCleared)
                        .HasColumnName("Delivery Process.Funding Agreement received/cleared")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessFundingAgreementRelatedComments)
                        .HasColumnName("Delivery Process.Funding Agreement related comments")
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessGeneralComments)
                        .HasColumnName("Delivery Process.General Comments")
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessGrantPaymentProcessed)
                        .HasColumnName("Delivery Process.Grant Payment processed")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessGrantPaymentType)
                        .HasColumnName("Delivery Process.Grant Payment Type")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessLand)
                        .HasColumnName("Delivery Process.Land")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessLetterSentWithDtFActionsGbLa)
                        .HasColumnName("Delivery Process.Letter sent with DtF Actions (GB & LA)")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessLinkToWorkplaces)
                        .HasColumnName("Delivery Process.Link to Workplaces")
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessMainContactForConversion)
                        .HasColumnName("Delivery Process.Main contact for conversion")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessMainContactForConversionEmail)
                        .HasColumnName("Delivery Process.Main contact for conversion email")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessMainContactForConversionName)
                        .HasColumnName("Delivery Process.Main contact for conversion name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessMainContactForConversionPhone)
                        .HasColumnName("Delivery Process.Main contact for conversion phone")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessMainIssueForDelay)
                        .HasColumnName("Delivery Process.Main Issue for delay")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessNumberOfSettlementAgreements)
                        .HasColumnName("Delivery Process.Number of settlement agreements")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessOfDfEEfaContributionToTotalPaidToEmployees)
                        .HasColumnName("Delivery Process.% of DfE/EFA contribution to total paid to employees")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessPan)
                        .HasColumnName("Delivery Process.PAN")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessPayRun)
                        .HasColumnName("Delivery Process.Pay Run")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessPfi)
                        .HasColumnName("Delivery Process.PFI")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessRagRating)
                        .HasColumnName("Delivery Process.RAG Rating")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessReasonForNoRpa)
                        .HasColumnName("Delivery Process.Reason for no RPA")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessRiskProtectionAgreementStartDate)
                        .HasColumnName("Delivery Process.Risk protection agreement start date")
                        .HasColumnType("date");

                    entity.Property(e => e.DeliveryProcessRiskProtectionArrangements)
                        .HasColumnName("Delivery Process.Risk protection arrangements")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessRisksAssociatedToLand)
                        .HasColumnName("Delivery Process.Risks associated to land")
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessSecondaryIssueForDelay)
                        .HasColumnName("Delivery Process.Secondary Issue for delay")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessSoSImposedIeb)
                        .HasColumnName("Delivery Process.SoS imposed IEB")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessTotalAmountPaidToSchoolEmployees)
                        .HasColumnName("Delivery Process.Total amount paid to school employees")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessViabilityClosureRoute)
                        .HasColumnName("Delivery Process.Viability Closure Route")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessViabilityConcernEffectingSponsorMatch)
                        .HasColumnName("Delivery Process.Viability Concern Effecting Sponsor Match")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.DeliveryProcessWhoPaidTheEnhancement)
                        .HasColumnName("Delivery Process.Who paid the enhancement?")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaFundingBankDetailsReceived)
                        .HasColumnName("EFA Funding.Bank details received")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaFundingDraftLetterSentDate)
                        .HasColumnName("EFA Funding.Draft letter sent date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaFundingDraftLetterTargetDate)
                        .HasColumnName("EFA Funding.Draft letter target date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaFundingEfaTerritory)
                        .HasColumnName("EFA Funding.EFA territory")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaFundingEfaWelcomeLetterAndFinanceLetterSentDate)
                        .HasColumnName("EFA Funding.EFA welcome letter and finance letter sent date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaFundingExpectedPaymentDate)
                        .HasColumnName("EFA Funding.Expected payment date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaFundingFinalFundingLetterSentDate)
                        .HasColumnName("EFA Funding.Final funding letter sent date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaFundingFinalFundingLetterTargetDate)
                        .HasColumnName("EFA Funding.Final funding letter target date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaFundingNavCode)
                        .HasColumnName("EFA Funding.NAV Code")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaFundingReminderLetterSentDate)
                        .HasColumnName("EFA Funding.Reminder letter sent date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaFundingSugAvailable)
                        .HasColumnName("EFA Funding.SUG available")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaFundingUpin)
                        .HasColumnName("EFA Funding.UPIN")
                        .HasMaxLength(6)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaHandoverFundingAgreementCopyToTheTrust)
                        .HasColumnName("EFA Handover.Funding Agreement copy to the trust")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverFundingAgreementDocumentsRedactedAndSavedInWorkplaces)
                        .HasColumnName("EFA Handover.Funding Agreement documents redacted and saved in workplaces")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverFundingAgreementOnGovUk)
                        .HasColumnName("EFA Handover.Funding Agreement on Gov.UK")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverFundingAgreementToRemoteStorage)
                        .HasColumnName("EFA Handover.Funding Agreement to remote storage")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverHandoverCompleteDate)
                        .HasColumnName("EFA Handover.Handover complete date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverIssue1RequiringEfaAction)
                        .HasColumnName("EFA Handover.Issue 1 (requiring EFA action)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaHandoverIssue1ToBeAwareOf)
                        .HasColumnName("EFA Handover.Issue 1 (to be aware of)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaHandoverIssue2RequiringEfaAction)
                        .HasColumnName("EFA Handover.Issue 2 (requiring EFA action)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaHandoverIssue2ToBeAwareOf)
                        .HasColumnName("EFA Handover.Issue 2 (to be aware of)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaHandoverLiveIssueSComments)
                        .HasColumnName("EFA Handover.Live issue(s) comments")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaHandoverOtherIssueSComments)
                        .HasColumnName("EFA Handover.Other issue(s) comments")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaHandoverPdfFaSavedInWorkplace)
                        .HasColumnName("EFA Handover.PDF FA saved in workplace")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverPreOpeningCertificateReceived)
                        .HasColumnName("EFA Handover.Pre Opening certificate received")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverSacreExemptionExpiryDate)
                        .HasColumnName("EFA Handover.SACRE exemption expiry date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverSacreExemptionGiven)
                        .HasColumnName("EFA Handover.SACRE exemption given")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaHandoverSacreExemptionIssuedOn)
                        .HasColumnName("EFA Handover.SACRE exemption issued on")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverSacreExemptionRenewalAppliedFor)
                        .HasColumnName("EFA Handover.SACRE exemption renewal applied for")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.EfaHandoverSacreExemptionRenewalApproved)
                        .HasColumnName("EFA Handover.SACRE exemption renewal approved")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverSacreExemptionRenewalRejected)
                        .HasColumnName("EFA Handover.SACRE exemption renewal rejected")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverSacreNewExemptionExpiryDate)
                        .HasColumnName("EFA Handover.SACRE new exemption expiry date")
                        .HasColumnType("date");

                    entity.Property(e => e.EfaHandoverSupportGrantCertificateReceived)
                        .HasColumnName("EFA Handover.Support Grant certificate received")
                        .HasColumnType("date");

                    entity.Property(e => e.GeneralDetailsAcademyLaestab)
                        .HasColumnName("General Details.Academy LAESTAB")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsAcademyName)
                        .HasColumnName("General Details.Academy Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsAcademyStatus)
                        .HasColumnName("General Details.Academy Status")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsAcademyUkprn)
                        .HasColumnName("General Details.Academy UKPRN")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsAcademyUrn)
                        .HasColumnName("General Details.Academy URN")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsActualDateOpened)
                        .HasColumnName("General Details.Actual date opened")
                        .HasColumnType("date");

                    entity.Property(e => e.GeneralDetailsDAoProgress)
                        .HasColumnName("General Details.dAO Progress")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsDivisionalLead)
                        .HasColumnName("General Details.Divisional lead")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsExpectedOpeningDate)
                        .HasColumnName("General Details.Expected opening date")
                        .HasColumnType("date");

                    entity.Property(e => e.GeneralDetailsGrade6)
                        .HasColumnName("General Details.Grade 6")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsInterestProjectLead)
                        .HasColumnName("General Details.Interest project lead")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsInterestStatus)
                        .HasColumnName("General Details.Interest  Status")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsLaestab)
                        .HasColumnName("General Details.LAESTAB")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsLocalAuthority)
                        .HasColumnName("General Details.Local Authority")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsPhase)
                        .HasColumnName("General Details.Phase")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsProjectLead)
                        .HasColumnName("General Details.Project lead")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsProjectName)
                        .HasColumnName("General Details.Project Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsProjectStatus)
                        .HasColumnName("General Details.Project status")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsReBrokeredDate)
                        .HasColumnName("General Details.Re-brokered date")
                        .HasColumnType("date");

                    entity.Property(e => e.GeneralDetailsRecordStatus)
                        .HasColumnName("General Details.Record Status")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsRouteOfProject)
                        .HasColumnName("General Details.Route of Project")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsRscRegion)
                        .HasColumnName("General Details.RSC Region")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsStage)
                        .HasColumnName("General Details.Stage")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsTeamLeader)
                        .HasColumnName("General Details.Team leader")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.GeneralDetailsUrn)
                        .HasColumnName("General Details.URN")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.InterestComments)
                        .HasColumnName("Interest.Comments")
                        .IsUnicode(false);

                    entity.Property(e => e.InterestContactEmail)
                        .HasColumnName("Interest.Contact Email")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.InterestContactName)
                        .HasColumnName("Interest.Contact name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.InterestContactPhone)
                        .HasColumnName("Interest.Contact phone")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.InterestDateOfInterest)
                        .HasColumnName("Interest.Date of Interest")
                        .HasColumnType("date");

                    entity.Property(e => e.InterestResponseToInterestContactDate)
                        .HasColumnName("Interest.Response to interest contact date")
                        .HasColumnType("date");

                    entity.Property(e => e.Modified).HasColumnType("datetime");

                    entity.Property(e => e.ModifiedBy).HasColumnName("Modified By");

                    entity.Property(e => e.OfstedLatestOfstedSection5CategoryOfConcern)
                        .HasColumnName("Ofsted.Latest Ofsted section 5 Category of Concern")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.OfstedLatestOfstedSection5DateInCategory4)
                        .HasColumnName("Ofsted.Latest Ofsted section 5 Date in Category 4")
                        .HasColumnType("date");

                    entity.Property(e => e.OfstedLatestOfstedSection5InspectionDate)
                        .HasColumnName("Ofsted.Latest Ofsted section 5 inspection date")
                        .HasColumnType("date");

                    entity.Property(e => e.OfstedLatestOfstedSection5OverallEffectiveness)
                        .HasColumnName("Ofsted.Latest Ofsted section 5 Overall Effectiveness")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.OfstedLatestOfstedSection8InspectionDate)
                        .HasColumnName("Ofsted.Latest Ofsted section 8 inspection date")
                        .HasColumnType("date");

                    entity.Property(e => e.OfstedLatestOfstedSection8Judgement)
                        .HasColumnName("Ofsted.Latest Ofsted section 8 judgement")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.OfstedNumberOfMonthsInCategory4)
                        .HasColumnName("Ofsted.Number of months in category 4")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.PRid)
                        .HasColumnName("p_rid")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationAcademicYear)
                        .HasColumnName("Project template information.Academic year")
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationAppointmentOfKeyStaffIncludingPrincipleDesignate)
                        .HasColumnName("Project template information.Appointment of key staff, including Principle Designate")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationAy1CapacityForecast)
                        .HasColumnName("Project template information.<AY>+1 capacity forecast")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationAy1TotalPupilNumberForecast)
                        .HasColumnName("Project template information.<AY>+1 total pupil number forecast")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationAy2CapacityForecast)
                        .HasColumnName("Project template information.<AY>+2 capacity forecast")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationAy2TotalPupilNumberForecast)
                        .HasColumnName("Project template information.<AY>+2 total pupil number forecast")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationAy3CapacityForecast)
                        .HasColumnName("Project template information.<AY>+3 capacity forecast")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationAy3TotalPupilNumberForecast)
                        .HasColumnName("Project template information.<AY>+3 total pupil number forecast")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationCapitalDeficitReasonsAndRemedialAction)
                        .HasColumnName("Project template information.Capital deficit reasons and remedial action")
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationCommunicationsAndMarketingSupport)
                        .HasColumnName("Project template information.Communications and marketing support")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationConsultationServices)
                        .HasColumnName("Project template information.Consultation services")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationDeficit)
                        .HasColumnName("Project template information.Deficit?")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationEducationAdviceDevelopmentOfEducationalPlanCurriculumStaffingStructureAndPolicies)
                        .HasColumnName("Project template information.Education advice & development of educational plan, curriculum, staffing structure and policies")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationEigRationale)
                        .HasColumnName("Project template information.EIG rationale")
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFinancialInformationSystems)
                        .HasColumnName("Project template information.Financial information systems")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFinancialManagementAndAdvice)
                        .HasColumnName("Project template information.Financial management and advice")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFinancialYear)
                        .HasColumnName("Project template information.Financial year")
                        .HasMaxLength(4)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy1RevenueBalanceBroughtForward)
                        .HasColumnName("Project template information.<FY>+1 Revenue balance brought forward")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy1RevenueBalanceCarriedForward)
                        .HasColumnName("Project template information.<FY>+1 Revenue balance carried forward")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy1RevenueBalanceInYear)
                        .HasColumnName("Project template information.<FY>+1 Revenue balance in year")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy1RevenueGrossExpenditure)
                        .HasColumnName("Project template information.<FY>+1 Revenue gross expenditure ")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy1TotalAllocationAndIncome)
                        .HasColumnName("Project template information.<FY>+1 Total allocation and income")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy2RevenueBalanceBroughtForward)
                        .HasColumnName("Project template information.<FY>+2 Revenue balance brought forward")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy2RevenueBalanceCarriedForward)
                        .HasColumnName("Project template information.<FY>+2 Revenue balance carried forward")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy2RevenueBalanceInYear)
                        .HasColumnName("Project template information.<FY>+2 Revenue balance in year")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy2RevenueGrossExpenditure)
                        .HasColumnName("Project template information.<FY>+2 Revenue gross expenditure ")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFy2TotalAllocationAndIncome)
                        .HasColumnName("Project template information.<FY>+2 Total allocation and income")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFyRevenueBalanceBroughtForward)
                        .HasColumnName("Project template information.<FY> Revenue balance brought forward")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFyRevenueBalanceCarriedForward)
                        .HasColumnName("Project template information.<FY> Revenue balance carried forward")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFyRevenueBalanceInYear)
                        .HasColumnName("Project template information.<FY> Revenue balance in year")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFyRevenueGrossExpenditure)
                        .HasColumnName("Project template information.<FY> Revenue gross expenditure ")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationFyTotalAllocationAndIncome)
                        .HasColumnName("Project template information.<FY> Total allocation and income")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationHrAndRecruitmentServicesInclTupe)
                        .HasColumnName("Project template information.HR and recruitment services (incl. TUPE)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationLegalServices)
                        .HasColumnName("Project template information.Legal services")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationOtherEGIctSystemsProjectContingencyAllocation)
                        .HasColumnName("Project template information.Other (e.g. ICT systems, project contingency allocation)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationProjectManagementForecast)
                        .HasColumnName("Project template information.Project management forecast (£)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationProjectedCapitalBalanceAtYearEnd)
                        .HasColumnName("Project template information.Projected capital balance at year end")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationProjectedRevenueBalanceAtYearEnd)
                        .HasColumnName("Project template information.Projected revenue balance at year end")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationRationaleForProject)
                        .HasColumnName("Project template information.Rationale for project")
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationRationaleForSponsor)
                        .HasColumnName("Project template information.Rationale for sponsor")
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationRelevantDistance)
                        .HasColumnName("Project template information.Relevant distance")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationRevenueDeficitReasonsAndRemedialAction)
                        .HasColumnName("Project template information.Revenue deficit reasons and remedial action")
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationRisksAndIssues)
                        .HasColumnName("Project template information.Risks and issues")
                        .IsUnicode(false);

                    entity.Property(e => e.ProjectTemplateInformationViabilityIssue)
                        .HasColumnName("Project template information.Viability issue?")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyLeadFinanceEmail)
                        .HasColumnName("Proposed Academy Details.Academy Lead Finance Email")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyLeadFinanceName)
                        .HasColumnName("Proposed Academy Details.Academy Lead Finance Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyLeadFinancePhone)
                        .HasColumnName("Proposed Academy Details.Academy Lead Finance Phone")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactAddressLine1)
                        .HasColumnName("Proposed Academy Details.Academy Main Contact Address Line 1")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactAddressLine2)
                        .HasColumnName("Proposed Academy Details.Academy Main Contact Address Line 2")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactAddressLine3)
                        .HasColumnName("Proposed Academy Details.Academy Main Contact Address Line 3")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactCounty)
                        .HasColumnName("Proposed Academy Details.Academy Main Contact County")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactEmail)
                        .HasColumnName("Proposed Academy Details.Academy Main Contact Email")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactName)
                        .HasColumnName("Proposed Academy Details.Academy main contact name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactPhone)
                        .HasColumnName("Proposed Academy Details.Academy Main Contact Phone")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactPostcode)
                        .HasColumnName("Proposed Academy Details.Academy Main Contact Postcode")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactRole)
                        .HasColumnName("Proposed Academy Details.Academy Main Contact Role")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyMainContactTown)
                        .HasColumnName("Proposed Academy Details.Academy Main Contact Town")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyPhaseProposed)
                        .HasColumnName("Proposed Academy Details.Academy Phase Proposed")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyProposedCapacityPost16)
                        .HasColumnName("Proposed Academy Details.Academy Proposed Capacity - Post 16")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyProposedCapacityPrimaryRYr6)
                        .HasColumnName("Proposed Academy Details.Academy Proposed Capacity - Primary (R-Yr6)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademyProposedCapacitySecondaryYr7Yr11)
                        .HasColumnName("Proposed Academy Details.Academy Proposed Capacity - Secondary (Yr7 - Yr11)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademySecureAccessContactEmail)
                        .HasColumnName("Proposed Academy Details.Academy Secure Access Contact email")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsAcademySecureAccessContactName)
                        .HasColumnName("Proposed Academy Details.Academy Secure Access Contact name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsGagFundingPupilNumbersType)
                        .HasColumnName("Proposed Academy Details.GAG Funding Pupil Numbers Type")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsMatFaClauses3A3FOption1ConvSpons)
                        .HasColumnName("Proposed Academy Details.MAT FA Clauses 3.A - 3.F Option 1(Conv & Spons)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsMatFaClauses3A3FOption2FsNewProv)
                        .HasColumnName("Proposed Academy Details.MAT FA Clauses 3.A - 3.F Option 2(FS & New Prov)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsMatFaClauses3HIfApplicableNotConv)
                        .HasColumnName("Proposed Academy Details.MAT FA Clauses 3.H (if applicable & not Conv)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsNewAcademyName)
                        .HasColumnName("Proposed Academy Details.New Academy Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsNewAcademyUrn)
                        .HasColumnName("Proposed Academy Details.New Academy URN")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsPost16)
                        .HasColumnName("Proposed Academy Details.Post 16")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsSatFaClause323IfApplicableNotConv)
                        .HasColumnName("Proposed Academy Details.SAT FA Clause 3.23 (if applicable & not Conv)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsSatFaClauses316321Option1ConvSpons)
                        .HasColumnName("Proposed Academy Details.SAT FA Clauses 3.16-3.21 Option 1 (Conv & Spons)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.ProposedAcademyDetailsSatFaClauses316321Option2FsNewProv)
                        .HasColumnName("Proposed Academy Details.SAT FA Clauses 3.16-3.21 Option 2 (FS & New Prov)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.Rid)
                        .HasColumnName("RID")
                        .HasMaxLength(11)
                        .IsUnicode(false);

                    //entity.Property(e => e.Sk).HasColumnName("SK");

                    entity.Property(e => e.TrustSponsorManagementCoSponsor1)
                        .HasColumnName("Trust & Sponsor Management.Co-sponsor 1")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementCoSponsor1SponsorName)
                        .HasColumnName("Trust & Sponsor Management.Co-sponsor 1 Sponsor Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementCoSponsor2)
                        .HasColumnName("Trust & Sponsor Management.Co-sponsor 2")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementCoSponsor2SponsorName)
                        .HasColumnName("Trust & Sponsor Management.Co-sponsor 2 Sponsor Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementCoSponsor3)
                        .HasColumnName("Trust & Sponsor Management.Co-sponsor 3")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementCoSponsor3SponsorName)
                        .HasColumnName("Trust & Sponsor Management.Co-sponsor 3 Sponsor Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementPreviousSponsorId)
                        .HasColumnName("Trust & Sponsor Management.Previous sponsor id")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementPreviousSponsorName)
                        .HasColumnName("Trust & Sponsor Management.Previous sponsor name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementPreviousTrust)
                        .HasColumnName("Trust & Sponsor Management.Previous Trust")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementPreviousTrustName)
                        .HasColumnName("Trust & Sponsor Management.Previous Trust name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementSponsor1NameProvisional)
                        .HasColumnName("Trust & Sponsor Management.Sponsor 1 Name (Provisional)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementSponsor1Provisional)
                        .HasColumnName("Trust & Sponsor Management.Sponsor 1 (Provisional)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementSponsor2NameProvisional)
                        .HasColumnName("Trust & Sponsor Management.Sponsor 2 Name (Provisional)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementSponsor2Provisional)
                        .HasColumnName("Trust & Sponsor Management.Sponsor 2 (Provisional)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementSponsor3NameProvisional)
                        .HasColumnName("Trust & Sponsor Management.Sponsor 3 Name (Provisional)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementSponsor3Provisional)
                        .HasColumnName("Trust & Sponsor Management.Sponsor 3 (Provisional)")
                        .HasMaxLength(5)
                        .IsUnicode(false);

                    entity.Property(e => e.TrustSponsorManagementTrust)
                        .HasColumnName("Trust & Sponsor Management.Trust")
                        .HasMaxLength(100)
                        .IsUnicode(false);
                });

            if(Database.IsSqlite())
                modelBuilder.Ignore<TrustMasterData>();
            else
                modelBuilder.Entity<TrustMasterData>(entity =>
                {
                    entity.HasKey(e => e.SK).HasName("SK");

                    entity.ToTable("Trust", "mstr");

                    entity.Property(e => e.TrustsTrustType).HasColumnName("FK_TrustType");
                    entity.Property(e => e.Region).HasColumnName("FK_Region");
                    entity.Property(e => e.TrustBanding).HasColumnName("FK_TrustBanding");
                    entity.Property(e => e.FK_TrustStatus).HasColumnName("FK_TrustStatus");
                    entity.Property(e => e.GroupUID).HasColumnName("Group UID").IsRequired();
                    entity.Property(e => e.GroupID).HasColumnName("Group ID");
                    entity.Property(e => e.RID).HasColumnName("RID");
                    entity.Property(e => e.Name).HasColumnName("Name").IsRequired();
                    entity.Property(e => e.CompaniesHouseNumber).HasColumnName("Companies House Number");
                    entity.Property(e => e.ClosedDate).HasColumnName("Closed Date");
                    entity.Property(e => e.TrustStatus).HasColumnName("Trust Status");
                    entity.Property(e => e.JoinedDate).HasColumnName("Joined Date");
                    entity.Property(e => e.MainPhone).HasColumnName("Main Phone");
                    entity.Property(e => e.AddressLine1).HasColumnName("Address Line1");
                    entity.Property(e => e.AddressLine2).HasColumnName("Address Line2");
                    entity.Property(e => e.AddressLine3).HasColumnName("Address Line3");
                    entity.Property(e => e.Town).HasColumnName("Town");
                    entity.Property(e => e.County).HasColumnName("County");
                    entity.Property(e => e.Postcode).HasColumnName("Postcode");
                    entity.Property(e => e.PrioritisedForReview).HasColumnName("Prioritised for Review");
                    entity.Property(e => e.CurrentSingleListGrouping).HasColumnName("Current Single List Grouping");
                    entity.Property(e => e.DateOfGroupingDecision).HasColumnName("Date of Grouping Decision");
                    entity.Property(e => e.DateEnteredOntoSingleList).HasColumnName("Date Entered Onto Single List");
                    entity.Property(e => e.TrustReviewWriteUp).HasColumnName("Trust Review Write Up");
                    entity.Property(e => e.DateOfTrustReviewMeeting).HasColumnName("Date of Trust Review Meeting");
                    entity.Property(e => e.FollowUpLetterSent).HasColumnName("Follow Up Letter Sent");
                    entity.Property(e => e.DateActionPlannedFor).HasColumnName("Date Action Planned For");
                    entity.Property(e => e.WIPSummaryGoesToMinister).HasColumnName("WIP Summary Goes To Minister");
                    entity.Property(e => e.ExternalGovernanceReviewDate).HasColumnName("External Governance Review Date");
                    entity.Property(e => e.EfficiencyICFPReviewCompleted).HasColumnName("Efficiency ICFP Review Completed");
                    entity.Property(e => e.EfficiencyICFPReviewOther).HasColumnName("Efficiency ICFP Review Other");
                    entity.Property(e => e.LinkToWorkplaceForEfficiencyICFPReview).HasColumnName("Link To Workplace For Efficiency ICFP Review");
                    entity.Property(e => e.NumberInTrust).HasColumnName("Number In Trust");
                    entity.Property(e => e.Modified).HasColumnName("Modified");
                    entity.Property(e => e.ModifiedBy).HasColumnName("Modified By");
                    entity.Property(e => e.AMSDTerritory).HasColumnName("AMSD Territory");
                    entity.Property(e => e.LeadAMSDTerritory).HasColumnName("Lead AMSD Territory");
                    entity.Property(e => e.UKPRN).HasColumnName("UKPRN");
                    entity.Property(e => e.TrustPerformanceAndRiskDateOfMeeting).HasColumnName("Trust Performance And Risk Date Of Meeting");
                    entity.Property(e => e.UPIN).HasColumnName("UPIN");
                    entity.Property(e => e.IncorporatedOnOpenDate).HasColumnName("Incorporated on (open date)");
                });
            
            if (!Database.IsSqlite())
                modelBuilder.HasSequence<int>("AcademyTransferProjectUrns")
                    .StartsAt(10000000)
                    .HasMin(10000000);
            
            OnModelCreatingEducationPerformancedata(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
            OnModelCreatingViewAcademyConversions(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
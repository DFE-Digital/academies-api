using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TramsDataApi.DatabaseModels
{
    public partial class MyContext : DbContext
    {
        public MyContext()
        {
        }

        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MisEstablishments> MisEstablishments { get; set; }
        public virtual DbSet<FurtherEducationEstablishments> FurtherEducationEstablishments { get; set; }
        public virtual DbSet<SmartData> SmartData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=127.0.0.1;Initial Catalog=local_trams_db;persist security info=True;User id=sa; Password=StrongPassword905");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MisEstablishments>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Establishments", "mis");

                entity.Property(e => e.AdmissionsPolicy).HasColumnName("Admissions policy");

                entity.Property(e => e.BehaviourAndAttitudes).HasColumnName("Behaviour and attitudes");

                entity.Property(e => e.CategoryOfConcern).HasColumnName("Category of concern");

                entity.Property(e => e.DateOfLatestSection8Inspection).HasColumnName("Date of latest section 8 inspection");

                entity.Property(e => e.DesignatedReligiousCharacter).HasColumnName("Designated religious character");

                entity.Property(e => e.DidTheLatestSection8InspectionConvertToAFullInspection).HasColumnName("Did the latest section 8 inspection convert to a full inspection?");

                entity.Property(e => e.DoesTheLatestFullInspectionRelateToTheUrnOfTheCurrentSchool).HasColumnName("Does the latest full inspection relate to the URN of the current school?");

                entity.Property(e => e.DoesThePreviousFullInspectionRelateToTheUrnOfTheCurrentSchool).HasColumnName("Does the previous full inspection relate to the URN of the current school?");

                entity.Property(e => e.DoesTheSection8InspectionRelateToTheUrnOfTheCurrentSchool).HasColumnName("Does the section 8 inspection relate to the URN of the current school?");

                entity.Property(e => e.EarlyYearsProvisionWhereApplicable).HasColumnName("Early years provision (where applicable)");

                entity.Property(e => e.EffectivenessOfLeadershipAndManagement).HasColumnName("Effectiveness of leadership and management");

                entity.Property(e => e.EventTypeGrouping).HasColumnName("Event type grouping");

                entity.Property(e => e.FaithGrouping).HasColumnName("Faith grouping");

                entity.Property(e => e.InspectionEndDate).HasColumnName("Inspection end date");

                entity.Property(e => e.InspectionNumberOfLatestFullInspection).HasColumnName("Inspection number of latest full inspection");

                entity.Property(e => e.InspectionStartDate).HasColumnName("Inspection start date");

                entity.Property(e => e.InspectionType).HasColumnName("Inspection type");

                entity.Property(e => e.InspectionTypeGrouping).HasColumnName("Inspection type grouping");

                entity.Property(e => e.Laestab).HasColumnName("LAESTAB");

                entity.Property(e => e.LaestabAtTimeOfLatestFullInspection).HasColumnName("LAESTAB at time of latest full inspection");

                entity.Property(e => e.LaestabAtTimeOfPreviousFullInspection).HasColumnName("LAESTAB at time of previous full inspection");

                entity.Property(e => e.LaestabAtTimeOfTheSection8Inspection).HasColumnName("LAESTAB at time of the section 8 inspection");

                entity.Property(e => e.LatestSection8InspectionNumberSinceLastFullInspection).HasColumnName("Latest section 8 inspection number since last full inspection");

                entity.Property(e => e.LocalAuthority).HasColumnName("Local authority");

                entity.Property(e => e.NumberOfOtherSection8InspectionsSinceLastFullInspection).HasColumnName("Number of other section 8 inspections since last full inspection");

                entity.Property(e => e.NumberOfSection8InspectionsSinceTheLastFullInspection).HasColumnName("Number of section 8 inspections since the last full inspection");

                entity.Property(e => e.OfstedPhase).HasColumnName("Ofsted phase");

                entity.Property(e => e.OfstedRegion).HasColumnName("Ofsted region");

                entity.Property(e => e.OverallEffectiveness).HasColumnName("Overall effectiveness");

                entity.Property(e => e.ParliamentaryConstituency).HasColumnName("Parliamentary constituency");

                entity.Property(e => e.PersonalDevelopment).HasColumnName("Personal development");

                entity.Property(e => e.PreviousBehaviourAndAttitudes).HasColumnName("Previous behaviour and attitudes");

                entity.Property(e => e.PreviousCategoryOfConcern).HasColumnName("Previous category of concern");

                entity.Property(e => e.PreviousEarlyYearsProvisionWhereApplicable).HasColumnName("Previous early years provision (where applicable)");

                entity.Property(e => e.PreviousEffectivenessOfLeadershipAndManagement).HasColumnName("Previous effectiveness of leadership and management");

                entity.Property(e => e.PreviousFullInspectionNumber).HasColumnName("Previous full inspection number");

                entity.Property(e => e.PreviousFullInspectionOverallEffectiveness).HasColumnName("Previous full inspection overall effectiveness");

                entity.Property(e => e.PreviousInspectionEndDate).HasColumnName("Previous inspection end date");

                entity.Property(e => e.PreviousInspectionStartDate).HasColumnName("Previous inspection start date");

                entity.Property(e => e.PreviousPersonalDevelopment).HasColumnName("Previous personal development");

                entity.Property(e => e.PreviousPublicationDate).HasColumnName("Previous publication date");

                entity.Property(e => e.PreviousQualityOfEducation).HasColumnName("Previous quality of education");

                entity.Property(e => e.PreviousSafeguardingIsEffective).HasColumnName("Previous safeguarding is effective?");

                entity.Property(e => e.PreviousSixthFormProvisionWhereApplicable).HasColumnName("Previous sixth form provision (where applicable)");

                entity.Property(e => e.PublicationDate).HasColumnName("Publication date");

                entity.Property(e => e.QualityOfEducation).HasColumnName("Quality of education");

                entity.Property(e => e.ReligiousEthos).HasColumnName("Religious ethos");

                entity.Property(e => e.SafeguardingIsEffective).HasColumnName("Safeguarding is effective?");

                entity.Property(e => e.SchoolName).HasColumnName("School name");

                entity.Property(e => e.SchoolNameAtTimeOfLatestFullInspection).HasColumnName("School name at time of latest full inspection");

                entity.Property(e => e.SchoolNameAtTimeOfPreviousFullInspection).HasColumnName("School name at time of previous full inspection");

                entity.Property(e => e.SchoolNameAtTimeOfTheLatestSection8Inspection).HasColumnName("School name at time of the latest section 8 inspection");

                entity.Property(e => e.SchoolOpenDate).HasColumnName("School open date");

                entity.Property(e => e.SchoolTypeAtTimeOfLatestFullInspection).HasColumnName("School type at time of latest full inspection");

                entity.Property(e => e.SchoolTypeAtTimeOfPreviousFullInspection).HasColumnName("School type at time of previous full inspection");

                entity.Property(e => e.SchoolTypeAtTimeOfTheLatestSection8Inspection).HasColumnName("School type at time of the latest section 8 inspection");

                entity.Property(e => e.Section8InspectionOverallOutcome).HasColumnName("Section 8 inspection overall outcome");

                entity.Property(e => e.Section8InspectionPublicationDate).HasColumnName("Section 8 inspection publication date");

                entity.Property(e => e.SixthForm).HasColumnName("Sixth form");

                entity.Property(e => e.SixthFormProvisionWhereApplicable).HasColumnName("Sixth form provision (where applicable)");

                entity.Property(e => e.TheIncomeDeprivationAffectingChildrenIndexIdaciQuintile).HasColumnName("The income deprivation affecting children index (IDACI) quintile");

                entity.Property(e => e.TotalNumberOfPupils).HasColumnName("Total number of pupils");

                entity.Property(e => e.TypeOfEducation).HasColumnName("Type of education");

                entity.Property(e => e.Urn).HasColumnName("URN");

                entity.Property(e => e.UrnAtTimeOfLatestFullInspection).HasColumnName("URN at time of latest full inspection");

                entity.Property(e => e.UrnAtTimeOfPreviousFullInspection).HasColumnName("URN at time of previous full inspection");

                entity.Property(e => e.UrnAtTimeOfTheSection8Inspection).HasColumnName("URN at time of the section 8 inspection");

                entity.Property(e => e.WebLink).HasColumnName("Web link");
            });

            modelBuilder.Entity<FurtherEducationEstablishments>(entity =>
            {
                entity.HasKey(e => e.ProviderUrn)
                    .HasName("PK_ManagementInformationFurtherEducationSchoolTableData");

                entity.ToTable("FurtherEducationEstablishments", "mis");

                entity.Property(e => e.ProviderUrn)
                    .HasColumnName("Provider URN")
                    .ValueGeneratedNever();

                entity.Property(e => e.BehaviourAndAttitudes).HasColumnName("Behaviour and attitudes");

                entity.Property(e => e.BehaviourAndAttitudesRaw).HasColumnName("Behaviour and attitudes RAW");

                entity.Property(e => e.DateOfLatestShortInspection).HasColumnName("Date of latest short inspection");

                entity.Property(e => e.DatePublished).HasColumnName("Date published");

                entity.Property(e => e.EffectivenessOfLeadershipAndManagement).HasColumnName("Effectiveness of leadership and management");

                entity.Property(e => e.EffectivenessOfLeadershipAndManagementRaw).HasColumnName("Effectiveness of leadership and management RAW");

                entity.Property(e => e.FirstDayOfInspection).HasColumnName("First day of inspection");

                entity.Property(e => e.ImprovedDeclinedStayedTheSame).HasColumnName("Improved/ declined/ stayed the same");

                entity.Property(e => e.InspectionNumber).HasColumnName("Inspection number");

                entity.Property(e => e.InspectionType).HasColumnName("Inspection type");

                entity.Property(e => e.IsSafeguardingEffective).HasColumnName("Is safeguarding effective?");

                entity.Property(e => e.LastDayOfInspection).HasColumnName("Last day of Inspection");

                entity.Property(e => e.LocalAuthority).HasColumnName("Local authority");

                entity.Property(e => e.NumberOfShortInspectionsSinceLastFullInspection).HasColumnName("Number of short inspections since last full inspection");

                entity.Property(e => e.NumberOfShortInspectionsSinceLastFullInspectionRaw).HasColumnName("Number of short inspections since last full inspection RAW");

                entity.Property(e => e.OfstedRegion).HasColumnName("Ofsted region");

                entity.Property(e => e.OverallEffectiveness).HasColumnName("Overall effectiveness");

                entity.Property(e => e.OverallEffectivenessRaw).HasColumnName("Overall effectiveness RAW");

                entity.Property(e => e.PersonalDevelopment).HasColumnName("Personal development");

                entity.Property(e => e.PersonalDevelopmentRaw).HasColumnName("Personal development RAW");

                entity.Property(e => e.PreviousBehaviourAndAttitudes).HasColumnName("Previous behaviour and attitudes");

                entity.Property(e => e.PreviousBehaviourAndAttitudesRaw).HasColumnName("Previous behaviour and attitudes RAW");

                entity.Property(e => e.PreviousEffectivenessOfLeadershipAndManagement).HasColumnName("Previous effectiveness of leadership and management");

                entity.Property(e => e.PreviousEffectivenessOfLeadershipAndManagementRaw).HasColumnName("Previous effectiveness of leadership and management RAW");

                entity.Property(e => e.PreviousInspectionNumber).HasColumnName("Previous inspection number");

                entity.Property(e => e.PreviousLastDayOfInspection).HasColumnName("Previous last day of inspection");

                entity.Property(e => e.PreviousOverallEffectiveness).HasColumnName("Previous overall effectiveness");

                entity.Property(e => e.PreviousOverallEffectivenessRaw).HasColumnName("Previous overall effectiveness RAW");

                entity.Property(e => e.PreviousPersonalDevelopment).HasColumnName("Previous personal development");

                entity.Property(e => e.PreviousPersonalDevelopmentRaw).HasColumnName("Previous personal development RAW");

                entity.Property(e => e.PreviousQualityOfEducation).HasColumnName("Previous quality of education");

                entity.Property(e => e.PreviousQualityOfEducationRaw).HasColumnName("Previous quality of education RAW");

                entity.Property(e => e.PreviousSafeguarding).HasColumnName("Previous safeguarding");

                entity.Property(e => e.ProviderGroup).HasColumnName("Provider group");

                entity.Property(e => e.ProviderName).HasColumnName("Provider name");

                entity.Property(e => e.ProviderType).HasColumnName("Provider type");

                entity.Property(e => e.ProviderUkprn).HasColumnName("Provider UKPRN");

                entity.Property(e => e.QualityOfEducation).HasColumnName("Quality of education");

                entity.Property(e => e.QualityOfEducationRaw).HasColumnName("Quality of education RAW");
            });

            modelBuilder.Entity<SmartData>(entity =>
            {
                entity.HasNoKey();

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

                entity.Property(e => e.FlagKs2CombinedDisadvantagedProgress).HasColumnName("Flag_KS2_CombinedDisadvantagedProgress");

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

                entity.Property(e => e.PredictedChanceOfChangeOccuring).HasColumnName("Predicted chance of change occuring");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

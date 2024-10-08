﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dfe.Academies.Infrastructure.Migrations.Mstr
{
    [DbContext(typeof(MstrContext))]
    partial class MstrContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dfe.Academies.Domain.Establishment.EducationEstablishmentTrust", b =>
                {
                    b.Property<int>("SK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SK"));

                    b.Property<int>("EducationEstablishmentId")
                        .HasColumnType("int")
                        .HasColumnName("FK_EducationEstablishment");

                    b.Property<int>("TrustId")
                        .HasColumnType("int")
                        .HasColumnName("FK_Trust");

                    b.HasKey("SK");

                    b.ToTable("EducationEstablishmentTrust", "mstr");
                });

            modelBuilder.Entity("Dfe.Academies.Domain.Establishment.Establishment", b =>
                {
                    b.Property<long?>("SK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("SK"));

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address Line1");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address Line2");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address Line3");

                    b.Property<string>("AdministrativeDistrict")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Administrative District");

                    b.Property<int?>("BehaviourAndAttitudes")
                        .HasColumnType("int")
                        .HasColumnName("Behaviour and attitudes");

                    b.Property<string>("CategoryOfConcern")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Category of concern");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("CloseDate");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("County");

                    b.Property<DateTime?>("DateOfLatestShortInspection")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date of latest short inspection");

                    b.Property<string>("DidTheLatestShortInspectionConvertToAFullInspection")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Did the latest short inspection convert to a full inspection?");

                    b.Property<string>("Diocese")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Diocese");

                    b.Property<string>("DioceseCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Diocese(code)");

                    b.Property<int?>("EarlyYearsProvisionWhereApplicable")
                        .HasColumnType("int")
                        .HasColumnName("Early years provision (where applicable)");

                    b.Property<int?>("EffectivenessOfLeadershipAndManagement")
                        .HasColumnType("int")
                        .HasColumnName("Effectiveness of leadership and management");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Email");

                    b.Property<long?>("EstablishmentGroupTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("FK_EstablishmentGroupType");

                    b.Property<string>("EstablishmentName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("EstablishmentName");

                    b.Property<int?>("EstablishmentNumber")
                        .HasColumnType("int")
                        .HasColumnName("EstablishmentNumber");

                    b.Property<long?>("EstablishmentStatusId")
                        .HasColumnType("bigint")
                        .HasColumnName("FK_EstablishmentStatus");

                    b.Property<long?>("EstablishmentTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("FK_EstablishmentType");

                    b.Property<string>("GORregion")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GORregion");

                    b.Property<string>("GORregionCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("GORregion(code)");

                    b.Property<DateTime?>("GiasLastChangedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("HeadFirstName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HeadFirstName");

                    b.Property<string>("HeadLastName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HeadLastName");

                    b.Property<string>("HeadPreferredJobTitle")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HeadPreferredJobTitle");

                    b.Property<string>("HeadTitle")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("HeadTitle");

                    b.Property<DateTime?>("InspectionEndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Inspection end date");

                    b.Property<DateTime?>("InspectionStartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Inspection start date");

                    b.Property<string>("InspectionType")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Inspection type");

                    b.Property<string>("IsSafeguardingEffective")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Is safeguarding effective?");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float")
                        .HasColumnName("Latitude");

                    b.Property<long?>("LocalAuthorityId")
                        .HasColumnType("bigint")
                        .HasColumnName("FK_LocalAuthority");

                    b.Property<double?>("Longitude")
                        .HasColumnType("float")
                        .HasColumnName("Longitude");

                    b.Property<string>("MainPhone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Main Phone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2")
                        .HasColumnName("Modified");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Modified By");

                    b.Property<int?>("NumberOfBoys")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfGirls")
                        .HasColumnType("int");

                    b.Property<int?>("NumberOfOtherSection8InspectionsSinceLastFullInspection")
                        .HasColumnType("int")
                        .HasColumnName("Number of other section 8 inspections since last full inspection");

                    b.Property<string>("NumberOfPupils")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("NumberOfPupils");

                    b.Property<int?>("NumberOfShortInspectionsSinceLastFullInspection")
                        .HasColumnType("int")
                        .HasColumnName("Number of short inspections since last full inspection");

                    b.Property<string>("OfstedLastInspection")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OfstedLastInspection");

                    b.Property<string>("OfstedRating")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OfstedRating");

                    b.Property<string>("OpenDate")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("OpenDate");

                    b.Property<int?>("OverallEffectiveness")
                        .HasColumnType("int")
                        .HasColumnName("Overall effectiveness");

                    b.Property<long?>("PK_CDM_ID")
                        .HasColumnType("bigint")
                        .HasColumnName("PK_CDM_ID");

                    b.Property<int?>("PK_GIAS_URN")
                        .HasColumnType("int")
                        .HasColumnName("PK_GIAS_URN");

                    b.Property<string>("ParliamentaryConstituency")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Parliamentary constituency");

                    b.Property<string>("ParliamentaryConstituencyCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ParliamentaryConstituency(code)");

                    b.Property<string>("PercentageFSM")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PercentageFSM");

                    b.Property<int?>("PersonalDevelopment")
                        .HasColumnType("int")
                        .HasColumnName("Personal development");

                    b.Property<string>("PhaseOfEducation")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhaseOfEducation");

                    b.Property<int?>("PhaseOfEducationCode")
                        .HasColumnType("int")
                        .HasColumnName("PhaseOfEducation(code)");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Postcode");

                    b.Property<string>("PreviousCategoryOfConcern")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Previous category of concern");

                    b.Property<int?>("PreviousEarlyYearsProvisionWhereApplicable")
                        .HasColumnType("int")
                        .HasColumnName("Previous early years provision (where applicable)");

                    b.Property<int?>("PreviousFullInspectionOverallEffectiveness")
                        .HasColumnType("int")
                        .HasColumnName("Previous full inspection overall effectiveness");

                    b.Property<DateTime?>("PreviousInspectionEndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Previous inspection end date");

                    b.Property<DateTime?>("PreviousInspectionStartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Previous inspection start date");

                    b.Property<string>("PreviousIsSafeguardingEffective")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Previous is safeguarding effective?");

                    b.Property<DateTime?>("PreviousPublicationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Previous publication date");

                    b.Property<string>("ProjectLead")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Project Lead");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Publication date");

                    b.Property<int?>("QualityOfEducation")
                        .HasColumnType("int")
                        .HasColumnName("Quality of education");

                    b.Property<string>("ReasonEstablishmentClosed")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReasonEstablishmentClosed");

                    b.Property<long?>("RegionId")
                        .HasColumnType("bigint")
                        .HasColumnName("FK_Region");

                    b.Property<string>("ReligiousCharacter")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReligiousCharacter");

                    b.Property<string>("ReligiousCharacterCode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReligiousCharacter(code)");

                    b.Property<string>("ReligiousEthos")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ReligiousEthos");

                    b.Property<string>("RouteOfProject")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Route of Project");

                    b.Property<string>("SFSOTerritory")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SFSO Territory");

                    b.Property<string>("SchoolCapacity")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("SchoolCapacity");

                    b.Property<int?>("SenUnitCapacity")
                        .HasColumnType("int");

                    b.Property<int?>("SenUnitOnRoll")
                        .HasColumnType("int");

                    b.Property<string>("ShortInspectionOverallOutcome")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Short inspection overall outcome");

                    b.Property<DateTime?>("ShortInspectionPublicationDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Short inspection publication date");

                    b.Property<int?>("SixthFormProvisionWhereApplicable")
                        .HasColumnType("int")
                        .HasColumnName("Sixth form provision (where applicable)");

                    b.Property<string>("StatutoryHighAge")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("StatutoryHighAge");

                    b.Property<string>("StatutoryLowAge")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("StatutoryLowAge");

                    b.Property<int?>("TheIncomeDeprivationAffectingChildrenIndexIDACIQuintile")
                        .HasColumnType("int")
                        .HasColumnName("The income deprivation affecting children index (IDACI) quintile");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Town");

                    b.Property<string>("UKPRN")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UKPRN");

                    b.Property<int?>("URN")
                        .HasColumnType("int")
                        .HasColumnName("URN");

                    b.Property<int?>("URNAtCurrentFullInspection")
                        .HasColumnType("int")
                        .HasColumnName("URN at Current full inspection");

                    b.Property<int?>("URNAtPreviousFullInspection")
                        .HasColumnType("int")
                        .HasColumnName("URN at Previous full inspection");

                    b.Property<int?>("URNAtSection8Inspection")
                        .HasColumnType("int")
                        .HasColumnName("URN at Section 8 inspection");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Website");

                    b.HasKey("SK");

                    b.HasIndex("EstablishmentTypeId");

                    b.HasIndex("LocalAuthorityId");

                    b.ToTable("EducationEstablishment", "mstr");
                });

            modelBuilder.Entity("Dfe.Academies.Domain.Establishment.EstablishmentType", b =>
                {
                    b.Property<long>("SK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SK"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SK");

                    b.ToTable("Ref_EducationEstablishmentType", "mstr");

                    b.HasData(
                        new
                        {
                            SK = 224L,
                            Code = "35",
                            Name = "Free schools"
                        },
                        new
                        {
                            SK = 228L,
                            Code = "18",
                            Name = "Further education"
                        });
                });

            modelBuilder.Entity("Dfe.Academies.Domain.Establishment.IfdPipeline", b =>
                {
                    b.Property<long?>("SK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("SK"));

                    b.Property<string>("DeliveryProcessPAN")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Delivery Process.PAN");

                    b.Property<string>("DeliveryProcessPFI")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Delivery Process.PFI");

                    b.Property<string>("GeneralDetailsUrn")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("General Details.URN");

                    b.Property<string>("ProjectTemplateInformationDeficit")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Project template information.Deficit?");

                    b.Property<string>("ProjectTemplateInformationViabilityIssue")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Project template information.Viability issue?");

                    b.HasKey("SK");

                    b.ToTable("IfdPipeline", "mstr");
                });

            modelBuilder.Entity("Dfe.Academies.Domain.Establishment.LocalAuthority", b =>
                {
                    b.Property<long>("SK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SK"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SK");

                    b.ToTable("Ref_LocalAuthority", "mstr");

                    b.HasData(
                        new
                        {
                            SK = 1L,
                            Code = "202",
                            Name = "Barnsley"
                        },
                        new
                        {
                            SK = 2L,
                            Code = "203",
                            Name = "Birmingham"
                        },
                        new
                        {
                            SK = 3L,
                            Code = "204",
                            Name = "Bradford"
                        });
                });

            modelBuilder.Entity("Dfe.Academies.Domain.Trust.Trust", b =>
                {
                    b.Property<long?>("SK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("SK"));

                    b.Property<string>("AMSDTerritory")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AMSD Territory");

                    b.Property<string>("AddressLine1")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address Line1");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address Line2");

                    b.Property<string>("AddressLine3")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Address Line3");

                    b.Property<DateTime?>("ClosedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Closed Date");

                    b.Property<string>("CompaniesHouseNumber")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Companies House Number");

                    b.Property<string>("County")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("County");

                    b.Property<string>("CurrentSingleListGrouping")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Current Single List Grouping");

                    b.Property<DateTime?>("DateActionPlannedFor")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date Action Planned For");

                    b.Property<DateTime?>("DateEnteredOntoSingleList")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date Entered Onto Single List");

                    b.Property<DateTime?>("DateOfGroupingDecision")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date of Grouping Decision");

                    b.Property<DateTime?>("DateOfTrustReviewMeeting")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date of Trust Review Meeting");

                    b.Property<string>("EfficiencyICFPReviewCompleted")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Efficiency ICFP Review Completed");

                    b.Property<string>("EfficiencyICFPReviewOther")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Efficiency ICFP Review Other");

                    b.Property<DateTime?>("ExternalGovernanceReviewDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("External Governance Review Date");

                    b.Property<string>("FollowUpLetterSent")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Follow Up Letter Sent");

                    b.Property<string>("GroupID")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Group ID");

                    b.Property<string>("GroupUID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Group UID");

                    b.Property<DateTime?>("IncorporatedOnOpenDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Incorporated on (open date)");

                    b.Property<DateTime?>("JoinedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Joined Date");

                    b.Property<string>("LeadAMSDTerritory")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Lead AMSD Territory");

                    b.Property<string>("LinkToWorkplaceForEfficiencyICFPReview")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Link To Workplace For Efficiency ICFP Review");

                    b.Property<string>("MainPhone")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Main Phone");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2")
                        .HasColumnName("Modified");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Modified By");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<int?>("NumberInTrust")
                        .HasColumnType("int")
                        .HasColumnName("Number In Trust");

                    b.Property<string>("Postcode")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Postcode");

                    b.Property<string>("PrioritisedForReview")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Prioritised for Review");

                    b.Property<string>("RID")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("RID");

                    b.Property<long?>("RegionId")
                        .HasColumnType("bigint")
                        .HasColumnName("FK_Region");

                    b.Property<string>("Town")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Town");

                    b.Property<long?>("TrustBandingId")
                        .HasColumnType("bigint")
                        .HasColumnName("FK_TrustBanding");

                    b.Property<DateTime?>("TrustPerformanceAndRiskDateOfMeeting")
                        .HasColumnType("datetime2")
                        .HasColumnName("Trust Performance And Risk Date Of Meeting");

                    b.Property<string>("TrustReviewWriteUp")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Trust Review Write Up");

                    b.Property<string>("TrustStatus")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Trust Status");

                    b.Property<long?>("TrustStatusId")
                        .HasColumnType("bigint")
                        .HasColumnName("FK_TrustStatus");

                    b.Property<long?>("TrustTypeId")
                        .HasColumnType("bigint")
                        .HasColumnName("FK_TrustType");

                    b.Property<string>("UKPRN")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UKPRN");

                    b.Property<string>("UPIN")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UPIN");

                    b.Property<string>("WIPSummaryGoesToMinister")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("WIP Summary Goes To Minister");

                    b.HasKey("SK");

                    b.HasIndex("TrustTypeId");

                    b.ToTable("Trust", "mstr");
                });

            modelBuilder.Entity("Dfe.Academies.Domain.Trust.TrustType", b =>
                {
                    b.Property<long>("SK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SK"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SK");

                    b.ToTable("Ref_TrustType", "mstr");

                    b.HasData(
                        new
                        {
                            SK = 30L,
                            Code = "06",
                            Name = "Multi-academy trust"
                        },
                        new
                        {
                            SK = 32L,
                            Code = "10",
                            Name = "Single-academy trust"
                        });
                });

            modelBuilder.Entity("Dfe.Academies.Domain.Establishment.Establishment", b =>
                {
                    b.HasOne("Dfe.Academies.Domain.Establishment.EstablishmentType", "EstablishmentType")
                        .WithMany()
                        .HasForeignKey("EstablishmentTypeId");

                    b.HasOne("Dfe.Academies.Domain.Establishment.LocalAuthority", "LocalAuthority")
                        .WithMany()
                        .HasForeignKey("LocalAuthorityId");

                    b.Navigation("EstablishmentType");

                    b.Navigation("LocalAuthority");
                });

            modelBuilder.Entity("Dfe.Academies.Domain.Trust.Trust", b =>
                {
                    b.HasOne("Dfe.Academies.Domain.Trust.TrustType", "TrustType")
                        .WithMany()
                        .HasForeignKey("TrustTypeId");

                    b.Navigation("TrustType");
                });
#pragma warning restore 612, 618
        }
    }
}

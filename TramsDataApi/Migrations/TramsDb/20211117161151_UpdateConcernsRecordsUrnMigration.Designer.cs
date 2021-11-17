﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Migrations.TramsDb
{
    [DbContext(typeof(TramsDbContext))]
    [Migration("20211117161151_UpdateConcernsRecordsUrnMigration")]
    partial class UpdateConcernsRecordsUrnMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.AcademyTransferProjectUrns", "'AcademyTransferProjectUrns', '', '10000000', '1', '10000000', '', 'Int32', 'False'")
                .HasAnnotation("Relational:Sequence:.ConcernsGlobalSequence", "'ConcernsGlobalSequence', '', '1', '1', '1', '', 'Int32', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TramsDataApi.DatabaseModels.AcademyConversionProject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademyOrderRequired")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AcademyTypeAndRoute")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ActualPupilNumbers")
                        .HasColumnType("int");

                    b.Property<string>("AgeRange")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ApplicationReceivedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ApplicationReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BaselineDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<decimal?>("CapitalCarryForwardAtEndMarchCurrentYear")
                        .HasColumnType("decimal(38, 2)");

                    b.Property<decimal?>("CapitalCarryForwardAtEndMarchNextYear")
                        .HasColumnType("decimal(38, 2)");

                    b.Property<string>("ClearedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ConversionSupportGrantAmount")
                        .HasColumnType("decimal(38, 2)");

                    b.Property<string>("ConversionSupportGrantChangeReason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiocesanTrust")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DistanceFromSchoolToTrustHeadquarters")
                        .HasColumnType("decimal(38, 3)");

                    b.Property<string>("DistanceFromSchoolToTrustHeadquartersAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EqualitiesImpactAssessmentConsidered")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FinancialDeficit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("GeneralInformationSectionComplete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("HeadTeacherBoardDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IfdPipelineId")
                        .HasColumnType("int");

                    b.Property<string>("KeyStage2PerformanceAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyStage4PerformanceAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyStage5PerformanceAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalAuthority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalAuthorityInformationTemplateComments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LocalAuthorityInformationTemplateLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LocalAuthorityInformationTemplateReturnedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool?>("LocalAuthorityInformationTemplateSectionComplete")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LocalAuthorityInformationTemplateSentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MemberOfParliamentParty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameOfTrust")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OpeningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PartOfPfiScheme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PercentageFreeSchoolMeals")
                        .HasColumnType("decimal(38, 3)");

                    b.Property<decimal?>("PercentageOfGoodOrOutstandingSchoolsInTheDiocesanTrust")
                        .HasColumnType("decimal(38, 3)");

                    b.Property<DateTime?>("PreviousHeadTeacherBoardDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PreviousHeadTeacherBoardDateQuestion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviousHeadTeacherBoardLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("ProjectedRevenueBalanceAtEndMarchNextYear")
                        .HasColumnType("decimal(38, 2)");

                    b.Property<DateTime?>("ProposedAcademyOpeningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublishedAdmissionNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RationaleForProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RationaleForTrust")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("RationaleSectionComplete")
                        .HasColumnType("bit");

                    b.Property<string>("RecommendationForProject")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RevenueCarryForwardAtEndMarchCurrentYear")
                        .HasColumnType("decimal(38, 2)");

                    b.Property<string>("RisksAndIssues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("RisksAndIssuesSectionComplete")
                        .HasColumnType("bit");

                    b.Property<bool?>("SchoolAndTrustInformationSectionComplete")
                        .HasColumnType("bit");

                    b.Property<string>("SchoolBudgetInformationAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("SchoolBudgetInformationSectionComplete")
                        .HasColumnType("bit");

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolPerformanceAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolPhase")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolPupilForecastsAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SchoolType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SponsorName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SponsorReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrustReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Urn")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ViabilityIssues")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("YearOneProjectedCapacity")
                        .HasColumnType("int");

                    b.Property<int?>("YearOneProjectedPupilNumbers")
                        .HasColumnType("int");

                    b.Property<int?>("YearThreeProjectedCapacity")
                        .HasColumnType("int");

                    b.Property<int?>("YearThreeProjectedPupilNumbers")
                        .HasColumnType("int");

                    b.Property<int?>("YearTwoProjectedCapacity")
                        .HasColumnType("int");

                    b.Property<int?>("YearTwoProjectedPupilNumbers")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AcademyConversionProject","sdd");
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.AcademyConversionProjectNote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AcademyConversionProjectId")
                        .HasColumnType("int");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AcademyConversionProjectId");

                    b.ToTable("AcademyConversionProjectNote","sdd");
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.AcademyTransferProjectIntendedTransferBenefits", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FkAcademyTransferProjectId")
                        .HasColumnName("fk_AcademyTransferProjectId")
                        .HasColumnType("int");

                    b.Property<string>("SelectedBenefit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FkAcademyTransferProjectId");

                    b.ToTable("AcademyTransferProjectIntendedTransferBenefits","sdd");
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.AcademyTransferProjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AcademyPerformanceAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ComplexLandAndBuildingFurtherSpecification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("ComplexLandAndBuildingShouldBeConsidered")
                        .HasColumnType("bit");

                    b.Property<string>("FinanceAndDebtFurtherSpecification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("FinanceAndDebtShouldBeConsidered")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasHtbDate")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasTargetDateForTransfer")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasTransferFirstDiscussedDate")
                        .HasColumnType("bit");

                    b.Property<string>("HighProfileFurtherSpecification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HighProfileShouldBeConsidered")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("HtbDate")
                        .HasColumnType("date");

                    b.Property<string>("KeyStage2PerformanceAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyStage4PerformanceAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KeyStage5PerformanceAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LatestOfstedJudgementAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherBenefitValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OtherTransferTypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OutgoingTrustUkprn")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("ProjectRationale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PupilNumbersAdditionalInformation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("RddOrEsfaIntervention")
                        .HasColumnType("bit");

                    b.Property<string>("RddOrEsfaInterventionDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Recommendation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("TargetDateForTransfer")
                        .HasColumnType("date");

                    b.Property<DateTime?>("TransferFirstDiscussed")
                        .HasColumnType("date");

                    b.Property<string>("TrustSponsorRationale")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfTransfer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Urn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR AcademyTransferProjectUrns");

                    b.Property<string>("WhoInitiatedTheTransfer")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id")
                        .HasName("PK__AcademyT__C5B214360AF6201A");

                    b.HasIndex("Urn")
                        .HasName("AcademyTransferProjectUrn");

                    b.ToTable("AcademyTransferProjects","sdd");
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.ConcernsCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CaseAim")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ClosedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CrmEnquiry")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CurrentStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DeEscalation")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeEscalationPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectionOfTravel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Issue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NextSteps")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonAtReview")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReviewAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusUrn")
                        .HasColumnType("int");

                    b.Property<string>("TrustUkprn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Urn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

                    b.HasKey("Id")
                        .HasName("PK__CCase__C5B214360AF620234");

                    b.ToTable("ConcernsCase","sdd");
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.ConcernsRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Urn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

                    b.HasKey("Id")
                        .HasName("PK__CRating");

                    b.ToTable("ConcernsRating","sdd");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(2270),
                            Name = "Red - Plus",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(2680),
                            Urn = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3070),
                            Name = "Red",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3080),
                            Urn = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3090),
                            Name = "Red - Amber",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3090),
                            Urn = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3090),
                            Name = "Amber - Green",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3100),
                            Urn = 0
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3100),
                            Name = "n/a",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3100),
                            Urn = 0
                        });
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.ConcernsRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ClosedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Primary")
                        .HasColumnType("bit");

                    b.Property<int>("RatingId")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReviewAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusUrn")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Urn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

                    b.HasKey("Id")
                        .HasName("PK__CRecord");

                    b.HasIndex("CaseId");

                    b.HasIndex("RatingId");

                    b.HasIndex("TypeId");

                    b.ToTable("ConcernsRecord","sdd");
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.ConcernsStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Urn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

                    b.HasKey("Id")
                        .HasName("PK__CStatus__C5B214360AF620234");

                    b.ToTable("ConcernsStatus","sdd");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 649, DateTimeKind.Local).AddTicks(4020),
                            Name = "Live",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(4920),
                            Urn = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5410),
                            Name = "Monitoring",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5420),
                            Urn = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5430),
                            Name = "Close",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5440),
                            Urn = 0
                        });
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.ConcernsType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Urn")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("NEXT VALUE FOR ConcernsGlobalSequence");

                    b.HasKey("Id")
                        .HasName("PK__CType");

                    b.ToTable("ConcernsType","sdd");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(8240),
                            Description = "Financial reporting",
                            Name = "Compliance",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(8650),
                            Urn = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9060),
                            Description = "Financial returns",
                            Name = "Compliance",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9070),
                            Urn = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9080),
                            Description = "Deficit",
                            Name = "Financial",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9080),
                            Urn = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9080),
                            Description = "Projected deficit / Low future surplus",
                            Name = "Financial",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090),
                            Urn = 0
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090),
                            Description = "Cash flow shortfall",
                            Name = "Financial",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090),
                            Urn = 0
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090),
                            Description = "Clawback",
                            Name = "Financial",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090),
                            Urn = 0
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100),
                            Name = "Force majeure",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100),
                            Urn = 0
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100),
                            Description = "Governance",
                            Name = "Governance",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100),
                            Urn = 0
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110),
                            Description = "Closure",
                            Name = "Governance",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110),
                            Urn = 0
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110),
                            Description = "Executive Pay",
                            Name = "Governance",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110),
                            Urn = 0
                        },
                        new
                        {
                            Id = 11,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110),
                            Description = "Safeguarding",
                            Name = "Governance",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120),
                            Urn = 0
                        },
                        new
                        {
                            Id = 12,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120),
                            Description = "Allegations and self reported concerns",
                            Name = "Irregularity",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120),
                            Urn = 0
                        },
                        new
                        {
                            Id = 13,
                            CreatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120),
                            Description = "Related party transactions - in year",
                            Name = "Irregularity",
                            UpdatedAt = new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120),
                            Urn = 0
                        });
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.TransferringAcademies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("FkAcademyTransferProjectId")
                        .HasColumnName("fk_AcademyTransferProjectId")
                        .HasColumnType("int");

                    b.Property<string>("IncomingTrustUkprn")
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.Property<string>("OutgoingAcademyUkprn")
                        .IsRequired()
                        .HasColumnType("nvarchar(8)")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.HasIndex("FkAcademyTransferProjectId");

                    b.ToTable("TransferringAcademies","sdd");
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.AcademyConversionProjectNote", b =>
                {
                    b.HasOne("TramsDataApi.DatabaseModels.AcademyConversionProject", "AcademyConversionProject")
                        .WithMany()
                        .HasForeignKey("AcademyConversionProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.AcademyTransferProjectIntendedTransferBenefits", b =>
                {
                    b.HasOne("TramsDataApi.DatabaseModels.AcademyTransferProjects", "FkAcademyTransferProject")
                        .WithMany("AcademyTransferProjectIntendedTransferBenefits")
                        .HasForeignKey("FkAcademyTransferProjectId")
                        .HasConstraintName("FK__AcademyTr__fk_Ac__4316F928");
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.ConcernsRecord", b =>
                {
                    b.HasOne("TramsDataApi.DatabaseModels.ConcernsCase", "ConcernsCase")
                        .WithMany("ConcernsRecords")
                        .HasForeignKey("CaseId")
                        .HasConstraintName("FK__ConcernsCase_ConcernsRecord")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TramsDataApi.DatabaseModels.ConcernsRating", "ConcernsRating")
                        .WithMany("FkConcernsRecord")
                        .HasForeignKey("RatingId")
                        .HasConstraintName("FK__ConcernsRecord_ConcernsRating")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TramsDataApi.DatabaseModels.ConcernsType", "ConcernsType")
                        .WithMany("FkConcernsRecord")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK__ConcernsRecord_ConcernsType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TramsDataApi.DatabaseModels.TransferringAcademies", b =>
                {
                    b.HasOne("TramsDataApi.DatabaseModels.AcademyTransferProjects", "FkAcademyTransferProject")
                        .WithMany("TransferringAcademies")
                        .HasForeignKey("FkAcademyTransferProjectId")
                        .HasConstraintName("FK__Transferr__fk_Ac__403A8C7D");
                });
#pragma warning restore 612, 618
        }
    }
}

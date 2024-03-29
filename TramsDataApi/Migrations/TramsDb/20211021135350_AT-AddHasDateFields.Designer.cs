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
    [Migration("20211021135350_AT-AddHasDateFields")]
    partial class ATAddHasDateFields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:.AcademyTransferProjectUrns", "'AcademyTransferProjectUrns', '', '10000000', '1', '10000000', '', 'Int32', 'False'")
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

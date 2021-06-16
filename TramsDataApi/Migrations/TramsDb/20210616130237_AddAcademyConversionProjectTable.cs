using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddAcademyConversionProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcademyConversionProject",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IfdPipelineId = table.Column<int>(nullable: false),
                    Urn = table.Column<int>(nullable: false),
                    SchoolName = table.Column<string>(nullable: true),
                    LocalAuthority = table.Column<string>(nullable: true),
                    ApplicationReferenceNumber = table.Column<string>(nullable: true),
                    ProjectStatus = table.Column<string>(nullable: true),
                    ApplicationReceivedDate = table.Column<DateTime>(nullable: true),
                    AssignedDate = table.Column<DateTime>(nullable: true),
                    HeadTeacherBoardDate = table.Column<DateTime>(nullable: true),
                    OpeningDate = table.Column<DateTime>(nullable: true),
                    BaselineDate = table.Column<DateTime>(nullable: true),
                    LocalAuthorityInformationTemplateSentDate = table.Column<DateTime>(nullable: true),
                    LocalAuthorityInformationTemplateReturnedDate = table.Column<DateTime>(nullable: true),
                    LocalAuthorityInformationTemplateComments = table.Column<string>(nullable: true),
                    LocalAuthorityInformationTemplateLink = table.Column<string>(nullable: true),
                    LocalAuthorityInformationTemplateSectionComplete = table.Column<bool>(nullable: true),
                    RecommendationForProject = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true),
                    ClearedBy = table.Column<string>(nullable: true),
                    IsAoRequired = table.Column<bool>(nullable: true),
                    PreviousHeadTeacherBoardDate = table.Column<DateTime>(nullable: true),
                    PreviousHeadTeacherBoardLink = table.Column<string>(nullable: true),
                    TrustReferenceNumber = table.Column<string>(nullable: true),
                    NameOfTrust = table.Column<string>(nullable: true),
                    SponsorReferenceNumber = table.Column<string>(nullable: true),
                    SponsorName = table.Column<string>(nullable: true),
                    AcademyTypeAndRoute = table.Column<string>(nullable: true),
                    ProposedAcademyOpeningDate = table.Column<DateTime>(nullable: true),
                    SchoolAndTrustInformationSectionComplete = table.Column<bool>(nullable: true),
                    SchoolPhase = table.Column<string>(nullable: true),
                    AgeRange = table.Column<string>(nullable: true),
                    SchoolType = table.Column<string>(nullable: true),
                    ActualPupilNumbers = table.Column<int>(nullable: true),
                    Capacity = table.Column<int>(nullable: true),
                    PublishedAdmissionNumber = table.Column<string>(nullable: true),
                    PercentageFreeSchoolMeals = table.Column<decimal>(type: "decimal(38, 3)", nullable: true),
                    PartOfPfiScheme = table.Column<string>(nullable: true),
                    ViabilityIssues = table.Column<bool>(nullable: true),
                    FinancialSurplusOrDeficit = table.Column<bool>(nullable: true),
                    IsThisADiocesanTrust = table.Column<bool>(nullable: true),
                    PercentageOfGoodOrOutstandingSchoolsInTheDiocesanTrust = table.Column<decimal>(type: "decimal(38, 3)", nullable: true),
                    DistanceFromSchoolToTrustHeadquarters = table.Column<decimal>(type: "decimal(38, 3)", nullable: true),
                    DistanceFromSchoolToTrustHeadquartersAdditionalInformation = table.Column<string>(nullable: true),
                    MemberOfParliamentParty = table.Column<string>(nullable: true),
                    GeneralInformationSectionComplete = table.Column<bool>(nullable: true),
                    SchoolPerformanceAdditionalInformation = table.Column<string>(nullable: true),
                    RationaleForProject = table.Column<string>(nullable: true),
                    RationaleForTrust = table.Column<string>(nullable: true),
                    RationaleSectionComplete = table.Column<bool>(nullable: true),
                    RisksAndIssues = table.Column<string>(nullable: true),
                    EqualitiesImpactAssessmentConsidered = table.Column<string>(nullable: true),
                    RisksAndIssuesSectionComplete = table.Column<bool>(nullable: true),
                    RevenueCarryForwardAtEndMarchCurrentYear = table.Column<decimal>(type: "decimal(38, 2)", nullable: true),
                    ProjectedRevenueBalanceAtEndMarchNextYear = table.Column<decimal>(type: "decimal(38, 2)", nullable: true),
                    CapitalCarryForwardAtEndMarchCurrentYear = table.Column<decimal>(type: "decimal(38, 2)", nullable: true),
                    CapitalCarryForwardAtEndMarchNextYear = table.Column<decimal>(type: "decimal(38, 2)", nullable: true),
                    SchoolBudgetInformationAdditionalInformation = table.Column<string>(nullable: true),
                    SchoolBudgetInformationSectionComplete = table.Column<bool>(nullable: true),
                    YearOneProjectedCapacity = table.Column<int>(nullable: true),
                    YearOneProjectedPupilNumbers = table.Column<int>(nullable: true),
                    YearTwoProjectedCapacity = table.Column<int>(nullable: true),
                    YearTwoProjectedPupilNumbers = table.Column<int>(nullable: true),
                    YearThreeProjectedCapacity = table.Column<int>(nullable: true),
                    YearThreeProjectedPupilNumbers = table.Column<int>(nullable: true),
                    SchoolPupilForecastsAdditionalInformation = table.Column<string>(nullable: true),
                    KeyStagePerformanceTablesAdditionalInformation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcademyConversionProject", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcademyConversionProject",
                schema: "sdd");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class _20211118150200AddApplyToBecomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "A2BApplication",
                schema: "sdd",
                columns: table => new
                {
                    ApplicationId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ApplicationType = table.Column<string>(nullable: true),
                    FormTrustProposedNameOfTrust = table.Column<string>(nullable: true),
                    ApplicationSubmitted = table.Column<bool>(nullable: false),
                    ApplicationLeadAuthorId = table.Column<string>(nullable: true),
                    ApplicationVersion = table.Column<string>(nullable: true),
                    ApplicationLeadAuthorName = table.Column<string>(nullable: true),
                    ApplicationRole = table.Column<string>(nullable: true),
                    ApplicationRoleOtherDescription = table.Column<string>(nullable: true),
                    ChangesToTrust = table.Column<int>(nullable: true),
                    ChangesToTrustExplained = table.Column<string>(nullable: true),
                    ChangesToLaGovernance = table.Column<int>(nullable: true),
                    ChangesToLaGovernanceExplained = table.Column<string>(nullable: true),
                    FormTrustOpeningDate = table.Column<DateTime>(nullable: true),
                    TrustApproverName = table.Column<string>(nullable: true),
                    TrustApproverEmail = table.Column<string>(nullable: true),
                    TrustId = table.Column<string>(nullable: true),
                    FormTrustReasonApprovalToConvertAsSat = table.Column<int>(nullable: true),
                    FormTrustReasonApprovedPerson = table.Column<string>(nullable: true),
                    FormTrustReasonForming = table.Column<string>(nullable: true),
                    FormTrustReasonVision = table.Column<string>(nullable: true),
                    FormTrustReasonGeoAreas = table.Column<string>(nullable: true),
                    FormTrustReasonFreedom = table.Column<string>(nullable: true),
                    FormTrustReasonImproveTeaching = table.Column<string>(nullable: true),
                    FormTrustPlanForGrowth = table.Column<string>(nullable: true),
                    FormTrustPlansForNoGrowth = table.Column<string>(nullable: true),
                    FormTrustGrowthPlansYesNo = table.Column<int>(nullable: true),
                    FormTrustImprovementSupport = table.Column<string>(nullable: true),
                    FormTrustImprovementStrategy = table.Column<string>(nullable: true),
                    FormTrustImprovementApprovedSponsor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplication", x => x.ApplicationId);
                });

            migrationBuilder.CreateTable(
                name: "A2BApplicationKeyPersons",
                schema: "sdd",
                columns: table => new
                {
                    KeyPersonId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    KeyPersonDateOfBirth = table.Column<string>(nullable: true),
                    KeyPersonBiography = table.Column<string>(nullable: true),
                    KeyPersonCeoExecutive = table.Column<string>(nullable: true),
                    KeyPersonChairOfTrust = table.Column<string>(nullable: true),
                    KeyPersonFinancialDirector = table.Column<string>(nullable: true),
                    KeyPersonFinancialDirectorTime = table.Column<string>(nullable: true),
                    KeyPersonMember = table.Column<string>(nullable: true),
                    KeyPersonOther = table.Column<string>(nullable: true),
                    KeyPersonTrustee = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationKeyPersons", x => x.KeyPersonId);
                });

            migrationBuilder.CreateTable(
                name: "A2BApplicationStatus",
                schema: "sdd",
                columns: table => new
                {
                    ApplicationStatusId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationStatus", x => x.ApplicationStatusId);
                });

            migrationBuilder.CreateTable(
                name: "A2BApplyingSchool",
                schema: "sdd",
                columns: table => new
                {
                    ApplyingSchoolsId = table.Column<string>(nullable: false),
                    UpdatedTrustFields = table.Column<string>(nullable: true),
                    SchoolDeclarationSignedById = table.Column<string>(nullable: true),
                    SchoolDeclarationBodyAgree = table.Column<int>(nullable: true),
                    SchoolDeclarationTeacherChair = table.Column<int>(nullable: true),
                    SchoolDeclarationSignedByEmail = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    UpdatedSchoolFields = table.Column<string>(nullable: true),
                    SchoolConversionReasonsForJoining = table.Column<string>(nullable: true),
                    SchoolConversionTargetDateDifferent = table.Column<int>(nullable: true),
                    SchoolConversionTargetDateDate = table.Column<DateTime>(nullable: true),
                    SchoolConversionTargetDateExplained = table.Column<string>(nullable: true),
                    SchoolConversionChangeName = table.Column<int>(nullable: true),
                    SchoolConversionChangeNameValue = table.Column<string>(nullable: true),
                    SchoolConversionContactHeadName = table.Column<string>(nullable: true),
                    SchoolConversionContactHeadEmail = table.Column<string>(nullable: true),
                    SchoolConversionContactHeadTel = table.Column<string>(nullable: true),
                    SchoolConversionContactChairName = table.Column<string>(nullable: true),
                    SchoolConversionContactChairEmail = table.Column<string>(nullable: true),
                    SchoolConversionContactChairTel = table.Column<string>(nullable: true),
                    SchoolConversionMainContact = table.Column<int>(nullable: true),
                    SchoolConversionMainContactOtherName = table.Column<string>(nullable: true),
                    SchoolConversionMainContactOtherEmail = table.Column<string>(nullable: true),
                    SchoolConversionMainContactOtherTelephone = table.Column<string>(nullable: true),
                    SchoolConversionMainContactOtherRole = table.Column<string>(nullable: true),
                    SchoolConversionApproverContactName = table.Column<string>(nullable: true),
                    SchoolConversionApproverContactEmail = table.Column<string>(nullable: true),
                    SchoolAdInspectedButReportNotPublished = table.Column<int>(nullable: true),
                    SchoolAdInspectedReportNotPublishedExplain = table.Column<string>(nullable: true),
                    SchoolLaReorganization = table.Column<int>(nullable: true),
                    SchoolLaReorganizationExplain = table.Column<string>(nullable: true),
                    SchoolLaClosurePlans = table.Column<int>(nullable: true),
                    SchoolLaClosurePlansExplain = table.Column<string>(nullable: true),
                    SchoolPartOfFederation = table.Column<int>(nullable: true),
                    SchoolAddFurtherInformation = table.Column<int>(nullable: true),
                    SchoolFurtherInformation = table.Column<string>(nullable: true),
                    SchoolAdSchoolContributionToTrust = table.Column<string>(nullable: true),
                    SchoolAdSafeguarding = table.Column<int>(nullable: true),
                    SchoolAdSafeguardingExplained = table.Column<string>(nullable: true),
                    SchoolSACREExemption = table.Column<int>(nullable: true),
                    SchoolSACREExemptionEndDate = table.Column<DateTime>(nullable: true),
                    SchoolFaithSchool = table.Column<int>(nullable: true),
                    SchoolFaithSchoolDioceseName = table.Column<string>(nullable: true),
                    SchoolSupportedFoundation = table.Column<int>(nullable: true),
                    SchoolSupportedFoundationBodyName = table.Column<string>(nullable: true),
                    SchoolAdFeederSchools = table.Column<string>(nullable: true),
                    SchoolAdEqualitiesImpactAssessment = table.Column<int>(nullable: true),
                    SchoolPFYRevenue = table.Column<double>(nullable: true),
                    SchoolPFYRevenueStatus = table.Column<int>(nullable: true),
                    SchoolPFYRevenueStatusExplained = table.Column<string>(nullable: true),
                    SchoolPFYCapitalForward = table.Column<double>(nullable: true),
                    SchoolPFYCapitalForwardStatus = table.Column<int>(nullable: true),
                    SchoolPFYCapitalForwardStatusExplained = table.Column<string>(nullable: true),
                    SchoolCFYRevenue = table.Column<double>(nullable: true),
                    SchoolCFYRevenueStatus = table.Column<int>(nullable: true),
                    SchoolCFYRevenueStatusExplained = table.Column<string>(nullable: true),
                    SchoolCFYCapitalForward = table.Column<double>(nullable: true),
                    SchoolCFYCapitalForwardStatus = table.Column<int>(nullable: true),
                    SchoolCFYCapitalForwardStatusExplained = table.Column<string>(nullable: true),
                    SchoolNFYRevenue = table.Column<double>(nullable: true),
                    SchoolNFYRevenueStatus = table.Column<int>(nullable: true),
                    SchoolNFYRevenueStatusExplained = table.Column<string>(nullable: true),
                    SchoolNFYCapitalForward = table.Column<double>(nullable: true),
                    SchoolNFYCapitalForwardStatus = table.Column<int>(nullable: true),
                    SchoolNFYCapitalForwardStatusExplained = table.Column<string>(nullable: true),
                    SchoolFinancialInvestigations = table.Column<int>(nullable: true),
                    SchoolFinancialInvestigationsExplain = table.Column<string>(nullable: true),
                    SchoolFinancialInvestigationsTrustAware = table.Column<int>(nullable: true),
                    SchoolNFYEndDate = table.Column<DateTime>(nullable: true),
                    SchoolPFYEndDate = table.Column<DateTime>(nullable: true),
                    SchoolCFYEndDate = table.Column<DateTime>(nullable: true),
                    SchoolLoanExists = table.Column<int>(nullable: true),
                    SchoolLeaseExists = table.Column<int>(nullable: true),
                    SchoolCapacityYear1 = table.Column<int>(nullable: true),
                    SchoolCapacityYear2 = table.Column<int>(nullable: true),
                    SchoolCapacityYear3 = table.Column<int>(nullable: true),
                    SchoolCapacityAssumptions = table.Column<string>(nullable: true),
                    SchoolCapacityPublishedAdmissionsNumber = table.Column<string>(nullable: true),
                    SchoolBuildLandOwnerExplained = table.Column<string>(nullable: true),
                    SchoolBuildLandSharedFacilities = table.Column<int>(nullable: true),
                    SchoolBuildLandSharedFacilitiesExplained = table.Column<string>(nullable: true),
                    SchoolBuildLandWorksPlanned = table.Column<int>(nullable: true),
                    SchoolBuildLandWorksPlannedExplained = table.Column<string>(nullable: true),
                    SchoolBuildLandWorksPlannedDate = table.Column<DateTime>(nullable: true),
                    SchoolBuildLandGrants = table.Column<int>(nullable: true),
                    SchoolBuildLandGrantsBody = table.Column<string>(nullable: true),
                    SchoolBuildLandPriorityBuildingProgramme = table.Column<int>(nullable: true),
                    SchoolBuildLandFutureProgramme = table.Column<int>(nullable: true),
                    SchoolBuildLandPFIScheme = table.Column<int>(nullable: true),
                    SchoolBuildLandPFISchemeType = table.Column<string>(nullable: true),
                    SchoolConsultationStakeholders = table.Column<int>(nullable: true),
                    SchoolConsultationStakeholdersConsult = table.Column<string>(nullable: true),
                    SchoolSupportGrantFundsPaidTo = table.Column<int>(nullable: true),
                    SchoolDeclarationSignedByName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplyingSchool", x => x.ApplyingSchoolsId);
                });

            migrationBuilder.CreateTable(
                name: "A2BContributor",
                schema: "sdd",
                columns: table => new
                {
                    ContributorUserId = table.Column<string>(nullable: false),
                    ApplicationTypeId = table.Column<string>(nullable: true),
                    ContributorAppIdTest = table.Column<string>(nullable: true),
                    ContributorUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BContributor", x => x.ContributorUserId);
                });

            migrationBuilder.CreateTable(
                name: "A2BCreateSchoolRequest",
                schema: "sdd",
                columns: table => new
                {
                    SchoolId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BCreateSchoolRequest", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "A2BSchoolLease",
                schema: "sdd",
                columns: table => new
                {
                    SchoolLeaseId = table.Column<string>(nullable: false),
                    SchoolLeaseTerm = table.Column<string>(nullable: true),
                    SchoolLeaseRepaymentValue = table.Column<string>(nullable: true),
                    SchoolLeaseInterestRate = table.Column<string>(nullable: true),
                    SchoolLeasePaymentToDate = table.Column<string>(nullable: true),
                    SchoolLeasePurpose = table.Column<string>(nullable: true),
                    SchoolLeaseValueOfAssets = table.Column<string>(nullable: true),
                    SchoolLeaseResponsibleForAssets = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BSchoolLease", x => x.SchoolLeaseId);
                });

            migrationBuilder.CreateTable(
                name: "A2BSchoolLoan",
                schema: "sdd",
                columns: table => new
                {
                    SchoolLoanId = table.Column<string>(nullable: false),
                    SchoolLoanAmount = table.Column<string>(nullable: true),
                    SchoolLoanPurpose = table.Column<string>(nullable: true),
                    SchoolLoanProvider = table.Column<string>(nullable: true),
                    SchoolLoanInterestRate = table.Column<string>(nullable: true),
                    SchoolLoanSchedule = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BSchoolLoan", x => x.SchoolLoanId);
                });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(180), "Red-Plus", new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(680) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(1070), new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(1080) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(1090), "Red-Amber", new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(1090) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(1090), "Amber-Green", new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(1100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(1100), new DateTime(2021, 11, 18, 15, 17, 20, 586, DateTimeKind.Local).AddTicks(1100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 571, DateTimeKind.Local).AddTicks(640), new DateTime(2021, 11, 18, 15, 17, 20, 575, DateTimeKind.Local).AddTicks(290) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 575, DateTimeKind.Local).AddTicks(880), new DateTime(2021, 11, 18, 15, 17, 20, 575, DateTimeKind.Local).AddTicks(900) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 575, DateTimeKind.Local).AddTicks(900), new DateTime(2021, 11, 18, 15, 17, 20, 575, DateTimeKind.Local).AddTicks(910) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(5940), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6400) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6760), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6770) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6780), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6790) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6790), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6790) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6790), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6790) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6790), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6800) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6800), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6800) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6800), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(6800) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7190), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7190) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7190), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7190) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7200), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7200) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7200), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7200) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7200), new DateTime(2021, 11, 18, 15, 17, 20, 584, DateTimeKind.Local).AddTicks(7200) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplication",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BApplicationKeyPersons",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BApplicationStatus",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BApplyingSchool",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BContributor",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BCreateSchoolRequest",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BSchoolLease",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BSchoolLoan",
                schema: "sdd");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(2270), "Red - Plus", new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(2680) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3070), new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3080) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3090), "Red - Amber", new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3090) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Name", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3090), "Amber - Green", new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsRating",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3100), new DateTime(2021, 11, 17, 16, 11, 50, 664, DateTimeKind.Local).AddTicks(3100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 649, DateTimeKind.Local).AddTicks(4020), new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(4920) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5410), new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5420) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5430), new DateTime(2021, 11, 17, 16, 11, 50, 652, DateTimeKind.Local).AddTicks(5440) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(8240), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(8650) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9060), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9070) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9080), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9080) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9080), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9090) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9110), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsType",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120), new DateTime(2021, 11, 17, 16, 11, 50, 662, DateTimeKind.Local).AddTicks(9120) });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class MergeA2BApplyingSchoolIntoA2BApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplyingSchool",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BCreateSchoolRequest",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "A2BSelectOption",
                schema: "sdd");

            migrationBuilder.CreateTable(
                name: "A2BApplicationApplyingSchool",
                schema: "sdd",
                columns: table => new
                {
                    ApplyingSchoolId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UpdatedTrustFields = table.Column<string>(nullable: true),
                    SchoolDeclarationSignedById = table.Column<string>(nullable: true),
                    SchoolDeclarationBodyAgree = table.Column<bool>(nullable: true),
                    SchoolDeclarationTeacherChair = table.Column<bool>(nullable: true),
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
                    SchoolLoanExists = table.Column<bool>(nullable: true),
                    SchoolLeaseExists = table.Column<bool>(nullable: true),
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
                    SchoolDeclarationSignedByName = table.Column<string>(nullable: true),
                    ApplicationId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationApplyingSchool", x => x.ApplyingSchoolId);
                    table.ForeignKey(
                        name: "FK_A2BApplicationApplyingSchool_A2BApplication_ApplicationId",
                        column: x => x.ApplicationId,
                        principalSchema: "sdd",
                        principalTable: "A2BApplication",
                        principalColumn: "ApplicationId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplicationApplyingSchool_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                column: "ApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "A2BApplicationApplyingSchool",
                schema: "sdd");

            migrationBuilder.CreateTable(
                name: "A2BCreateSchoolRequest",
                schema: "sdd",
                columns: table => new
                {
                    SchoolId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApplicationId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BCreateSchoolRequest", x => x.SchoolId);
                });

            migrationBuilder.CreateTable(
                name: "A2BSelectOption",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BSelectOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "A2BApplyingSchool",
                schema: "sdd",
                columns: table => new
                {
                    ApplyingSchoolId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAdEqualitiesImpactAssessment = table.Column<int>(type: "int", nullable: true),
                    SchoolAdFeederSchools = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAdInspectedButReportNotPublished = table.Column<int>(type: "int", nullable: true),
                    SchoolAdInspectedReportNotPublishedExplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAdSafeguarding = table.Column<int>(type: "int", nullable: true),
                    SchoolAdSafeguardingExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAdSchoolContributionToTrust = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolAddFurtherInformation = table.Column<int>(type: "int", nullable: true),
                    SchoolBuildLandFutureProgramme = table.Column<int>(type: "int", nullable: true),
                    SchoolBuildLandGrants = table.Column<int>(type: "int", nullable: true),
                    SchoolBuildLandGrantsBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolBuildLandOwnerExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolBuildLandPFIScheme = table.Column<int>(type: "int", nullable: true),
                    SchoolBuildLandPFISchemeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolBuildLandPriorityBuildingProgramme = table.Column<int>(type: "int", nullable: true),
                    SchoolBuildLandSharedFacilities = table.Column<int>(type: "int", nullable: true),
                    SchoolBuildLandSharedFacilitiesExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolBuildLandWorksPlanned = table.Column<int>(type: "int", nullable: true),
                    SchoolBuildLandWorksPlannedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolBuildLandWorksPlannedExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCFYCapitalForward = table.Column<double>(type: "float", nullable: true),
                    SchoolCFYCapitalForwardStatus = table.Column<int>(type: "int", nullable: true),
                    SchoolCFYCapitalForwardStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCFYEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolCFYRevenue = table.Column<double>(type: "float", nullable: true),
                    SchoolCFYRevenueStatus = table.Column<int>(type: "int", nullable: true),
                    SchoolCFYRevenueStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCapacityAssumptions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCapacityPublishedAdmissionsNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolCapacityYear1 = table.Column<int>(type: "int", nullable: true),
                    SchoolCapacityYear2 = table.Column<int>(type: "int", nullable: true),
                    SchoolCapacityYear3 = table.Column<int>(type: "int", nullable: true),
                    SchoolConsultationStakeholders = table.Column<int>(type: "int", nullable: true),
                    SchoolConsultationStakeholdersConsult = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionApproverContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionApproverContactName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionChangeName = table.Column<int>(type: "int", nullable: true),
                    SchoolConversionChangeNameValue = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactChairEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactChairName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactChairTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactHeadEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactHeadName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionContactHeadTel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionMainContact = table.Column<int>(type: "int", nullable: true),
                    SchoolConversionMainContactOtherEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionMainContactOtherName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionMainContactOtherRole = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionMainContactOtherTelephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionReasonsForJoining = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolConversionTargetDateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolConversionTargetDateDifferent = table.Column<int>(type: "int", nullable: true),
                    SchoolConversionTargetDateExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolDeclarationBodyAgree = table.Column<int>(type: "int", nullable: true),
                    SchoolDeclarationSignedByEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolDeclarationSignedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolDeclarationSignedByName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolDeclarationTeacherChair = table.Column<int>(type: "int", nullable: true),
                    SchoolFaithSchool = table.Column<int>(type: "int", nullable: true),
                    SchoolFaithSchoolDioceseName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolFinancialInvestigations = table.Column<int>(type: "int", nullable: true),
                    SchoolFinancialInvestigationsExplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolFinancialInvestigationsTrustAware = table.Column<int>(type: "int", nullable: true),
                    SchoolFurtherInformation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLaClosurePlans = table.Column<int>(type: "int", nullable: true),
                    SchoolLaClosurePlansExplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLaReorganization = table.Column<int>(type: "int", nullable: true),
                    SchoolLaReorganizationExplain = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolLeaseExists = table.Column<int>(type: "int", nullable: true),
                    SchoolLoanExists = table.Column<int>(type: "int", nullable: true),
                    SchoolNFYCapitalForward = table.Column<double>(type: "float", nullable: true),
                    SchoolNFYCapitalForwardStatus = table.Column<int>(type: "int", nullable: true),
                    SchoolNFYCapitalForwardStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolNFYEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolNFYRevenue = table.Column<double>(type: "float", nullable: true),
                    SchoolNFYRevenueStatus = table.Column<int>(type: "int", nullable: true),
                    SchoolNFYRevenueStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolPFYCapitalForward = table.Column<double>(type: "float", nullable: true),
                    SchoolPFYCapitalForwardStatus = table.Column<int>(type: "int", nullable: true),
                    SchoolPFYCapitalForwardStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolPFYEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolPFYRevenue = table.Column<double>(type: "float", nullable: true),
                    SchoolPFYRevenueStatus = table.Column<int>(type: "int", nullable: true),
                    SchoolPFYRevenueStatusExplained = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SchoolPartOfFederation = table.Column<int>(type: "int", nullable: true),
                    SchoolSACREExemption = table.Column<int>(type: "int", nullable: true),
                    SchoolSACREExemptionEndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SchoolSupportGrantFundsPaidTo = table.Column<int>(type: "int", nullable: true),
                    SchoolSupportedFoundation = table.Column<int>(type: "int", nullable: true),
                    SchoolSupportedFoundationBodyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedSchoolFields = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedTrustFields = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplyingSchool", x => x.ApplyingSchoolId);
                    table.ForeignKey(
                        name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolDeclarationBodyAgree",
                        column: x => x.SchoolDeclarationBodyAgree,
                        principalSchema: "sdd",
                        principalTable: "A2BSelectOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolDeclarationTeacherChair",
                        column: x => x.SchoolDeclarationTeacherChair,
                        principalSchema: "sdd",
                        principalTable: "A2BSelectOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolLeaseExists",
                        column: x => x.SchoolLeaseExists,
                        principalSchema: "sdd",
                        principalTable: "A2BSelectOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_A2BApplyingSchool_A2BSelectOption_SchoolLoanExists",
                        column: x => x.SchoolLoanExists,
                        principalSchema: "sdd",
                        principalTable: "A2BSelectOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplyingSchool_SchoolDeclarationBodyAgree",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolDeclarationBodyAgree");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplyingSchool_SchoolDeclarationTeacherChair",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolDeclarationTeacherChair");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplyingSchool_SchoolLeaseExists",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolLeaseExists");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplyingSchool_SchoolLoanExists",
                schema: "sdd",
                table: "A2BApplyingSchool",
                column: "SchoolLoanExists");
        }
    }
}

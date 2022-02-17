using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class A2BApplicationSchoolChangeIntToBool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SchoolCFYCapitalForwardStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolCFYRevenueStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolConversionMainContact",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolNFYCapitalForwardStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolNFYRevenueStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolPFYCapitalForwardStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolPFYRevenueStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolSupportedFoundation",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolSupportGrantFundsPaidTo",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolSACREExemption",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolPartOfFederation",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolPFYRevenue",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolPFYCapitalForward",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolNFYRevenue",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolNFYCapitalForward",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolLaReorganization",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolLaClosurePlans",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolFinancialInvestigationsTrustAware",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolFinancialInvestigations",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolFaithSchool",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolConversionTargetDateDifferent",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolConversionChangeName",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolConsultationStakeholders",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolCapacityPublishedAdmissionsNumber",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolCFYRevenue",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolCFYCapitalForward",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolBuildLandWorksPlanned",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolBuildLandSharedFacilities",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolBuildLandPriorityBuildingProgramme",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolBuildLandPFIScheme",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolBuildLandGrants",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolBuildLandFutureProgramme",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolAddFurtherInformation",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolAdSafeguarding",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolAdInspectedButReportNotPublished",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "SchoolAdEqualitiesImpactAssessment",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SchoolConversionContactRole",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplyingSchoolId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolConversionContactRole",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.AlterColumn<int>(
                name: "SchoolSupportedFoundation",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolSupportGrantFundsPaidTo",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolSACREExemption",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolPartOfFederation",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SchoolPFYRevenue",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SchoolPFYCapitalForward",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SchoolNFYRevenue",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SchoolNFYCapitalForward",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolLaReorganization",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolLaClosurePlans",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolFinancialInvestigationsTrustAware",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolFinancialInvestigations",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolFaithSchool",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolConversionTargetDateDifferent",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolConversionChangeName",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolConsultationStakeholders",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SchoolCapacityPublishedAdmissionsNumber",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SchoolCFYRevenue",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "SchoolCFYCapitalForward",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "float",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolBuildLandWorksPlanned",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolBuildLandSharedFacilities",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolBuildLandPriorityBuildingProgramme",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolBuildLandPFIScheme",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolBuildLandGrants",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolBuildLandFutureProgramme",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolAddFurtherInformation",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolAdSafeguarding",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolAdInspectedButReportNotPublished",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SchoolAdEqualitiesImpactAssessment",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "KeyPersonId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "SchoolCFYCapitalForwardStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolCFYRevenueStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolConversionMainContact",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolNFYCapitalForwardStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolNFYRevenueStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolPFYCapitalForwardStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SchoolPFYRevenueStatus",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_A2BApplicationApplyingSchool",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                column: "KeyPersonId");
        }
    }
}

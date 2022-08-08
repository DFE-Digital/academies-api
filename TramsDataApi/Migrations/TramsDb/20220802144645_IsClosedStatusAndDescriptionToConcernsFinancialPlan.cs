using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class IsClosedStatusAndDescriptionToConcernsFinancialPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "sdd",
                table: "FinancialPlanStatus",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsClosedStatus",
                schema: "sdd",
                table: "FinancialPlanStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "FinancialPlanStatus",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Description",
                value: "Awaiting Plan");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "FinancialPlanStatus",
                keyColumn: "Id",
                keyValue: 2L,
                column: "Description",
                value: "Return To Trust");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "FinancialPlanStatus",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "Description", "IsClosedStatus" },
                values: new object[] { "Viable Plan Received", true });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "FinancialPlanStatus",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "Description", "IsClosedStatus" },
                values: new object[] { "Abandoned", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                schema: "sdd",
                table: "FinancialPlanStatus");

            migrationBuilder.DropColumn(
                name: "IsClosedStatus",
                schema: "sdd",
                table: "FinancialPlanStatus");
        }
    }
}

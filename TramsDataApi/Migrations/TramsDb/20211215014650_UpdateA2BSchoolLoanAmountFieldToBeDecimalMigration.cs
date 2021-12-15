using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class UpdateA2BSchoolLoanAmountFieldToBeDecimalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolLoanAmount",
                schema: "sdd",
                table: "A2BSchoolLoan",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SchoolLoanAmount",
                schema: "sdd",
                table: "A2BSchoolLoan",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);
        }
    }
}

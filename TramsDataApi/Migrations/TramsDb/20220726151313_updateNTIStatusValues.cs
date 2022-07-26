using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class updateNTIStatusValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Standard conditions (mandatory)");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Non-compliance with Academies Financial/Trust Handbook");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Non-compliance with financial returns");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Conditions have not been met. Close NTI: Warning letter and begin NTI on case page using \"Add to case\".");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterConditionType",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Standard conditions (Mandatory)");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Non-Compliance with Academies Financial/Trust Handbook");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterReason",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Non-Compliance with financial returns");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Conditions have not been met. Close NTI: Warning letter and begin NTI on case page using \"Add to case\"");
        }
    }
}

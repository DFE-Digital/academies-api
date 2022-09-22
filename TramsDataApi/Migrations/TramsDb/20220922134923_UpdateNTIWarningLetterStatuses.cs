using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class UpdateNTIWarningLetterStatuses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "PastTenseName",
                value: "Cancelled");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "PastTenseName",
                value: "Escalated to Notice To Improve");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 3,
                column: "PastTenseName",
                value: "Conditions met");

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "NTIWarningLetterStatus",
                keyColumn: "Id",
                keyValue: 5,
                column: "PastTenseName",
                value: "Conditions met");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class ATAddHasDateFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasHtbDate",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasTargetDateForTransfer",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasTransferFirstDiscussedDate",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasHtbDate",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "HasTargetDateForTransfer",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "HasTransferFirstDiscussedDate",
                schema: "sdd",
                table: "AcademyTransferProjects");
        }
    }
}

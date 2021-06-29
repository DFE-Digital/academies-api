using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class atgeneralinformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Recommendation",
                schema: "sdd",
                table: "AcademyTransferProjects",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                schema: "sdd",
                table: "AcademyTransferProjects");

            migrationBuilder.DropColumn(
                name: "Recommendation",
                schema: "sdd",
                table: "AcademyTransferProjects");
        }
    }
}

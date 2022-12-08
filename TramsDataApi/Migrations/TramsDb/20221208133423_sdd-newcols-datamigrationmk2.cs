using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class sddnewcolsdatamigrationmk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalAuthorityName",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Urn",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalAuthorityName",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "Urn",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");
        }
    }
}

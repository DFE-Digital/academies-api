using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddConcernsTeamCaseworkSelectedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcernsTeamCaseworkSelectedUser",
                schema: "sdd",
                columns: table => new
                {
                    OwnerId = table.Column<string>(nullable: false),
                    SelectedTeamMember = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsTeamCaseworkSelectedUser", x => new { x.OwnerId, x.SelectedTeamMember });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernsTeamCaseworkSelectedUser",
                schema: "sdd");
        }
    }
}

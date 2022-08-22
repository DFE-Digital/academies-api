using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddConcernsTeamCaseworkSelectedUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcernsTeamCaseworkTeam",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsTeamCaseworkTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsTeamCaseworkTeamMember",
                schema: "sdd",
                columns: table => new
                {
                    TeamMemberId = table.Column<Guid>(nullable: false),
                    TeamMember = table.Column<string>(nullable: true),
                    ConcernsCaseworkTeamId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsTeamCaseworkTeamMember", x => x.TeamMemberId);
                    table.ForeignKey(
                        name: "FK_ConcernsTeamCaseworkTeamMember_ConcernsTeamCaseworkTeam_ConcernsCaseworkTeamId",
                        column: x => x.ConcernsCaseworkTeamId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsTeamCaseworkTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsTeamCaseworkTeamMember_ConcernsCaseworkTeamId",
                schema: "sdd",
                table: "ConcernsTeamCaseworkTeamMember",
                column: "ConcernsCaseworkTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernsTeamCaseworkTeamMember",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsTeamCaseworkTeam",
                schema: "sdd");
        }
    }
}

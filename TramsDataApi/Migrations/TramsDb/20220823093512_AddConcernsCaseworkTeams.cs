using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AddConcernsCaseworkTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcernsCaseworkTeam",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsCaseworkTeam", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConcernsCaseworkTeamMember",
                schema: "sdd",
                columns: table => new
                {
                    TeamMemberId = table.Column<Guid>(nullable: false),
                    TeamMember = table.Column<string>(nullable: true),
                    ConcernsCaseworkTeamId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcernsCaseworkTeamMember", x => x.TeamMemberId);
                    table.ForeignKey(
                        name: "FK_ConcernsCaseworkTeamMember_ConcernsCaseworkTeam_ConcernsCaseworkTeamId",
                        column: x => x.ConcernsCaseworkTeamId,
                        principalSchema: "sdd",
                        principalTable: "ConcernsCaseworkTeam",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsCaseworkTeamMember_ConcernsCaseworkTeamId",
                schema: "sdd",
                table: "ConcernsCaseworkTeamMember",
                column: "ConcernsCaseworkTeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcernsCaseworkTeamMember",
                schema: "sdd");

            migrationBuilder.DropTable(
                name: "ConcernsCaseworkTeam",
                schema: "sdd");
        }
    }
}

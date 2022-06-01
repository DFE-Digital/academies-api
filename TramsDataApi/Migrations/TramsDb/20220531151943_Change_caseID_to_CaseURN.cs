using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class Change_caseID_to_CaseURN : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SRMACase_ConcernsCase_CaseId",
                schema: "sdd",
                table: "SRMACase");

            migrationBuilder.DropIndex(
                name: "IX_SRMACase_CaseId",
                schema: "sdd",
                table: "SRMACase");

            migrationBuilder.DropColumn(
                name: "CaseId",
                schema: "sdd",
                table: "SRMACase");

            migrationBuilder.AddColumn<int>(
                name: "CaseUrn",
                schema: "sdd",
                table: "SRMACase",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CaseUrn",
                schema: "sdd",
                table: "SRMACase");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                schema: "sdd",
                table: "SRMACase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SRMACase_CaseId",
                schema: "sdd",
                table: "SRMACase",
                column: "CaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_SRMACase_ConcernsCase_CaseId",
                schema: "sdd",
                table: "SRMACase",
                column: "CaseId",
                principalSchema: "sdd",
                principalTable: "ConcernsCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

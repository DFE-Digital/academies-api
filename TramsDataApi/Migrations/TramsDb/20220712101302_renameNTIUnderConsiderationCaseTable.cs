using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class renameNTIUnderConsiderationCaseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NTIUnderConsideration_NTIUnderConsiderationStatus_ClosedStatusId",
                schema: "sdd",
                table: "NTIUnderConsideration");

            migrationBuilder.DropForeignKey(
                name: "FK_NTIUnderConsiderationReasonMapping_NTIUnderConsideration_NTIUnderConsiderationId",
                schema: "sdd",
                table: "NTIUnderConsiderationReasonMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NTIUnderConsideration",
                schema: "sdd",
                table: "NTIUnderConsideration");

            migrationBuilder.RenameTable(
                name: "NTIUnderConsideration",
                schema: "sdd",
                newName: "NTIUnderConsiderationCase",
                newSchema: "sdd");

            migrationBuilder.RenameIndex(
                name: "IX_NTIUnderConsideration_ClosedStatusId",
                schema: "sdd",
                table: "NTIUnderConsiderationCase",
                newName: "IX_NTIUnderConsiderationCase_ClosedStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NTIUnderConsiderationCase",
                schema: "sdd",
                table: "NTIUnderConsiderationCase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NTIUnderConsiderationCase_NTIUnderConsiderationStatus_ClosedStatusId",
                schema: "sdd",
                table: "NTIUnderConsiderationCase",
                column: "ClosedStatusId",
                principalSchema: "sdd",
                principalTable: "NTIUnderConsiderationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NTIUnderConsiderationReasonMapping_NTIUnderConsiderationCase_NTIUnderConsiderationId",
                schema: "sdd",
                table: "NTIUnderConsiderationReasonMapping",
                column: "NTIUnderConsiderationId",
                principalSchema: "sdd",
                principalTable: "NTIUnderConsiderationCase",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NTIUnderConsiderationCase_NTIUnderConsiderationStatus_ClosedStatusId",
                schema: "sdd",
                table: "NTIUnderConsiderationCase");

            migrationBuilder.DropForeignKey(
                name: "FK_NTIUnderConsiderationReasonMapping_NTIUnderConsiderationCase_NTIUnderConsiderationId",
                schema: "sdd",
                table: "NTIUnderConsiderationReasonMapping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NTIUnderConsiderationCase",
                schema: "sdd",
                table: "NTIUnderConsiderationCase");

            migrationBuilder.RenameTable(
                name: "NTIUnderConsiderationCase",
                schema: "sdd",
                newName: "NTIUnderConsideration",
                newSchema: "sdd");

            migrationBuilder.RenameIndex(
                name: "IX_NTIUnderConsiderationCase_ClosedStatusId",
                schema: "sdd",
                table: "NTIUnderConsideration",
                newName: "IX_NTIUnderConsideration_ClosedStatusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NTIUnderConsideration",
                schema: "sdd",
                table: "NTIUnderConsideration",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NTIUnderConsideration_NTIUnderConsiderationStatus_ClosedStatusId",
                schema: "sdd",
                table: "NTIUnderConsideration",
                column: "ClosedStatusId",
                principalSchema: "sdd",
                principalTable: "NTIUnderConsiderationStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_NTIUnderConsiderationReasonMapping_NTIUnderConsideration_NTIUnderConsiderationId",
                schema: "sdd",
                table: "NTIUnderConsiderationReasonMapping",
                column: "NTIUnderConsiderationId",
                principalSchema: "sdd",
                principalTable: "NTIUnderConsideration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class UpdateConcernsCaseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Case_fk_Status",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropIndex(
                name: "IX_ConcernsCase_fk_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropColumn(
                name: "fk_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropColumn(
                name: "ReasonForReview",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropColumn(
                name: "ReviewedAt",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.AddColumn<int>(
                name: "ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConcernsStatusUrn",
                schema: "sdd",
                table: "ConcernsCase",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReasonAtReview",
                schema: "sdd",
                table: "ConcernsCase",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewAt",
                schema: "sdd",
                table: "ConcernsCase",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 40, 56, 645, DateTimeKind.Local).AddTicks(9630), new DateTime(2021, 11, 1, 14, 40, 56, 648, DateTimeKind.Local).AddTicks(8580) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 40, 56, 648, DateTimeKind.Local).AddTicks(9030), new DateTime(2021, 11, 1, 14, 40, 56, 648, DateTimeKind.Local).AddTicks(9050) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 1, 14, 40, 56, 648, DateTimeKind.Local).AddTicks(9060), new DateTime(2021, 11, 1, 14, 40, 56, 648, DateTimeKind.Local).AddTicks(9060) });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsCase_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase",
                column: "ConcernsStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_ConcernsCase_ConcernsStatus_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase",
                column: "ConcernsStatusId",
                principalSchema: "sdd",
                principalTable: "ConcernsStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConcernsCase_ConcernsStatus_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropIndex(
                name: "IX_ConcernsCase_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropColumn(
                name: "ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropColumn(
                name: "ConcernsStatusUrn",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropColumn(
                name: "ReasonAtReview",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.DropColumn(
                name: "ReviewAt",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.AddColumn<int>(
                name: "fk_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReasonForReview",
                schema: "sdd",
                table: "ConcernsCase",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ReviewedAt",
                schema: "sdd",
                table: "ConcernsCase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 20, 19, 14, 3, 879, DateTimeKind.Local).AddTicks(1210), new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(1600) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(2090), new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(2100) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(2110), new DateTime(2021, 10, 20, 19, 14, 3, 882, DateTimeKind.Local).AddTicks(2120) });

            migrationBuilder.CreateIndex(
                name: "IX_ConcernsCase_fk_ConcernsStatusId",
                schema: "sdd",
                table: "ConcernsCase",
                column: "fk_ConcernsStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Case_fk_Status",
                schema: "sdd",
                table: "ConcernsCase",
                column: "fk_ConcernsStatusId",
                principalSchema: "sdd",
                principalTable: "ConcernsStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

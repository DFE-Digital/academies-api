using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class UpdateConcernsCaseStatusMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcernsStatusUrn",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.AddColumn<int>(
                name: "StatusUrn",
                schema: "sdd",
                table: "ConcernsCase",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 1, 15, 46, 15, 533, DateTimeKind.Local).AddTicks(3970), new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(2910) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(3380), new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(3400) });

            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "ConcernsStatus",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(3410), new DateTime(2021, 11, 1, 15, 46, 15, 536, DateTimeKind.Local).AddTicks(3410) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StatusUrn",
                schema: "sdd",
                table: "ConcernsCase");

            migrationBuilder.AddColumn<string>(
                name: "ConcernsStatusUrn",
                schema: "sdd",
                table: "ConcernsCase",
                type: "nvarchar(max)",
                nullable: true);

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
        }
    }
}

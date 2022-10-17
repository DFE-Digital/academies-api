using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class concernsDecisionsRenameCreatedAt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAtDateTimeOffset",
                schema: "sdd",
                table: "ConcernsDecision");

            migrationBuilder.DropColumn(
                name: "UpdatedAtDateTimeOffset",
                schema: "sdd",
                table: "ConcernsDecision");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAt",
                schema: "sdd",
                table: "ConcernsDecision",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAt",
                schema: "sdd",
                table: "ConcernsDecision",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "sdd",
                table: "ConcernsDecision");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "sdd",
                table: "ConcernsDecision");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedAtDateTimeOffset",
                schema: "sdd",
                table: "ConcernsDecision",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "UpdatedAtDateTimeOffset",
                schema: "sdd",
                table: "ConcernsDecision",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }
    }
}

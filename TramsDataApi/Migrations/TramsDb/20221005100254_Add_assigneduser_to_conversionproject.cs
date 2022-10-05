using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class Add_assigneduser_to_conversionproject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedUserEmailAddress",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AssignedUserFullName",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AssignedUserId",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedUserEmailAddress",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.DropColumn(
                name: "AssignedUserFullName",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.DropColumn(
                name: "AssignedUserId",
                schema: "sdd",
                table: "AcademyConversionProject");
        }
    }
}

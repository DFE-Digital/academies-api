using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class datesschoolbudget : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "EndOfCurrentFinancialYear",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndOfNextFinancialYear",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndOfCurrentFinancialYear",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.DropColumn(
                name: "EndOfNextFinancialYear",
                schema: "sdd",
                table: "AcademyConversionProject");
        }
    }
}

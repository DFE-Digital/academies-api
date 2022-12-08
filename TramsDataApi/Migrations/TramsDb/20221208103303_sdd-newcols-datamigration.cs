using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class sddnewcolsdatamigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DynamicsSchoolLoanId",
                schema: "sdd",
                table: "A2BSchoolLoan",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DynamicsSchoolLeaseId",
                schema: "sdd",
                table: "A2BSchoolLease",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DynamicsKeyPersonId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DynamicsApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DynamicsApplyingSchoolId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "DynamicsApplicationId",
                schema: "sdd",
                table: "A2BApplication",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DynamicsSchoolLoanId",
                schema: "sdd",
                table: "A2BSchoolLoan");

            migrationBuilder.DropColumn(
                name: "DynamicsSchoolLeaseId",
                schema: "sdd",
                table: "A2BSchoolLease");

            migrationBuilder.DropColumn(
                name: "DynamicsKeyPersonId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons");

            migrationBuilder.DropColumn(
                name: "DynamicsApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "DynamicsApplyingSchoolId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "DynamicsApplicationId",
                schema: "sdd",
                table: "A2BApplication");
        }
    }
}

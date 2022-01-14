using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class UpdateA2BApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "KeyPersonFinancialDirector",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "KeyPersonDateOfBirth",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "KeyPersonChairOfTrust",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "KeyPersonCeoExecutive",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "FormTrustReasonApprovalToConvertAsSat",
                schema: "sdd",
                table: "A2BApplication",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "FormTrustGrowthPlansYesNo",
                schema: "sdd",
                table: "A2BApplication",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ChangesToTrust",
                schema: "sdd",
                table: "A2BApplication",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ChangesToLaGovernance",
                schema: "sdd",
                table: "A2BApplication",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationLeadEmail",
                schema: "sdd",
                table: "A2BApplication",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ApplicationStatusId",
                schema: "sdd",
                table: "A2BApplication",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "A2BApplicationType",
                schema: "sdd",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A2BApplicationType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplicationKeyPersons_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplication_ApplicationType",
                schema: "sdd",
                table: "A2BApplication",
                column: "ApplicationType");

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplication_A2BApplicationType_ApplicationType",
                schema: "sdd",
                table: "A2BApplication",
                column: "ApplicationType",
                principalSchema: "sdd",
                principalTable: "A2BApplicationType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplicationKeyPersons_A2BApplication_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                column: "ApplicationId",
                principalSchema: "sdd",
                principalTable: "A2BApplication",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.InsertData(
                schema: "sdd",
                table: "A2BApplicationType",
                columns: new[] {"Id", "Name"},
                values: new object[] {100000001, "JoinMat"});
                        
            migrationBuilder.InsertData(
                schema: "sdd",
                table: "A2BApplicationType",
                columns: new[] {"Id", "Name"},
                values: new object[] {907660000, "FormMat"});
                        
            migrationBuilder.InsertData(
                schema: "sdd",
                table: "A2BApplicationType",
                columns: new[] {"Id", "Name"},
                values: new object[] {907660001, "FormSat"});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplication_A2BApplicationType_ApplicationType",
                schema: "sdd",
                table: "A2BApplication");

            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplicationKeyPersons_A2BApplication_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons");

            migrationBuilder.DropTable(
                name: "A2BApplicationType",
                schema: "sdd");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplicationKeyPersons_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplication_ApplicationType",
                schema: "sdd",
                table: "A2BApplication");

            migrationBuilder.DropColumn(
                name: "ApplicationId",
                schema: "sdd",
                table: "A2BApplicationKeyPersons");

            migrationBuilder.DropColumn(
                name: "ApplicationLeadEmail",
                schema: "sdd",
                table: "A2BApplication");

            migrationBuilder.DropColumn(
                name: "ApplicationStatusId",
                schema: "sdd",
                table: "A2BApplication");

            migrationBuilder.AlterColumn<string>(
                name: "KeyPersonFinancialDirector",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KeyPersonDateOfBirth",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KeyPersonChairOfTrust",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KeyPersonCeoExecutive",
                schema: "sdd",
                table: "A2BApplicationKeyPersons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FormTrustReasonApprovalToConvertAsSat",
                schema: "sdd",
                table: "A2BApplication",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FormTrustGrowthPlansYesNo",
                schema: "sdd",
                table: "A2BApplication",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChangesToTrust",
                schema: "sdd",
                table: "A2BApplication",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ChangesToLaGovernance",
                schema: "sdd",
                table: "A2BApplication",
                type: "int",
                nullable: true,
                oldClrType: typeof(bool),
                oldNullable: true);
        }
    }
}

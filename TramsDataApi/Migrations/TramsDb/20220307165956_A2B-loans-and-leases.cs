using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class A2Bloansandleases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplicationApplyingSchool_A2BApplication_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplicationApplyingSchool_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolLeaseExists",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "SchoolLoanExists",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.AddColumn<int>(
                name: "A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "A2BApplicationApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_A2BSchoolLoan_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan",
                column: "A2BApplicationApplyingSchoolApplyingSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BSchoolLease_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease",
                column: "A2BApplicationApplyingSchoolApplyingSchoolId");

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplicationApplyingSchool_A2BApplicationApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                column: "A2BApplicationApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplicationApplyingSchool_A2BApplication_A2BApplicationApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                column: "A2BApplicationApplicationId",
                principalSchema: "sdd",
                principalTable: "A2BApplication",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_A2BSchoolLease_A2BApplicationApplyingSchool_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease",
                column: "A2BApplicationApplyingSchoolApplyingSchoolId",
                principalSchema: "sdd",
                principalTable: "A2BApplicationApplyingSchool",
                principalColumn: "ApplyingSchoolId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_A2BSchoolLoan_A2BApplicationApplyingSchool_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan",
                column: "A2BApplicationApplyingSchoolApplyingSchoolId",
                principalSchema: "sdd",
                principalTable: "A2BApplicationApplyingSchool",
                principalColumn: "ApplyingSchoolId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_A2BApplicationApplyingSchool_A2BApplication_A2BApplicationApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropForeignKey(
                name: "FK_A2BSchoolLease_A2BApplicationApplyingSchool_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease");

            migrationBuilder.DropForeignKey(
                name: "FK_A2BSchoolLoan_A2BApplicationApplyingSchool_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan");

            migrationBuilder.DropIndex(
                name: "IX_A2BSchoolLoan_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan");

            migrationBuilder.DropIndex(
                name: "IX_A2BSchoolLease_A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease");

            migrationBuilder.DropIndex(
                name: "IX_A2BApplicationApplyingSchool_A2BApplicationApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.DropColumn(
                name: "A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan");

            migrationBuilder.DropColumn(
                name: "ApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLoan");

            migrationBuilder.DropColumn(
                name: "A2BApplicationApplyingSchoolApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease");

            migrationBuilder.DropColumn(
                name: "ApplyingSchoolId",
                schema: "sdd",
                table: "A2BSchoolLease");

            migrationBuilder.DropColumn(
                name: "A2BApplicationApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SchoolLeaseExists",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SchoolLoanExists",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_A2BApplicationApplyingSchool_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                column: "ApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_A2BApplicationApplyingSchool_A2BApplication_ApplicationId",
                schema: "sdd",
                table: "A2BApplicationApplyingSchool",
                column: "ApplicationId",
                principalSchema: "sdd",
                principalTable: "A2BApplication",
                principalColumn: "ApplicationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class A2Bloansandleases2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_A2BSchoolLoan",
                schema: "sdd",
                table: "A2BSchoolLoan");

            migrationBuilder.DropColumn(
                name: "SchoolLoanId",
                schema: "sdd",
                table: "A2BSchoolLoan");

            migrationBuilder.AddColumn<int>(
                name: "SchoolLoanId",
                schema: "sdd",
                table: "A2BSchoolLoan",
                nullable: false
                )
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_A2BSchoolLoan",
                schema: "sdd",
                column: "SchoolLoanId",
                table: "A2BSchoolLoan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_A2BSchoolLease",
                schema: "sdd",
                table: "A2BSchoolLease");

            migrationBuilder.DropColumn(
                name: "SchoolLeaseId",
                schema: "sdd",
                table: "A2BSchoolLease");

            migrationBuilder.AddColumn<int>(
                name: "SchoolLeaseId",
                schema: "sdd",
                table: "A2BSchoolLease",
                nullable: false)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_A2BSchoolLease",
                schema: "sdd",
                column: "SchoolLeaseId",
                table: "A2BSchoolLease");

            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolLeaseRepaymentValue",
                schema: "sdd",
                table: "A2BSchoolLease",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolLeasePaymentToDate",
                schema: "sdd",
                table: "A2BSchoolLease",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "SchoolLeaseInterestRate",
                schema: "sdd",
                table: "A2BSchoolLease",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_A2BSchoolLoan",
                schema: "sdd",
                table: "A2BSchoolLoan");

            migrationBuilder.DropColumn(
                name: "SchoolLoanId",
                schema: "sdd",
                table: "A2BSchoolLoan");

            migrationBuilder.AddColumn<string>(
                name: "SchoolLoanId",
                schema: "sdd",
                table: "A2BSchoolLoan",
                nullable: false
                );

            migrationBuilder.AddPrimaryKey(
                name: "PK_A2BSchoolLoan",
                schema: "sdd",
                column: "SchoolLoanId",
                table: "A2BSchoolLoan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_A2BSchoolLease",
                schema: "sdd",
                table: "A2BSchoolLease");

            migrationBuilder.DropColumn(
                name: "SchoolLeaseId",
                schema: "sdd",
                table: "A2BSchoolLease");

            migrationBuilder.AddColumn<string>(
                name: "SchoolLeaseId",
                schema: "sdd",
                table: "A2BSchoolLease",
                nullable: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_A2BSchoolLease",
                schema: "sdd",
                column: "SchoolLeaseId",
                table: "A2BSchoolLease");

             migrationBuilder.AlterColumn<string>(
                name: "SchoolLeaseRepaymentValue",
                schema: "sdd",
                table: "A2BSchoolLease",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolLeasePaymentToDate",
                schema: "sdd",
                table: "A2BSchoolLease",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolLeaseInterestRate",
                schema: "sdd",
                table: "A2BSchoolLease",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}

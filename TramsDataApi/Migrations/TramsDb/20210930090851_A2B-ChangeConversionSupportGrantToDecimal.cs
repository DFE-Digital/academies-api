using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class A2BChangeConversionSupportGrantToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "ConversionSupportGrantAmount",
                schema: "sdd",
                table: "AcademyConversionProject",
                type: "decimal(38, 2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ConversionSupportGrantAmount",
                schema: "sdd",
                table: "AcademyConversionProject",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(38, 2)");
        }
    }
}

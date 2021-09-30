using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class A2BSetExistingConversionTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                schema: "sdd",
                table: "AcademyConversionProject",
                column: "AcademyTypeAndRoute",
                value: "Converter",
                keyColumn: "AcademyTypeAndRoute",
                keyValue: null
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
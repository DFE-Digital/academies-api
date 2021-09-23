using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class A2BAddConversionGrantFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConversionSupportGrantAmount",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: false,
                defaultValue: 25000);

            migrationBuilder.AddColumn<string>(
                name: "ConversionSupportGrantChangeReason",
                schema: "sdd",
                table: "AcademyConversionProject",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConversionSupportGrantAmount",
                schema: "sdd",
                table: "AcademyConversionProject");

            migrationBuilder.DropColumn(
                name: "ConversionSupportGrantChangeReason",
                schema: "sdd",
                table: "AcademyConversionProject");
        }
    }
}
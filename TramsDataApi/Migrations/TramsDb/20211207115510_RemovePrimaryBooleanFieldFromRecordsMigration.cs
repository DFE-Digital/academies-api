using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class RemovePrimaryBooleanFieldFromRecordsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Primary",
                schema: "sdd",
                table: "ConcernsRecord");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Primary",
                schema: "sdd",
                table: "ConcernsRecord",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

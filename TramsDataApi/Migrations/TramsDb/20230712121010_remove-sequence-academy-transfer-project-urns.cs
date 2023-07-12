using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class removesequenceacademytransferprojecturns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"IF EXISTS(SELECT 1 FROM sys.sequences WHERE name = 'AcademyTransferProjectUrns' and SCHEMA_NAME(schema_id) = 'dbo')
                                     BEGIN
                                       DROP SEQUENCE [dbo].[AcademyTransferProjectUrns]
                                     END");

            migrationBuilder.Sql(@"IF EXISTS(SELECT 1 FROM sys.sequences WHERE name = 'AcademyTransferProjectUrns' and SCHEMA_NAME(schema_id) = 'sdd')
                                     BEGIN
                                       DROP SEQUENCE [sdd].[AcademyTransferProjectUrns]
                                     END");
        }
    }
}

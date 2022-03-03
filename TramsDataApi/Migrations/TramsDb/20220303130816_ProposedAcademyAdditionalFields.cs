using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class ProposedAcademyAdditionalFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            _ = migrationBuilder.Sql(@"CREATE  VIEW sdd.vw_proposed_academy_additional_fields
                                        AS 
                                    SELECT 
                                    /* Academy data */
                                    a.[URN] 
                                    ,NewLAEstab = CONCAT(la.[Code],'/',e.[EstablishmentNumber])
                                    /* Trust data */
                                    ,NewUPIN = t.[UPIN]
                                    ,TrustUKPRN = t.[UKPRN]
                                    /* Pipeline data */
                                    ,NewURN = p.[Proposed Academy Details.New Academy URN]
                                    ,NewAcademyName =p.[Proposed Academy Details.New Academy Name] 
                                    ,AcademyUKPRN = p.[General Details.Academy UKPRN]

                                    FROM [sdd].[AcademyConversionProject] a
                                    INNER JOIN [mstr].[EducationEstablishment] e ON a.Urn = e.URN
                                    INNER JOIN [mstr].[Ref_LocalAuthority] la ON e.[FK_LocalAuthority] = la.[SK]
                                    LEFT OUTER JOIN [mstr].[EducationEstablishmentTrust] et ON e.[SK] = et.[FK_EducationEstablishment]
                                    LEFT OUTER JOIN [mstr].[Trust] t ON et.[FK_Trust] = t.[SK]
                                    LEFT OUTER JOIN [mstr].[IfdPipeline] p ON e.[URN] =  p.[General Details.URN]");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"drop view sdd.vw_proposed_academy_additional_fields");

        }
    }
}

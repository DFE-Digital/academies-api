using Microsoft.EntityFrameworkCore.Migrations;

namespace TramsDataApi.Migrations.TramsDb
{
    public partial class AlterFSSProjectData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
//             ALTER VIEW [fsg].[vw_Fss_ProjectData]
//                   AS
//                   SELECT
//                    [Project Status.Current free school name] AS CurrentFreeSchoolName
//                   ,[Project Status.Project status] AS ProjectStatus
//                   ,[Project Status.Project ID] AS ProjectId
//                   ,[Project Status.Free school application wave] AS ApplicationWave
//                   ,[Project Status.Provisional opening date agreed with trust] AS ProvisionalOpeningDateAgreedWithTrust
//                   ,[Project Status.Actual opening date] AS ActualOpeningDate
//                   ,[Project Status.Free school pen portrait] AS FreeSchoolPenPortrait
//                   ,[Project Status.URN (when given one)] AS URN
//                 ,[Project Status.Date closed] AS DateSchoolClosed
//                 ,[Project Status.Date of entry into pre-opening] As DateOfEntryIntoPreOpening
//                   ,[Local authority] AS LocalAuthority
//                   ,[School Details.LAESTAB (when given one)] AS LAESTAB
//                   ,[School Details.RSC region] AS RSCRegion
//                   ,[School Details.Number of forms of entry] AS NumberOfFormsOfEntry
//                   ,[School Details.School type (mainstream, AP etc)] AS SchoolType
//                   ,[School Details.School phase (primary, secondary)] AS SchoolPhase
//                   ,[School Details.Age range] AS AgeRange
//                   ,[School Details.Gender] AS Gender
//                   ,[School Details.Residential or boarding provision] AS ResidentialOrBoardingProvision
//                 ,[School Details.Details of residential/boarding provision] AS ResidentialBoardingProvisionDetails
//                   ,[School Details.Nursery] AS Nursery
//                   ,[School Details.Sixth form] AS SixthForm
//                   ,[School Details.Sixth form type] AS SixthFormType
//                   ,[School Details.Faith status] AS FaithStatus
//                   ,[School Details.Faith type] AS FaithType
//                   ,[School Details.Please specify other faith type] AS OtherFaithType
//                   ,[School Details.Specialism] AS Specialism
//                   ,[School Details.Trust ID] AS TrustId
//                   ,[School Details.Trust name] AS TrustName
//                   ,[Key Contacts.School address] AS SchoolAddress
//                   ,[Key Contacts.Postcode] As Postcode
//                   ,[Key Contacts.FSG lead contact] AS FSGLeadContact
//                   ,[FSG Pre Opening Milestones.Kick off meeting held Actual Date] AS KickOfMeetingHeldDate
//                 ,[FSG Pre Opening Milestones.FA Actual date of completion] AS FAActualCompletionDate
//                 ,[FSG Pre Opening Milestones.FA Forecast date] AS FAForecastDate
// ,[Project Status.Realistic year of opening] AS RealisticYearofOpening
// ,[School Details.Constituency MP] AS MemberOfParliament
//                 FROM [fsg].[KPI] KPI
//                 LEFT JOIN [fsg].[Milestones] Milestones ON KPI.[RID] = Milestones.RID
// WHERE [Project Status.Project ID] IS NOT NULL
// GO
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

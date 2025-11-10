using Dfe.Academies.Domain.SignificantChange; 
using Dfe.Academies.Infrastructure;

namespace Dfe.Academies.Tests.Common.Seeders
{
    public static class SigChgMstrContextSeeder
    {
        public static void Seed(SigChgMstrContext sigChgMstrContext)
        {
            if (!sigChgMstrContext.SignificantChanges.Any())
            {
                // Populate Trust
                var significantChange1 = new SignificantChange
                {
                    SignificantChangeId = 1,
                    LocalAuthority = "Warwickshire",
                    TrustName = "Trust A",
                    MetaSourceSystem = "Academies Dev Spoof Table",
                    ChangeCreationDate = DateTime.UtcNow,
                    DecisionDate = DateOnly.FromDateTime(DateTime.UtcNow),
                    ChangeEditDate = DateTime.UtcNow,
                    CreatedUserName = "User A",
                    AcademyName = "Nicholas Chamberlaine School",
                    AllActionsCompleted = true,
                    ApplicationType = "Tier 1",
                    EditedUserName = "Editor A",
                    MetaIngestionDateTime = DateTime.UtcNow.ToString("o"),
                    TypeofSignificantChange = "Adding a SEN unit or resourced provision to a mainstream academy",
                    TypeofSignificantChangeMapped = "Change in SEN provision",
                    URN = 1001,
                    TypeofGiasChangeId = 1,
                    Withdrawn = false,
                    DeliveryLead = "Lead A",
                    Region = "West Midlands"

                };
                var significantChange2 = new SignificantChange
                {
                    SignificantChangeId = 1,
                    LocalAuthority = "Warwickshire",
                    TrustName = "Trust A",
                    MetaSourceSystem = "Academies Dev Spoof Table",
                    ChangeCreationDate = DateTime.UtcNow,
                    DecisionDate = DateOnly.FromDateTime(DateTime.UtcNow),
                    ChangeEditDate = DateTime.UtcNow,
                    CreatedUserName = "User A",
                    AcademyName = "Yarm Primary School",
                    AllActionsCompleted = true,
                    ApplicationType = "Full Business Case",
                    EditedUserName = "Editor A",
                    MetaIngestionDateTime = DateTime.UtcNow.ToString("o"),
                    TypeofSignificantChange = "Change of Age Range without changing school type",
                    TypeofSignificantChangeMapped = "Change of age range",
                    URN = 1001,
                    TypeofGiasChangeId = 1,
                    Withdrawn = false,
                    DeliveryLead = "Hardip Sembhi",
                    Region = "West Midlands",

                };
                sigChgMstrContext.SignificantChanges.AddRange(significantChange1, significantChange2);

                // Save changes
                sigChgMstrContext.SaveChanges();
            }
        }
    }
}
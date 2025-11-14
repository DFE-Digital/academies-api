using Dfe.Academies.Domain.SignificantChange; 
using Dfe.Academies.Infrastructure;
using System.Globalization;

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
                    ChangeCreationDate = DateTime.Parse("2024-05-15 12:21:49.197", CultureInfo.InvariantCulture),
                    DecisionDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    ChangeEditDate = DateTime.Parse("2025-05-28 15:49:46.327", CultureInfo.InvariantCulture),
                    CreatedUserName = "User A",
                    AcademyName = "Nicholas Chamberlaine School",
                    AllActionsCompleted = true,
                    ApplicationType = "Tier 1",
                    EditedUserName = "Editor A",
                    MetaIngestionDateTime = DateTime.UtcNow,
                    TypeofSigChange = "Adding a SEN unit or resourced provision to a mainstream academy",
                    TypeofSigChangedMapped = "Change in SEN provision",
                    URN = 1001,
                    TypeofGiasChangeId = 1,
                    Withdrawn = false,
                    DeliveryLead = "Lead A",
                    Region = "West Midlands"

                };
                var significantChange2 = new SignificantChange
                {
                    SignificantChangeId = 2,
                    LocalAuthority = "Warwickshire",
                    TrustName = "Trust A",
                    MetaSourceSystem = "Academies Dev Spoof Table",
                    ChangeCreationDate = DateTime.Parse("2024-05-16 18:16:31.463", CultureInfo.InvariantCulture),
                    DecisionDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    ChangeEditDate = DateTime.Parse("2025-04-15 17:28:22.103", CultureInfo.InvariantCulture),
                    CreatedUserName = "User A",
                    AcademyName = "Yarm Primary School",
                    AllActionsCompleted = true,
                    ApplicationType = "Full Business Case",
                    EditedUserName = "Editor A",
                    MetaIngestionDateTime = DateTime.UtcNow,
                    TypeofSigChange = "Change of Age Range without changing school type",
                    TypeofSigChangedMapped = "Change of age range",
                    URN = 1001,
                    TypeofGiasChangeId = 1,
                    Withdrawn = false,
                    DeliveryLead = "Hardip Sembhi",
                    Region = "West Midlands", 
                };
                var significantChange3 = new SignificantChange
                {
                    SignificantChangeId = 3,
                    LocalAuthority = "Warwickshire",
                    TrustName = "Trust A",
                    MetaSourceSystem = "Academies Dev Spoof Table",
                    ChangeCreationDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    DecisionDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    ChangeEditDate = DateTime.Parse("2024-12-11 10:26:39.440", CultureInfo.InvariantCulture),
                    CreatedUserName = "User A",
                    AcademyName = "Yarm Primary School",
                    AllActionsCompleted = true,
                    ApplicationType = "Full Business Case",
                    EditedUserName = "Editor A",
                    MetaIngestionDateTime = DateTime.UtcNow,
                    TypeofSigChange = "Change of Age Range without changing school type",
                    TypeofSigChangedMapped = "Change of age range",
                    URN = 1001,
                    TypeofGiasChangeId = 1,
                    Withdrawn = false,
                    DeliveryLead = "Lead A",
                    Region = "West Midlands",
                };
                sigChgMstrContext.SignificantChanges.AddRange(significantChange1, significantChange2, significantChange3);

                // Save changes
                sigChgMstrContext.SaveChanges();
            }
        }
    }
}
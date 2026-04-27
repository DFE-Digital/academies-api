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
                    ChangeCreationDate = DateTime.Parse("2024-06-17 11:36:50.087", CultureInfo.InvariantCulture),
                    DecisionDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    ChangeEditDate = DateTime.Parse("2025-03-14 15:23:55.497", CultureInfo.InvariantCulture),
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
                    Region = "West Midlands",
                    RSCContact = "RSCContact 1"
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
                    RSCContact = "RSCContact 2"
                };
                var significantChange3 = new SignificantChange
                {
                    SignificantChangeId = 3,
                    LocalAuthority = "Warwickshire",
                    TrustName = "Trust A",
                    MetaSourceSystem = "Academies Dev Spoof Table",
                    ChangeCreationDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
                    DecisionDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    ChangeEditDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
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
                    RSCContact = "RSCContact 3"
                };
                var significantChange4 = new SignificantChange
                {
                    SignificantChangeId = 4,
                    LocalAuthority = "Warwickshire",
                    TrustName = "Trust 4",
                    MetaSourceSystem = "Academies Test Spoof Table",
                    ChangeCreationDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
                    DecisionDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    ChangeEditDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
                    CreatedUserName = "User 4",
                    AcademyName = "Yarm Primary School",
                    AllActionsCompleted = true,
                    ApplicationType = "Full Business Case",
                    EditedUserName = "Editor 4",
                    MetaIngestionDateTime = DateTime.UtcNow,
                    TypeofSigChange = "Change of Age Range without changing school type",
                    TypeofSigChangedMapped = "Change of age range",
                    URN = 1001,
                    TypeofGiasChangeId = 1,
                    Withdrawn = false,
                    DeliveryLead = "DLead",
                    Region = "West Midlands",
                    RSCContact = "RSCContact 4"
                };
                var significantChange5 = new SignificantChange
                {
                    SignificantChangeId = 5,
                    LocalAuthority = "Warwickshire",
                    TrustName = "Trust 5",
                    MetaSourceSystem = "Academies Dev Spoof Table",
                    ChangeCreationDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
                    DecisionDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    ChangeEditDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
                    CreatedUserName = "User 5",
                    AcademyName = "Yarm Primary School",
                    AllActionsCompleted = true,
                    ApplicationType = "Full Business Case",
                    EditedUserName = "Editor 5",
                    MetaIngestionDateTime = DateTime.UtcNow,
                    TypeofSigChange = "Change of Age Range without changing school type",
                    TypeofSigChangedMapped = "Change of age range",
                    URN = 1001,
                    TypeofGiasChangeId = 1,
                    Withdrawn = false,
                    DeliveryLead = "Lead6",
                    Region = "West Midlands",
                    RSCContact = "RContact"
                };
                var significantChange6 = new SignificantChange
                {
                    SignificantChangeId = 6,
                    LocalAuthority = "Warwickshire",
                    TrustName = "Trust A",
                    MetaSourceSystem = "Academies Dev Spoof Table",
                    ChangeCreationDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
                    DecisionDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    ChangeEditDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
                    CreatedUserName = "User 6",
                    AcademyName = "Yarm Primary School",
                    AllActionsCompleted = true,
                    ApplicationType = "Full Business Case",
                    EditedUserName = "Editor 6",
                    MetaIngestionDateTime = DateTime.UtcNow,
                    TypeofSigChange = "Change of Age Range without changing school type",
                    TypeofSigChangedMapped = "Change of age range",
                    URN = 1001,
                    TypeofGiasChangeId = 1,
                    Withdrawn = false,
                    DeliveryLead = "Lead6",
                    Region = "West Midlands",
                    RSCContact = "RContact6"
                };
                var significantChange7 = new SignificantChange
                {
                    SignificantChangeId = 7,
                    LocalAuthority = "Warwickshire",
                    TrustName = "Trust 7",
                    MetaSourceSystem = "Academies Dev7 Spoof Table",
                    ChangeCreationDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
                    DecisionDate = DateTime.Parse("2024-05-16 12:32:11.223", CultureInfo.InvariantCulture),
                    ChangeEditDate = DateTime.Parse("2025-02-17 12:24:34.247", CultureInfo.InvariantCulture),
                    CreatedUserName = "User 7",
                    AcademyName = "Yarm Primary School",
                    AllActionsCompleted = true,
                    ApplicationType = "Full Business Case",
                    EditedUserName = "Editor 7",
                    MetaIngestionDateTime = DateTime.UtcNow,
                    TypeofSigChange = "Change of Age Range without changing school type",
                    TypeofSigChangedMapped = "Change of age range",
                    URN = 1001,
                    TypeofGiasChangeId = 1,
                    Withdrawn = false,
                    DeliveryLead = "Lead 7",
                    Region = "West Midlands",
                    RSCContact = "Contact7"
                };
                sigChgMstrContext.SignificantChanges.AddRange(significantChange1, significantChange2, significantChange3, significantChange4, significantChange5, significantChange6, significantChange7);

                // Save changes
                sigChgMstrContext.SaveChanges();
            }
        }
    }
}
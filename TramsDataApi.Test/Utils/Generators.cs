using System;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;

namespace TramsDataApi.Test.Utils
{
    public class Generators
    {
        public static SmartData GenerateSmartData(int urn)
        {
            var randomGenerator = new RandomGenerator();
            return new SmartData
            {
                Urn = urn.ToString(),
                LaCode = randomGenerator.NextString(1, 100),
                LocalAuthority = randomGenerator.NextString(1, 40),
                EstablishmentNumber = randomGenerator.NextString(1, 100),
                EstablishmentName = randomGenerator.NextString(1, 100),
                Status = randomGenerator.NextString(1, 30),
                RscRegion = randomGenerator.NextString(1, 40),
                RscShort = randomGenerator.NextString(8, 8),
                TypeGroup = randomGenerator.NextString(1, 30),
                EstablishmentType = randomGenerator.NextString(1, 50),
                Phase = randomGenerator.NextString(1, 30),
                TrustId = randomGenerator.NextString(7, 7),
                TrustName = randomGenerator.NextString(1, 100),
                TrustType = randomGenerator.NextString(12, 12),
                RatGrade = randomGenerator.NextString(2, 2),
                RatDefinition = randomGenerator.NextString(1, 25),
                IsSpecial = randomGenerator.Boolean(),
                IsConsideredOpen = randomGenerator.Int(),
                PostCode = randomGenerator.NextString(1, 100),
                Lat = Decimal.Parse("38.8951"),
                Lon = Decimal.Parse("-77.0364"),
                SponsorId = randomGenerator.NextString(7, 7),
                SponsorName = randomGenerator.NextString(1, 100),
                ShortInspectionNumber = randomGenerator.Int(),
                ShortInspectionPubDate = randomGenerator.DateTime(),
                RebrokerageDate = randomGenerator.DateTime(),
                MostRecentRating = randomGenerator.Int(),
                MostRecentPublicationDate = randomGenerator.DateTime(),
                HtchangesLastyear = randomGenerator.Int(),
                HtchangesTotal = randomGenerator.Int(),
                Ks4Attainment8Score = Decimal.Parse("0.0"),
                Ks4Progress8Score = Decimal.Parse("0.0"),
                Ks4DisadvProgress8Score = Decimal.Parse("0.0"),
                Ks4AvgAchieveBasics3Years = Decimal.Parse("0.0"),
                Ks4CoastingFlag = randomGenerator.Boolean(),
                Ks2ExpStandardsRwm = Decimal.Parse("0.0"),
                Ks2Reading = Decimal.Parse("0.0"),
                Ks2Maths = Decimal.Parse("0.0"),
                Ks2Writing = Decimal.Parse("0.0"),
                Ks2DisadvReading = Decimal.Parse("0.0"),
                Ks2DisadvMaths = Decimal.Parse("0.0"),
                Ks2DisadvWriting = Decimal.Parse("0.0"),
                Ks2CoastingFlag = randomGenerator.Boolean(),
                AbsencesOverall = Decimal.Parse("0.0"),
                AbsencesPa = Decimal.Parse("0.0"),
                AbsencesUnauthorised = Decimal.Parse("0.0"),
                PsdFlag = randomGenerator.Char().ToString(),
                PredecessorUrn = randomGenerator.NextString(8, 8),
                PredecessorName = randomGenerator.NextString(1, 100),
                OfstedSource = randomGenerator.Int(),
                Ks4Source = randomGenerator.Int(),
                Ks2Source = randomGenerator.Int(),
                AbsSource = randomGenerator.Int(),
                PsdSource = randomGenerator.Int(),
                FlagOfstedEverInadequate = randomGenerator.Int(),
                FlagOfstedLastTwoRi = randomGenerator.Int(),
                FlagHtchangesTotal = randomGenerator.Int(),
                FlagHtchangesLastYear = randomGenerator.Int(),
                FlagKs4Attainment8 = randomGenerator.Int(),
                FlagKs4Progress8Score = randomGenerator.Int(),
                FlagKs4AvgAchieveBasics3Years = randomGenerator.Int(),
                FlagKs4DisadvProgress8Score = randomGenerator.Int(),
                FlagKs4CoastingFlag = randomGenerator.Int(),
                FlagKs2ExpStandardsRwm = randomGenerator.Int(),
                FlagKs2CombinedProgress = randomGenerator.Int(),
                FlagKs2CombinedDisadvantagedProgress = randomGenerator.Int(),
                FlagKs2CoastingFlag = randomGenerator.Int(),
                FlagAbsencesUnauthorised = randomGenerator.Int(),
                FlagAbsencesOverallPa = randomGenerator.Int(),
                IsNa = randomGenerator.Boolean(),
                DateOfLastFullOrShortInspection = randomGenerator.DateTime(),
                ProbabilityOfDeclining = randomGenerator.Float(),
                ProbabilityOfStayingTheSame = randomGenerator.Float(),
                ProbabilityOfImproving = randomGenerator.Float(),
                PredictedChangeInProgress8Score = randomGenerator.NextString(1, 23),
                PredictedChanceOfChangeOccuring = randomGenerator.Float(),
                TotalNumberOfRisks = randomGenerator.Int(),
                TotalRiskScore = Decimal.Parse("0.0"),
                RiskRatingNum = randomGenerator.Int()
            };
        }

        public static ViewAcademyConversions GenerateViewAcademyConversions(int urn)
        {
            var randomGenerator = new RandomGenerator();
            return new ViewAcademyConversions
            {
                Rid = randomGenerator.NextString(11, 11),
                GeneralDetailsAcademyUrn = urn.ToString(),
                ProjectTemplateInformationDeficit = randomGenerator.NextString(2, 100),
                ProjectTemplateInformationViabilityIssue = randomGenerator.NextString(2, 100),
                DeliveryProcessPfi = randomGenerator.NextString(2, 100),
                DeliveryProcessPan = randomGenerator.NextString(2, 100)
            };
        }

        public static ViewAcademyConversions GenerateViewAcademyConversionsWithUkprn(string ukprn)
        {
            var randomGenerator = new RandomGenerator();
            return new ViewAcademyConversions
            {
                Rid = randomGenerator.NextString(11, 11),
                GeneralDetailsAcademyUkprn = ukprn,
                ProjectTemplateInformationDeficit = randomGenerator.NextString(2, 100),
                ProjectTemplateInformationViabilityIssue = randomGenerator.NextString(2, 100),
                DeliveryProcessPfi = randomGenerator.NextString(2, 100),
                DeliveryProcessPan = randomGenerator.NextString(2, 100)
            };
        }
    }
}
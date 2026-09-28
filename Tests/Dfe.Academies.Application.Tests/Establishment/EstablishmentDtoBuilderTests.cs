using Dfe.Academies.Application.Establishment;
using Dfe.Academies.Domain.Census;
using Dfe.Academies.Domain.Establishment;
using FluentAssertions;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4;
using GovUK.Dfe.CoreLibs.Contracts.Academies.V4.Establishments;

namespace Dfe.Academies.Application.Tests.Establishment
{
    public class EstablishmentDtoBuilderTests
    {
        [Fact]
        public void WithBasicDetails_MapsPopulatedEstablishment()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                UKPRN = "10000001",
                NumberOfBoys = 120,
                NumberOfGirls = 130,
                GiasLastChangedDate = new DateTime(2024, 6, 15),
                ReligiousEthos = "Church of England",
                SenUnitCapacity = 12,
                SenUnitOnRoll = 8,
                EstablishmentName = "Example Academy",
                URN = 123456,
                OfstedRating = "Good",
                OfstedLastInspection = "01/05/2024",
                StatutoryLowAge = "4",
                StatutoryHighAge = "11",
                SchoolCapacity = "250",
                EstablishmentNumber = 3456,
                HeadTitle = "Mrs",
                HeadFirstName = "Ada",
                HeadLastName = "Lovelace",
                HeadPreferredJobTitle = "Headteacher",
                MainPhone = "01234567890",
                NurseryProvision = "Yes",
                EducationEstablishmentTrust = new EducationEstablishmentTrust
                {
                    DateJoinedTrust = "2020-06-15"
                },
                IfdPipeline = new IfdPipeline
                {
                    DeliveryProcessPFI = "Yes",
                    DeliveryProcessPAN = "30",
                    ProjectTemplateInformationDeficit = "No",
                    ProjectTemplateInformationViabilityIssue = "None"
                }
            };

            var result = new EstablishmentDtoBuilder()
                .WithBasicDetails(establishment)
                .Build();

            result.Ukprn.Should().Be("10000001");
            result.NoOfBoys.Should().Be("120");
            result.NoOfGirls.Should().Be("130");
            result.GiasLastChangedDate.Should().Be("15/06/2024");
            result.ReligousEthos.Should().Be("Church of England");
            result.SenUnitCapacity.Should().Be("12");
            result.SenUnitOnRoll.Should().Be("8");
            result.Name.Should().Be("Example Academy");
            result.Urn.Should().Be("123456");
            result.OfstedRating.Should().Be("Good");
            result.OfstedLastInspection.Should().Be("01/05/2024");
            result.StatutoryLowAge.Should().Be("4");
            result.StatutoryHighAge.Should().Be("11");
            result.SchoolCapacity.Should().Be("250");
            result.Pfi.Should().Be("Yes");
            result.EstablishmentNumber.Should().Be("3456");
            result.Pan.Should().Be("30");
            result.Deficit.Should().Be("No");
            result.ViabilityIssue.Should().Be("None");
            result.HeadteacherTitle.Should().Be("Mrs");
            result.HeadteacherFirstName.Should().Be("Ada");
            result.HeadteacherLastName.Should().Be("Lovelace");
            result.HeadteacherPreferredJobTitle.Should().Be("Headteacher");
            result.MainPhone.Should().Be("01234567890");
            result.NurseryProvision.Should().Be("Yes");
            result.DateJoinedTrust.Should().Be("2020-06-15");
        }

        [Fact]
        public void WithBasicDetails_WhenOptionalValuesAreNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithBasicDetails(new Domain.Establishment.Establishment())
                .Build();

            result.Ukprn.Should().BeEmpty();
            result.NoOfBoys.Should().BeEmpty();
            result.NoOfGirls.Should().BeEmpty();
            result.GiasLastChangedDate.Should().BeEmpty();
            result.ReligousEthos.Should().BeEmpty();
            result.SenUnitCapacity.Should().BeEmpty();
            result.SenUnitOnRoll.Should().BeEmpty();
            result.Name.Should().BeEmpty();
            result.Urn.Should().BeEmpty();
            result.OfstedRating.Should().BeEmpty();
            result.OfstedLastInspection.Should().BeEmpty();
            result.StatutoryLowAge.Should().BeEmpty();
            result.StatutoryHighAge.Should().BeEmpty();
            result.SchoolCapacity.Should().BeEmpty();
            result.Pfi.Should().BeEmpty();
            result.EstablishmentNumber.Should().BeEmpty();
            result.Pan.Should().BeEmpty();
            result.Deficit.Should().BeEmpty();
            result.ViabilityIssue.Should().BeEmpty();
            result.HeadteacherTitle.Should().BeEmpty();
            result.HeadteacherFirstName.Should().BeEmpty();
            result.HeadteacherLastName.Should().BeEmpty();
            result.HeadteacherPreferredJobTitle.Should().BeEmpty();
            result.MainPhone.Should().BeEmpty();
            result.NurseryProvision.Should().BeEmpty();
            result.DateJoinedTrust.Should().BeEmpty();
        }

        [Fact]
        public void WithLocalAuthority_MapsCodeAndName()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                LocalAuthority = new Domain.Establishment.LocalAuthority
                {
                    Code = "373",
                    Name = "Manchester"
                }
            };

            var result = new EstablishmentDtoBuilder()
                .WithLocalAuthority(establishment)
                .Build();

            result.LocalAuthorityCode.Should().Be("373");
            result.LocalAuthorityName.Should().Be("Manchester");
        }

        [Fact]
        public void WithLocalAuthority_WhenLocalAuthorityIsNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithLocalAuthority(new Domain.Establishment.Establishment())
                .Build();

            result.LocalAuthorityCode.Should().BeEmpty();
            result.LocalAuthorityName.Should().BeEmpty();
        }

        [Fact]
        public void WithDiocese_MapsNameAndCode()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                Diocese = "Diocese of London",
                DioceseCode = "CE01"
            };

            var result = new EstablishmentDtoBuilder()
                .WithDiocese(establishment)
                .Build();

            result.Diocese.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = "Diocese of London",
                Code = "CE01"
            });
        }

        [Fact]
        public void WithDiocese_WhenValuesAreNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithDiocese(new Domain.Establishment.Establishment())
                .Build();

            result.Diocese.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = string.Empty,
                Code = string.Empty
            });
        }

        [Fact]
        public void WithEstablishmentType_MapsNameAndCode()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                EstablishmentType = new EstablishmentType
                {
                    Name = "Academy converter",
                    Code = "34"
                }
            };

            var result = new EstablishmentDtoBuilder()
                .WithEstablishmentType(establishment)
                .Build();

            result.EstablishmentType.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = "Academy converter",
                Code = "34"
            });
        }

        [Fact]
        public void WithEstablishmentType_WhenEstablishmentTypeIsNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithEstablishmentType(new Domain.Establishment.Establishment())
                .Build();

            result.EstablishmentType.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = string.Empty,
                Code = string.Empty
            });
        }

        [Fact]
        public void WithGor_MapsNameAndCode()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                GORregion = "North West",
                GORregionCode = "B"
            };

            var result = new EstablishmentDtoBuilder()
                .WithGor(establishment)
                .Build();

            result.Gor.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = "North West",
                Code = "B"
            });
        }

        [Fact]
        public void WithGor_WhenValuesAreNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithGor(new Domain.Establishment.Establishment())
                .Build();

            result.Gor.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = string.Empty,
                Code = string.Empty
            });
        }

        [Fact]
        public void WithPhaseOfEducation_MapsNameAndCode()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                PhaseOfEducation = "Primary",
                PhaseOfEducationCode = 2
            };

            var result = new EstablishmentDtoBuilder()
                .WithPhaseOfEducation(establishment)
                .Build();

            result.PhaseOfEducation.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = "Primary",
                Code = "2"
            });
        }

        [Fact]
        public void WithPhaseOfEducation_WhenValuesAreNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithPhaseOfEducation(new Domain.Establishment.Establishment())
                .Build();

            result.PhaseOfEducation.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = string.Empty,
                Code = string.Empty
            });
        }

        [Fact]
        public void WithReligiousCharacter_MapsNameAndCode()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                ReligiousCharacter = "Roman Catholic",
                ReligiousCharacterCode = "RC"
            };

            var result = new EstablishmentDtoBuilder()
                .WithReligiousCharacter(establishment)
                .Build();

            result.ReligiousCharacter.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = "Roman Catholic",
                Code = "RC"
            });
        }

        [Fact]
        public void WithReligiousCharacter_WhenValuesAreNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithReligiousCharacter(new Domain.Establishment.Establishment())
                .Build();

            result.ReligiousCharacter.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = string.Empty,
                Code = string.Empty
            });
        }

        [Fact]
        public void WithParliamentaryConstituency_MapsNameAndCode()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                ParliamentaryConstituency = "Manchester Central",
                ParliamentaryConstituencyCode = "E14000807"
            };

            var result = new EstablishmentDtoBuilder()
                .WithParliamentaryConstituency(establishment)
                .Build();

            result.ParliamentaryConstituency.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = "Manchester Central",
                Code = "E14000807"
            });
        }

        [Fact]
        public void WithParliamentaryConstituency_WhenValuesAreNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithParliamentaryConstituency(new Domain.Establishment.Establishment())
                .Build();

            result.ParliamentaryConstituency.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = string.Empty,
                Code = string.Empty
            });
        }

        [Fact]
        public void WithCensus_MapsEstablishmentAndCensusFields()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                NumberOfPupils = "250",
                PercentageFSM = "18.5"
            };
            var censusData = new CensusData
            {
                PSENELK = "12.4",
                PNUMEAL = "22.1",
                PNUMFSMEVER = "30.0"
            };

            var result = new EstablishmentDtoBuilder()
                .WithCensus(establishment, censusData)
                .Build();

            result.Census.Should().BeEquivalentTo(new CensusDto
            {
                NumberOfPupils = "250",
                PercentageFsm = "18.5",
                PercentageSen = "12.4",
                PercentageEnglishAsSecondLanguage = "22.1",
                PercentageFsmLastSixYears = "30.0"
            });
        }

        [Fact]
        public void WithCensus_WhenCensusDataAndEstablishmentValuesAreNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithCensus(new Domain.Establishment.Establishment(), null!)
                .Build();

            result.Census.Should().BeEquivalentTo(new CensusDto
            {
                NumberOfPupils = string.Empty,
                PercentageFsm = string.Empty,
                PercentageSen = string.Empty,
                PercentageEnglishAsSecondLanguage = string.Empty,
                PercentageFsmLastSixYears = string.Empty
            });
        }

        [Fact]
        public void WithMISEstablishment_MapsPopulatedEstablishment()
        {
            var misEstablishment = new MisEstablishment
            {
                DateOfLatestSection8Inspection = "01/02/2024",
                Section8InspectionOverallOutcome = "School remains good",
                InspectionStartDate = "10/03/2024",
                OverallEffectiveness = "2",
                QualityOfEducation = 2,
                BehaviourAndAttitudes = 1,
                PersonalDevelopment = 2,
                EffectivenessOfLeadershipAndManagement = 2,
                EarlyYearsProvisionWhereApplicable = 1,
                SixthFormProvisionWhereApplicable = 3,
                WebLink = "https://reports.ofsted.gov.uk/example",
                CategoryOfConcern = "Not applicable",
                SafeguardingIsEffective = "Yes",
                PreviousInspectionStartDate = "01/03/2019",
                PreviousFullInspectionOverallEffectiveness = "2",
                PreviousQualityOfEducation = 2,
                PreviousBehaviourAndAttitudes = 2,
                PreviousPersonalDevelopment = 2,
                PreviousEffectivenessOfLeadershipAndManagement = 3,
                PreviousEarlyYearsProvisionWhereApplicable = 2,
                PreviousSixthFormProvisionWhereApplicable = "Good",
                PreviousCategoryOfConcern = "None",
                PreviousSafeguardingIsEffective = "Yes"
            };

            var result = new EstablishmentDtoBuilder()
                .WithMISEstablishment(misEstablishment)
                .Build();

            result.MISEstablishment.Should().BeEquivalentTo(new MisEstablishmentDto
            {
                DateOfLatestSection8Inspection = "01/02/2024",
                Section8InspectionOverallOutcome = "School remains good",
                InspectionStartDate = "10/03/2024",
                OverallEffectiveness = "2",
                QualityOfEducation = "2",
                BehaviourAndAttitudes = "1",
                PersonalDevelopment = "2",
                EffectivenessOfLeadershipAndManagement = "2",
                EarlyYearsProvision = "1",
                SixthFormProvision = "3",
                Weblink = "https://reports.ofsted.gov.uk/example",
                CategoryOfConcern = "Not applicable",
                SafeguardingIsEffective = "Yes",
                PreviousInspectionStartDate = "01/03/2019",
                PreviousFullInspectionOverallEffectiveness = "2",
                PreviousQualityOfEducation = "2",
                PreviousBehaviourAndAttitudes = "2",
                PreviousPersonalDevelopment = "2",
                PreviousEffectivenessOfLeadershipAndManagement = "3",
                PreviousEarlyYearsProvision = "2",
                PreviousSixthFormProvision = "Good",
                PreviousCategoryOfConcern = "None",
                PreviousSafeguardingIsEffective = "Yes"
            });
        }

        [Fact]
        public void WithMISEstablishment_WhenEstablishmentIsNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithMISEstablishment(null)
                .Build();

            result.MISEstablishment.Should().BeEquivalentTo(EmptyMisEstablishment());
        }

        [Fact]
        public void WithFurtherEducationEstablishment_MapsPopulatedEstablishment()
        {
            var establishment = new FurtherEducationEstablishment
            {
                DateOfLatestShortInspection = "04/04/2023",
                LastDayOfInspection = "05/05/2024",
                OverallEffectiveness = "Good",
                QualityOfEducation = 2,
                BehaviourAndAttitudes = 1,
                PersonalDevelopment = 2,
                EffectivenessOfLeadershipAndManagement = 2,
                IsSafeguardingEffective = "Yes",
                PreviousLastDayOfInspection = "06/06/2019",
                PreviousOverallEffectiveness = "Requires improvement",
                PreviousQualityOfEducation = 3,
                PreviousBehaviourAndAttitudes = 3,
                PreviousPersonalDevelopment = 2,
                PreviousEffectivenessOfLeadershipAndManagement = 3,
                PreviousSafeguarding = "Yes"
            };

            var result = new EstablishmentDtoBuilder()
                .WithFurtherEducationEstablishment(establishment)
                .Build();

            result.MisFurtherEducationEstablishment.Should().BeEquivalentTo(new MisFurtherEducationEstablishmentDto
            {
                DateOfLatestSection8Inspection = "04/04/2023",
                LastDayOfInspection = "05/05/2024",
                OverallEffectiveness = "Good",
                QualityOfEducation = "2",
                BehaviourAndAttitudes = "1",
                PersonalDevelopment = "2",
                EffectivenessOfLeadershipAndManagement = "2",
                SafeguardingIsEffective = "Yes",
                PreviousLastDayOfInspection = "06/06/2019",
                PreviousOverallEffectiveness = "Requires improvement",
                PreviousQualityOfEducation = "3",
                PreviousBehaviourAndAttitudes = "3",
                PreviousPersonalDevelopment = "2",
                PreviousEffectivenessOfLeadershipAndManagement = "3",
                PreviousSafeguardingIsEffective = "Yes"
            });
        }

        [Fact]
        public void WithFurtherEducationEstablishment_WhenEstablishmentIsNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithFurtherEducationEstablishment(null)
                .Build();

            result.MisFurtherEducationEstablishment.Should().BeEquivalentTo(new MisFurtherEducationEstablishmentDto
            {
                DateOfLatestSection8Inspection = string.Empty,
                LastDayOfInspection = string.Empty,
                OverallEffectiveness = string.Empty,
                QualityOfEducation = string.Empty,
                BehaviourAndAttitudes = string.Empty,
                PersonalDevelopment = string.Empty,
                EffectivenessOfLeadershipAndManagement = string.Empty,
                SafeguardingIsEffective = string.Empty,
                PreviousLastDayOfInspection = string.Empty,
                PreviousOverallEffectiveness = string.Empty,
                PreviousQualityOfEducation = string.Empty,
                PreviousBehaviourAndAttitudes = string.Empty,
                PreviousPersonalDevelopment = string.Empty,
                PreviousEffectivenessOfLeadershipAndManagement = string.Empty,
                PreviousSafeguardingIsEffective = string.Empty
            });
        }

        [Fact]
        public void WithAddress_MapsAddressLines()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                AddressLine1 = "1 School Lane",
                AddressLine2 = "Building A",
                AddressLine3 = "City Centre",
                Town = "Manchester",
                County = "Greater Manchester",
                Postcode = "M1 1AA"
            };

            var result = new EstablishmentDtoBuilder()
                .WithAddress(establishment)
                .Build();

            result.Address.Should().BeEquivalentTo(new AddressDto
            {
                Street = "1 School Lane",
                Additional = "Building A",
                Locality = "City Centre",
                Town = "Manchester",
                County = "Greater Manchester",
                Postcode = "M1 1AA"
            });
        }

        [Fact]
        public void WithAddress_WhenAddressValuesAreNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithAddress(new Domain.Establishment.Establishment())
                .Build();

            result.Address.Should().BeEquivalentTo(new AddressDto
            {
                Street = string.Empty,
                Additional = string.Empty,
                Locality = string.Empty,
                Town = string.Empty,
                County = string.Empty,
                Postcode = string.Empty
            });
        }

        [Fact]
        public void WithPreviousEstablishment_MapsLinkUrn()
        {
            var link = new EducationEstablishmentLink
            {
                LinkURN = 999111,
                LinkType = "Predecessor",
                ModifiedBy = "test"
            };

            var result = new EstablishmentDtoBuilder()
                .WithPreviousEstablishment(link)
                .Build();

            result.PreviousEstablishment!.Urn.Should().Be("999111");
        }

        [Fact]
        public void WithPreviousEstablishment_WhenLinkIsNull_LeavesUrnNull()
        {
            var result = new EstablishmentDtoBuilder()
                .WithPreviousEstablishment(null)
                .Build();

            result.PreviousEstablishment.Should().NotBeNull();
            result.PreviousEstablishment!.Urn.Should().BeNull();
        }

        [Theory]
        [InlineData("Example Trust", "Example Trust")]
        [InlineData(null, null)]
        public void WithTrustName_AssignsTrustName(string? trustName, string? expected)
        {
            var result = new EstablishmentDtoBuilder()
                .WithTrustName(trustName)
                .Build();

            result.TrustName.Should().Be(expected);
        }

        [Fact]
        public void WithEstablishmentGroupType_MapsNameAndCode()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                EstablishmentGroupType = new EstablishmentGroupType
                {
                    Name = "Multi-academy trust",
                    Code = "06"
                }
            };

            var result = new EstablishmentDtoBuilder()
                .WithEstablishmentGroupType(establishment)
                .Build();

            result.EstablishmentGroupType.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = "Multi-academy trust",
                Code = "06"
            });
        }

        [Fact]
        public void WithEstablishmentGroupType_WhenGroupTypeIsNull_MapsEmptyStrings()
        {
            var result = new EstablishmentDtoBuilder()
                .WithEstablishmentGroupType(new Domain.Establishment.Establishment())
                .Build();

            result.EstablishmentGroupType.Should().BeEquivalentTo(new NameAndCodeDto
            {
                Name = string.Empty,
                Code = string.Empty
            });
        }

        [Fact]
        public void Build_ReturnsDtoAccumulatedAcrossChainedCalls()
        {
            var establishment = new Domain.Establishment.Establishment
            {
                EstablishmentName = "Chained Academy",
                URN = 42,
                LocalAuthority = new Domain.Establishment.LocalAuthority { Code = "001", Name = "Test LA" },
                Diocese = "Test Diocese",
                DioceseCode = "TD"
            };

            var builder = new EstablishmentDtoBuilder();

            var chained = builder
                .WithBasicDetails(establishment)
                .WithLocalAuthority(establishment)
                .WithDiocese(establishment)
                .WithTrustName("Chained Trust");

            chained.Should().BeSameAs(builder);

            var result = chained.Build();

            result.Name.Should().Be("Chained Academy");
            result.Urn.Should().Be("42");
            result.LocalAuthorityCode.Should().Be("001");
            result.LocalAuthorityName.Should().Be("Test LA");
            result.Diocese!.Name.Should().Be("Test Diocese");
            result.Diocese.Code.Should().Be("TD");
            result.TrustName.Should().Be("Chained Trust");
        }

        private static MisEstablishmentDto EmptyMisEstablishment()
        {
            return new MisEstablishmentDto
            {
                DateOfLatestSection8Inspection = string.Empty,
                Section8InspectionOverallOutcome = string.Empty,
                InspectionStartDate = string.Empty,
                OverallEffectiveness = string.Empty,
                QualityOfEducation = string.Empty,
                BehaviourAndAttitudes = string.Empty,
                PersonalDevelopment = string.Empty,
                EffectivenessOfLeadershipAndManagement = string.Empty,
                EarlyYearsProvision = string.Empty,
                SixthFormProvision = string.Empty,
                Weblink = string.Empty,
                CategoryOfConcern = string.Empty,
                SafeguardingIsEffective = string.Empty,
                PreviousInspectionStartDate = string.Empty,
                PreviousFullInspectionOverallEffectiveness = string.Empty,
                PreviousQualityOfEducation = string.Empty,
                PreviousBehaviourAndAttitudes = string.Empty,
                PreviousPersonalDevelopment = string.Empty,
                PreviousEffectivenessOfLeadershipAndManagement = string.Empty,
                PreviousEarlyYearsProvision = string.Empty,
                PreviousSixthFormProvision = string.Empty,
                PreviousCategoryOfConcern = string.Empty,
                PreviousSafeguardingIsEffective = string.Empty
            };
        }
    }
}

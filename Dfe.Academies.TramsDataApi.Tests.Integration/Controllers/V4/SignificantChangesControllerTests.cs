using Dfe.Academies.Domain.SignificantChange;
using Dfe.Academies.Infrastructure;
using Dfe.Academies.Tests.Common.Customizations;
using Dfe.Academies.Utils.Extensions;
using Dfe.AcademiesApi.Client.Contracts;
using GovUK.Dfe.CoreLibs.Testing.AutoFixture.Attributes;
using GovUK.Dfe.CoreLibs.Testing.Mocks.WebApplicationFactory;
using TramsDataApi;

namespace Dfe.Academies.TramsDataApi.Tests.Integration.Controllers.V4
{
    public class SignificantChangesControllerTests
    {
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task SearchSignificantChangesAsync_ShouldReturnOrderByCreationDateSignificantChanges_WhenMatchesWithDeliveryOfficer(
            CustomWebApplicationDbContextFactory<Startup> factory,
            ISignificantChangesV4Client significantChangesV4Client)
        {
            // Arrange
            factory.TestClaims = default;
            var deliveryOfficer = "Lead A";
            var page = 1;

            // Act
            var result = await significantChangesV4Client.SearchSignificantChangesAsync(deliveryOfficer, false, false, page, 10, default);

            var significantChangeDtos = result.Data;

            // Assert
            Assert.NotNull(significantChangeDtos);
            Assert.Equal(2, significantChangeDtos.Count);
            var significantChangeDto = significantChangeDtos.FirstOrDefault(); 
            Assert.NotNull(significantChangeDto); 
            var dbContext = factory.GetDbContext<SigChgMstrContext>();
            var significantChange = dbContext.SignificantChanges.First(sc => sc.SignificantChangeId == 1);
            VerifyAsserts(significantChangeDto, significantChange);
            Assert.NotNull(result.Paging);
            Assert.Equal(2, result.Paging.RecordCount);
            Assert.Equal(page, result.Paging.Page);
        } 
          
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task SearchSignificantChangesAsync_ShouldReturnOrderByEditDateSignificantChanges_WhenMatchesWithDeliveryOfficer(
            CustomWebApplicationDbContextFactory<Startup> factory,
            ISignificantChangesV4Client significantChangesV4Client)
        {
            // Arrange
            factory.TestClaims = default;
            var deliveryOfficer = "Lead A";
            var page = 1;

            // Act
            var result = await significantChangesV4Client.SearchSignificantChangesAsync(deliveryOfficer, true, false, page, 10, default);

            var significantChangeDtos = result.Data;

            // Assert
            Assert.NotNull(significantChangeDtos);
            Assert.Equal(2, significantChangeDtos.Count);
            var significantChangeDto = significantChangeDtos.FirstOrDefault();
            Assert.NotNull(significantChangeDto);
            var dbContext = factory.GetDbContext<SigChgMstrContext>();
            var significantChange = dbContext.SignificantChanges.First(sc => sc.SignificantChangeId == 3);
            VerifyAsserts(significantChangeDto, significantChange);
            Assert.NotNull(result.Paging);
            Assert.Equal(2, result.Paging.RecordCount);
            Assert.Equal(page, result.Paging.Page);
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task SearchSignificantChangesAsync_ShouldReturnEmptyResult_WhenNoMatchesWithDeliveryOfficer(
            CustomWebApplicationDbContextFactory<Startup> factory,
            ISignificantChangesV4Client significantChangesV4Client)
        {
            // Arrange
            factory.TestClaims = default;
            var deliveryOfficer = "John Doe";
            var page = 1;

            // Act
            var result = await significantChangesV4Client.SearchSignificantChangesAsync(deliveryOfficer, false, true, page, 10, default);

            var significantChangeDtos = result.Data;

            // Assert
            Assert.NotNull(significantChangeDtos);
            Assert.Empty(significantChangeDtos);
            Assert.NotNull(result.Paging);
            Assert.Equal(0, result.Paging.RecordCount);
            Assert.Equal(page, result.Paging.Page);
        }
        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task SearchSignificantChangesAsync_ShouldReturnDescendingOrderByCreationDateSignificantChanges_WhenMatchesWithDeliveryOfficer(
            CustomWebApplicationDbContextFactory<Startup> factory,
            ISignificantChangesV4Client significantChangesV4Client)
        {
            // Arrange
            factory.TestClaims = default;
            var deliveryOfficer = "Lead A";
            var page = 1;

            // Act
            var result = await significantChangesV4Client.SearchSignificantChangesAsync(deliveryOfficer, false, true, page, 10, default);

            var significantChangeDtos = result.Data;

            // Assert
            Assert.NotNull(significantChangeDtos);
            Assert.Equal(2, significantChangeDtos.Count);
            var significantChangeDto = significantChangeDtos.FirstOrDefault();
            Assert.NotNull(significantChangeDto);
            var dbContext = factory.GetDbContext<SigChgMstrContext>();
            var significantChange = dbContext.SignificantChanges.First(sc => sc.SignificantChangeId == 3);
            VerifyAsserts(significantChangeDto, significantChange);
            Assert.NotNull(result.Paging);
            Assert.Equal(2, result.Paging.RecordCount);
            Assert.Equal(page, result.Paging.Page);
        }

        [Theory]
        [CustomAutoData(typeof(CustomWebApplicationDbContextFactoryCustomization<Startup>))]
        public async Task SearchSignificantChangesAsync_ShouldReturnDescendingOrderByEditDateSignificantChanges_WhenMatchesWithDeliveryOfficer(
            CustomWebApplicationDbContextFactory<Startup> factory,
            ISignificantChangesV4Client significantChangesV4Client)
        {
            // Arrange
            factory.TestClaims = default;
            var deliveryOfficer = "Lead A";
            var page = 1;

            // Act
            var result = await significantChangesV4Client.SearchSignificantChangesAsync(deliveryOfficer, true, true, page, 10, default);

            var significantChangeDtos = result.Data;

            // Assert
            Assert.NotNull(significantChangeDtos);
            Assert.Equal(2, significantChangeDtos.Count);
            var significantChangeDto = significantChangeDtos.FirstOrDefault();
            Assert.NotNull(significantChangeDto);
            var dbContext = factory.GetDbContext<SigChgMstrContext>();
            var significantChange = dbContext.SignificantChanges.First(sc => sc.SignificantChangeId == 1);
            VerifyAsserts(significantChangeDto, significantChange);
            Assert.NotNull(result.Paging);
            Assert.Equal(2, result.Paging.RecordCount);
            Assert.Equal(page, result.Paging.Page);
        }

        private static void VerifyAsserts(SignificantChangeDto significantChangeDto, SignificantChange significantChange)
        {
            Assert.Equal(significantChange.SignificantChangeId, significantChangeDto.SigChangeId);
            Assert.Equal(significantChange.URN, significantChangeDto.Urn);
            Assert.Equal(significantChange.TypeofGiasChangeId, significantChangeDto.TypeofGiasChangeId);
            Assert.Equal(significantChange.TypeofSigChange, significantChangeDto.TypeofSigChange);
            Assert.Equal(significantChange.TypeofSigChangedMapped, significantChangeDto.TypeOfSigChangeMapped);
            Assert.Equal(significantChange.CreatedUserName, significantChangeDto.CreatedUserName);
            Assert.Equal(significantChange.EditedUserName, significantChangeDto.EditedUserName);
            Assert.Equal(significantChange.ApplicationType, significantChangeDto.ApplicationType);
            Assert.Equal(significantChange.DecisionDate.ToISODateOnly(), significantChangeDto.DecisionDate);
            Assert.Equal(significantChange.DeliveryLead, significantChangeDto.DeliveryLead);
            Assert.Equal(significantChange.ChangeCreationDate.ToISO8601DateTime(), significantChangeDto.ChangeCreationDate);
            Assert.Equal(significantChange.ChangeEditDate.ToISO8601DateTime(), significantChangeDto.ChangeEditDate);
            Assert.Equal(significantChange.AllActionsCompleted, significantChangeDto.AllActionsCompleted);
            Assert.Equal(significantChange.Withdrawn, significantChangeDto.Withdrawn);
            Assert.Equal(significantChange.LocalAuthority, significantChangeDto.LocalAuthority);
            Assert.Equal(significantChange.Region, significantChangeDto.Region);
            Assert.Equal(significantChange.TrustName, significantChangeDto.TrustName);
            Assert.Equal(significantChange.MetaSourceSystem, significantChangeDto.MetaSourceSystem);
            Assert.Equal(significantChange.AcademyName, significantChangeDto.AcademyName);
            Assert.Equal(significantChange.MetaIngestionDateTime.ToISO8601DateTime(), significantChangeDto.MetaIngestionDateTime);
        }
    }
}

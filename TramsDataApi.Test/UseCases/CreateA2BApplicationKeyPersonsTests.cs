using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Gateways;
using TramsDataApi.RequestModels.ApplyToBecome;
using TramsDataApi.UseCases;
using Xunit;

namespace TramsDataApi.Test.UseCases
{
    
    public class CreateA2BApplicationKeyPersonsTests
    {
	    [Fact]
        public void CreateA2BApplicationKeyPersons_ShouldCreateAndReturnA2BApplicationKeyPersons_WhenGivenA2BApplicationKeyPerson()
        {
            var keyPersonsCreateRequest = Builder<A2BApplicationKeyPersonsCreateRequest>.CreateNew().Build();

            var expectedKeyPerson = new A2BApplicationKeyPersons
            {
                KeyPersonId = 10001,
                Name = keyPersonsCreateRequest.Name,
                KeyPersonDateOfBirth = keyPersonsCreateRequest.KeyPersonDateOfBirth,
                KeyPersonBiography = keyPersonsCreateRequest.KeyPersonBiography,
                KeyPersonCeoExecutive = keyPersonsCreateRequest.KeyPersonCeoExecutive,
                KeyPersonChairOfTrust = keyPersonsCreateRequest.KeyPersonChairOfTrust,
                KeyPersonFinancialDirector = keyPersonsCreateRequest.KeyPersonFinancialDirector,
                KeyPersonFinancialDirectorTime = keyPersonsCreateRequest.KeyPersonFinancialDirectorTime,
                KeyPersonMember = keyPersonsCreateRequest.KeyPersonMember,
                KeyPersonOther = keyPersonsCreateRequest.KeyPersonOther,
                KeyPersonTrustee = keyPersonsCreateRequest.KeyPersonTrustee
            };
            
            var mockGateway = new Mock<IA2BApplicationKeyPersonsGateway>();
            
            mockGateway.Setup(g => g.CreateA2BApplicationKeyPersons(It.IsAny<A2BApplicationKeyPersons>())).Returns(expectedKeyPerson);
            
            var useCase = new CreateA2BApplicationKeyPersons(mockGateway.Object);
            
            var result = useCase.Execute(keyPersonsCreateRequest);

            result.Should().NotBeNull();
            result.KeyPersonId.Should().BeGreaterThan(0);
            result.Should().BeEquivalentTo(expectedKeyPerson);
        }
    }
}
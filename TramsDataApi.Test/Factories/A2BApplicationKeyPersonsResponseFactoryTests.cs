using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.ResponseModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplicationKeyPersonsResponseFactoryTests
    {
	    [Fact]
        public void Create_ReturnsNull_WhenA2BApplicationKeyPersonsIsNull()
        {
            var response = A2BApplicationKeyPersonsResponseFactory.Create(null);

            response.Should().BeNull();
        }

        [Fact]
        public void Create_ReturnsExpectedA2BApplicationKeyPersonsResponse_WhenA2BApplicationKeyPersonsIsProvided()
        {
            var keyPersons = Builder<A2BApplicationKeyPersons>
                .CreateNew()
                .Build();

            var expectedResponse = new A2BApplicationKeyPersonsResponse
            {
                KeyPersonId = keyPersons.KeyPersonId,
                Name = keyPersons.Name,
                KeyPersonDateOfBirth = keyPersons.KeyPersonDateOfBirth,
                KeyPersonBiography = keyPersons.KeyPersonBiography,
                KeyPersonCeoExecutive = keyPersons.KeyPersonCeoExecutive,
                KeyPersonChairOfTrust = keyPersons.KeyPersonChairOfTrust,
                KeyPersonFinancialDirector = keyPersons.KeyPersonFinancialDirector,
                KeyPersonFinancialDirectorTime = keyPersons.KeyPersonFinancialDirectorTime,
                KeyPersonMember = keyPersons.KeyPersonMember,
                KeyPersonOther = keyPersons.KeyPersonOther,
                KeyPersonTrustee = keyPersons.KeyPersonTrustee
            };
                
            var response = A2BApplicationKeyPersonsResponseFactory.Create(keyPersons);

            response.Should().BeEquivalentTo(expectedResponse);
        }
    }
}
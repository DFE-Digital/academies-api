using System;
using FluentAssertions;
using FizzWare.NBuilder;
using TramsDataApi.DatabaseModels;
using TramsDataApi.Factories;
using TramsDataApi.Factories.A2BApplicationFactories;
using TramsDataApi.RequestModels.ApplyToBecome;
using Xunit;

namespace TramsDataApi.Test.Factories
{
    public class A2BApplicationKeyPersonsFactoryTests
    {
        [Fact]
        public void Create_ReturnsExpectedA2BApplicationKeyPerson_WhenA2BApplicationKeyPersonsModelIsProvided()
        {
            var keyPersonsModel = Builder<A2BApplicationKeyPersonsServiceModel>
                .CreateNew()
                .Build();

            var expectedKeyPersons = new A2BApplicationKeyPersons
            {
                Name = keyPersonsModel.Name,
                KeyPersonDateOfBirth = keyPersonsModel.KeyPersonDateOfBirth,
                KeyPersonBiography = keyPersonsModel.KeyPersonBiography,
                KeyPersonCeoExecutive = keyPersonsModel.KeyPersonCeoExecutive,
                KeyPersonChairOfTrust = keyPersonsModel.KeyPersonChairOfTrust,
                KeyPersonFinancialDirector = keyPersonsModel.KeyPersonFinancialDirector,
                KeyPersonMember = keyPersonsModel.KeyPersonMember,
                KeyPersonOther = keyPersonsModel.KeyPersonOther,
                KeyPersonTrustee = keyPersonsModel.KeyPersonTrustee,
                DynamicsKeyPersonId = keyPersonsModel.DynamicsKeyPersonId
            };
                
            var response = A2BApplicationKeyPersonsFactory.Create(keyPersonsModel);

            response.Should().BeEquivalentTo(expectedKeyPersons);
        }
        
        [Fact]
        public void Create_ReturnsExpectedA2BApplicationKeyPersonsModel_WhenA2BApplicationKeyPersonsIsProvided()
        {
            var keyPersons = Builder<A2BApplicationKeyPersons>
                .CreateNew()
                .Build();

            var expectedKeyPersonsModel = new A2BApplicationKeyPersonsServiceModel
            {
                Name = keyPersons.Name,
                KeyPersonDateOfBirth = keyPersons.KeyPersonDateOfBirth,
                KeyPersonBiography = keyPersons.KeyPersonBiography,
                KeyPersonCeoExecutive = keyPersons.KeyPersonCeoExecutive,
                KeyPersonChairOfTrust = keyPersons.KeyPersonChairOfTrust,
                KeyPersonFinancialDirector = keyPersons.KeyPersonFinancialDirector,
                KeyPersonMember = keyPersons.KeyPersonMember,
                KeyPersonOther = keyPersons.KeyPersonOther,
                KeyPersonTrustee = keyPersons.KeyPersonTrustee,
                DynamicsKeyPersonId = keyPersons.DynamicsKeyPersonId
            };
                
            var response = A2BApplicationKeyPersonsFactory.Create(keyPersons);

            response.Should().BeEquivalentTo(expectedKeyPersonsModel);
        }
    }
}
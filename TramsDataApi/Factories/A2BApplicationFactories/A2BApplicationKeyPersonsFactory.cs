using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Factories.A2BApplicationFactories
{
    public static class A2BApplicationKeyPersonsFactory
    {
        public static A2BApplicationKeyPersons Create(A2BApplicationKeyPersonsServiceModel request)
        {
            return new A2BApplicationKeyPersons
                {
                    Name = request.Name,
                    KeyPersonDateOfBirth = request.KeyPersonDateOfBirth,
                    KeyPersonBiography = request.KeyPersonBiography,
                    KeyPersonCeoExecutive = request.KeyPersonCeoExecutive,
                    KeyPersonChairOfTrust = request.KeyPersonChairOfTrust,
                    KeyPersonFinancialDirector = request.KeyPersonFinancialDirector,
                    KeyPersonFinancialDirectorTime = request.KeyPersonFinancialDirectorTime,
                    KeyPersonMember = request.KeyPersonMember,
                    KeyPersonOther = request.KeyPersonOther,
                    KeyPersonTrustee = request.KeyPersonTrustee
                };
        }
        
        public static A2BApplicationKeyPersonsServiceModel Create(A2BApplicationKeyPersons request)
        { 
            return new A2BApplicationKeyPersonsServiceModel
            {
                Name = request.Name,
                KeyPersonDateOfBirth = request.KeyPersonDateOfBirth,
                KeyPersonBiography = request.KeyPersonBiography,
                KeyPersonCeoExecutive = request.KeyPersonCeoExecutive,
                KeyPersonChairOfTrust = request.KeyPersonChairOfTrust,
                KeyPersonFinancialDirector = request.KeyPersonFinancialDirector,
                KeyPersonFinancialDirectorTime = request.KeyPersonFinancialDirectorTime,
                KeyPersonMember = request.KeyPersonMember,
                KeyPersonOther = request.KeyPersonOther,
                KeyPersonTrustee = request.KeyPersonTrustee
            };
        }
    }
}
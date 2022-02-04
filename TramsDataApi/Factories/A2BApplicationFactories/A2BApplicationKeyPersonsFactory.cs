using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Factories.A2BApplicationFactories
{
    public static class A2BApplicationKeyPersonsFactory
    {
        public static A2BApplicationKeyPersons Create(A2BApplicationKeyPersonsModel request)
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
        
        public static A2BApplicationKeyPersonsModel Create(A2BApplicationKeyPersons request)
        { 
            return new A2BApplicationKeyPersonsModel
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
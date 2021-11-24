using TramsDataApi.DatabaseModels;
using TramsDataApi.RequestModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public static class A2BApplicationKeyPersonsFactory
    {
        public static A2BApplicationKeyPersons Create(A2BApplicationKeyPersonsCreateRequest request)
        {
            return request == null
                ? null
                : new A2BApplicationKeyPersons
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
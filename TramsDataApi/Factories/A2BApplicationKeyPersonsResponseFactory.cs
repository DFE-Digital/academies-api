using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
	public class A2BApplicationKeyPersonsResponseFactory
    {
	    public static A2BApplicationKeyPersonsResponse Create(A2BApplicationKeyPersons request)
	    { 
		    return request is null ? null : new A2BApplicationKeyPersonsResponse
		    {
			    KeyPersonId = request.KeyPersonId,
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

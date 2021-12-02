using TramsDataApi.DatabaseModels;
using TramsDataApi.ResponseModels.AcademyConversionProject;
using TramsDataApi.ResponseModels.ApplyToBecome;

namespace TramsDataApi.Factories
{
    public class A2BApplicationStatusResponseFactory
    {
        public static A2BApplicationStatusResponse Create(A2BApplicationStatus request)
        { 
            return request is null ? null : new A2BApplicationStatusResponse
            {
                ApplicationStatusId = request.ApplicationStatusId,
                Name = request.Name
            };
        }
    }
}